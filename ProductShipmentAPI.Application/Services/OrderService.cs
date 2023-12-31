﻿using ProductShipmentAPI.Application.Core;
using ProductShipmentAPI.Domain.Entities.Database;
using ProductShipmentAPI.Domain.Entities.Request;
using ProductShipmentAPI.Domain.Entities.Response;
using ProductShipmentAPI.Domain.Interfaces;
using AutoMapper;
using Stripe;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AutoMapper.Execution;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace ProductShipmentAPI.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly PostgreSqlContext _context;
        private readonly IMapper _mapper;
        private readonly LogWriter _logWriter;
        private static Random RNG = new Random();
        public OrderService(PostgreSqlContext context, IMapper mapper, LogWriter logWriter)
        {
            _context = context;
            _mapper = mapper;
            _logWriter = logWriter;
        }


        public string CreateCardNumber()
        {
            var builder = new StringBuilder();
            while (builder.Length < 16)
            {
                builder.Append(RNG.Next(10).ToString());
            }
            return builder.ToString();
        }
        public Charge CreatePayment(double amount, string email)
        {
            var chargeResult = new Stripe.Charge();
            var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string stripeApiKey = MyConfig.GetSection("Payment:StripeApiKey").Value;
            StripeConfiguration.SetApiKey(stripeApiKey);
            try
            {
                //Create Card Object to create Token 
                var tokenOptions = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = CreateCardNumber(),
                        ExpMonth = DateTime.Today.Month.ToString(),
                        ExpYear = DateTime.Today.AddYears(2).Year.ToString(),
                        Cvc = "314",
                    },
                };
                var tokenService = new TokenService();
                var tokenResult = tokenService.Create(tokenOptions);


                //Create Customer Object and Register it on Stripe  
                var customerOptions = new CustomerCreateOptions
                {
                    Email = email,
                    Source = tokenResult.Id,
                    Description = "Smartness customer created through API",
                };
                var customerService = new CustomerService();
                var customerResult = customerService.Create(customerOptions);

                //Create Charge Object with details of Charge 
                var chargeOptions = new ChargeCreateOptions
                {
                    Amount = (long)(amount*100),
                    Currency = "USD",
                    ReceiptEmail = email,
                    Customer = customerResult.Id,
                    Description = "Smartness payment created through API", //Optional  
                };
                var chargeService = new ChargeService();
                chargeResult = chargeService.Create(chargeOptions);

            }
            catch (StripeException e)
            {
                return null;
            }

            return chargeResult;
        }


        public string AddOrderRecord(OrderReq order, string clientID)
        {
            try
            {
                var user = _context.SnUsers.Where(u => u.AuthId == clientID).FirstOrDefault();
                order.UserId = user.Id;
                var totalPrice = 0.0;

                if (string.IsNullOrEmpty(order.OrderType))return "Error:- Order type can not be null.";
                if(order.OrderType.ToLower() == "supplier product" && order.ContainerId == null)return "Error:- ContainerId can not be null for supplier product order types.";
                if (order.OrderType.ToLower() == "supplier product")
                {
                    var container = _context.SnContainers.FirstOrDefault(t => t.Id == order.ContainerId);
                    if (container == null) return "Error:- Please use a valid containerId.";
                    order.ContainerName = container.Name ?? string.Empty;
                    totalPrice = Math.Round(((double)container.Price * order.Qty), 2);
                }
                else
                {
                    var product = _context.SnProducts.FirstOrDefault(t => t.Id == order.ProductId);
                    if (product == null) return "Error:- Please use a valid productId.";
                    order.ProductName = product.Name ?? string.Empty;
                    totalPrice = Math.Round((product.Price * order.Qty), 2);
                }

                var paymentMethod = _context.SnUserPaymentMethods.FirstOrDefault(t => t.UserId == user.Id && t.Default.Value);
                if (paymentMethod == null || paymentMethod.UserId != user.Id) return "Error:- The user does not have a default payment method. Please create a defaoult payment method and try again!.";            

                var address = _context.SnUserAddresses.FirstOrDefault(t => t.UserId == user.Id);
                if (address == null)return "Error:- The user does not have an address.";

                var chargeResult = CreatePayment(totalPrice, user.Email);

                if (chargeResult.Status == "succeeded")
                {
                    order.PaymentRef = chargeResult.Id;
                    order.PaidAmount = chargeResult.AmountCaptured/100m;
                    order.Status = "Paid";
                }else return "Error:- Unable to create a payment with the given details.";
                var snOrder = _mapper.Map<SnOrder>(order);
                //copy address to order
                snOrder.Address1 = address.Address1 ?? string.Empty;
                snOrder.Address2 = address.Address2 ?? string.Empty;
                snOrder.Suburb = address.Suburb ?? string.Empty;
                snOrder.ContactNumber = address.ContactNumber ?? string.Empty;
                snOrder.Postcode = address.Postcode ?? string.Empty;
                _context.SnOrders.Add(snOrder);
                _context.SaveChanges();
                return "Order created successfully!";
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while adding order. Error:- " + ex.Message);
                return "Error:- Unable to create a payment with the given details.";
            }
        }

        public bool DeleteOrderRecord(Guid id)
        {
            try
            {
                var entity = _context.SnOrders.FirstOrDefault(t => t.Id == id);
                _context.SnOrders.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while deleting order. Error:- " + ex.Message);
                return false;
            }
        }

        public List<OrderRes> GetOrderRecords(string clientId)
        {
            try
            {
                var userId = _context.SnUsers.Where(u => u.AuthId == clientId).Select(a => a.Id).FirstOrDefault();
                return _mapper.Map<List<OrderRes>>(_context.SnOrders.Where(u=>u.UserId==userId).ToList());
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving orders. Error:- " + ex.Message);
            }
            return new List<OrderRes>();
        }

        public OrderRes GetOrderSingleRecord(Guid id)
        {
            try
            {
                return _mapper.Map<OrderRes>(_context.SnOrders.FirstOrDefault(t => t.Id == id));
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving orders. Error:- " + ex.Message);
            }
            return new OrderRes();
        }

        public bool UpdateOrderRecord(OrderReq order)
        {
            try
            {
                _context.Update(_mapper.Map<SnOrder>(order));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while updating orders. Error:- " + ex.Message);
                return false;
            }
        }
    }
}

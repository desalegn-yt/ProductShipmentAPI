using System;
using System.Collections.Generic;

namespace ProductShipmentAPI.Domain.Entities.Response

{
    public class OnBoardingRes
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string SubTitle { get; set; } = null!;
        public string Image { get; set; } = null!;
    }
}

﻿FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /
COPY ["/SmartNestAPI/SmartNestAPI.csproj", "."]
RUN dotnet restore "./SmartNestAPI.csproj"
COPY . .
WORKDIR "/"
RUN dotnet build "/SmartNestAPI/SmartNestAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "/SmartNestAPI/SmartNestAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmartNestAPI.dll"]
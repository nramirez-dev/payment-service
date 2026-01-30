
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src


COPY src/Payment.Api/Payment.Api.csproj src/Payment.Api/
COPY src/Payment.Service/Payment.Service.csproj src/Payment.Service/
COPY src/Payment.Share/Payment.Share.csproj src/Payment.Share/
COPY src/Payment.Model/Payment.Model.csproj src/Payment.Model/
COPY src/Payment.Abstractions/Payment.Abstractions.csproj src/Payment.Abstractions/
COPY src/Payment.Stripe/Payment.Stripe.csproj src/Payment.Stripe/
COPY src/Payment.Infrastructure/Payment.Infrastructure.csproj src/Payment.Infrastructure/

RUN dotnet restore src/Payment.Api/Payment.Api.csproj


COPY . .

WORKDIR /src/src/Payment.Api
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Payment.Api.dll"]

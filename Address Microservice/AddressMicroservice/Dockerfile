#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Address Microservice/AddressMicroservice/AddressMicroservice.csproj", "Address Microservice/AddressMicroservice/"]
COPY ["Address Microservice/AddressMicroservice.BusinessLogic/AddressMicroservice.BusinessLogic.csproj", "Address Microservice/AddressMicroservice.BusinessLogic/"]
COPY ["Address Microservice/AddressMicroservice.DAL/AddressMicroservice.DAL.csproj", "Address Microservice/AddressMicroservice.DAL/"]
COPY ["Shared/SharedAzureServiceBus/SharedAzureServiceBus.csproj", "Shared/SharedAzureServiceBus/"]
COPY ["Address Microservice/AddressMicroservice.DTO/AddressMicroservice.DTO.csproj", "Address Microservice/AddressMicroservice.DTO/"]
RUN dotnet restore "Address Microservice/AddressMicroservice/AddressMicroservice.csproj"
COPY . .
WORKDIR "/src/Address Microservice/AddressMicroservice"
RUN dotnet build "AddressMicroservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AddressMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AddressMicroservice.dll"]
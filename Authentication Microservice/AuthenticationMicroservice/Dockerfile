#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Authentication Microservice/AuthenticationMicroservice/AuthenticationMicroservice.csproj", "Authentication Microservice/AuthenticationMicroservice/"]
COPY ["Authentication Microservice/AuthenticationMicroservice.BusinessLogic/AuthenticationMicroservice.BusinessLogic.csproj", "Authentication Microservice/AuthenticationMicroservice.BusinessLogic/"]
COPY ["Authentication Microservice/AuthenticationMicroservice.DAL/AuthenticationMicroservice.DAL.csproj", "Authentication Microservice/AuthenticationMicroservice.DAL/"]
COPY ["Authentication Microservice/AuthenticationMicroservice.DTO/AuthenticationMicroservice.DTO.csproj", "Authentication Microservice/AuthenticationMicroservice.DTO/"]
RUN dotnet restore "Authentication Microservice/AuthenticationMicroservice/AuthenticationMicroservice.csproj"
COPY . .
WORKDIR "/src/Authentication Microservice/AuthenticationMicroservice"
RUN dotnet build "AuthenticationMicroservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuthenticationMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthenticationMicroservice.dll"]
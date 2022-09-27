#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["gatlin.demo.shopping.productapi/gatlin.demo.shopping.productapi.csproj", "gatlin.demo.shopping.productapi/"]
RUN dotnet restore "gatlin.demo.shopping.productapi/gatlin.demo.shopping.productapi.csproj"
COPY . .
WORKDIR "/src/gatlin.demo.shopping.productapi"
RUN dotnet build "gatlin.demo.shopping.productapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "gatlin.demo.shopping.productapi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "gatlin.demo.shopping.productapi.dll"]
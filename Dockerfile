# 1. Build application in image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /Source

COPY ["Source/CBD.ShoppingService.WebAPI/CBD.ShoppingService.WebAPI.csproj", "CBD.ShoppingService.WebAPI/"]
COPY ["Source/CBD.ShoppingService.Port/CBD.ShoppingService.Port.csproj", "CBD.ShoppingService.Port/"]
COPY ["Source/CBD.ShoppingService.Core/CBD.ShoppingService.Core.csproj", "CBD.ShoppingService.Core/"]

RUN dotnet restore "CBD.ShoppingService.WebAPI/CBD.ShoppingService.WebAPI.csproj"

COPY ./Source .
WORKDIR "/Source/CBD.ShoppingService.WebAPI"

RUN dotnet build "CBD.ShoppingService.WebAPI.csproj" -c Release -o /app/build

# 2. Publish built application in image
FROM build AS publish
RUN dotnet publish "CBD.ShoppingService.WebAPI.csproj" -c Release -o /app/publish

# 3. Take published version
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS final
EXPOSE 7002
WORKDIR /app
COPY --from=publish /app/publish .
RUN dotnet dev-certs https

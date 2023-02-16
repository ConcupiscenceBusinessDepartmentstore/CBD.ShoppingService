FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Source/CBD.ShoppingService.WebAPI/CBD.ShoppingService.WebAPI.csproj", "Source/CBD.ShoppingService.WebAPI/"]
RUN dotnet restore "Source/CBD.ShoppingService.WebAPI/CBD.ShoppingService.WebAPI.csproj"
COPY . .
WORKDIR "/src/Source/CBD.ShoppingService.WebAPI"
RUN dotnet build "CBD.ShoppingService.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CBD.ShoppingService.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CBD.ShoppingService.WebAPI.dll"]

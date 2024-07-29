FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /source

COPY ["src/ShoppingCenter.Shipping/ShoppingCenter.Shipping.csproj", "ShoppingCenter.Shipping/"]
COPY ["src/ShoppingCenter.Data/ShoppingCenter.Data.csproj", "ShoppingCenter.Data/"]

RUN dotnet restore "ShoppingCenter.Shipping/ShoppingCenter.Shipping.csproj"

COPY src/ShoppingCenter.Shipping ./ShoppingCenter.Shipping
COPY src/ShoppingCenter.Data ./ShoppingCenter.Data

WORKDIR /source/ShoppingCenter.Shipping

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:8.0 as development

RUN apt-get update \
    && apt-get install unzip \
    && curl -sSL https://aka.ms/getvsdbgsh | /bin/sh /dev/stdin -v latest -l /vsdbg

WORKDIR /source

COPY ["src/ShoppingCenter.Shipping/ShoppingCenter.Shipping.csproj", "ShoppingCenter.Shipping/"]
COPY ["src/ShoppingCenter.Data/ShoppingCenter.Data.csproj", "ShoppingCenter.Data/"]

RUN dotnet restore "ShoppingCenter.Shipping/ShoppingCenter.Shipping.csproj"

COPY src/ShoppingCenter.Shipping ./ShoppingCenter.Shipping
COPY src/ShoppingCenter.Data ./ShoppingCenter.Data

WORKDIR /source/ShoppingCenter.Shipping

CMD dotnet watch run

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app

COPY --from=build /app/src/out .

ENTRYPOINT ["dotnet", "ShoppingCenter.Shipping.dll"]
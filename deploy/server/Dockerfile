FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /source
    
COPY ["src/ShoppingCenter.Api/ShoppingCenter.Api.csproj", "ShoppingCenter.Api/"]
COPY ["src/ShoppingCenter.Data/ShoppingCenter.Data.csproj", "ShoppingCenter.Data/"]

RUN dotnet restore "ShoppingCenter.Api/ShoppingCenter.Api.csproj"

COPY src/ShoppingCenter.Api/ ./ShoppingCenter.Api
COPY src/ShoppingCenter.Data/ ./ShoppingCenter.Data

WORKDIR /source/ShoppingCenter.Api

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:8.0 as development

RUN apt-get update \
    && apt-get install unzip \
    && curl -sSL https://aka.ms/getvsdbgsh | /bin/sh /dev/stdin -v latest -l /vsdbg

WORKDIR /source
    
COPY ["src/ShoppingCenter.Api/ShoppingCenter.Api.csproj", "ShoppingCenter.Api/"]
COPY ["src/ShoppingCenter.Data/ShoppingCenter.Data.csproj", "ShoppingCenter.Data/"]

RUN dotnet restore "ShoppingCenter.Api/ShoppingCenter.Api.csproj"

COPY src/ShoppingCenter.Api ./ShoppingCenter.Api
COPY src/ShoppingCenter.Data ./ShoppingCenter.Data

WORKDIR /source/ShoppingCenter.Api

CMD dotnet watch run --no-launch-profile

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app

COPY --from=build /app/src/out .

ENTRYPOINT ["dotnet", "ShoppingCenter.Api.dll"]
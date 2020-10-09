# INICIAL #
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS basesdk
RUN apt-get update

# RESTAURA BUILD #
FROM basesdk AS basebuild
WORKDIR /src
COPY HangFireTest/*.csproj ./
RUN dotnet restore --configfile Nuget.config HangFireTest/HangFireTest.csproj

COPY . .

# BUILD #
FROM basebuild as build
WORKDIR /src/HangFireTest
RUN dotnet build HangFireTest.csproj --no-restore -c Release -o /app

# PUBLISH #
FROM build AS publish
RUN dotnet publish HangFireTest.csproj -c Release -o /app

# FINAL #
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "HangFireTest.dll"]


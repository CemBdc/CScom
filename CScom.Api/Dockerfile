FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY CScom.Api/CScom.Api.csproj CScom.Api/
RUN dotnet restore CScom.Api/CScom.Api.csproj
COPY . .
WORKDIR /src/CScom.Api
RUN dotnet build CScom.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish CScom.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CScom.Api.dll"]

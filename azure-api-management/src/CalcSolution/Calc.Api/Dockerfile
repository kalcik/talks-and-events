FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Calc.Api.csproj", ""]
RUN dotnet restore "Calc.Api.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Calc.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Calc.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
EXPOSE 80/tcp
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Calc.Api.dll"]
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PrizedrawRegistrationWebsite/PrizedrawRegistrationWebsite.csproj", "PrizedrawRegistrationWebsite/"]
RUN dotnet restore "PrizedrawRegistrationWebsite/PrizedrawRegistrationWebsite.csproj"
COPY . .
WORKDIR "/src/PrizedrawRegistrationWebsite"
RUN dotnet build "PrizedrawRegistrationWebsite.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PrizedrawRegistrationWebsite.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PrizedrawRegistrationWebsite.dll"]

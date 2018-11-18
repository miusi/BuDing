FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["BuDing.Sunrise.Web/BuDing.Sunrise.Web.csproj", "BuDing.Sunrise.Web/"]
RUN dotnet restore "BuDing.Sunrise.Web/BuDing.Sunrise.Web.csproj"
COPY . .
WORKDIR "/src/BuDing.Sunrise.Web"
RUN dotnet build "BuDing.Sunrise.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BuDing.Sunrise.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BuDing.Sunrise.Web.dll"]
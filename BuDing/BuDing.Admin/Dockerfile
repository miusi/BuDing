FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 64590
EXPOSE 44311

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["BuDing.Admin/BuDing.Admin.csproj", "BuDing.Admin/"]
RUN dotnet restore "BuDing.Admin/BuDing.Admin.csproj"
COPY . .
WORKDIR "/src/BuDing.Admin"
RUN dotnet build "BuDing.Admin.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BuDing.Admin.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BuDing.Admin.dll"]
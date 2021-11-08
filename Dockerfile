FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WebApiEfCorePoc/WebApiEfCorePoc.csproj", "WebApiEfCorePoc/"]
RUN dotnet restore "WebApiEfCorePoc/WebApiEfCorePoc.csproj"
COPY . .
WORKDIR "/src/WebApiEfCorePoc"
RUN dotnet build "WebApiEfCorePoc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApiEfCorePoc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApiEfCorePoc.dll"]

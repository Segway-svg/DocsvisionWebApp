FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DocsvisionClientServer/DocsvisionClientServer.csproj", "DocsvisionClientServer/"]
RUN dotnet restore "DocsvisionClientServer/DocsvisionClientServer.csproj"
COPY . .
WORKDIR "/src/DocsvisionClientServer"
RUN dotnet build "DocsvisionClientServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DocsvisionClientServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DocsvisionClientServer.dll"]

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DocsvisionConsoleApp/DocsvisionConsoleApp.csproj", "DocsvisionConsoleApp/"]
RUN dotnet restore "DocsvisionConsoleApp/DocsvisionConsoleApp.csproj"
COPY . .
WORKDIR "/src/DocsvisionConsoleApp"
RUN dotnet build "DocsvisionConsoleApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DocsvisionConsoleApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DocsvisionConsoleApp.dll"]

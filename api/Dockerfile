# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia apenas o arquivo de projeto e restaura dependências
COPY ["api/api.csproj", "api/"]
RUN dotnet restore "api/api.csproj"

# Copia o resto do código
COPY . .
WORKDIR "/src/api"
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
ENTRYPOINT ["dotnet", "api.dll"]
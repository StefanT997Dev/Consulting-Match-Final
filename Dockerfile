FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

# Build
FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build

WORKDIR /src

# copy all the layers' csproj files into respective folders
COPY API/API.csproj src/API
COPY Application/Application.csproj src/Application
COPY Domain/Domain.csproj src/Domain
COPY Infrastructure/Infrastructure.csproj src/Infrastructure
COPY Persistence/Persistence.csproj src/Persistence

COPY . .

# run build over the API project
WORKDIR "/src/API"
RUN dotnet build -c Release -o /app/build

# run publish over the API project
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS runtime
WORKDIR /app

COPY --from=publish /app/publish .
RUN ls -l
EXPOSE 5000
ENTRYPOINT ["dotnet", "API.dll"]
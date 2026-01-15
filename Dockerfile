FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .
WORKDIR /src/JiraLike.Api
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
EXPOSE 8080

COPY --from=build /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "JiraLike.Api.dll"]

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN --mount=type=secret,id=dotnet_secrets \
    cat /run/secrets/dotnet_secrets | dotnet user-secrets --project Api set
RUN dotnet restore --disable-parallel
RUN dotnet publish -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
EXPOSE 8080
ENTRYPOINT [ "dotnet", "Api.dll" ]
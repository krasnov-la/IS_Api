FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore --disable-parallel
RUN dotnet publish -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
RUN --mount=type=secret,id=dotnet_secrets \
    cat /run/secrets/dotnet_secrets > secrets.json
EXPOSE 8080
ENTRYPOINT [ "dotnet", "Api.dll" ]
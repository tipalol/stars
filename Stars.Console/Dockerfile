FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Stars.Console/Stars.Console.csproj", "Stars.Console/"]
RUN dotnet restore "Stars.Console/Stars.Console.csproj"
COPY . .
WORKDIR "/src/Stars.Console"
RUN dotnet build "Stars.Console.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Stars.Console.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Stars.Console.dll"]

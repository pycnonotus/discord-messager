FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["discord-messager/Pycnonotus.ConsoleRunner/Pycnonotus.ConsoleRunner.csproj", "discord-messager/Pycnonotus.ConsoleRunner/"]
RUN dotnet restore "Pycnonotus.ConsoleRunner/Pycnonotus.ConsoleRunner.csproj"
COPY . .
WORKDIR "/src/Pycnonotus.ConsoleRunner"
RUN dotnet build "Pycnonotus.ConsoleRunner.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pycnonotus.ConsoleRunner.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pycnonotus.ConsoleRunner.dll"]

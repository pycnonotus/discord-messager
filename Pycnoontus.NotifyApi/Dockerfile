FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["discord-messager/Pycnoontus.NotifyApi/Pycnoontus.NotifyApi.csproj", "discord-messager/Pycnoontus.NotifyApi/"]
RUN dotnet restore "Pycnoontus.NotifyApi/Pycnoontus.NotifyApi.csproj"
COPY . .
WORKDIR "/src/Pycnoontus.NotifyApi"
RUN dotnet build "Pycnoontus.NotifyApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pycnoontus.NotifyApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pycnoontus.NotifyApi.dll"]

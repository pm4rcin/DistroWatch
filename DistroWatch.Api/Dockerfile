FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 7051

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["DistroWatch.csproj", "./"]
RUN dotnet restore "DistroWatch.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "DistroWatch.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DistroWatch.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DistroWatch.dll"]

#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HrSolution.NotificationWorker/HrSolution.NotificationWorker.csproj", "HrSolution.NotificationWorker/"]
RUN dotnet restore "HrSolution.NotificationWorker/HrSolution.NotificationWorker.csproj"
COPY . .
WORKDIR "/src/HrSolution.NotificationWorker"
RUN dotnet build "HrSolution.NotificationWorker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HrSolution.NotificationWorker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HrSolution.NotificationWorker.dll"]
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:latest AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:latest AS build
WORKDIR /src
COPY ["WorkforceMedicalNetwork.Api/WorkforceMedicalNetwork.Api.csproj", "WorkforceMedicalNetwork.Api/"]
RUN dotnet restore "WorkforceMedicalNetwork.Api/WorkforceMedicalNetwork.Api.csproj"
COPY . .
WORKDIR "/src/WorkforceMedicalNetwork.Api"
RUN dotnet build "WorkforceMedicalNetwork.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WorkforceMedicalNetwork.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WorkforceMedicalNetwork.Api.dll"]
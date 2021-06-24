#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Hyacinth.GrpcDemo.Client/Hyacinth.GrpcDemo.Client.csproj", "Hyacinth.GrpcDemo.Client/"]
RUN dotnet restore "Hyacinth.GrpcDemo.Client/Hyacinth.GrpcDemo.Client.csproj"
COPY . .
WORKDIR "/src/Hyacinth.GrpcDemo.Client"
RUN dotnet build "Hyacinth.GrpcDemo.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hyacinth.GrpcDemo.Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hyacinth.GrpcDemo.Client.dll"]
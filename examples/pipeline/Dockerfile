FROM microsoft/dotnet:3.0-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:3.0-sdk AS build
WORKDIR /src
COPY ["sample1722/sample1722.csproj", "sample1722/"]
RUN dotnet restore "sample1722/sample1722.csproj"
COPY . .
WORKDIR "/src/sample1722"
RUN dotnet build "sample1722.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "sample1722.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "sample1722.dll"]


FROM mcr.microsoft.com/dotnet/core/sdk:5.0 AS build
WORKDIR /app

#COPY Hiromi.sln .

COPY MALRewriteBackend/MALRewriteBackend.csproj MALRewriteBackend/

RUN dotnet restore 

COPY . .

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/runtime:5.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

ENTRYPOINT ["dotnet", "MALRewriteBackend.dll"]
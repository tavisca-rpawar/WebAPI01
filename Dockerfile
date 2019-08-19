FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
COPY WebApplication1/bin/Debug/netcoreapp2.2/publish /app 
EXPOSE 5505
ENTRYPOINT [ "dotnet", "WebApplication1.dll" ]

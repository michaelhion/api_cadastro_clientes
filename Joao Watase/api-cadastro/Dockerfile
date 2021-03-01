FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app
COPY . .
ENV ASPNETCORE_URLS=http://+:5001
EXPOSE 5001/tcp
CMD ["dotnet", "bin/Debug/net5.0/api-cadastro.dll"]
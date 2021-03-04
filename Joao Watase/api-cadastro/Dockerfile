FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app
COPY . .
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000/tcp
CMD ["dotnet","bin/Debug/net5.0/api-cadastro.dll"]
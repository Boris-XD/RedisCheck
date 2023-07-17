# Utilizar la imagen base con el SDK de .NET
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Establecer el directorio de trabajo dentro del contenedor
WORKDIR /app

# Copiar los archivos de proyecto y restaurar las dependencias
COPY Redis.Sample.csproj .
RUN dotnet restore Redis.Sample.csproj

# Copiar el resto del código fuente y compilar la aplicación
COPY . .
RUN dotnet publish Redis.Sample.csproj -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

COPY --from=build /publish /bms/api/

# Exponer el puerto en el que se ejecuta la aplicación
# EXPOSE 7041 80 6379

# Establecer el comando de inicio de la aplicación
WORKDIR /bms/api/

ENTRYPOINT ["dotnet"]
CMD ["Redis.Sample.dll"]
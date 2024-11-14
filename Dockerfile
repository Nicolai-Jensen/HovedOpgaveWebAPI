# https://medium.com/@jaydeepvpatil225/containerization-of-the-net-core-7-web-api-using-docker-3abdd543f78a
# https://stackoverflow.com/questions/72817377/how-to-run-a-net-core-web-api-locally-on-docker
# Use the official .NET Core SDK as a parent image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the project file and restore any dependencies (use .csproj for the project name)
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application code
COPY . .

# Publish the application
RUN dotnet publish -c Release -o out

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Expose the port your application will run on
EXPOSE 5134
ENV ASPNETCORE_URLS=http://+:5134

# Start the application
ENTRYPOINT ["dotnet", "HovedOpgaveWebAPI.dll"]
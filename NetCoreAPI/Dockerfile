#docker run -it -p 8181:80 cloudworkloadcoreapi \
#ExtraSettingNotInSettingsFile='01.00.1.' \
#ConnectionStrings:CUSTOMCONNSTR_MONGO="Server=TestServer;Database=TestDb;Persist Security Info=True;User ID=TestUser;Password=testpassword;MultipleActiveResultSets=true"

FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "coreapi.dll"]

# docker run -it -v c:/Data:/app/dataVol  chandrabhan/aspnetapp  // notice full path
# docker run -it -v myvol:/app/dataVol  chandrabhan/aspnetapp  //for windows container


# docker run -it --mount type=bind,source=c:/Data,target=/app/dataVol chandrabhan/aspnetapp
# docker create vol
# docker run -it --mount source=myvol,target=/app/dataVol  chandrabhan/aspnetapp

#az container create --resource-group myResourceGroup --name cloud-workloadapi --image acrapiworkload.azurecr.io/cl
#oudworkload-dotnetapi --cpu 1 --memory 1 --registry-login-server acrapiworkload.azurecr.io --registry-username acrapiworkload --regist
#ry-password 6giHm2XByEOjc3gW+6j=qE5erMiCbEdG --dns-name-label dockerworkloadapi --ports 80 --azure-file-volume-account-name fileshares
#torageacc --azure-file-volume-account-key WIcSxPJcGfOQvSvCjpiT0tejkBHiw2C2ad+BWNp09WEuSJ4r0ZB5D+lUiufMXjZBclJOQPqWBpe02qu0eq8/bA== --a
#zure-file-volume-share-name dockervol --azure-file-volume-mount-path /app/vol
# signalr-core-demo

Quick demo app to play with signalR Core, Webpack, Docker, EF Core 

## Quick Documentation Links

Before using ef core to create database we need to spin up the database via docker. Copy and paste the following command to spin up a SQL Server Container with docker
```console
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=isamel234@22222' -p 3100:1433 -d mcr.microsoft.com/mssql/server:2019-latest
```

Working with ef core via command line [ef core tools](https://docs.microsoft.com/en-us/ef/core/get-started/overview/install) 

You need to run the following command to get access to the ef core command line tools
```console
dotnet tool install --global dotnet-ef
```

Once you have access to dotnet ef run the following command to run our commited ef core migrations
```console
dotnet ef database update 
```

Better EF Core Configuration[EF Core Entity Configuration](https://dotnetcoretutorials.com/2020/06/27/a-cleaner-way-to-do-entity-configuration-with-ef-core/)

EF Core Relationships [EF Core Relationships](https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key)

[signalR Sending Messages to certain users](https://stackoverflow.com/questions/19522103/signalr-sending-a-message-to-a-specific-user-using-iuseridprovider-new-2-0)


[Mapping Connections](https://docs.microsoft.com/en-us/aspnet/signalr/overview/guide-to-the-api/mapping-users-to-connections#IUserIdProvider)







## Model State Validation Links
https://blog.zhaytam.com/2019/04/13/asp-net-core-checking-modelstate-isvalid-is-boring/
https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-5.0
https://exceptionnotfound.net/asp-net-mvc-demystified-modelstate/









## Link to javascript api 
https://docs.microsoft.com/en-us/javascript/api/@microsoft/signalr/?view=signalr-js-latest \ 

 
## Send message to certain user \ 
https://stackoverflow.com/questions/19522103/signalr-sending-a-message-to-a-specific-user-using-iuseridprovider-new-2-0 \ 

##ES6 Importing and Exporting 
https://www.freecodecamp.org/news/how-to-use-es6-modules-and-why-theyre-important-a9b20b480773/ \
https://www.digitalocean.com/community/tutorials/js-modules-es6 \ 

##Dealing with EF Core  
https://docs.microsoft.com/en-us/ef/core/get-started/overview/install \
https://www.entityframeworktutorial.net/efcore/cli-commands-for-ef-core-migration.aspx \
https://www.entityframeworktutorial.net/efcore/cli-commands-for-ef-core-migration.aspx#database-update

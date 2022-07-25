# ProjectMarket
Project for a market template


## Required Softwares

- Visual Studio or Visual Studio Code https://visualstudio.microsoft.com/pt-br/downloads/
- DotNet Runtime https://dotnet.microsoft.com/en-us/download/dotnet/6.0/runtime
- Docker https://docs.docker.com/desktop/windows/install/
- Postman https://www.postman.com/downloads/
    
    
    
## solution setup

created the folders and used the following commands to implement the solution structure:

```
dotnet new sln
```
```
dotnet new classlib
```
inside domain and shared folders and
```
dotnet new mstest
```
inside the tests folder.
```
dotnet sln add (ls -r **\*.csproj)
```
to add all folders to the solution
```
dotnet restore
```
to compile all files to the solution

and finally we need to enter in each folder to make the relations to the other folders using the command

```
dotnet add reference {folder path}
```

## creating the DataBase

to create the database that we will use inside the docker container (that we did in the previous step) we will use the 
concept of "code first" and "fluent mapping" we code the database structure on visual studio and then use the entity 
framework to create the database for us using the migration files. Entity Framework is package with isntructions 
and commands made by Microsoft will translte our C# code to and SQL code and make a migration file so we can apply 
this code inside our database.

that is why the entity framework is called an object relational mapping (ORM) because make the relation between 
or C# code and the SQL database code.

to use the entity framework in our application we need to install the following packages inside our WebApiTemplate.Api folder:
```
dotnet tool install --global dotnet-ef
```
```
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```
```
dotnet add package Microsoft.EntityFrameworkCore.Design
```

Entity framework will check for the DbContext instruction inside our files in our project, this instruction are located in
the AppDbContext.cs file. then he will check for all the models that we are mapping inside this file.

in this case we are mapping only the UserModel.cs file but to improve the precision of entity framework and avoid any 
future problem with the database creation we add some instructions to this process using the UserMap.cs file, where
we specify to entity framework any property that we want in our coluns and tables.

before we run the command to create our migrations we need to setup the code inside our Program.cs file this way
the migrations file will have the information about the connection port and other informations related to the database

with all this finished we can execute the following command:

```
dotnet ef migrations add InitialCreation 
```

you can use any name for the first time you are creating the migration files here we used the InitialCreation name
after this if you want to make a new migration file you can use the following command:

```
dotnet ef migrations update (name of your migration)
```

if you check the migrations file inside your migrations folder you will see the instructions that Entity Framework made 
to build our database, so when we execute this code the app will build our database tables and coluns inside our docker
container.


## Migrations Auto Update

each time we start our application we need to run the command:

```
docker ef migrations update
```

this way the entity framework will check if he needs to update our database our tables inside our server. to avoid this
we will created an auto update code that is found inside our Program.cs, using the DataBaseManagementService.cs file, so 
each time we start the application entity framework will update our database for us.

if in any moment you need to make a new database, new table or add/remove coluns to your tables you need to make/change
the models, add/remove the configurations in the map file, add/remove in the AppDbContext file and execute the command to 
update the migrations files. a new migration file will be made by entity framework and then you can run the app to changes
take place in the database.



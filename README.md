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




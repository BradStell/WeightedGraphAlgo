***
## Running the project

First follow the [building the project](#building-the-project) instructions.

### Running the console program
Pass optional graph data to program
```
cd GraphTraversal  
dotnet run -- "AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7"
```
If no graph data parameter is supplied the program will use a default one.  
Example of running the program with out passing graph data
```
dotnet run
```

### Running the unit tests
```
cd Tests  
dotnet test
```

***

## Building the project
This project was written in C# on dotnet core 2.1.3

### Installing dotnet core SDK
Download the SDK for your platform  
  - [Windows](https://www.microsoft.com/net/learn/get-started/windows)
  - [Mac](https://www.microsoft.com/net/learn/get-started/mac)
  - [Linux](https://www.microsoft.com/net/learn/get-started/linux)


### Installing project dependencies
This command will install the nuget packages for both the GraphTraversal and Tests projects  
```
$ cd <project root>  

$ ls
    GraphTraversal/ GraphTraversal.sln README.md Tests/

$ dotnet restore
```  

Setup is now complete, the project and unit tests can be executed. [Instructions here](#running-the-project)
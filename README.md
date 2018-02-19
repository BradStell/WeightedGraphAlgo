***
## Running the project

First follow the [building the project](##buildingtheproject) instructions building the project.

### Running the console program
```
cd GraphTraversal  
dotnet run
```

### Running the unit tests
```
cd Tests  
dotnet test
```

***

## Building the project

### Installing dotnet core SDK
Download the SDK for your platform  
  - [Windows](https://www.microsoft.com/net/learn/get-started/windows)
  - [Mac](https://www.microsoft.com/net/learn/get-started/mac)
  - [Linux](https://www.microsoft.com/net/learn/get-started/linux)


### Installing project dependencies
This command will install the nuget packages for both the GraphTraversal and Tests projects  
```
cd <workspace root>  
dotnet restore
```  

Setup is now complete, the project and unit tests can be executed. [Instructions here](##runningtheproject)
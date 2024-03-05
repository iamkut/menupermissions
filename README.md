# Menu Permissions

## Introduction
Welcome to Menu Permissions. This console application is a permissions mapper that operates by taking in two input files, namely users.txt (containing a list of users and their permissions indicators) and menus.txt (containing different menus) then mapping User Menu permissions.

## Prerequisites
- .NET 8 SDK version
- Windows 11
- Visual Studio 2022 Community

## Getting Started

### Setting Up the Development Environment
1. **Install the .NET 8 SDK**: [Download it here](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks).
2. **Install Visual Studio 2022 Community**: [Download it here](https://visualstudio.microsoft.com/vs/community).
3. **Clone the Repository**: Clone the application repository to your local machine using Git.
   ```
   git clone https://github.com/iamkut/menupermissions.git
   ```
4. **Open a command line tool as administrator**.
5. **Navigate to the Project Directory**.

### Running the Application Locally
1. **Restore Dependencies**: Ensure you're in the root folder of the project. Run the command:
   ```
   dotnet restore
   ```
   This command restores all the NuGet packages required by the application.

2. **Build the Application**:
   ```
   dotnet build
   ```
   This compiles the application.

3. **Run the Application**:
   ```
   dotnet run
   ```
   This launches the application.

## Dependencies
- **users.txt**: This file contains a list of users and their permissions indicators. It must be in the root directory of the application.
- **menus.txt**: This file contains a list of menus. It must be in the root directory of the application.
- **Newtonsoft.Json**: This is used for serializing objects to JSON strings.

## Publish
1. **Publish the Application**:
   ```
   dotnet publish -c Release
   ```
   This command packages the application into a folder that can be deployed to a hosting environment.
2. **Navigate to the Publish Directory**:
   ```
   cd bin\Release\net8.0\publish
   ```
   This directory contains the published application. The following actions require that all the files in this directory be copied to the target environment.
3.1. **Run the Application**:
   ```
   dotnet MenuPermissions.dll
   ```
   This launches the application.
3.2. **Run the Application using the Executable**:
   ```
   MenuPermissions.exe
   ```
   This launches the application.

## License
You have the license to kill. Just not me, please :).

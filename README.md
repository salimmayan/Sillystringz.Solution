

# ## ## Dr. Sillystringz's Factory

##### Date: **06/06/2021**

#### By **_Salim Mayan_**

## Description

#### An MVC app built for _Dr. Sillystringz's_ factory to help manage _Engineers_ and  _Machines_.  _Dr. Sillystringz_ is allowed to add a list of engineers, a list of machines, and specify which engineers are licensed to repair which machines (implementation of many-to-many relationship between `Engineer`s and `Machine`s). 

### Implemented User Stories

-   Dr. Sillystringz need to be able to see a list of all engineers, and be able to see a list of all machines.
-   Dr. Sillystringz need to be able to select a engineer, see their details, and see a list of all machines that engineer is licensed to repair. Dr. Sillystringz also need to be able to select a machine, see its details, and see a list of all engineers licensed to repair it.
-   Dr. Sillystringz need to add new engineers to system when they are hired. Dr. Sillystringz also need to add new machines to system when they are installed.
-   Dr. Sillystringz should be able to add new machines even if no engineers are employed. Dr. Sillystringz should also be able to add new engineers even if no machines are installed
-   Dr. Sillystringz need to be able to add or remove machines that a specific engineer is licensed to repair. Dr. Sillystringz also need to be able to modify this relationship from the other side, and add or remove engineers from a specific machine.
-   Dr. Sillystringz should be able to navigate to a splash page that lists all engineers and machines. Dr. Sillystringz should be able to click on an individual engineer or machine to see all the engineers/machines that belong to it.

## Setup/Installation Requirements

1. Clone this repository from GitHub using `git clone https://github.com/salimmayan/Sillystringz.Solution`

2. Open directory `Sillystringz.Solution` in VS Code

3. To install packages listed in `.csproj` file, from command line navigate to `Factory`  directory and then run  `dotnet restore` (**'obj'** directory would get created in `Factory` directory)

4. To create internal content for build, from command line navigate to `Factory`  directory and then run  `dotnet build` (**'bin'** directory would get created in `Factory`  directory)

5. **Re-create Database with MySQL Workbench Migration Functionality**:  From command line navigate to `Factory`  directory and execute below three commands    
	-   		dotnet restore
	-   		dotnet ef migrations add Initial
	-           dotnet ef database update
    
   *Note*: In _MySQL Workbench_ Reopen the  _Navigator_  >  _Schemas_  tab. Right click and select  _Refresh All_ (new database will appear with the name "salim_mayan".

6. **Execute Application:** Navigate to `Factory` directory and enter `dotnet run`

7. In Browser enter URL `http://localhost:5000` to access application

⚠️  *Note*: To run project locally you need to have .NET Core (confirm running of .NET Core using command `dotnet --version` in command line)



| **Spec** |
## Running Tests:

-  Tests are not applicable for this application

## Known Bugs

* No Known bugs

## Improvement opportunities

* Add more styling.
* Improve routing/navigation between pages

## Technologies Used

-   C# 9
-   ASP.NET MVC
-   .NET Core v5.0
-   Razor View Engine
-   RESTful Routing
-   CRUD & HTTP
-   Bootstrap
-   REPL
-   Git and GitHub
-   Entity Framework Core

## Support and contact details

* For questions, comments, or concerns *[email author](mailto:mailsalim@gmail.com?subject=[GitHub])*


### License

*{This software is licensed under the MIT license}*

Copyright (c) 2021 **_{Salim Mayan}_**
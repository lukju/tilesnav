# tilesnav

## relevant links
http://mobilemancer.com/2016/10/19/aurelia-spa-typescript-dotnet-core/
https://fullstackmark.com/post/7/learning-unit-testing-in-aspnet-core

https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/migrations
https://codingblast.com/entityframework-core-idesigntimedbcontextfactory/

## topics for further reading

* System.ComponentModel.DataAnnotations;
generic Repository
* Seeding
* DbContext Add or AddAsync
* Unit Of Work
* Error Handling / Logging


## EF Migrations:

* Create new Migration:
	* `dotnet ef migrations add <MigrationName> `
* Apply all un-applied migrations to database: 
	* `dotnet ef database update`
* Remove last migration (if not applied to database yet): 
	* `dotnet ef migrations remove`
* Revert all applied migrations from database: 
	* `dotnet ef database update 0` 
    * (means: drop all tables)
* Revert applied migrations back to a certain migration: 
  * `dotnet ef database update <MigrationName> `
  * (means: Make migration "MigrationName" the current state)
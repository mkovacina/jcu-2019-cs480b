# Notes

## Add the NuGet references
After creation of the two initial projects, in the lorem.core project add NuGet references to Microsoft.EntityFrameworkCore.Sqlite.  That package will transitively add the other references that will be needed.

## Create the database context
Create the class LoremContext.cs in the lorem.core project and have that class extend DbContext.

## Create the model classes
Create the initial models, in this case Document and Author.
Also create the relation table.

## Update the database context
Add DbSet properties for Document and Author.

## Make the console app do something approximately useful with the database
First be sure to add a reference to lorem.core.
Using the ServiceCollection/ServiceProvider to follow a depenency injection style.
Setup the database to use Sqlite.
Try to retrieve all the documents (which would be a grand total of 0).

## Create the database
Use the convenient EnsureCreated method off of context.Database to ensure the database exists.
Run.
No documents.
Functioning to spec.
But notice that a file named 'lorem.db' now exists in the directory where your executable lives (bin/).

## Seed the database
Generate some data for the database so there is something to print out.
Depending on your application, this might be something you would actually do.
Or you might just have a blank database.
It is useful for testing though.
So is adding in the line EnsureDeleted (temporarily) before EnsureCreated.
This will delete your database...intuitive, no?
While testing though, this can save you some time as you can always start with a fresh database.
Though be warned, you can't (ok, shouldn't) run this way forever becuase
(A) it biases your development and testing to a clean environment which is not what customers have
(B) you are dodging most of the migration process.


## Misc.
[ ] Consider installing the "SQLite/SQL Server Compact Toolbox" extension so that you can browse the SQLite database structure


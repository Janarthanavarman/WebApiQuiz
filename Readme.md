
## Entity refer page
https://www.learnentityframeworkcore.com/walkthroughs/existing-database

## EF for Db First 
 Properities : https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet#dotnet-ef-dbcontext-scaffold

> dotnet add package Microsoft.EntityFrameworkCore.SqlServer
> dotnet add package Microsoft.EntityFrameworkCore.Tools 
> dotnet add package Microsoft.EntityFrameworkCore.SqlServer.Design
Modify the .csproj  >> <DotNetCliToolReference  Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="x.x.x" />

> dotnet ef DbContext Scaffold  "Server=xxxxxx;Database=training;Trusted_Connection=False;User ID=training;password=training;" Microsoft.EntityFrameworkCore.SqlServer -o Models

## Update EF
> dotnet ef dbcontext scaffold  "Server=10.100.8.148;Database=training;Trusted_Connection=False;User ID=training;password=training;" Microsoft.EntityFrameworkCore.SqlServer -f -o Models -t tbl_mst_QuizCategory -t tbl_mst_questions -t tbl_mst_quizoptions --context-dir Models/Context -c DBContext


## Updating the Model 
>dotnet ef dbcontext scaffold  "Server=xxxxxx;Database=training;Trusted_Connection=False;User ID=training;password=training;" Microsoft.EntityFrameworkCore.SqlServer -force

## Procedure
http://www.entityframeworktutorial.net/efcore/working-with-stored-procedure-in-ef-core.aspx

Eg. context.Database.ExecuteSqlCommand("CreateStudents @p0, @p1", parameters: new[] { "Bill", "Gates" });
    Context.Set<Object>().FromSql("EXECUTE dbo.GetProductByName  @productCategory");
    Context.Student.FromSql("EXECUTE dbo.GetProductByName  @productCategory");

## Annotation

https://www.learnentityframeworkcore.com/configuration/data-annotation-attributes
# BlazorApp
 
 A Blazor-based library app made for 2021 Code Bootcamp. It also uses Entity Framework for Object-Relation Mapping (ORM). It was created in roughly 3 days.

 ON THE SURFACE

 Basically, this is a Blazor-based web application for listing authors and their books. The user can select an author from a dropdown menu, which will load a table of books written by the author asynchronously (basically, without requiring reload of the entire 
 page). The user is capable of adding new authors as well as books, as well as deleting books. These actions also occur asynchronously, and the user will see the changes come to effect practically instantly.

 UNDER THE HOOD

 As mentioned before this application is based on Microsoft's Blazor technology, which in turn is based on Razor Pages. Effectively, Blazor allows creation of reactive web pages similar to React without having to use JavaScript, making the code 100 % server side 
 AND 100 % ASP.NET-based. Additionally, this application uses Entity Framework for Object-Relation Mapping (ORM). ORM basically takes database tables and creates matching classes, with variables substituting for columns. These classes are then used in lieu of the 
 traditional SQL queries to perform database-related functions. Together, these technologies effectively allow a full stack application to be coded purely on C#. Theoretically, this has multiple benefits such as simplifying the code and making tracing of the 
 origin of any errors easier and less time consuming.

 STRUCTURE

 The most relevants parts of this application are divided in four layers, physically represented as folders containing relevant files. These are as follows:

 - Data
   - DataService.cs: Class containing the public database-related functions that are called from the webpage, which then make function calls to DataAccessLayer.cs to actually execute these functions. Some of these are executed asynchronously as Tasks.
 - DataAccess
   - DataAccessLayer.cs: As mentioned above, this class is the one that actually executes database functions, using an instance of BlazorContext.cs to call functions with similar functionality to SQL queries.
 - Models
   - Author.cs: A class representing Author database table, with variables as columns.
   - Book.cs: As above, but for books.
   - Publisher.cs: As above, but for publishers.
   - BlazorContext.cs: A "database context", this class is the one that actually connects to the database, and is used by DataAccessLayer.cs to execute queries.
 - Pages
   - Books.razor: This is the webpage the user actually sees and interacts with. Most code in the page will call functions in the Dataservice.cs, which is instanced with @inject.

 DUDE, THERE'S MORE FILES THAN THAT IN THOSE FOLDERS. WHAT'S UP WITH THAT?

 The above only mentions files that are relevant for understanding the application. The rest fall into two categories:

 - Automatically generated files that contains basic functionalities for Blazor apps. These for the most part shouldn't be messed with or have only minor modifications made to them.
 - Automatically generated examples that demonstrate basic Blazor functionality. These could be deleted (Remember to delete them from NavMenu.razor as well), but given the time constraints, I just couldn't be arsed.
   - These are WeatherForecast.cs, WeatherForecastService.cs, Counter.razor and FetchData.razor.
  
  For the time being, I'm gonna end here. I might in the future describe Books.razor in detail to give a more in-depth explanation of the app, but for now, this should give you an elementary understanding of this app.    

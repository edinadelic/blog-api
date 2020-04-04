The application was created in the Visual Studio Code editor.

ASP.NET CORE 3.0.0 and EntityFrameworkCore and SQL Server Express were used.

To start the application, you need to customize the server name in the connection string. It is currently located there
the name of my server.

Make sure to have ef tools 3.0.0 installed so we can use EntityFramework and SQL Server Express.

Running the dotnet run command will create and sedd the database on the specified server.

WebApi was tested through Postman.

Post and Put methods, PostsContoller receive data in the format:

 {
        "slug": "ex-adipisicing-pariatur-voluptate-cupidatat-magna-enim-ea-reprehenderit",
        "title": "Update Update Update",
        "description": "Duis incididunt fugiat sint elit cillum. Veniam culpa labore ex Lorem esse. You are not sit veniam dolor qui. Nostrud cupidatat eu consequat nulla commodo dolore nulla you are not incididunt occaecat amet anim. \ r \ n".
        "body": "Commodo excepteur amet exercising labore en officia cupidatat pariatur. Ut enim qui ullamco consequat in do nulla ut elit est adipisicing proident magna elit. Ad laboris ea consectetur ipsum ullamco id pariatur laborum commodo reprehenderit enim.",
        "createdAt": "2017-06-29T00: 00: 00",
        "updatedAt": "2020-07-13T00: 00: 00",
        "tagList": [
            "deserunt",
            "elite",
            "cupidatat",
            "reprehenderit"
        ]
    }
 Previous example is example of Updating record trough Postman.
  
The database consists of a single table that has a tags field where stores data from tagList.

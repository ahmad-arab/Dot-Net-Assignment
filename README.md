# Dot-Net-Assignment
This is a simple ASP.NET core API to show off some of my abilities.<br />
It's an interface that can be interracted with for the purpose of creating, storing and managing a TODO list.<br />

# Controllers and methods
This API consists of two controllers:<br />
  1. TodoController: handles all the actions related to the main purpos of the API; TODO entries.<br />
     It contains the following methods:<br />
       - GetAll(HttpGet): gets all the todo items in the list. It's called via: [IpAddress].[Port]/todo/getall<br />
           All authenticated users are allowed to call this method<br />
       - Get(HttpGet): gets a specific Todo entry by it's Id. It's called via: [IpAddress].[Port]/todo/get/{id}<br />
           where {id} is the id of the wanted todo entry.<br />
           Only autenticated users with the role "Admin" can call this method.<br />
       - Create(HttpPost): Creates a new todo entry and adds it to the list. It's called via [IpAddress].[Port]/todo/create<br />
           the body of the request should contain the new Todo entry object as following:<br />
           {<br />
            "date": "2022-04-14T06:52:39.3335412+00:00",<br />
            "title": "Visit Grandma",<br />
            "discrbtion": "It's grandma birthday"<br />
            }<br />
            Only autenticated users with the role "Admin" can call this method.<br />
       - Update(HttpPut): updates an existing todo entry and saves chenges to the list. It's called via [IpAddress].[Port]/todo/put/{id}<br />
           where {id} is the id of the wanted todo entry.<br />
           the body of the request should contain the new details of the Todo entry object as following:<br />
           {<br />
            "date": "2022-05-14T06:52:39.3335412+00:00",<br />
            "title": "Visit Grandma again",<br />
            "discrbtion": "This time it is not a birthday"<br />
            }<br />
            Only autenticated users with the role "Admin" can call this method.<br />
       - Delete(HttpDelete): deletes a specific Todo entry by it's Id. It's called via: [IpAddress].[Port]/todo/delete/{id}<br />
           where {id} is the id of the wanted todo entry.<br />
           Only autenticated users with the role "Admin" can call this method.<br />
           
  2. AuthController: Handles all the logic related to authorization and authenticating.<br />
     It has a single methd that loges in a user and returns a token that contains: FirstName, LastName, Email, IsActive, Roles<br />
     (1) Authenticate(HttpPost): authenticats a user and returns atoken. It's called via [IpAddress].[Port]/auth<br />
         the body of the request should contain the username and the password as following:<br />
         {<br />
          "Username": "username",<br />
          "Password": "password",<br />
         }<br />
         All users can call this method wether authenticated or not.<br />
         
# Authenticating
To use the api you can log in using these credintials in the http request body:<br />
  - {"Username":"user1","Password":"pass1}         this is auser the role "Admin"<br />
  - {"Username":"user2","Password":"pass2}         this is auser the role "User"<br />
  - {"Username":"user3","Password":"pass3}         this is auser the role "User"<br />

         

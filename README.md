# Dot-Net-Assignment
This is a simple ASP.NET core API to show off some of my abilities.
It's an interface that can be interracted with for the purpose of creating, storing and managing a TODO list.

_________________________________________________________________________________________________________________________________
This API consists of two controllers:
  1- TodoController: handles all the actions related to the main purpos of the API; TODO entries.
     It contains the following methods:
       (1) GetAll(HttpGet): gets all the todo items in the list. It's called via: [IpAddress].[Port]/todo/getall
           All authenticated users are allowed to call this method
       (2) Get(HttpGet): gets a specific Todo entry by it's Id. It's called via: [IpAddress].[Port]/todo/get/{id}
           where {id} is the id of the wanted todo entry.
           Only autenticated users with the role "Admin" can call this method.
       (3) Create(HttpPost): Creates a new todo entry and adds it to the list. It's called via [IpAddress].[Port]/todo/create
           the body of the request should contain the new Todo entry object as following:
           {
            "date": "2022-04-14T06:52:39.3335412+00:00",
            "title": "Visit Grandma",
            "discrbtion": "It's grandma birthday"
            }
            Only autenticated users with the role "Admin" can call this method.
       (4) Update(HttpPut): updates an existing todo entry and saves chenges to the list. It's called via [IpAddress].[Port]/todo/put/{id}
           where {id} is the id of the wanted todo entry.
           the body of the request should contain the new details of the Todo entry object as following:
           {
            "date": "2022-05-14T06:52:39.3335412+00:00",
            "title": "Visit Grandma again",
            "discrbtion": "This time it is not a birthday"
            }
            Only autenticated users with the role "Admin" can call this method.
       (2) Delete(HttpDelete): deletes a specific Todo entry by it's Id. It's called via: [IpAddress].[Port]/todo/delete/{id}
           where {id} is the id of the wanted todo entry.
           Only autenticated users with the role "Admin" can call this method.
           
  2- AuthController: Handles all the logic related to authorization and authenticating.
     It has a single methd that loges in a user and returns a token that contains: FirstName, LastName, Email, IsActive, Roles
     (1) Authenticate(HttpPost): authenticats a user and returns atoken. It's called via [IpAddress].[Port]/auth
         the body of the request should contain the username and the password as following:
         {
          "Username": "username",
          "Password": "password",
         }
         All users can call this method wether authenticated or not.
         
_______________________________________________________________________________________________________________________________________

To use the api you can log in using these credintials in the http request body:
  {"Username":"user1","Password":"pass1}         this is auser the role "Admin"
  {"Username":"user2","Password":"pass2}         this is auser the role "User"
  {"Username":"user3","Password":"pass3}         this is auser the role "User"

         

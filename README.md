# The-People-Search
ASP.NET MVC application for searching user information in a database or adding a new user. The applications makes use of the Microsoft stack using an MVC front end, an ASP.NET Web API and a MS SQL database. The project also makes use of services and tools such as Dapper (ORM), Bootstrap 4 and jQuery (UI) and Amazon Web Services (RDS). 

## Project Status
This application was built simply as a demo / test for the purposes of displaying experience with full stack development on the Microsoft stack. Due to this, the project will not be hosted / put into a production state at this time.

## Installation
Given that this is a test project, the current "installation" practices are to open the .sln and run the project via Visual Studio and localhost. The project has already been configured to startup both the API and MVC applications at the same time as well as build all required dependencies. Furthermore, the database is currently hosted in a free tier AWS account so no database installation or script running is required (db connection is already configured in the Web.Config file for the API).

## Usage
Usage of the application is simple and revolves around two main pieces of functionality. The first is the search bar which takes in a text search and matches it against the firstName and lastName columns in the database. If any part of a user's first or last name contains the search string, then that user gets returned and displayed in the UI. If the search string is empty then no users are returned.

The second piece of functionality is adding a new uers. Next to the search bar is a button for adding a user and displays a bootstrap modal containing a form. Upon hitting the add button in this form (once all required fields are filled out) the user is written to the database and is immediately available for searching.

For testing purposes, three test users have already been added to the database (please see the below screenshot 'TestUsers.png' for details) to allow for user querying from the start.

## Important Information
Here is a list of important notes to know about the project with regards to setup and usage:
- The search function has a built in random number generator and setTimeout command to simulate random query lag / delay
	- If the randomly generated delay is greater than 3 seconds then the search task is canceled and a message appears for the user
	
- An endpoint in the MVC project was created at /home/error for the purposes of testing error logging to the database
	- Upon navigation to this endpoint a test error is automatically thrown and logged to the database while redirecting a user to an error page on the UI

## Screenshots
![TestUsers.png](TestUsers.png)

## Authors
Mitchell Console

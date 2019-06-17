# The-People-Search
ASP.NET MVC application for searching user information in a database or adding a new user. 

## Project Status
This application was build simply as a demo / test for the purposes of displaying experience with full stack development on the Microsoft stack. Due to this, the project will not be hosted / put into a production state at this time.

## Installation
Given that this is a test project, the current "installation" practices are to open the .sln and run the project via Visual Studio and localhost. The project has already been configured to startup both the API and MVC applications at the same time as well as build all required dependencies. Furthermore, the database is currently hosted in a free tier AWS account so no database installation or script running is required (db connection is already configured in the Web.Config file for the API).

## Usage

## Important Information
Here is a list of important notes to know about the project with regards to setup and usage:
- The search function has a built in random number generator and setTimeout command to simulate random query lag / delay
	- If the randomly generated delay is greater than 3 seconds then the search task is canceled and a message appears for the user
	
- An endpoint in the MVC project was created at /home/error for the purposes of testing error logging to the database
	- Upon navigation to this endpoint a test error is automatically thrown and logged to the database why redirecting a user to an error page on the UI
	

## Authors
Mitchell Console

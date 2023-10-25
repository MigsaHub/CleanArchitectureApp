# CleanArchitectureApp
It is an application for registering applications to properties. The user must have an account and log in to be able to do CRUD with respect to edit their data and to interact with the property controller through an authorization scheme to register/consult/update and even delete an application to a property, whose userid is the id of the user already created.

After Login, the user can add a property with the fields: Status, Area, Price, Temporary, URL, Observation.

The user can see all the properties listed.

As a user I want to be able to register and login to interact with properties also I could modified my own information.

# Development Process: 
	
First, I created a NetCore Web API application and defined Clean Architecture layers:

- Api where I exposed controllers
- Application where I concentrated business logic DTOs and services that connect to the repository.
- Infrastructure, where I exposed repositories and connection to database
- Domain where I defined class for entities User and Property
- Test Layer - where I exposed controllers and services to be tested.
  
  	I started to work with TDD and develop UserService, which is the first stage of the process. That help me to define the contract and services entities and repositories with an empty state.
  
  	In terms of business logic, I firstly focused on developing UserService all layers.
  
  	I went with the authorization approach because it is more time consuming because it is so detailed and it was necessary to use authorized methods. For unauthorized methods, I use the AllowAnonymous attribute because I need to register first and then get the token with the login.
  	After that I worked with PropertyService with the same approach, this part was more difficult because I had to think about a story that would need to be related to UserService, besides working with a different ORM than EntityFramework, I chose Dapper because among the ORMs it is one of the fastest and recommended and also easy to implement. I created a database with SQLLite, and designed two tables, one for users and one for properties.
  
  	I had to do some refactoring when the business logic was developed, I had to adapt the unit tests, I had to clean up unused references.
  
  	I left the frontend and the end because was optional but a great option to expose methods consumption with React. Update: CleanArchitectureAppFront is in this github proyect.
  
  	About refactoring and development, I focused on the SOLID principles for good practices. Work and delegated responsability to contracts(repositories and services interfaces) and implemented to develop internal logic (Open-Closed, Dependency inversion, Liskov Sustitution principle to define that only high level defined contracts and controllers and implementations work with that also Single Responsability to delegated methods. 
  
  	About design patterns I worked with Singleton Pattern, to defined a unique instance of Database with DapperContext. 

You can run with docker locally with this command:
     
     docker-compose up --build -d

You could access front and back with this ports:
     
     https://localhost:32774/swagger/index.html (Backend)
     http://localhost:5173/ (Front)
# Endpoints
![image](https://github.com/MigsaHub/CleanArchitectureApp/assets/77845203/2c50e140-8e31-41f1-a7df-1e8b9b8f8e6a)

# Technologies Used:

- Dapper - ORM for database communication
- SQLLITE - Database approach
- Net Core Web Api C#
- Automapper - Useful for working with DTOs and domain entities
- Moq and Xunit - To perform a unit test
- JWT Library - Used to generate tokens for authentication and authorization.
- Docker - to containerize the application

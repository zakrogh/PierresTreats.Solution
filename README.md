# _Pierre's Treats_

#### _A program created to practice many-to-many relationships and authentication in ASP.NET 10/27/2019_

#### By _Zach Krogh_

## Description

_This web application allows the user to create an account and login, once logged in they can create sweets and treats with a many to many relationship._

## Setup/Installation Requirements
* _Install dotnet core._
* _Download all files into the same directory_
* _Setup MySQL database as folows:_
  * _Using mysql or MySQL workbench:_
    * DROP DATABASE zach_krogh;
  * _Using the terminal:_
    * _run "dotnet ef databse update"_

* _run "dotnet run"_

## Project Specifications

* _The user can create a treat._
  * _input: name:"candy"_
  * _output: none (name is saved to database)_
  * _description: This is the most basic requirement of the program, allowing the user to create a treat._
* _The user can create a flavor with a treat._
  * _input: name: "chocolate" treat:"candy"_
  * _output: none (everything saved to database)_
  * _description: The next simplest behavior, the user can create a flavor and assign it to a treat._
* _The user can view details of a treat or flavor._
  * _input: Navigate to a treat or flavor._
  * _output: The treat or flavor details and name are displayed._
  * _description: Ensure the user can view details._
* _The user can delete a treat or flavor._
  * _input: Navigate to a treat or flavor and click delete, then confirm the delete._
  * _output: The treat or flavor is no longer accessible on the treat or flavor list._
  * _description: Ensure the user can delete a treat or flavor._

## Support and contact details

_contact: zakrogh@gmail.com_

## Technologies Used

_C#, ASP.NET MVC, MySQL, Razor, HTML, CSS, Bootstrap_

### License

*MIT License*

Copyright (c) 2019 **_Zach Krogh_**

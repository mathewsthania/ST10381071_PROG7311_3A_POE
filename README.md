Agri-Energy Connect 
----------------------

Agri-Energy Connect is a sustainable agriculture and green energy web application, that allows farmers and employee to manage and view agricultural products, using SQLite.

![image](https://github.com/user-attachments/assets/85d0fb6b-83ab-4bab-a764-157348162d70)

Description
-----------
This web application is built with ASP.NET Core MVC, which allows farmers to manage their products and employees to view them.

The main features of the web application include:
- A login feature 
- CRUD operations for farmer products
- CRUD operations for farmer profiles
- Employee view of all farmer products with a filter feature

This web application is role based. It has roles for an employee and farmers.

Features 
---------

1. Farmer: 
	- Manage Products: Farmers can view, add, edit and delete their products.

2. Employee:
	- Manage Farmers: Employees can add new farmers, edit farmer account details, and delete farmer profiles.
	- Employee creates Farmer profiles, farmers cannot register by themselves as their is only a log in page.
	
Both:
	- Home Page: Welcomes users to the Agri-Energy connect web application.
	- About Us: COMING SOON.
	- Blog: COMING SOON.
	- Contact Us: COMING SOON

Database:
SQLite Database (DB Browser for SQLite) 
--------------------------------------
This project uses a SQLite database file (`POE2Database.db`), created and managed using DB Browser for SQLite.

- The database contains the tables used in the application, such as `Product` and `Farmer`, and 'Employee'.
- All insert, update, and delete operations are handled using raw SQL commands in the application.
Installation
------------
If you would like to test out this web application, follow these steps to set up the project on your local machine.

Prerequisites 
-------------
- .NET SDK (version 5.0 or later)
- SQLite for database storage
- Visual Studio for editing and running web application.

Steps
------

1. Clone the repository:

[https://github.com/mathewsthania/ST10381071_PROG7311_3A_POE.git]

2. Open the solution in Visual Studio.

3. Ensure the database is present:

[The SQLite database file is located in the Database folder:/Database/POE2Database.db]
No configuration changes are needed. The project uses a relative path to connect to the database:

" "ConnectionStrings": {
  "DefaultConnection": "Data Source=Database/POE2Database.db"
} "

4. Build and run the project:

[Press F5 or click on Start]

Accessing the Application
---------------------------
To test the different roles.

Farmer: Log in as a farmer to manage your products.

[ Can use user: Name: John | Email: johndoe@gmail.com   |  Password: John1234 ]
[ Can use user: Name: Bob  | Email: bobmarley@gmail.com |  Password: Bob1234  ]

Employee: Log in as an employee to view the available products from different farmers and to manage or add new farmers.

[ Can use user: Name: Jack | Email: jackblack@gmail.com   |  Password: Jack1234 ]

Website Interfaces:
-----------------------
![image](https://github.com/user-attachments/assets/96ba362a-cdfe-4d2b-94fd-41ce288c0b3c)

<br>

![image](https://github.com/user-attachments/assets/28d8dbd3-8a4e-4e84-8856-87638efd7e16)

<br>

![image](https://github.com/user-attachments/assets/b31d07b9-759e-47ba-a50d-cfaf10f85871)

<br>

![image](https://github.com/user-attachments/assets/ac07c111-e6b2-4956-be55-429deb82530b)

<br>

![image](https://github.com/user-attachments/assets/2574d5a4-ad39-4fbc-9539-76971af24774)

<br>

GitHub Repository: 
-------------------
[https://github.com/mathewsthania/ST10381071_PROG7311_3A_POE.git]

Included in Zip file:
-----------------------
- All source code
- Database/POE2Database.db
- ReadMe.md file (text-document)

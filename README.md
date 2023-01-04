# Capstone Project w/Client from Town Of Stettler
## Group Members: Jean-Marc Delisle, Gary Murdoch, and Grant Stenruds
---
We were paired up with a Client from Town Of Stettler to build an application that manage computer inventory. 

`User Manual with Installation:`\
Install XAMPP Control Panel v3.3.0 and Visual Studio 2022.\
Once both application installed, make sure to run XAMPP in administration.\
Click start on Apache and MySQL, then click on MySQL admin, this will bring up a web browser to show where you can put in your database.\
`Folder Explorer`\
In the folder of where all the files are, double click on "TownOfStettler.sln" which will open up Visual Studio and load the project.\
`Using Visual Studio 2022`\
Go to the tools tab, select Nuget Package Manager and select on Package Manager Console.\
Click next to PM> ![image](https://user-images.githubusercontent.com/97612908/198075171-7eccd322-6dec-4f16-a768-1d276dac1b04.png)
and type in this following command "dotnet ef database update" which will merge the database context in Visual Studio to XAMPP.\
If you look in your web browser and refresh the page where the database is, you will now see ![image](https://user-images.githubusercontent.com/97612908/198070219-9e1b17a8-df93-4179-a927-364b27865d0b.png).\
Click on the new database, and you will see all the table that was created for this project.

Go back to Visual Studio 2022, and click on the complier above the red line as shown ![image](https://user-images.githubusercontent.com/97612908/198070911-af342edf-64c8-478c-9708-868d9470701b.png)

`Using the web browser of your new database entry`\
The home page has a option to use the menu on the navbar, or to use the drop down menu to search
the database tables.The user can search the entire database with the search bar on the home page.(Still work in progress at this time)\
Each database table has a option to enter in new data by using the Create New link. You can also edit existing data or delete unwanted data from the table by using the links at the end of each row.\


The picture was provided from the client and all rights reserved to Town of Stettler.

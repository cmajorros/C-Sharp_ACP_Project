# C-Sharp_ACP_Project
It is stock control c# Application. This system is mainly used in adding stock update and delete items.
I built it last year. I notice that in the business application is usally related to database command.
Some tasks were done repetedly for example in searching product , we use the ID in searching and we also
do this with searching product categories too. Therefore, I try to reduce coding as much as possible. 
I use MySQL for the database, but sorry I could not provide you the database file. This project is the 
an assignment from an employer for testing the new recruitment in C# developer. I still have some bugs in 
deleting the data. 

Basically, there are 5 tables used for this project
1) Products
2) Parts
3) Inventory
4) Kit_Relations


All Products must have parts and cannot exist without parts and a product can be a kit and can have many kits
and Parts have the relationships with inventory. 
Whenever part is delelted all tables which related to parts such as Products, Inventory and kit relations will 
be deleted as well. 

For full project can be downloaded at https://www.dropbox.com/sh/br8upan1stz3xzt/AADZ8d3b16VtJO0CnZd7EFtOa?dl=0



Best Regards,
Siroros R.

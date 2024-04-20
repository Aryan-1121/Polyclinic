```
In appsettings.json add your MySQL DB details in PolyclinicDBConnectionString field.
(change 'uid' field with your userName & 'pwd' field with your password )
then comment out line 43 and uncomment line 42 in PolyClinicDBContext.cs
eg.

"ConnectionStrings": {
    "PolyclinicDBConnectionString":"server=localhost;port=3306;database=PolyclinicDB;uid=root;pwd=root;"
  }


      OR  
      
let everything be same just create a .env file in root directory of PolyClinicWebServices and add this one line in the file
(with your MySQL userName and password)

MYSQL_CONNECTION_STRING="server=localhost;port=3306;database=PolyclinicDB;uid=root;pwd=root;"

```

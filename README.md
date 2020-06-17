# Introduction 
Create a C# console application that can be given a CSV file and convert it to XML or JSON. The idea
is to show off your knowledge of C# and OOP principles, rather than to do it as quickly as possible.
Feel free to use a library or framework, e.g. to help handle the interaction with the command line.
Your solution should be written with possible future requirements in mind, e.g. converting back to
CSV from other XML or JSON, converting between XML and JSON, or possibly taking input from a
different source, e.g. a database.

# Getting Started
This is a console application, so, to execute it you will need to open the command prompt,
go to the folder where is located the executable and execute the next command:

 csvtojson <path_where_is_located_the_csv_file> <conversion_type>

<path_where_is_located_the_csv_file>: Folder where are located the high definition pictures
<conversion_type>: json or xml

# Architecture

This project is splitted in diferent layers using the Clean Architecture methodology described here (https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures). Here you can find an explanation of each layer:

CSVToJSON: It contains the first layer logic. Here we'll show to the user the interactive messages.<br />
Core: It contains the business logic: Entities, Services, DTOs, etc.<br />
Infrastructure.Data: It contains the data layer.<br />
Infrastructure.DependencyBuilder: It contains all the dependecy injections. If you add a new service or repository class, you will need to add the injection here.<br />

# Author
Oscar Rodriguez - oscar.chelo@gmail.com<br />
https://oscarchelo.blogspot.com/<br />
https://www.linkedin.com/in/oscar-rodriguez-lopez-70b2a337<br />

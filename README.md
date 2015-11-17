## ASP.NET Web API Sample

CRUD:

+ Create (POST)
+ Read (GET)
+ Update (PUT)
+ Delete (DELETE)

## CURL Client Examples

Create:

    curl -v -X POST http://peeps.azurewebsites.net/api/persons -d "{\"Name\": \"Gilberto\", \"Phone\": \"4253499816\"}" --header "Content-Type: application/json"

Read all:

    curl -v http://peeps.azurewebsites.net/api/persons

Read one:

    curl -v http://peeps.azurewebsites.net/api/persons/4253499816

Update:

    curl -v -X PUT http://peeps.azurewebsites.net/api/persons/4253499816 -d "{\"Name\": \"Gilberto S\" }" --header "Content-Type: application/json"

Delete:

    curl -v -X DELETE http://peeps.azurewebsites.net/api/persons/4253499816

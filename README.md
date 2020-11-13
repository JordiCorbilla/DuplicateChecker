# Duplicate Checker
.Net service that allows you to check duplicated rows in a sql table.

The concept is very straight forward. You have a table that contains x number of rows and you would like to know if there are any duplicates on it. By saying duplicate I mean exact duplicates or "almost" duplicates. For example if you have the name "John Snow" and "John Snow." you can see that they are actually the same but one contains one additional character. To solve this problem I will rely on the Levenshtein distance to tell me how "similar" those two texts are and then provide the list of similarities aka duplicates.

This service will allow you to:
- Run the duplicate checker on a particular SQL server table where a row would be inspected and a List<string> of items would be returned with the duplicates.
 - The service will run several threads to try to use as many CPU cycles as possible. The complexity of the whole solution is O(n2) as it requires to run all rows against all of them: M x N, where M is a single row and N is the size of the table - 1 row.

From the sample list below, the results are as follows:
`````c#
public List<Car> Get()
{
    List<Car> list = new List<Car>();

    list.Add(new Car { Id = 1, Name = "Caballero" });
    list.Add(new Car { Id = 2, Name = "Cabrio" });
    list.Add(new Car { Id = 3, Name = "Cabriolet" });
    list.Add(new Car { Id = 4, Name = "Calais" });
    list.Add(new Car { Id = 5, Name = "Camargue" });
    list.Add(new Car { Id = 6, Name = "Camaro" });
    list.Add(new Car { Id = 7, Name = "Camry" });
    list.Add(new Car { Id = 8, Name = "Capri" });
    list.Add(new Car { Id = 9, Name = "Caprice" });
    list.Add(new Car { Id = 10, Name = "Caravan" });
    list.Add(new Car { Id = 11, Name = "Caravana" });
    list.Add(new Car { Id = 12, Name = "Caravelle" });
    list.Add(new Car { Id = 13, Name = "Caravella" });
    list.Add(new Car { Id = 14, Name = "Carry" });
    list.Add(new Car { Id = 15, Name = "Catera" });
    list.Add(new Car { Id = 16, Name = "Cattera" });
    list.Add(new Car { Id = 17, Name = "Cavalier" });
    list.Add(new Car { Id = 18, Name = "Cayenne" });
    list.Add(new Car { Id = 19, Name = "Celebrity" });
    list.Add(new Car { Id = 20, Name = "Celica" });
    list.Add(new Car { Id = 21, Name = "Century" });
    list.Add(new Car { Id = 22, Name = "Challenger" });
    list.Add(new Car { Id = 23, Name = "Champ" });
    list.Add(new Car { Id = 24, Name = "Charade" });
    list.Add(new Car { Id = 25, Name = "Charade" });
    return list;
}
`````
Output:

`````
Duplicates
Charade, Charade, 0, exact

Close Fit
Cabrio, Cabriolet, 3, closefit
Capri, Caprice, 2, closefit
Caravan, Caravana, 1, closefit
Caravelle, Caravella, 1, closefit
Catera, Cattera, 1, closefit

Similar
Caballero, Cavalier, 3, similar
Cabrio, Capri, 2, similar
Camargue, Camaro, 3, similar
Camaro, Camry, 2, similar
Camry, Carry, 1, similar
Caravana, Caravella, 3, similar
`````

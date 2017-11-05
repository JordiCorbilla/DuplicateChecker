# Duplicate Checker
.Net service that allows you to check duplicated rows in a sql table.

The concept is very straight forward. You have a table that contains x number of rows and you would like to know if there are any duplicates on it. By saying duplicate I mean exact duplicates or "almost" duplicates. For example if you have the name "John Snow" and "John Snow." you can see that they are actually the same but one contains one additional character. To solve this problem I will rely on the Levenshtein distance to tell me how "similar" those two texts are and then provide the list of similarities aka duplicates.

This service will allow you to:
- Run the duplicate checker on a particular SQL server table where a row would be inspected and a List<string> of items would be returned with the duplicates.
 - The service will run several threads to try to use as many CPU cycles as possible. The complexity of the whole solution is O(n2) as it requires to run all rows against all of them: M x N, where M is a single row and N is the size of the table - 1 row.

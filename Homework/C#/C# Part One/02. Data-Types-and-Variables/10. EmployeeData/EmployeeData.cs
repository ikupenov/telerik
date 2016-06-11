/*
A marketing company wants to keep record of its employees. Each record would have the following characteristics:

First name
Last name
Age (0...100)
Gender (m or f)
Personal ID number (e.g. 8306112507)
Unique employee number (27560000…27569999)

Declare the variables needed to keep the information for a single employee using appropriate primitive data types. 
Use descriptive names. Print the data at the console.
*/

using System;

class EmployeeData
{
    static void Main()
    {
        string firstName = "Iliyan";
        string lastName = "Kupenov";
        byte age = 19;
        string gender = "Male";
        ulong personalID = 8306112507;
        ulong employeeNumber = 275600021127569999;

        Console.WriteLine("\n First name: {0} \n Last name: {1} \n Age: {2} \n Gender: {3} \n Personal ID: {4} \n Unique Employee Number: {5} \n", firstName, lastName, age, gender, personalID, employeeNumber);
    }
}

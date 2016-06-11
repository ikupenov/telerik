/*
A bank account has a holder name (first name, middle name and last name), available amount of money (balance), bank name, IBAN, 
3 credit card numbers associated with the account. Declare the variables needed to keep the information for a single bank account 
using the appropriate data types and descriptive names.
*/

using System;

class BankData
{
    static void Main()
    {
        string firstName = "Iliyan";
        string lastName = "Kupenov";
        string middleName = "Iliev";

        double availableAmount = 1050.27;
        string bankName = "DSK";
        object IBAN = "BG51BUIB98881001075808";

        ulong cardOne = 1234456776544321;
        ulong cardTwo = 1234456776544322;
        ulong cardThree = 1234456776544323;

        Console.WriteLine("\n First Name: {0} \n Middle Name: {1} \n lastName {2} \n Available Amount: {3} \n Bank Name: {4} \n IBAN Number: {5} \n Credit Cards: \n {6} \n {7} \n {8}", firstName, middleName, lastName, availableAmount, bankName, IBAN, cardOne, cardTwo, cardThree);
    }
}
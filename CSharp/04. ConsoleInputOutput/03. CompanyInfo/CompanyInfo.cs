/* A company has name, address, phone number, fax number, web site and manager. 
 * The manager has first name, last name, age and a phone number. 
 * Write a program that reads the information 
 * about a company and its manager and prints them on the console.
 */

using System;

class CompanyInfo
{
    static void Main()
    {
        string companyName = Console.ReadLine();
        string address = Console.ReadLine();
        int phoneNumber = int.Parse(Console.ReadLine());
        int faxNumber = int.Parse(Console.ReadLine());
        string webSite = Console.ReadLine();
        string managerFirstName = Console.ReadLine();
        string managerLastName = Console.ReadLine();
        sbyte age = sbyte.Parse(Console.ReadLine());
        int managerPhoneNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("The company name is: {0}", companyName);
        Console.WriteLine("Address: {0}", address);
        Console.WriteLine("Phone number: {0}", phoneNumber);
        Console.WriteLine("Fax number: {0}", faxNumber);
        Console.WriteLine("Web site: {0}", webSite);
        Console.WriteLine("Manager first name: {0}", managerFirstName);
        Console.WriteLine("manager last name: {0}", managerLastName);
        Console.WriteLine("Manager age: {0}", age);
        Console.WriteLine("Manager Phone Number: {0}", managerPhoneNumber);

    }
}

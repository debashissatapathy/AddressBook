// See https://aka.ms/new-console-template for more information

using AddressBook;

Console.WriteLine("Welcome to Address Book Program in AddressBookMain!");

CreateContact contact = new CreateContact();

while (true)
{
    Console.WriteLine("Enter the number :\n1.Create Contact\n2.Update Contact\n3.Delete contact\n4.Add multiple Contact" +
                        "\n5.View Contact\n6.Add Unique Contact\n7.Display unique contact\n8.Search by city or state" +
                        "\n9.Count by city or state\n10.Contact by city\n11.Contact by state\n12.Sort contact by Name\n13.Sort contact by City" +
                        "\n14.Sort contact by State\n15.Sort contact by Zip\n16.Write in text file\n17.Read File in IO\n18.Append File in Text file" +
                        "\n19.Write CSV file\n20.Read CSV data\n21.Write to json file\n22.Read to json file");
    int option = Convert.ToInt32(Console.ReadLine());
    switch (option)
    {
        case 1:
            contact.AddContact();
            break;
        case 2:
            contact.UpdateContact();
            break;
        case 3:
            contact.Deletecontact();
            break;
        case 4:
            Console.WriteLine("Enter the number of contact to add");
            int n = Convert.ToInt16(Console.ReadLine());  
            contact.AddMultipleContact(n);
            break;
        case 5:
            contact.ViewContact();
            break;
        case 6:
            contact.AddUniqueContact();
            break;
        case 7:
            contact.DisplayUniqueContacts();
            break;
        case 8:
            contact.SearchByCityState();
            break;
        case 9:
            contact.CountByCityState();
            break;
        case 10:
            contact.ContactByCity();
            contact.DisplayContactsByCities_Dictionary();
            break;
        case 11:
            contact.ContactByState();
            contact.DisplayContactsByStates_Dictionary();
            break;
        case 12:
            Console.WriteLine("Sort contact by name");
            contact.SortContactByName();
            break;
        case 13:
            Console.WriteLine("Sort contact by city");
            contact.SortContactByCity();
            break;
        case 14:
            Console.WriteLine("Sort contact by state");
            contact.SortContactByState();
            break;
        case 15:
            Console.WriteLine("Sort contact by zip");
            contact.SortContactByZip();
            break;
        case 16:
            contact.WriteInFileIO();
            break;
        case 17:
            contact.ReadInFileIO();
            break;
        case 18:
            contact.AppendInFileIO();
            break;
        case 19:
            contact.WriteCSVFile();
            break;        
        case 20:
            contact.ReadCSVFile();
            break;
        case 21:
            contact.WriteJsonFile();
            break;
        case 22:
            contact.ReadJsonFile();
            break;
    }
    Console.Write("\n");
}

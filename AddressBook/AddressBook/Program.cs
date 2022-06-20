// See https://aka.ms/new-console-template for more information

using AddressBook;

Console.WriteLine("Welcome to Address Book Program in AddressBookMain!");

CreateContact contact = new CreateContact();

while (true)
{
    Console.WriteLine("Enter the number :\n1.Create Contact\n2.Update Contact\n3.Delete contact\n4.Add multiple Contact" +
                        "\n5.Add Unique Contact\n6.Display unique contact\n7.Search by city or state\n8.Count by city or state" +
                        "\n9.Contact by city\n10.contact by state\n11.Sort contact by Name\n12.Sort contact by City\n13.Sort contact by State" +
                        "\n14.Sort contact by Zip\n15.Write in text file\n16.View Contact");
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
            contact.AddUniqueContact();
            break;
        case 6:
            contact.DisplayUniqueContacts();
            break;
        case 7:
            contact.SearchByCityState();
            break;
        case 8:
            contact.CountByCityState();
            break;
        case 9:
            contact.ContactByCity();
            contact.DisplayContactsByCities_Dictionary();
            break;
        case 10:
            contact.ContactByState();
            contact.DisplayContactsByStates_Dictionary();
            break;
        case 11:
            Console.WriteLine("Sort contact by name");
            contact.SortContactByName();
            break;
        case 12:
            Console.WriteLine("Sort contact by city");
            contact.SortContactByCity();
            break;
        case 13:
            Console.WriteLine("Sort contact by state");
            contact.SortContactByState();
            break;
        case 14:
            Console.WriteLine("Sort contact by zip");
            contact.SortContactByZip();
            break;
        case 15:
            contact.WriteInFileIO();
            break;
        case 16:
            contact.ViewContact();
            break;

    }
}

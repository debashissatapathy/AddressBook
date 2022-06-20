// See https://aka.ms/new-console-template for more information

using AddressBook;

Console.WriteLine("Welcome to Address Book Program in AddressBookMain!");

CreateContact contact = new CreateContact();

while (true)
{
    Console.WriteLine("Enter the number :\n1.Create Contact\n2.Update Contact\n3.Delete contact\n4.Add multiple Contact" +
                        "\n5.Add Unique Contact\n6.Display unique contact\n7.Search by city or state\n8.Count by city or state" +
                        "\n9.Contact by city\n10.View Contact");
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
            break;
        case 10:
            contact.ViewContact();
            break;

    }
}

// See https://aka.ms/new-console-template for more information

using AddressBook;

Console.WriteLine("Welcome to Address Book Program in AddressBookMain!");

CreateContact contact = new CreateContact();

while (true)
{
    Console.WriteLine("Enter the number :\n1)Create Contact\n2)View Contact");
    int option = Convert.ToInt32(Console.ReadLine());
    switch (option)
    {
        case 1:
            contact.AddContact();
            break;
        case 2:
            contact.ViewContact();
            break;
    }
}

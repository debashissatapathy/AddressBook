using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class CreateContact
    {
        public List<Contacts> People = new List<Contacts>();
        Dictionary<string, List<Contacts>> dict = new Dictionary<string, List<Contacts>>();

        public void AddContact()
        {
            int flag = 0;
            Contacts contact = new Contacts();
            Console.WriteLine("Enter first Name");
            string AddFirstName = contact.FirstName = Console.ReadLine();

            foreach (var data in People)
            {
                if (People.Exists(data => data.FirstName == AddFirstName))
                {
                    flag++;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("{0} already Exist! Can't take the Duplicate Record", AddFirstName);
                    Console.ResetColor();
                    break;
                }
            }
            if (flag == 0)
            {
                Console.WriteLine("Enter Last Name : ");
                contact.LastName = Console.ReadLine();

                Console.WriteLine("Enter Email : ");
                contact.Email = Console.ReadLine();

                Console.WriteLine("Enter Phone Number : ");
                contact.PhoneNumber = Console.ReadLine();

                Console.WriteLine("Enter Address : ");
                contact.Address = Console.ReadLine();

                Console.WriteLine("Enter City : ");
                contact.City = Console.ReadLine();

                Console.WriteLine("Enter Zip : ");
                contact.Zip = Console.ReadLine();

                Console.WriteLine("Enter State : ");
                contact.State = Console.ReadLine();

                People.Add(contact);
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine("Contact added successfully.");
                Console.ResetColor();
                Console.WriteLine();
            }
        }
        public void ViewContact()
        {
            foreach (var data in People)
            {

                Console.WriteLine("Name of the Person : " + data.FirstName + " " + data.LastName);
                Console.WriteLine("Email ID : " + data.Email);
                Console.WriteLine("Mobile Number : " + data.PhoneNumber);
                Console.WriteLine("\n");

            }


        }
    }
    
}

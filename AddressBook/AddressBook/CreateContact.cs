using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class CreateContact
    {
        public Contacts contact = new Contacts();
        public List<Contacts> People = new List<Contacts>();
        Dictionary<string, List<Contacts>> dict = new Dictionary<string, List<Contacts>>();

        public void AddContact()
        {
            int flag = 0;
            
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
        public void UpdateContact()
        {
            Console.WriteLine("Enter Firstname for update.");
            string name = Console.ReadLine();
            foreach(var data in People)
            {
                if(data.FirstName == null)
                {
                    Console.WriteLine("{0} couldn't found in contact list!", name);
                }
                else if (People.Exists(data => data.FirstName == name))
                {
                    Console.WriteLine("choose option to update data\n1.FirstName\n2.LastName\n3.address\n4.City\n5.State" +
                                        "\n6.Zip\n7.Email\n8.Phone Number");
                    int ch = Convert.ToInt32(Console.ReadLine());
                    switch(ch)
                    {
                        case 1:
                            Console.WriteLine("Please enter the first name: ");
                            string firstname = Console.ReadLine();
                            data.FirstName = firstname;
                            break;
                        case 2:
                            Console.WriteLine("Please enter the last name: ");
                            string lastname = Console.ReadLine();
                            data.LastName = lastname;
                            break;
                        case 3:
                            Console.WriteLine("Please enter the address: ");
                            string address = Console.ReadLine();
                            data.Address = address;
                            break;
                        case 4:
                            Console.WriteLine("Please enter the city: ");
                            string city = Console.ReadLine();
                            data.City = city; ;
                            break;
                        case 5:
                            Console.WriteLine("Please enter the state: ");
                            string state = Console.ReadLine();
                            data.State = state;
                            break;
                        case 6:
                            Console.WriteLine("Please enter the zip: ");
                            string zip = Console.ReadLine();
                            data.Zip = zip;
                            break;
                        case 7:
                            Console.WriteLine("Please enter the email: ");
                            string email = Console.ReadLine();
                            data.Email = email;
                            break;
                        case 8:
                            Console.WriteLine("Please enter the phone number: ");
                            string phoneNumber = Console.ReadLine();
                            data.PhoneNumber = phoneNumber;
                            break;
                        default:
                            Console.WriteLine("Please choose correct option.");
                            break;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Contact updated successfully\n");
                    Console.ResetColor();
                    
                }
            }
        }
        public void ViewContact()
        {
            foreach (var data in People)
            {

                Console.WriteLine("Name of the Person : " + data.FirstName + " " + data.LastName);                
                Console.WriteLine("Mobile Number : " + data.PhoneNumber);
                Console.WriteLine("Address: At: {0}, City: {1}, State: {2}-{3}", data.Address, data.City, data.State, data.Zip);
                Console.WriteLine("Email ID : " + data.Email);
                Console.WriteLine("\n");

            }


        }
    }
    
}

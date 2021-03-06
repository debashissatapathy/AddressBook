using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using System.Globalization;
using Newtonsoft.Json;

namespace AddressBook
{
    public class CreateContact
    {
        public Contacts contact = new Contacts();
        public List<Contacts> People = new List<Contacts>();
        Dictionary<string, List<Contacts>> dict = new Dictionary<string, List<Contacts>>();
        Dictionary<string, List<Contacts>> dict_City = new Dictionary<string, List<Contacts>>();
        Dictionary<string, List<Contacts>> dict_State = new Dictionary<string, List<Contacts>>();

        public void AddContact()
        {
            int flag = 0;

            Console.WriteLine("Enter first Name");
            string AddFirstName = Console.ReadLine();

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
                Console.WriteLine("Enter First Name : ");
                contact.FirstName = Console.ReadLine();

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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Contact added successfully.");
                Console.ResetColor();
                Console.WriteLine();
            }
        }
        public void UpdateContact()
        {
            Console.WriteLine("Enter Firstname for update.");
            string name = Console.ReadLine();
            foreach (var data in People)
            {
                if (data.FirstName == null)
                {
                    Console.WriteLine("{0} couldn't found in contact list!", name);
                }
                else if (People.Exists(data => data.FirstName == name))
                {
                    Console.WriteLine("choose option to update data\n1.FirstName\n2.LastName\n3.address\n4.City\n5.State" +
                                        "\n6.Zip\n7.Email\n8.Phone Number");
                    int ch = Convert.ToInt32(Console.ReadLine());
                    switch (ch)
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
        public void Deletecontact()
        {
            Console.WriteLine("Enter first name for delete contact.");
            string name = Console.ReadLine();
            try
            {
                foreach (var data in People)
                {
                    if (People.Contains(data))
                    {
                        if (data.FirstName == name)
                        {
                            Console.WriteLine("{0} is exists in contact list, Do you wany to delete? Press Y/N", name);
                            string del = Console.ReadLine();
                            switch (del)
                            {
                                case "Y":
                                    People.Remove(data);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Contact deleted successfully.");
                                    Console.ResetColor();
                                    break;
                                case "N":
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine("Enter valid name.");
                                    Console.ResetColor();
                                    break;

                            }
                            return;

                        }
                    }
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("given name contact does not exists");
                Console.ResetColor();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void ViewContact()
        {
            foreach (var data in People)
            {

                Console.WriteLine("Name of the Person : {0} {1}", data.FirstName, data.LastName);
                Console.WriteLine("Mobile Number : " + data.PhoneNumber);
                Console.WriteLine("Address: At: {0}, City: {1}, State: {2}-{3}", data.Address, data.City, data.State, data.Zip);
                Console.WriteLine("Email ID : " + data.Email);
                Console.WriteLine("\n");

            }


        }

        public void AddMultipleContact(int n)
        {
            while (n > 0)
            {
                AddContact();
                n--;
            }
        }
        public void AddUniqueContact()
        {
            Console.WriteLine("Enter first name in your contact list: ");
            string name = Console.ReadLine();

            foreach (var data in People)
            {
                if (People.Contains(data))
                {
                    if (data.FirstName == name)
                    {
                        Console.WriteLine("{0} already exists in Address Book, please add a unique name to save.", name);
                        string uniqueName = Console.ReadLine();
                        if (dict.ContainsKey(uniqueName))
                        {
                            Console.WriteLine("{0} is already exists in contact list.", uniqueName);
                        }
                        dict.Add(uniqueName, People);
                        return;
                    }

                }
            }
            Console.WriteLine("This contactlist doesn't exist, please create a contactlist");
            return;
        }
        public void DisplayUniqueContacts()
        {
            Console.WriteLine("Enter the Uniquename of your contacts");
            string name = Console.ReadLine();
            foreach (var data in dict)
            {
                //Console.WriteLine("The details of " + name + " are \n" + contacts.Value);
                if (data.Key.Contains(name))
                {
                    foreach (var contact in data.Value)
                    {
                        Console.WriteLine("The details of {0} are Name: {1} {2}\nEmail: {3}\nPhone Number: {4}\nAddress: {5} " +
                                             "\ncity: {6}\nZip: {7}\nState: {8}", name, contact.FirstName, contact.LastName,
                                             contact.Email, contact.PhoneNumber, contact.Address, contact.City, contact.Zip,
                                             contact.State);
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("this unique name doesn't exist");
                }
            }
            Console.WriteLine("This Uniquelist doesn't exist, please creat a Uniquelist");
        }
        public void SearchByCityState()
        {
            Console.WriteLine("Please enter the City or State name");
            string CityOrState = Console.ReadLine();
            foreach (var data in People)
            {
                if (People.Exists(data => (data.City == CityOrState || data.State == CityOrState)))
                {
                    Console.WriteLine("Name of the Person : {0} {1}", data.FirstName, data.LastName);
                    Console.WriteLine("Email ID : {0}", data.Email);
                    Console.WriteLine("Mobile Number : {0}", data.PhoneNumber);
                    Console.WriteLine("Address : {0}", data.Address);
                    Console.WriteLine("City : {0}", data.City);
                    Console.WriteLine("State : {0}", data.State);
                    Console.WriteLine("Zip : {0}", data.Zip);
                    Console.WriteLine("\n");
                }
            }
        }
        public void CountByCityState()
        {
            Console.WriteLine("Please enter the name of City or State:");
            string CityOrState = Console.ReadLine();

            int count = 0;
            foreach (var data in People)
            {
                if (People.Exists(data => (data.City == CityOrState || data.State == CityOrState)))
                {
                    count++;
                }
            }
            Console.WriteLine("There are {0} Persons in {1}:", count, CityOrState);
        }
        public void ContactByCity()
        {

            try
            {
                var data = People.GroupBy(x => x.City);
                foreach (var cities in data)
                {
                    List<Contacts> citylist = new List<Contacts>();
                    foreach (var city in cities)
                    {
                        citylist.Add(city);
                    }
                    dict_City.Add(cities.Key, citylist);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void ContactByState()
        {
            try
            {
                var data = People.GroupBy(x => x.State);
                foreach (var states in data)
                {
                    List<Contacts> statelist = new List<Contacts>();
                    foreach (var state in states)
                    {
                        statelist.Add(state);
                    }
                    dict_State.Add(states.Key, statelist);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void DisplayContactsByCities_Dictionary()
        {
            if (dict_City.Count == 0)
                Console.WriteLine("No AddressBook to Show.");
            if (dict_City.Count >= 1)
            {
                foreach (KeyValuePair<string, List<Contacts>> addressBooks in dict_City)
                {
                    Console.WriteLine("Contacts From City: " + addressBooks.Key);
                    foreach (Contacts items in addressBooks.Value)
                    {
                        Console.WriteLine($"Name: {items.FirstName + " " + items.LastName}, Phone Number: {items.PhoneNumber}, City: {items.City}, State: {items.State}" +
                            $"\n Address: {items.Address}, Zipcode: {items.Zip}, Email: {items.Email}");
                        Console.WriteLine();
                    }
                }
            }
        }
        public void DisplayContactsByStates_Dictionary()
        {
            if (dict_State.Count == 0)
                Console.WriteLine("No AddressBook to Show.");
            if (dict_State.Count >= 1)
            {
                foreach (KeyValuePair<string, List<Contacts>> addressBooks in dict_State)
                {
                    Console.WriteLine("Contacts From City: " + addressBooks.Key);
                    foreach (Contacts items in addressBooks.Value)
                    {
                        Console.WriteLine($"Name: {items.FirstName + " " + items.LastName}, Phone Number: {items.PhoneNumber}, City: {items.City}, State: {items.State}" +
                            $"\n Address: {items.Address}, Zipcode: {items.Zip}, Email: {items.Email}");
                        Console.WriteLine();
                    }
                }
            }
        }
        public void SortContactByName()
        {
            foreach (var data in People.OrderBy(x => x.FirstName).ToList())
            {
                if (People.Contains(data))
                {
                    Console.WriteLine("Name of the Person : {0} {1}", data.FirstName, data.LastName);
                    Console.WriteLine("Email ID : {0}", data.Email);
                    Console.WriteLine("Mobile Number : {0}", data.PhoneNumber);
                    Console.WriteLine("Address : {0}", data.Address);
                    Console.WriteLine("City : {0}", data.City);
                    Console.WriteLine("State : {0}", data.State);
                    Console.WriteLine("Zip : {0}", data.Zip);
                    Console.WriteLine("\n");
                }
            }
        }
        public void SortContactByCity()
        {
            foreach (var data in People.OrderBy(x => x.City).ToList())
            {
                if (People.Contains(data))
                {
                    Console.WriteLine("Name of the Person : {0} {1}", data.FirstName, data.LastName);
                    Console.WriteLine("Email ID : {0}", data.Email);
                    Console.WriteLine("Mobile Number : {0}", data.PhoneNumber);
                    Console.WriteLine("Address : {0}", data.Address);
                    Console.WriteLine("City : {0}", data.City);
                    Console.WriteLine("State : {0}", data.State);
                    Console.WriteLine("Zip : {0}", data.Zip);
                    Console.WriteLine("\n");
                }
            }
        }
        public void SortContactByState()
        {
            foreach (var data in People.OrderBy(x => x.State).ToList())
            {
                if (People.Contains(data))
                {
                    Console.WriteLine("Name of the Person : {0} {1}", data.FirstName, data.LastName);
                    Console.WriteLine("Email ID : {0}", data.Email);
                    Console.WriteLine("Mobile Number : {0}", data.PhoneNumber);
                    Console.WriteLine("Address : {0}", data.Address);
                    Console.WriteLine("City : {0}", data.City);
                    Console.WriteLine("State : {0}", data.State);
                    Console.WriteLine("Zip : {0}", data.Zip);
                    Console.WriteLine("\n");
                }
            }
        }
        public void SortContactByZip()
        {
            foreach (var data in People.OrderBy(x => x.Zip).ToList())
            {
                if (People.Contains(data))
                {
                    Console.WriteLine("Name of the Person : {0} {1}", data.FirstName, data.LastName);
                    Console.WriteLine("Email ID : {0}", data.Email);
                    Console.WriteLine("Mobile Number : {0}", data.PhoneNumber);
                    Console.WriteLine("Address : {0}", data.Address);
                    Console.WriteLine("City : {0}", data.City);
                    Console.WriteLine("State : {0}", data.State);
                    Console.WriteLine("Zip : {0}", data.Zip);
                    Console.WriteLine("\n");
                }
            }
        }

        string FilePath = @"D:\C#\AddressBook\AddressBook\Contact.txt";

        public void WriteInFileIO()
        {
            using (TextWriter sw = File.CreateText(FilePath))
            {
                foreach (Contacts item in People)
                {
                    Console.WriteLine("Writing the details in Contact.txt File......");
                    Console.WriteLine("Details updated to the Contact.txt file");
                    sw.WriteLine("FirstName: " + item.FirstName.ToString());
                    sw.WriteLine("lastName: " + item.LastName.ToString());
                    sw.WriteLine("Email ID: " + item.Email.ToString());
                    sw.WriteLine("Mobile Number: " + item.PhoneNumber.ToString());
                    sw.WriteLine("City: " + item.City.ToString());
                    sw.WriteLine("State: " + item.State.ToString());
                    sw.WriteLine("ZIP: " + item.Zip.ToString());
                    Console.WriteLine("\n");

                }
            }
        }
        public void ReadInFileIO()
        {
            if (File.Exists(FilePath))
            {
                using (StreamReader file = new StreamReader(FilePath))
                {
                    int counter = 0;
                    string ln;

                    while ((ln = file.ReadLine()) != null)
                    {
                        Console.WriteLine(ln);
                        counter++;
                    }
                    file.Close();
                    Console.WriteLine($"File has {counter} lines.");
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Press Any key to close");
            Console.ResetColor();
            Console.ReadKey();
        }
        public void AppendInFileIO()
        {
            using(TextWriter tw = File.AppendText(FilePath))
            {
                foreach(Contacts item in People)
                {
                    Console.WriteLine("Appending the new details to the Previous File");
                    tw.WriteLine("FirstName :" + item.FirstName.ToString());
                    tw.WriteLine("lastName :" + item.LastName.ToString());
                    tw.WriteLine("Email ID :" + item.Email.ToString());
                    tw.WriteLine("Mobile Number :" + item.PhoneNumber.ToString());
                    tw.WriteLine("City  :" + item.City.ToString());
                    tw.WriteLine("State :" + item.State.ToString());
                    tw.WriteLine("ZIP :" + item.Zip.ToString());
                    Console.WriteLine("\n");
                }
            }
        }
        string CsvPath = @"D:\C#\AddressBook\AddressBook\WriteToCSV.csv";
        public void WriteCSVFile()
        {
            
            StreamWriter sw = new StreamWriter(CsvPath);
            using(var CsvData = new CsvWriter(sw, CultureInfo.InvariantCulture))
            {
                CsvData.WriteRecords(People);
            }
            Console.WriteLine("People List is saved as Csv file");
        }
        public void ReadCSVFile()
        {
            if (File.Exists(CsvPath))
            {
                StreamReader sr = new StreamReader(CsvPath);
                CsvReader cr = new CsvReader(sr, CultureInfo.InvariantCulture);
                List<Contacts> readCsv = cr.GetRecords<Contacts>().ToList();
                Console.WriteLine("Reading from CSV file");

                foreach (var item in readCsv)
                {
                    Console.WriteLine(item.FirstName.ToString());
                    Console.WriteLine(item.LastName.ToString());
                    Console.WriteLine(item.Email.ToString());
                    Console.WriteLine(item.PhoneNumber.ToString());
                    Console.WriteLine(item.Address.ToString());
                    Console.WriteLine(item.City.ToString());
                    Console.WriteLine(item.State.ToString());
                    Console.WriteLine(item.Zip.ToString());
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Press Any key to close");
            Console.ResetColor();
            Console.ReadKey();
        }
        string jsonPath = @"D:\C#\AddressBook\AddressBook\WriteToJson.json";
        public void WriteJsonFile()
        {
            foreach (Contacts item in People)
            {
                string json = JsonConvert.SerializeObject(People);
                File.WriteAllText(jsonPath, json);
            }
            Console.WriteLine("All data printed");
        }
        public void ReadJsonFile()
        {
            string jsonData = File.ReadAllText(jsonPath);
            var jsonResult = JsonConvert.DeserializeObject<List<Contacts>>(jsonData).ToList();
            Console.WriteLine("Reading from Json file");
            foreach(var data in jsonResult)
            {
                Console.WriteLine("Name of the Person : " + data.FirstName + " " + data.LastName);
                Console.WriteLine("Email ID : " + data.Email);
                Console.WriteLine("Mobile Number : " + data.PhoneNumber);
                Console.WriteLine("Address : " + data.Address);
                Console.WriteLine("City : " + data.City);
                Console.WriteLine("State : " + data.State);
                Console.WriteLine("Zip : " + data.Zip);
                Console.WriteLine("\n");
            }
        }
            
    }
    

}




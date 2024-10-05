using Cafe.Models;

namespace HelloWorldApp
{

    class Program
    {

        static void Main(string[] args)
        {
            string filePath = @"C:\Users\sobha\OneDrive\Desktop\Sobhan\University\term 5\Data Base\Customers.txt";
            Console.WriteLine("0_Login \n" +
                              "1_SignUp  \n");
            var first = Int32.Parse(Console.ReadLine());


            if (first == 1)
            {
                string[] existingCustomers = File.ReadAllLines(filePath);
                int customerCount = existingCustomers.Length;
                StreamWriter sw = File.AppendText(filePath);
                Customer customer = new Customer();
                customer.ID = customerCount++;
                sw.Write(" ID : " + customer.ID);
                customer.Role = "User";
                sw.Write(", Role : " + customer.Role);
                Console.WriteLine(" enter you Username : \n");
                string fullName = Console.ReadLine();
                customer.userName = fullName;
                sw.Write(", Username : " + fullName);
                Console.WriteLine(" enter you Password : \n");
                string Password = Console.ReadLine();
                customer.Password = Password;
                sw.Write($", Password : {Password} ");
                Console.WriteLine(" What is your Email Address? \n");
                string email = Console.ReadLine();
                sw.Write(", Email : " + email);
                sw.Write("\n");
                sw.Close();
            }
            int val = 0;
            string b = "";
            Customer cus = new Customer();
            if (first == 0)
            {
                Console.WriteLine("enter your username : ");
                string username = Console.ReadLine();
                Console.WriteLine("enter your password : ");
                string password = Console.ReadLine();
                string[] gettingCustomers = File.ReadAllLines(filePath);
                string[] customers = new string[gettingCustomers.Length];
                int flag = 0;
                int blag = 0;
                string[] word = new string[100];
                foreach (string customer in gettingCustomers)
                {
                    if ((customer.Contains($"Username : {username}")) && (customer.Contains($"Password : {password}")) &&
                        (customer.Contains($"Role : Admin")))
                    {
                        word = customer.Split(',');

                        //extracting id
                        string findingId = word[0];
                        for (int i = 0; i < findingId.Length; i++)
                        {
                            if (Char.IsDigit(findingId[i]))
                                b += findingId[i];
                        }

                        if (b.Length > 0)
                        {
                            val = int.Parse(b);

                            cus.ID = val;
                        }

                        flag = 1;
                        blag = 1;
                        break;

                    }

                    if ((customer.Contains($"Username : {username}")) && (customer.Contains($"Password : {password}")))
                    {
                        word = customer.Split(',');
                        string findingId = word[0];
                        for (int i = 0; i < findingId.Length; i++)
                        {
                            if (Char.IsDigit(findingId[i]))
                                b += findingId[i];
                        }

                        if (b.Length > 0)
                        {
                            val = int.Parse(b);

                            cus.ID = val;
                        }


                        flag = 1;
                        break;

                    }

                }

                if ((flag == 1) && (blag == 1))
                {
                    Console.WriteLine($"hello admin your ID is {cus.ID}");
                }
                if (flag == 1 && blag == 0)
                {
                    Console.WriteLine($"Hello user your id is {cus.ID}");
                }
                if (flag == 0)
                {
                    Console.WriteLine("USername or password is wrong");
                }


            }
        }
    }
}

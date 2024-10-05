using Cafe.Models;

namespace HelloWorldApp
{

    class Program
    {
        public static int customerNum = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Login or SignUp : ");
            var first = Int32.Parse(Console.ReadLine());

            if (first == 1)
            {
                StreamWriter sw = new StreamWriter(@"C:\Users\sobha\OneDrive\Desktop\Sobhan\University\term 5\Data Base\Customers.txt");
                customerNum++;
                Customer customer = new Customer();
                customer.ID = customerNum;
                sw.WriteLine(customer.ID);
                customer.Role = "User";
                sw.WriteLine(customer.Role);
                Console.WriteLine("What is your Full Name\n");
                string fullName = Console.ReadLine();
                customer.FullName = fullName;
                sw.WriteLine(fullName);
                Console.WriteLine("What is your Email Address? \n");
                string email = Console.ReadLine();
                sw.WriteLine(email);
                sw.WriteLine("\n");
                sw.Close();
            }
        }
    }
}

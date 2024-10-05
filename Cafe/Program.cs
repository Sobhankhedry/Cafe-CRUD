using Cafe.Models;

namespace HelloWorldApp
{

    class Program
    {

        static void Main(string[] args)
        {
            string filePath = @"C:\Users\sobha\OneDrive\Desktop\Sobhan\University\term 5\Data Base\Customers.txt";
            Console.WriteLine("Login or SignUp : ");
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
            if (first == 0)
            {
                string[] existingCustomers = File.ReadAllLines(filePath);
                Console.WriteLine(existingCustomers[1]);
            }
        }
    }
}

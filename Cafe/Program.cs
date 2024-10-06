using Cafe.Models;

namespace HelloWorldApp
{

    class Program
    {

        static void Main(string[] args)
        {
            string CustomerfilePath = @"C:\Users\sobha\OneDrive\Desktop\Sobhan\University\term 5\Database\Customers.txt";
            string readingIngrediants = @"C:\Users\sobha\OneDrive\Desktop\Sobhan\University\term 5\Database\Ingrediants.txt";
            string ingrediantsCartFilePath = @"C:\Users\sobha\OneDrive\Desktop\Sobhan\University\term 5\Database\IngrediantCart.txt";

            while (true)
            {
                Console.WriteLine("0_Login \n" +
                                  "1_SignUp  \n");
                var first = Int32.Parse(Console.ReadLine());


                if (first == 1)
                {
                    string[] existingCustomers = File.ReadAllLines(CustomerfilePath);
                    int customerCount = existingCustomers.Length;
                    StreamWriter sw = File.AppendText(CustomerfilePath);
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
                    string[] gettingCustomers = File.ReadAllLines(CustomerfilePath);
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


                            //extractin Username :
                            string findingUsernamew = word[2];
                            string[] extractuserName = findingUsernamew.Split(" ");
                            cus.userName = extractuserName[3];


                            //etracting password
                            string findPassword = word[3];
                            string[] extractPass = findPassword.Split(" ");
                            cus.Password = extractPass[3];


                            //extracting email
                            string finemailw = word[4];
                            string[] extractEmail = finemailw.Split(" ");
                            cus.Mail = extractEmail[3];


                            flag = 1;
                            blag = 1;
                            break;

                        }

                        if ((customer.Contains($"Username : {username}")) && (customer.Contains($"Password : {password}")))
                        {
                            word = customer.Split(',');

                            // extractinID
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

                            //extractin Username :
                            string findingUsernamew = word[2];
                            string[] extractuserName = findingUsernamew.Split(" ");
                            cus.userName = extractuserName[3];

                            //etracting password
                            string findPassword = word[3];
                            string[] extractPass = findPassword.Split(" ");
                            cus.Password = extractPass[3];

                            //extracting email
                            string finemailw = word[4];
                            string[] extractEmail = finemailw.Split(" ");
                            cus.Mail = extractEmail[3];


                            flag = 1;
                            break;

                        }

                    }

                    if ((flag == 1) && (blag == 1))
                    {
                        while (true)
                        {
                            Console.WriteLine("what do you want to do?");
                            Console.WriteLine("1_Insert Item");
                            Console.WriteLine("2_Delete Item");
                            Console.WriteLine("3_Buy Ingrediants");
                            Console.WriteLine("4_Net(Sum of income and outcome)");
                            Console.WriteLine("5_List of customers");
                            int Do = Int32.Parse(Console.ReadLine());
                            if (Do == 1)
                            {
                                Console.WriteLine("insert the name of the item : ");
                                string name = Console.ReadLine();
                                Console.WriteLine("insert the price : ");
                                double price = double.Parse(Console.ReadLine());

                                string[] lin = File.ReadAllLines(readingIngrediants);
                                int len = lin.Length;
                                len++;
                                StreamWriter sw = File.AppendText(readingIngrediants);
                                sw.Write($" ID : {len} ");
                                sw.Write($", Name : {name} ");
                                sw.Write($", Price : {price}");
                                sw.Write('\n');
                                sw.Close();
                            }
                            if (Do == 2)
                            {

                            }
                            if (Do == 3)
                            {
                                StreamReader sr = new StreamReader(readingIngrediants);

                                Ingredients ing = new Ingredients();


                                string line = sr.ReadLine();
                                string[] words;
                                int extractId = 0;
                                while (line != null)
                                {

                                    words = line.Split(",");

                                    //extracting ID
                                    string t = "";
                                    string findingId = words[0];
                                    for (int i = 0; i < findingId.Length; i++)
                                    {
                                        if (Char.IsDigit(findingId[i]))
                                            t += findingId[i];

                                    }
                                    if (t.Length > 0)
                                    {
                                        val = Int32.Parse(t);

                                        ing.id = val;
                                    }

                                    //extracting username
                                    string findingnamew = words[1];
                                    string[] extractuserName = findingnamew.Split(":");
                                    ing.ingredaintName = extractuserName[1];


                                    //extracting Price
                                    string findinprice = words[2];
                                    string[] extracprice = findinprice.Split(":");
                                    ing.Price = double.Parse(extracprice[1]);


                                    Console.WriteLine($"{ing.id}_{ing.ingredaintName} price : {ing.Price}");
                                    line = sr.ReadLine();
                                }

                                Dictionary<string, int> dic = new Dictionary<string, int>();
                                string[] lord;
                                string[] lerd;
                                while (true)
                                {
                                    IngrediantsCart ic = new IngrediantsCart();


                                    Console.WriteLine("what do you want to order? (use $ to exit)");
                                    string itemWant = Console.ReadLine();


                                    string[] gettingIngrediant = File.ReadAllLines(readingIngrediants);
                                    Console.WriteLine(gettingIngrediant.Length + " is the length");
                                    if (itemWant == "$")
                                        break;
                                    Console.WriteLine("how many do you want?");
                                    int qty = Int32.Parse(Console.ReadLine());
                                    dic.Add(itemWant, qty);


                                    foreach (string inger in gettingIngrediant)
                                    {

                                        if (inger.Contains($"{itemWant}"))
                                        {

                                            lord = inger.Split(",");


                                            //extracting price 
                                            string findingPrice = lord[2];
                                            string[] exactPrice = findingPrice.Split(":");
                                            double p = double.Parse(exactPrice[1]);
                                            double fullp = p * qty;


                                            string[] existingINgrediants = File.ReadAllLines(ingrediantsCartFilePath);
                                            int ingCount = existingINgrediants.Length;
                                            StreamWriter sw = File.AppendText(ingrediantsCartFilePath);
                                            sw.Write($" ID : {ingCount} ");
                                            sw.Write($", Name : {itemWant}");
                                            sw.Write($", Price : {fullp}");
                                            sw.WriteLine("");
                                            sw.Close();

                                        }
                                    }

                                }

                                sr.Close();

                                break;
                            }
                            if (Do == 4)
                            {

                            }
                            if (Do == 5)
                            {
                                StreamReader sr = new StreamReader(CustomerfilePath);
                                string line = sr.ReadLine();
                                while (line != null)
                                {
                                    Console.WriteLine(line);
                                    line = sr.ReadLine();
                                }
                                Console.WriteLine("\n");
                                Console.WriteLine("\n");

                            }
                            else
                            {
                                Console.WriteLine("Something went wrong try again!!");
                            }
                        }
                    }
                    if (flag == 1 && blag == 0)
                    {
                        Console.WriteLine($"welcome user your id is {cus.ID} with {cus.userName} username");
                        Console.WriteLine($" with {cus.Password} password  {cus.Mail} email");
                        break;
                    }
                    if (flag == 0)
                    {
                        Console.WriteLine("USername or password is wrong \n");

                    }


                }
            }
        }
    }
}

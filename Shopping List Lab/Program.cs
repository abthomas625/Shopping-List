using System.Linq;

namespace Shopping_List_Lab
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to HomeGrown Market!");

            Dictionary<string, double> itemsAndPrice = new Dictionary<string, double>();
            List<string> shoppingCart = new List<string>();
            
            itemsAndPrice.Add("eggs", 4.25);
            itemsAndPrice.Add("milk", 4.19);
            itemsAndPrice.Add("banana", 0.2);
            itemsAndPrice.Add("ice cream", 2.75);
            itemsAndPrice.Add("bacon", 9.75);
            itemsAndPrice.Add("cheese", 2.19);
            itemsAndPrice.Add("butter", 4.39);
            itemsAndPrice.Add("cereal", 2.95);

            foreach (KeyValuePair<string, double> kvp in itemsAndPrice)
            {
                Console.WriteLine($"{kvp.Key} {kvp.Value}");
            }

            bool goOn = true;
            while (goOn == true) 
            {              

                bool isValid = true;
                while (isValid)
                {
                    Console.WriteLine("Enter an item listed that you'd like to order.");
                    string order = Console.ReadLine().ToLower().Trim();

                    if (itemsAndPrice.ContainsKey(order))
                    {
                        Console.WriteLine("Item added successfully!");
                        shoppingCart.Add(order);
                    }
                    else
                    {

                        Console.WriteLine("I'm sorry we don't have that product. Please choose from the list provided");
                    }
                    isValid = AskAgain();
                }

                Console.WriteLine("Here are the items in your cart:");
                foreach (string cart in shoppingCart)
                {
                    Console.WriteLine($"{cart}");
                }

                double sum = 0;

                foreach(string cart in shoppingCart)
                {
                    sum += itemsAndPrice[cart];
                    
                }
                string total = String.Format("Your current total is {0:C2}", sum);
                Console.WriteLine(total);

                goOn = AskToContinue();
            }
        }
        static bool AskAgain()
        {
            Console.WriteLine("Would you like to add another item? Y/N");
            string response = Console.ReadLine().ToLower();
            if (response == "y" || response == "yes")
            {
                return true;
            }
            else if (response == "n" || response == "no")
            {
                return false;
            }
            else
            {
                Console.WriteLine("\nI didn't understand that. Please try again!");
                return AskAgain();
            }
        }

        static bool AskToContinue()
        {
            Console.WriteLine("Would you like to make create a new order?");
            string input = Console.ReadLine().ToLower();
            
            if (input == "y")
            {
                return true;
            }
            else if (input == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("\nI didn't understand that. Please try again!");
                return AskToContinue();
            }
        }
    }
}
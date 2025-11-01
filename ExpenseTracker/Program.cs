using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Globalization;


namespace ExpenseTracker
{

    class Program
    {
        static void Main()
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //Loads the current saved expenses from a .json file
            var groceries = Helpers.LoadExpenses("groceries.json");
            var clothing = Helpers.LoadExpenses("clothing.json");
            var housing = Helpers.LoadExpenses("housing.json");
            var other = Helpers.LoadExpenses("other.json");

            //Program start:
            while (true)
            {
                Console.Clear();

                Console.WriteLine("EXPENSE TRACKER");
                Console.WriteLine("---------------");

                //Start menu
                Console.WriteLine("\nPlease choose 1-5 and press Enter.");
                Console.WriteLine("\n1. Add expense");
                Console.WriteLine("2. Remove expense");
                Console.WriteLine("3. Display expenses");
                Console.WriteLine("4. Clear expense list");
                Console.WriteLine("5. Export expenses");
                Console.WriteLine("6. Exit application\n");

                Console.Write("Your choice: ");
                string? initialChoice = Console.ReadLine();

                //First choose an operation, after that, choosing a dictionary is prompted
                switch (initialChoice)
                {
                    // Add item to a dictionary
                    case "1":
                        Console.WriteLine("\nPlease choose an expense to add");
                        Console.WriteLine("(Write the number of your choice, and press Enter)");
                        Console.WriteLine("\n1. Groceries\n2. Clothing\n3. Housing\n4. Other\n");
                        Console.Write("Your choice: ");

                        string? addExpenseChoice = Console.ReadLine();


                        if (addExpenseChoice == "1" && addExpenseChoice != null)
                        {
                            Helpers.Add(groceries, "Groceries");
                            Helpers.SaveExpenses(groceries, "groceries.json");
                        }

                        else if (addExpenseChoice == "2" && addExpenseChoice != null)
                        {
                            Helpers.Add(clothing, "Clothing");
                            Helpers.SaveExpenses(clothing, "clothing.json");
                        }

                        else if (addExpenseChoice == "3" && addExpenseChoice != null)
                        {
                            Helpers.Add(housing, "Housing");
                            Helpers.SaveExpenses(housing, "housing.json");
                        }

                        else if (addExpenseChoice == "4" && addExpenseChoice != null)
                        {
                            Helpers.Add(other, "Other");
                            Helpers.SaveExpenses(other, "other.json");
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid choice.");
                            Console.WriteLine("Press any key to return to menu.");
                            Console.ReadKey();
                        }
                        break;

                    //Remove item from a dictionary.
                    case "2":
                        Console.WriteLine("\nPlease choose an expense to remove");
                        Console.WriteLine("(Write the number of your choice, and press Enter)");
                        Console.WriteLine("\n1. Groceries\n2. Clothing\n3. Housing\n4. Other\n");
                        Console.Write("Your choice: ");

                        string? removeExpenseChoice = Console.ReadLine();

                        if (removeExpenseChoice == "1" && removeExpenseChoice != null && groceries.Count > 0)
                        {
                            Helpers.Remove(groceries, "Groceries");
                            Helpers.SaveExpenses(groceries, "groceries.json");
                        }
                        else if (removeExpenseChoice == "2" && removeExpenseChoice != null && clothing.Count > 0)
                        {
                            Helpers.Remove(clothing, "Clothing");
                            Helpers.SaveExpenses(clothing, "clothing.json");
                        }
                        else if (removeExpenseChoice == "3" && removeExpenseChoice != null && housing.Count > 0)
                        {
                            Helpers.Remove(housing, "Housing");
                            Helpers.SaveExpenses(housing, "housing.json");
                        }
                        else if (removeExpenseChoice == "4" && removeExpenseChoice != null && other.Count > 0)
                        {
                            Helpers.Remove(other, "Other");
                            Helpers.SaveExpenses(other, "other.json");
                        }

                        else
                        {
                            Console.WriteLine("\nThe selected list was empty, or your choice was not valid.");
                            Console.WriteLine("Press any key to return to menu.");
                            Console.ReadKey();

                        }
                        break;

                    //Display dictionaries
                    case "3":
                        Console.WriteLine("\nPlease choose an expense list to display");
                        Console.WriteLine("(Write the number of your choice, and press Enter)");
                        Console.WriteLine("\n1. Groceries\n2. Clothing\n3. Housing\n4. Other\n5. All expense lists");
                        Console.Write("\nYour choice: ");

                        string? listDisplayChoice = Console.ReadLine();

                        if (listDisplayChoice == "1")
                        {
                            Helpers.Display(groceries, "Groceries");
                            Console.WriteLine("");

                            Helpers.ListSum(groceries);
                        }

                        else if (listDisplayChoice == "2")
                        {

                            Helpers.Display(clothing, "Clothing");
                            Console.WriteLine("");

                            Helpers.ListSum(clothing);
                        }

                        else if (listDisplayChoice == "3")
                        {
                            Helpers.Display(housing, "Housing");
                            Console.WriteLine("");

                            Helpers.ListSum(housing);

                        }
                        else if (listDisplayChoice == "4")
                        {
                            Helpers.Display(other, "Other");
                            Console.WriteLine("");

                            Helpers.ListSum(other);

                        }
                        else if (listDisplayChoice == "5")
                        {
                            Console.WriteLine(Helpers.DisplayAll(groceries, clothing, housing, other, "Groceries", "Clothing", "Housing", "Other"));
                            Console.WriteLine("");
                            Helpers.ListAllSum(groceries, clothing, housing, other);
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid choice.");
                            Console.WriteLine("Press any key to return to menu.");
                            Console.ReadKey();
                        }
                        break;

                    //Clears a dictionary, or clears all dictionaries
                    case "4":
                        Console.WriteLine("\nPlease choose an expense list to clear");
                        Console.WriteLine("(Write your choice, and press Enter)");
                        Console.WriteLine("\n1. Groceries\n2. Clothing\n3. Housing\n4. Other\n5. All expense lists");
                        Console.Write("\nYour choice: ");

                        string? clearChoice = Console.ReadLine();

                        if (clearChoice == "1")
                        {
                            groceries.Clear();
                            Console.WriteLine("");
                            Helpers.SaveExpenses(groceries, "groceries.json");

                            Console.WriteLine("Groceries list cleared.");
                            break;
                        }

                        else if (clearChoice == "2")
                        {

                            clothing.Clear();
                            Console.WriteLine("");
                            Helpers.SaveExpenses(clothing, "clothing.json");

                            Console.WriteLine("Clothing list cleared.");
                            break;
                        }

                        else if (clearChoice == "3")
                        {
                            housing.Clear();
                            Console.WriteLine("");
                            Helpers.SaveExpenses(housing, "housing.json");

                            Console.WriteLine("Housing list cleared.");
                            break;

                        }
                        else if (clearChoice == "4")
                        {
                            other.Clear();
                            Console.WriteLine("");
                            Helpers.SaveExpenses(other, "other.json");

                            Console.WriteLine("Other items list cleared.");
                            break;

                        }
                        else if (clearChoice == "5")
                        {
                            Console.WriteLine("\nAre you sure you want to clear all expense lists (y/n)?");
                            Console.Write("Your choice: ");
                            string? verifyChoice = Console.ReadLine();

                            if (verifyChoice == "y")
                            {
                                Helpers.ClearAllLists(groceries, clothing, housing, other);
                                Helpers.SaveExpenses(groceries, "groceries.json");
                                Helpers.SaveExpenses(clothing, "clothing.json");
                                Helpers.SaveExpenses(housing, "housing.json");
                                Helpers.SaveExpenses(other, "other.json");
                                Console.WriteLine("");
                            }
                            else if (verifyChoice == "n")
                            {
                                Console.WriteLine("\nOperation aborted.");
                                Console.WriteLine("Press any key to return to menu.");
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nNeither 'y' or 'n' was chosen. Aborting operation.");
                                Console.WriteLine("Press any key to return to menu.");
                                Console.ReadKey();
                                break;
                            }
                        }

                        else
                        {
                            Console.WriteLine("\nPlease enter a valid choice.");
                            Console.WriteLine("Press any key to return to menu.");
                            Console.ReadKey();
                            break;
                        }

                        Console.WriteLine("All expenses cleared.");
                        Console.WriteLine("Press any key to return to menu.");
                        Console.ReadKey();
                        break;

                    //Saves expenses to a text file
                    case "5":

                        string report = Helpers.DisplayAll(groceries, clothing, housing, other,
                                            "Groceries", "Clothing", "Housing", "Other");

                        string fileName = "expenses.txt";

                        File.WriteAllText(fileName, report);

                        Console.WriteLine($"\nAll expenses saved to {fileName}.");
                        Console.WriteLine("Press any key to return to menu.");
                        Console.ReadKey();
                        break;

                    //Basic application exit operation
                    case "6":
                        Console.Write("\nExiting application.");
                        Thread.Sleep(500);
                        Console.Write(".");
                        Thread.Sleep(500);
                        Console.Write(".");
                        Thread.Sleep(500);
                        Environment.Exit(0);
                        break;

                    //This runs if the start menu choice is not valid
                    default:
                        Console.WriteLine("\nPlease enter a valid choice.");
                        Console.WriteLine("Press any key to return to menu.");
                        Console.ReadKey();
                        break;
                }
                //This clears the console, so that only the start menu is visible after an operation
                Helpers.ClearBelowMenu(11);
            }

        }
    }
}


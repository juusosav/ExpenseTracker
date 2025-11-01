using System;
using System.Text.Json;

class Helpers
{
    public static void ClearBelowMenu(int menuLines)
    {
        // Set cursor position below the menu
        Console.SetCursorPosition(0, menuLines);

        // Clear lines below the menu
        for (int i = menuLines; i < Console.WindowHeight; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write(new string(' ', Console.WindowWidth));
        }

        // Reset cursor to the menu's end
        Console.SetCursorPosition(0, menuLines);
    }
    public static void Display(Dictionary<string, double> items, string dictName)
    {
        Console.WriteLine($"\n{dictName.ToUpper()}");
        Console.WriteLine("-----------");

        int i = 1;
        foreach (var item in items)
        {
            //Displays the expense list of the selected dictionary
            Console.WriteLine($"{i}. {item.Key} - {item.Value}€");
            i++;

        }
    }

    public static string DisplayAll(
        Dictionary<string, double> items1,
        Dictionary<string, double> items2,
        Dictionary<string, double> items3,
        Dictionary<string, double> items4,
        string dictName1,
        string dictName2,
        string dictName3,
        string dictName4)
    {
        //Enables saving to a text file
        var sb = new System.Text.StringBuilder();

        void appendDict(Dictionary<string, double> items, string dictName)
        {
            sb.AppendLine($"\n{dictName.ToUpper()}");
            sb.AppendLine("-----------");

            int i = 1;
            foreach (var item in items)
            {
                //Displays the expense list of the selected dictionary
                sb.AppendLine($"{i}. {item.Key} - {item.Value}€");
                i++;
            }
            sb.AppendLine("-----------");
            sb.AppendLine($" Total: {items.Values.Sum()}€");
        }
        appendDict(items1, dictName1);
        appendDict(items2, dictName2);
        appendDict(items3, dictName3);
        appendDict(items4, dictName4);

        return sb.ToString();
    }

    public static void Add(Dictionary<string, double> items, string dictName)
    {

        Console.WriteLine($"\nPlease specify an item to add to: {dictName}");
        Console.Write("Item: ");

        string? expenseChoice = Console.ReadLine();

        if (!string.IsNullOrEmpty(expenseChoice))
        {
            expenseChoice = char.ToUpper(expenseChoice[0]) + expenseChoice[1..].ToLower();
            Console.WriteLine($"\n{expenseChoice} added to list: {dictName}");
        }
        else
        {
            Console.WriteLine("\nYou tried to enter a empty list item.\n");
            Console.WriteLine("Press any key to return to menu.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("\nPlease specify the price of the expense (format: xx,xx) ");
        Console.Write("Price: ");
        string? input = Console.ReadLine();
        input = input?.Replace(".", ",");

        try
        {
            if (double.TryParse(input, out double number))
            {
                number = Math.Round(number, 2);
                items.Add(expenseChoice, number);
            }
            else
            {
                Console.WriteLine("\nPlease enter a valid number");
                Console.WriteLine("Press any key to return to menu.");
                Console.ReadKey();
                return;
            }
        }
        catch (ArgumentException)
        {
            Console.WriteLine($"\nThe item \"{expenseChoice}\" already exits in that list. Please remove the item if you want to re-enter it.");
            Console.WriteLine("Press any key to return to menu.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine($"\nItem added to: {dictName}!\n");
        Console.WriteLine("Press any key to return to menu.");
        Console.ReadKey();
    }

    public static void Remove(Dictionary<string, double> items, string dictName)
    {
        Console.WriteLine($"\nPlease specify an item to remove from: {dictName}");
        Console.WriteLine("");
        Helpers.Display(items, dictName);
        Console.Write("\nItem: ");

        string? RemoveChoice = Console.ReadLine();

        if (!string.IsNullOrEmpty(RemoveChoice) && int.TryParse(RemoveChoice, out int number))
        {
            if (number >= 1 && number <= items.Count)
            {
                var keyToRemove = items.Keys.ElementAt(number - 1);
                items.Remove(keyToRemove);
                Console.WriteLine($"\nThe item \"{keyToRemove}\" was removed from list: {dictName}\n");
            }
            else
            {
                Console.WriteLine("Please enter a valid list number.");
            }
            Console.WriteLine("Press any key to return to menu.");
            Console.ReadKey();

        }
        else
        {
            Console.WriteLine("\nItem not found, please enter a valid list number.\n");
            Console.WriteLine("Press any key to return to menu.");
            Console.ReadKey();
            return;
        }

    }

    public static void ListSum(Dictionary<string, double> items)
    {
        // Adds all the item values together
        double? totalSum = items.Values.Sum();
        Console.WriteLine("-----------");
        Console.WriteLine($"\nTotal: {totalSum}€\n");
        Console.WriteLine("Press any key to return to menu.");
        Console.ReadKey();
    }

    public static Dictionary<string, double> LoadExpenses(string filePath)
    {
        //Loads expenses from json file (if found)
        if (!File.Exists(filePath)) return [];
        string json = File.ReadAllText(filePath);
        try
        {
            return JsonSerializer.Deserialize<Dictionary<string, double>>(json) ?? [];
        }
        catch
        {
            Console.WriteLine($"Error loading {filePath}. Creating a new empty file.");
            return [];
        }
    }

    public static void SaveExpenses(Dictionary<string, double> data, string path)
    {
        try
        {
            File.WriteAllText(path, JsonSerializer.Serialize(data));
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error saving to {path}: {ex.Message}");
        }
    }

    public static void ClearAllLists(
        Dictionary<string, double> items1,
        Dictionary<string, double> items2,
        Dictionary<string, double> items3,
        Dictionary<string, double> items4)
    {
        items1.Clear();
        items2.Clear();
        items3.Clear();
        items4.Clear();
    }

    //Lists all values added together
    public static void ListAllSum(Dictionary<string, double> items1,
        Dictionary<string, double> items2,
        Dictionary<string, double> items3,
        Dictionary<string, double> items4)
    {
        double value1 = items1.Values.Sum();
        double value2 = items2.Values.Sum();
        double value3 = items3.Values.Sum();
        double value4 = items4.Values.Sum();

        double allValuesAdded = value1 + value2 + value3 + value4;

        Console.WriteLine("\n-------------------");
        Console.WriteLine($"Total of all expenses: {allValuesAdded}€");
        Console.WriteLine("\nPress any key to return to menu.");
        Console.ReadKey();
    }
}

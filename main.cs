using System;

class Program
{
    static void Main(string[] args)
    {

        string[] salespersonNames = { "Danielle", "Edward", "Francis" };
        char[] allowedInitials = { 'D', 'E', 'F' };
        double[] accumulatedSales = new double[salespersonNames.Length];


        double grandTotal = 0;

        while (true)
        {
            Console.WriteLine("Enter the initial of the salesperson: ");
            string input = Console.ReadLine().Trim();

            if (input.Equals("Z", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            bool validInitial = false;
            for (int i = 0; i < allowedInitials.Length; i++)
            {
                if (input.Equals(allowedInitials[i].ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    validInitial = true;

                    Console.WriteLine($"Enter the amount for {salespersonNames[i]}: ");
                    if (double.TryParse(Console.ReadLine(), out double saleAmount) && saleAmount >= 0)
                    {
                        accumulatedSales[i] += saleAmount;
                        grandTotal += saleAmount;
                    }
                    else
                    {
                        Console.WriteLine("Invalid sale amount entered. Please enter a positive number.");
                    }
                    break;
                }
            }

            if (!validInitial)
            {
                Console.WriteLine("Error, invalid salesperson selected, please try again");
            }
        }

        Console.WriteLine("\nSales Summary:");
        for (int i = 0; i < salespersonNames.Length; i++)
        {
            Console.WriteLine($"{salespersonNames[i]}: ${accumulatedSales[i]:F2}");
        }

        Console.WriteLine($"\nGrand Total Sales: ${grandTotal:F2}");

        int highestIndex = 0;
        for (int i = 1; i < accumulatedSales.Length; i++)
        {
            if (accumulatedSales[i] > accumulatedSales[highestIndex])
            {
                highestIndex = i;
            }
        }

        Console.WriteLine($"The salesperson with the highest total is {salespersonNames[highestIndex]} with ${accumulatedSales[highestIndex]:F2} in sales.");
    }
}
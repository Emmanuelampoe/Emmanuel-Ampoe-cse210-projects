using System;

// EXCEEDING REQUIREMENTS:
// The program keeps track of how many mindfulness activities the user
// completes during the session and displays the total when the user quits.

class Program
{
    static void Main(string[] args)
    {
        int activitiesCompleted = 0;
        string choice = "";

        while (choice != "4")
        {
            Console.Clear();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathingActivity = new BreathingActivity();
                breathingActivity.Run();
                activitiesCompleted++;
            }
            else if (choice == "2")
            {
                ReflectingActivity reflectingActivity = new ReflectingActivity();
                reflectingActivity.Run();
                activitiesCompleted++;
            }
            else if (choice == "3")
            {
                ListingActivity listingActivity = new ListingActivity();
                listingActivity.Run();
                activitiesCompleted++;
            }
            else if (choice == "4")
            {
                Console.Clear();
                Console.WriteLine("Thank you for using the Mindfulness Program!");
                Console.WriteLine($"You completed {activitiesCompleted} activities this session.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid choice. Please choose 1, 2, 3, or 4.");
                Thread.Sleep(1500);
            }
        }
    }
}
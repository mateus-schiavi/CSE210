using System;
class Program
{
    static void Main(string[] args)
    {
        int choice = 0;

        while (choice != 4)
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Breathing Exercise");
            Console.WriteLine("2. Listing Exercise");
            Console.WriteLine("3. Reflection Exercise");
            Console.WriteLine("4. Quit");

            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid choice. Please try again.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Breath breath = new Breath();
                    breath.DoBreathing();
                    break;

                case 2:
                    Listing listing = new Listing();
                    listing.DoListing();
                    break;

                case 3:
                    Reflection reflection = new Reflection();
                    reflection.DoReflection();
                    break;

                case 4:
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}

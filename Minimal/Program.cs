using System;

namespace NanoFSM
{
    class Program
    {
        static void Main()
        {
            Func<dynamic> state = MainMenuState;

            while (state != null)
                state = state.Invoke();

            Environment.Exit(0);
        }

        static Func<dynamic> MainMenuState()
        {
            Console.Clear();
            Console.WriteLine("Follow the instructions. Press any key to begin...");
            Console.ReadKey();

            return PlayState;
        }

        static Func<dynamic> PlayState()
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                Console.Clear();
                Console.WriteLine("Enter the number {0}.", i);

                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    i--;
                    continue;
                }

                if (input != i.ToString())
                    break;
            }

            return GameoverState;
        }

        static Func<dynamic> GameoverState()
        {
            Console.Clear();
            Console.WriteLine("Game Over. Play again? [Y/N]");

            var input = Console.ReadLine().ToLower();

            if (input == "y")
                return PlayState;

            if (input == "n")
                return null;

            return GameoverState;
        }
    }
}

// I have added a few things that i thought would be good. first i have it loading a random scripture from a list. I have 12 of them  in scriptures.txt. 
// second i added a function to select new  if the random scripture that it gives you isnt the one that you want. this new function will give you a new scripture 
// and it wont repeat the last one and it resets the hidden words function
// third it wont try to hide a word that is already hidden

using System;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            ScriptureLibrary library = new ScriptureLibrary("scriptures.txt");
            Scripture scripture = library.GetRandomScripture();
            scripture.Reset();

            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress Enter to hide words, type 'new' for a new scripture, or type 'quit' to exit.");
                string input = Console.ReadLine().ToLower();

                if (input == "quit")
                {
                    break;
                }
                else if (input == "new")
                {
                    scripture = library.GetRandomScripture();
                    scripture.Reset();
                    continue;
                }
                else if (string.IsNullOrWhiteSpace(input))
                {
                    scripture.HideRandomWords(3);

                    if (scripture.IsCompletelyHidden())
                    {
                        Console.Clear();
                        Console.WriteLine(scripture.GetDisplayText());
                        Console.WriteLine("\nAll words are hidden. Program ending.");
                        break;
                    }
                }
            }
        }
    }
}

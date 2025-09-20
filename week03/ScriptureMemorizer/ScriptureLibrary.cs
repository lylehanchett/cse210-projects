using System;
using System.Collections.Generic;
using System.IO;

namespace ScriptureMemorizer
{
    public class ScriptureLibrary
    {
        private List<Scripture> _scriptures;
        private Random _random;
        private Scripture _lastScripture;

        public ScriptureLibrary(string filePath)
        {
            _random = new Random();
            _scriptures = new List<Scripture>();
            _lastScripture = null;

            LoadScriptures(filePath);
        }

        private void LoadScriptures(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Error: File not found at {filePath}");
                return;
            }

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split('|');
                if (parts.Length < 4) continue;

                string book = parts[0];
                int chapter = int.Parse(parts[1]);

                string versePart = parts[2];
                int verse;
                int endVerse = -1;

                if (versePart.Contains("-"))
                {
                    string[] range = versePart.Split('-');
                    verse = int.Parse(range[0]);
                    endVerse = int.Parse(range[1]);
                }
                else
                {
                    verse = int.Parse(versePart);
                }

                string text = parts[3];

                Reference reference = endVerse > -1
                    ? new Reference(book, chapter, verse, endVerse)
                    : new Reference(book, chapter, verse);

                _scriptures.Add(new Scripture(reference, text));
            }
        }

        public Scripture GetRandomScripture()
        {
            if (_scriptures.Count == 0)
            {
                throw new Exception("No scriptures loaded.");
            }

            if (_scriptures.Count == 1)
            {
                _lastScripture = _scriptures[0];
                return _lastScripture;
            }

            Scripture newScripture;
            int attempts = 0;

            do
            {
                int index = _random.Next(_scriptures.Count);
                newScripture = _scriptures[index];
                attempts++;
            } while (newScripture == _lastScripture && attempts < 10);

            _lastScripture = newScripture;
            return newScripture;
        }
    }
}

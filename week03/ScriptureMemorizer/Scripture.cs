using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();

            string[] wordArray = text.Split(' ');
            foreach (string word in wordArray)
            {
                _words.Add(new Word(word));
            }
        }

        public void HideRandomWords(int numberToHide)
        {
            Random rand = new Random();

            List<Word> visibleWords = _words.FindAll(w => !w.IsHidden());

            int wordsToHide = Math.Min(numberToHide, visibleWords.Count);

            for (int i = 0; i < wordsToHide; i++)
            {
                int index = rand.Next(visibleWords.Count);
                visibleWords[index].Hide();

                visibleWords.RemoveAt(index);
            }
        }

        public string GetDisplayText()
        {
            List<string> displayWords = new List<string>();
            foreach (Word word in _words)
            {
                displayWords.Add(word.GetDisplayText());
            }

            return $"{_reference.GetDisplayText()}\n{string.Join(" ", displayWords)}";
        }

        public bool IsCompletelyHidden()
        {
            foreach (Word word in _words)
            {
                if (!word.IsHidden())
                {
                    return false;
                }
            }
            return true;
        }

        public void Reset()
        {
            foreach (Word word in _words)
            {
                word.Show();
            }
        }
    }
}

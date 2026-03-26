using System;
using System.Collections.Generic;
using System.Linq;

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
            
            // Split the text into words and create Word objects
            string[] wordArray = text.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in wordArray)
            {
                // Clean punctuation from the word for display, but preserve for hiding
                _words.Add(new Word(word));
            }
        }

        public void HideRandomWords(int numberToHide)
        {
            // Get all visible words
            List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();
            
            // If there are fewer visible words than we want to hide, hide all of them
            int wordsToHide = Math.Min(numberToHide, visibleWords.Count);
            
            // Randomly select words to hide
            Random random = new Random();
            for (int i = 0; i < wordsToHide; i++)
            {
                int index = random.Next(visibleWords.Count);
                visibleWords[index].Hide();
                visibleWords.RemoveAt(index); // Remove to avoid hiding the same word again in this iteration
            }
        }

        public bool IsCompletelyHidden()
        {
            return _words.All(w => w.IsHidden());
        }

        public string GetDisplayText()
        {
            string displayText = $"{_reference.GetDisplayText()}\n\n";
            
            foreach (Word word in _words)
            {
                displayText += word.GetDisplayText() + " ";
            }
            
            return displayText.Trim();
        }

        public int GetVisibleWordCount()
        {
            return _words.Count(w => !w.IsHidden());
        }
    }
}
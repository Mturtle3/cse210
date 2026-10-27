using System;
using System.Collections.Generic;

class Scripture
{
    private Reference _reference;
    private List<Word> _passage;

    public Scripture(Reference reference, List<Word> passage)
    {
        _reference = reference;
        _passage = passage;
    }

    public void Display()
    {
        _reference.Display();
        Console.WriteLine();

        foreach (Word word in _passage)
        {
            word.Display();
            Console.Write(" ");
        }

        Console.WriteLine();
    }

    public void HideWords(int num)
    {
        Random random = new Random();

        List<Word> visibleWords = new List<Word>();

        foreach (Word word in _passage)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }

        for (int i = 0; i < num && visibleWords.Count > 0; i++)
        {
            int index = random.Next(visibleWords.Count);

            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool AllWordsHidden()
    {
        foreach (Word word in _passage)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }
}
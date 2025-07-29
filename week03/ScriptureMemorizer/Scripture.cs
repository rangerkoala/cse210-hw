using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        foreach (string word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random rand = new Random();
        int hidden = 0;

        List<Word> visibleWords = _words.FindAll(w => !w.IsHidden());

        while (hidden < numberToHide && visibleWords.Count > 0)
        {
            int index = rand.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
            hidden++;
        }
    }

    public string GetDisplayText()
    {
        string verseText = "";
        foreach (Word word in _words)
        {
            verseText += word.GetDisplayText() + " ";
        }

        return _reference.GetDisplayText() + " - " + verseText.Trim();
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
                return false;
        }
        return true;
    }
}

public static class ScriptureLibrary
{
    public static Scripture GetRandomScripture()
    {
        List<(Reference, string)> scriptures = new List<(Reference, string)>()
        {
            // Old Testament
            (new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
            (new Reference("Genesis", 1, 26, 27), "And God said, Let us make man in our image, after our likeness... So God created man in his own image."),
            (new Reference("Isaiah", 1, 18), "ome now, and let us reason together, saith the Lord: though your sins be as scarlet, they shall be as white as snow; though they be red like crimson, they shall be as wool."),

            // New Testament
            (new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            (new Reference("Philippians", 4, 13), "I can do all things through Christ which strengtheneth me."),
            (new Reference("2 Timothy", 3, 16, 17), "All scripture is given by inspiration of God, and is profitable for doctrine, for reproof, for correction, for instruction in righteousness: That the man of God may be perfect, throughly furnished unto all good works."),

            // Book of Mormon
            (new Reference("2 Nephi", 2, 25), "Adam fell that men might be; and men are, that they might have joy."),
            (new Reference("Mosiah", 2, 17), "When ye are in the service of your fellow beings ye are only in the service of your God."),
            (new Reference("Ether", 12, 27), "And if men come unto me I will show unto them their weakness. I give unto men weakness that they may be humble; and my grace is sufficient for all men that humble themselves before me; for if they humble themselves before me, and have faith in me, then will I make weak things become strong unto them."),

            // Doctrine and Covenants
            (new Reference("D&C", 89, 18, 21), "And all saints who remember to keep and do these sayings, walking in obedience to the commandments, shall receive health in their navel and marrow to their bones; And shall find wisdom and great treasures of knowledge, even hidden treasures; And shall run and not be weary, and shall walk and not faint. And I, the Lord, give unto them a promise, that the destroying angel shall pass by them, as the children of Israel, and not slay them. Amen."),
            (new Reference("D&C", 18, 10), "Remember the worth of souls is great in the sight of God."),
            (new Reference("D&C", 58, 27), "Verily I say, men should be anxiously engaged in a good cause, and do many things of their own free will, and bring to pass much righteousness;")
        };

        Random rand = new Random();
        var selected = scriptures[rand.Next(scriptures.Count)];
        return new Scripture(selected.Item1, selected.Item2);
    }
}
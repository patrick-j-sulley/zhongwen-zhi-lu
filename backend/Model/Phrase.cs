using System;
using System.Collections.Generic;   

public class Phrase
{
    public int Id { get; set; }
    public int CategoryId { get; set; } // Foreign key to Category
    public int WeekId { get; set; } // Foreign key to Week
    public string Chinese { get; set; } // e.g., "你好"
    public string Pinyin { get; set; } // e.g., "nǐ hǎo"
    public string English { get; set; } // e.g., "Hello"

    public Phrase()
    {
        Chinese = string.Empty; // Initialize with a default value
        Pinyin = string.Empty; // Initialize with a default value
        English = string.Empty; // Initialize with a default value
    }
}
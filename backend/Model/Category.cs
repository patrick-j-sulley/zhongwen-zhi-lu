using System;
using System.Collections.Generic;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } // e.g., "Greetings", "Numbers", "Colors"
    public string Description { get; set; } // e.g., "Common phrases for greetings"

    public Category()
    {
        Name = string.Empty; // Initialize Name with a default value
        Description = string.Empty; // Initialize Description with a default value
    }
}
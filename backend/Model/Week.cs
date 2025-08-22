using System;
using System.Collections.Generic;

public class Week
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; } // Start date of the week
    public DateTime EndDate { get; set; } // End date of the week
    public string Notes { get; set; } // Name of the week, e.g., "Week 1"

    public Week()
    {
        StartDate = DateTime.MinValue; // Initialize with a default value
        EndDate = DateTime.MinValue; // Initialize with a default value
        Notes = string.Empty; // Initialize with a default value
    }
}
using System;
using System.Collections.Generic;

public static string Likes(List<string> names)
{
    // Handle different cases based on the number of names in the list
    switch (names.Count)
    {
        case 0:
            return "no one likes this";
        case 1:
            return $"{names[0]} likes this";
        case 2:
            return $"{names[0]} and {names[1]} like this";
        case 3:
            return $"{names[0]}, {names[1]} and {names[2]} like this";
        default:
            // For 4 or more names, show the first two and the count of others

            return $"{names[0]}, {names[1]} and {names.Count - 2} others like this";
    }
}
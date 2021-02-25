using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentorDataModel
{
    public string Name { get; private set; }

    public string Surname { get; private set; }

    public string FullName => Name + " " + Surname;

    public IEnumerable<StudentDataModel> Required { get; private set; }

    public IEnumerable<StudentDataModel> Excluded { get; private set; }

    /// <summary>
    /// Creates a MentorData from params.
    /// </summary>
    /// <param name="fullName">Name + " " + Surname is expected.</param>
    /// <param name="mark"></param>
    public MentorDataModel(string fullName, IEnumerable<StudentDataModel> required, IEnumerable<StudentDataModel> excluded)
    {
        var trimmedName = fullName.Trim();

        if (!trimmedName.Contains(" "))
            throw new ArgumentException("There isn't space symbol in the 'fullName' argument.", "fullName");

        var nameSurname = trimmedName.Split(' ');

        if (nameSurname.Length < 2)
            throw new FormatException("Please provide 'fullName' in the 'Name Surname' format.");

        Name = nameSurname[0];
        Surname = nameSurname[1];

        Required = required;
        Excluded = excluded;
    }
}

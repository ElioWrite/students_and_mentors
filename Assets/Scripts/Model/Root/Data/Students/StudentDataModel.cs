using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentDataModel
{
    public string Name { get; private set; }

    public string Surname { get; private set; }

    public string FullName => Name + " " + Surname;

    public float Mark { get; private set; }

    /// <summary>
    /// Creates a StudentData from params.
    /// </summary>
    /// <param name="fullName">Name + " " + Surname is expected.</param>
    /// <param name="mark"></param>
    public StudentDataModel(string fullName, float mark)
    {
        var trimmedName = fullName.Trim();

        if (!trimmedName.Contains(" "))
            throw new ArgumentException("There isn't space symbol in the 'fullName' argument.", "fullName");

        var nameSurname = trimmedName.Split(' ');

        if (nameSurname.Length < 2)
            throw new FormatException("Please provide 'fullName' in the 'Name Surname' format.");

        Name = nameSurname[0];
        Surname = nameSurname[1];

        Mark = mark;
    }

    /// <summary>
    /// Creates a StudentData from StudentJsonData.
    /// </summary>
    public StudentDataModel(StudentJsonDataModel jsonModel) : this(jsonModel.Name, jsonModel.Score) { }
}

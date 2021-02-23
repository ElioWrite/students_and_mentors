using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class StudentsDataModel : JsonDataModel
{
    public IEnumerable<StudentDataModel> FetchedData { get; private set; }

    public StudentDataModel FindByName(string fullName) =>
        FetchedData.FirstOrDefault(s => s.FullName == fullName);

    public override void FetchData()
    {
        if (FetchedData != null)
            ClearData();

        FetchedData = FetchDataFromJSON<StudentsJsonDataModel>(JsonPath)
            .Students.Select(s => new StudentDataModel(s));
    }

    public override void ClearData()
    {
        FetchedData = null;
    }
}


[System.Serializable]
public class StudentsJsonDataModel
{
    public StudentJsonDataModel[] Students;
}

[System.Serializable]
public class StudentJsonDataModel
{
    public string Name;
    public float Score;
}

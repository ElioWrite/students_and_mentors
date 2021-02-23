using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MentorsDataModel : JsonDataModel
{
    public IEnumerable<MentorDataModel> FetchedData { get; private set; }

    public override void FetchData()
    {
        if (FetchedData != null)
            ClearData();

        FetchedData = FetchDataFromJSON<MentorsJsonDataModel>(JsonPath)
            .Mentors.Select(s => new MentorDataModel(
                fullName: s.Name, 
                required: Root.Students.GetStudentModelsByNames(s.Required),
                excluded: Root.Students.GetStudentModelsByNames(s.Excluded)
                )
            );
    }

    public override void ClearData()
    {
        FetchedData = null;
    }
}

[System.Serializable]
public class MentorsJsonDataModel
{
    public MentorJsonDataModel[] Mentors;
}

[System.Serializable]
public class MentorJsonDataModel
{
    public string Name;
    public string[] Required;
    public string[] Excluded;
}

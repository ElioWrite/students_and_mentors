using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataModel : Model
{
    [SerializeField]
    private StudentsDataModel _studentsDataModel;
    public StudentsDataModel Students => _studentsDataModel;

    [SerializeField]
    private MentorsDataModel _mentorsDataModel;
    public MentorsDataModel Mentors => _mentorsDataModel;

    [SerializeField]
    private ResultDataModel _resultDataModel;
    public ResultDataModel Result => _resultDataModel;
}

public abstract class JsonDataModel : Model
{
    [SerializeField]
    private string _jsonPath;
    public string JsonPath => _jsonPath;

    public abstract void FetchData();
    public abstract void ClearData();

    public static T FetchDataFromJSON<T>(string path)
    {
        if (!File.Exists(path))
            throw new ArgumentNullException("path", string.Format("File wasn't found at path: {0}", path));

        var strContent = File.ReadAllText(path);

        return JsonUtility.FromJson<T>(strContent);
    }
}

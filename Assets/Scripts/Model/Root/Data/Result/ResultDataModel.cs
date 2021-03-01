using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class ResultDataModel : JsonDataModel
{
    public override void ClearData()
    {
        // TODO
    }

    public override void FetchData()
    {
        // TODO
    }

    public void WriteJsonResult(IEnumerable<MentorShuffleModel> shuffleModels)
    {
        WriteJsonResult(new ResultJsonDataModel(shuffleModels));
    }

    public void WriteJsonResult(ResultJsonDataModel data)
    {
        if (!File.Exists(JsonPath))
            throw new ArgumentNullException("path", string.Format("File wasn't found at path: {0}", JsonPath));

        File.WriteAllText(JsonPath, JsonUtility.ToJson(data, true));
    }
}

[System.Serializable]
public class ResultJsonDataModel
{
    public MentorShuffleJsonDataModel[] Shuffles;

    public ResultJsonDataModel(IEnumerable<MentorShuffleModel> shuffleModels)
    {
        Shuffles = shuffleModels.Select(s => s.ToJsonModel).ToArray();
    }
}

[System.Serializable]
public class MentorShuffleJsonDataModel
{
    public string Name;
    public string[] Students;
    public float AverageScore;
}

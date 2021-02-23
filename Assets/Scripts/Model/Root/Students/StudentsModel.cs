using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StudentsModel : Model
{
    public IEnumerable<StudentDataModel> GetStudentModelsByNames(IEnumerable<string> names) 
        => names.Select(n => Root.Data.Students.FindByName(n));
}

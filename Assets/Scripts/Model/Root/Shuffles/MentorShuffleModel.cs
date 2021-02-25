using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MentorShuffleModel
{
    public MentorDataModel Mentor { get; private set; }

    private List<StudentDataModel> _students;
    public IEnumerable<StudentDataModel> Students => _students;

    public MentorShuffleModel(MentorDataModel mentor)
    {
        Mentor = mentor;

        _students = new List<StudentDataModel>();
    }

    public void AddStudent(StudentDataModel student)
    {
        if (student is null)
            throw new ArgumentNullException("student", "Student cannot be null.");

        _students?.Add(student);
    }

    public void AddStudents(IEnumerable<StudentDataModel> students)
    {
        if (students is null || students.Contains(null))
            throw new ArgumentNullException("students", "Student cannot be null.");

        foreach (var item in students)
            _students?.Add(item);
    }

    public void RemoveStudent(StudentDataModel student)
    {
        if (student is null)
            throw new ArgumentNullException("student", "Student cannot be null.");

        _students?.Remove(student);
    }

    public void Clear()
    {
        _students = new List<StudentDataModel>();
    }

    public float AverageMark
    {
        get
        {
            if (_students == null || _students.Count() < 1)
                return 0;
            return _students.Average(s => s.Mark);
        }
        
    }

}

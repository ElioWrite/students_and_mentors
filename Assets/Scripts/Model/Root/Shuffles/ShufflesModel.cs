using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShufflesModel : Model
{
    private List<MentorShuffleModel> _shuffles;
    public IEnumerable<MentorShuffleModel> Shuffles => _shuffles;

    /// <summary>
    /// Initialize empty shuffle models from MentorData collection.
    /// </summary>
    public void InitializeShuffles(IEnumerable<MentorDataModel> mentors)
    {
        _shuffles = new List<MentorShuffleModel>();

        foreach (var mentor in mentors)
            _shuffles.Add(new MentorShuffleModel(mentor));
    }

    /// <summary>
    /// Shuffle with the lowest average score
    /// </summary>
    public MentorShuffleModel WeakestShuffle => _shuffles.OrderBy(s => s.AverageMark).FirstOrDefault();

    /// <summary>
    /// Shuffle with the lowest average score and haven't student in the rejected list
    /// WARNING: returns NULL if system cannot find the mentor who can accept this student
    /// </summary>
    public MentorShuffleModel WeakestShuffleAndStudentAccepted(StudentDataModel student)
    {
        var ordered = _shuffles.OrderBy(s => s.AverageMark);

        return ordered.FirstOrDefault(o => !o.Mentor.Excluded.Contains(student));
    }

    public void AddStudentsToShuffle(MentorDataModel mentorData, IEnumerable<StudentDataModel> studentsData)
    {
        var shuffle = GetShuffleByMentor(mentorData.FullName);

        shuffle.AddStudents(studentsData);
    }

    public void AddStudentToShuffle(MentorDataModel mentorData, StudentDataModel studentData) =>
        GetShuffleByMentor(mentorData.FullName).AddStudent(studentData);

    public MentorShuffleModel GetShuffleByMentor(MentorDataModel mentorData) 
        => Shuffles.FirstOrDefault(m => m.Mentor == mentorData);

    public MentorShuffleModel GetShuffleByMentor(string fullName)
        => Shuffles.FirstOrDefault(m => m.Mentor.FullName == fullName);

    public void ClearAll()
    {
        foreach (var item in Shuffles)
            item.Clear();
    }
}

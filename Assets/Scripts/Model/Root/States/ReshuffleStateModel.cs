using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ReshuffleStateModel : StateModel
{
    private List<StudentDataModel> _readyToShuffleStudents;
    public IEnumerable<StudentDataModel> ReadyToShuffleStudents => _readyToShuffleStudents;

    public override IEnumerator OnStateBeginning()
    {
        yield return base.OnStateBeginning();

        // randomly shuffle FetchedStudentsData via Guid.NewGuid()
        _readyToShuffleStudents = new List<StudentDataModel>(Root.Data.Students.FetchedData.OrderBy(a => Guid.NewGuid()));

        // randomly shuffle FetchedMentorsData via Guid.NewGuid()
        Root.Shuffle.InitializeShuffles(Root.Data.Mentors.FetchedData.OrderBy(a => Guid.NewGuid()));

        // assign recommended students to each mentor
        foreach (var item in Root.Data.Mentors.FetchedData)
            AddRequiredToShuffle(item);

        var iteration = _readyToShuffleStudents.Count;

        for (int i = 0; i < iteration; i++)
            AddToShuffle(Root.Shuffle.WeakestShuffleInSmallestTeam(HightscoredStudent), HightscoredStudent);


        //var count = 0;

        //foreach (var item in Root.Shuffle.Shuffles)
        //{
        //    Debug.Log(item.Mentor.FullName);
        //    Debug.Log(item.Students.Count());
        //    count += item.Students.Count();
        //    Debug.Log(item.AverageMark);

        //    foreach (var item2 in item.Students)
        //    {
        //        Debug.Log(item2.FullName);
        //    }
        //}

        //Debug.Log(count);

        yield return Root.States.GoToStateCoroutine(StateCode.Result);
    }

    public override IEnumerator OnStateEnding()
    {
        yield return base.OnStateEnding();
    }

    private StudentDataModel HightscoredStudent => _readyToShuffleStudents.OrderByDescending(s => s.Mark).FirstOrDefault();

    private void AddRequiredToShuffle(MentorDataModel mentor)
    {
        Root.Shuffle.AddStudentsToShuffle(mentor, mentor.Required);

        foreach (var req in mentor.Required)
            _readyToShuffleStudents.Remove(_readyToShuffleStudents.FirstOrDefault(r => r.FullName == req.FullName)); 
    }

    private void AddToShuffle(MentorShuffleModel shuffle, StudentDataModel student)
    {
        shuffle.AddStudent(student);

        _readyToShuffleStudents.Remove(_readyToShuffleStudents.FirstOrDefault(r => r.FullName == student.FullName));
    }
}

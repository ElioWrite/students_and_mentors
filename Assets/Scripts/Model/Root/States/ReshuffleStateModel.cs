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

        _readyToShuffleStudents = new List<StudentDataModel>(Root.Data.Students.FetchedData);

        Root.Shuffle.InitializeShuffles(Root.Data.Mentors.FetchedData);

        // assign recommended students to each mentor
        foreach (var item in Root.Data.Mentors.FetchedData)
            AddRequiredToShuffle(item);

        for(int i = 0; i < _readyToShuffleStudents.Count; i++)
            AddToShuffle(Root.Shuffle.WeakestShuffleAndStudentAccepted(HightscoredStudent), HightscoredStudent);

        foreach (var item in Root.Shuffle.Shuffles)
        {
            Debug.Log(item.Mentor.FullName);
            Debug.Log(item.Students.Count());

            foreach (var item2 in item.Students)
            {
                Debug.Log(item2.FullName);
            }
        }
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
            _readyToShuffleStudents.Remove(req); 
    }

    private void AddToShuffle(MentorShuffleModel shuffle, StudentDataModel student)
    {
        shuffle.AddStudent(student);

        _readyToShuffleStudents.Remove(student);
    }
}

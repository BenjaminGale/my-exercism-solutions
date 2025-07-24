using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private readonly Dictionary<int, List<string>> studentsByGrade = new();
    
    public void Add(string student, int grade)
    {
        if (studentsByGrade.ContainsKey(grade))
        {
            studentsByGrade[grade].Add(student);
        }
        else
        {
            var studentList = new List<string>() { student };
            studentsByGrade[grade] = studentList;
        }
    }

    public IEnumerable<string> Roster() =>
        studentsByGrade
            .OrderBy(kvp => kvp.Key)
            .SelectMany(kvp => kvp.Value.OrderBy(student => student));

    public IEnumerable<string> Grade(int grade) =>
        studentsByGrade.ContainsKey(grade) ?
            studentsByGrade[grade].OrderBy(student => student) :
            Enumerable.Empty<string>();
}
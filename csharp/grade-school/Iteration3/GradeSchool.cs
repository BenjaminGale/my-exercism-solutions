using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private readonly Dictionary<int, List<string>> studentsByGrade = new();
    
    public bool Add(string student, int grade)
    {
        if (studentsByGrade.SelectMany(kvp => kvp.Value).Contains(student))
            return false;
        
        studentsByGrade.TryAdd(grade, new List<string>());
        studentsByGrade[grade].Add(student);
        
        return true;
    }

    public IEnumerable<string> Roster() =>
        studentsByGrade
            .OrderBy(kvp => kvp.Key)
            .SelectMany(kvp => kvp.Value.OrderBy(student => student));

    public IEnumerable<string> Grade(int grade) =>
        studentsByGrade.ContainsKey(grade)
            ? studentsByGrade[grade].OrderBy(student => student)
            : Enumerable.Empty<string>();
}

import algorithm

type
  
  Student* = tuple [
    name: string,
    grade: int
  ]
  
  School* = object
    students*: seq[Student]

func compareStudents(a, b: Student): int =
  result = cmp(a.grade, b.grade)
  if result == 0:
    result = cmp(a.name, b.name)

func roster*(school: School): seq[string] =
  var s = school.students
  sort(s, compareStudents)

  for student in s:
    result.add(student.name)

func grade*(school: School, target: int): seq[string] =
  for student in school.students:
    if student.grade == target:
      result.add(student.name)
      sort(result, system.cmp[string])
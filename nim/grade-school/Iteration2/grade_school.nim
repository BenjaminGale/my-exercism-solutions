
import algorithm
import sequtils
import sugar

type
  
  Student = tuple
    name: string
    grade: int
  
  School* = object
    students*: seq[Student]

func cmp(a, b: Student): int =
  return cmp((a.grade, a.name), (b.grade, b.name))

func roster*(school: School): seq[string] =
  school
    .students
    .sorted(cmp)
    .map(s => s.name)

func grade*(school: School, target: int): seq[string] =
  school
    .students
    .filter(s => s.grade == target)
    .map(s => s.name)
    .sorted
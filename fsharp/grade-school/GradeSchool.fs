module GradeSchool

type School = Map<int, string list>

let empty: School =
    Map.empty

let roster (school: School): string list =
    school
    |> Map.toList
    |> List.sortBy (fun kvp -> fst kvp)
    |> List.collect (fun kvp -> snd kvp |> List.sort)

let grade (grade: int) (school: School): string list =
    let maybeStudents =
        school
        |> Map.tryFind grade

    match maybeStudents with
    | Some students -> students |> List.sort
    | None -> []

let add (student: string) (grade: int) (school: School): School =
    let studentEnrolled = 
        roster school
        |> List.contains student

    match studentEnrolled with
    | true -> school
    | false ->
        school
        |> Map.change grade (fun g ->
            match g with
            | Some students -> Some (student :: students |> List.distinct)
            | None -> Some [student]
        )

module HighScores

let scores (values: int list): int list =
    values

let rec latest (values: int list): int =
    values 
    |> List.rev
    |> List.head

let getTopThree (values: int list): int list =
    match values with
    | one :: two :: three :: rest -> [one; two; three]
    | _ -> values

let personalTopThree (values: int list): int list =
    values
    |> List.sortDescending
    |> getTopThree

let personalBest (values: int list): int =
    values
    |> personalTopThree
    |> List.head
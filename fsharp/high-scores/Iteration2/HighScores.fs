module HighScores

let scores (values: int list): int list =
    values

let rec latest (values: int list): int =
    values
    |> List.rev
    |> List.head

let personalTopThree (values: int list): int list =
    values
    |> List.sortDescending
    |> List.truncate 3

let personalBest (values: int list): int =
    values
    |> personalTopThree
    |> List.head
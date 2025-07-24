module Raindrops

let pling (number: int): string =
    if number % 3 = 0
    then "Pling"
    else ""

let plang (number: int): string =
    if number % 5 = 0
    then "Plang"
    else ""

let plong (number: int): string =
    if number % 7 = 0
    then "Plong"
    else ""

let convert (number: int): string =
    let result =
        [(pling number); (plang number); (plong number)]
        |> String.concat ""

    if System.String.IsNullOrWhiteSpace(result)
    then number.ToString()
    else result
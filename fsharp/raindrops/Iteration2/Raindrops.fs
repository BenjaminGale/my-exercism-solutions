module Raindrops

let convert (number: int): string =
    let raindrops = [(3, "Pling"); (5, "Plang"); (7, "Plong")]

    let result =
        raindrops
        |> List.map (fun (factor, sound) -> if number % factor = 0 then sound else "")
        |> String.concat ""

    match result with
    | "" -> string number
    | _ -> result
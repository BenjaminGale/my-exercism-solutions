module Raindrops

let convert (number: int): string =
    [(3, "Pling"); (5, "Plang"); (7, "Plong")]
    |> List.map (fun (factor, sound) -> if number % factor = 0 then sound else "")
    |> String.concat ""
    |> fun result -> if result = "" then string number else result

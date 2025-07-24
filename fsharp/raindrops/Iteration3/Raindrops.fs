module Raindrops

let convert (number: int): string =
    let result =
        [(3, "Pling"); (5, "Plang"); (7, "Plong")]
        |> List.map (fun (factor, sound) -> if number % factor = 0 then sound else "")
        |> String.concat ""

    match result with
    | "" -> string number
    | _ -> result
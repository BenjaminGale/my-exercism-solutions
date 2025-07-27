module Isogram

open System

let isIsogram (phrase: string): bool =
    List.ofSeq phrase
        |> List.filter Char.IsLetter
        |> List.map Char.ToLower
        |> List.countBy id
        |> List.forall (fun (_, count) -> count = 1)

module Pangram

let alphabet: char Set = Set.ofSeq { 'a' .. 'z' }

let isPangram (input: string): bool =
    input
    |> fun s -> s.ToLower()
    |> Set.ofSeq
    |> Set.isSubset alphabet
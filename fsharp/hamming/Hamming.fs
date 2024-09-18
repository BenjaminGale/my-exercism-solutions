module Hamming

let equalLengths (s1: string, s2: string): bool =
    s1.Length = s2.Length

let letterDistance (letter1: char, letter2: char): int =
    if letter1 <> letter2 then 1 else 0

let zipStrands (strand1: string, strand2: string) : int =
    Seq.zip strand1 strand2
    |> Seq.map letterDistance
    |> Seq.sum

let distance (strand1: string) (strand2: string): int option =
    Option.Some (strand1, strand2)
    |> Option.filter equalLengths
    |> Option.map zipStrands
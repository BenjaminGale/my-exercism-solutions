module Hamming

let letterDistance (letter1: char, letter2: char): int =
    if letter1 <> letter2 then 1 else 0

let zipStrands (strand1: string, strand2: string) : int =
    Seq.zip strand1 strand2
    |> Seq.map letterDistance
    |> Seq.sum

let distance (strand1: string) (strand2: string): int option =
    Option.Some (strand1, strand2)
    |> Option.filter (fun (l, r) -> l.Length = r.Length)
    |> Option.map zipStrands
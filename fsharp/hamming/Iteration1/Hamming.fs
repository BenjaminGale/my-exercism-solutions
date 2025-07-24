module Hamming

let compareLetters (letters: char * char): int =
    match letters with
    | (l, r) -> if l <> r then 1 else 0 

let compareStrands (strand1: string, strand2: string): int option =
    Seq.zip strand1 strand2
    |> Seq.map compareLetters
    |> Seq.sum
    |> Option.Some

let strandsSameLength (strand1: string, strand2: string): (string * string) option =
    Option.Some (strand1, strand2)
    |> Option.filter (fun (l, r) -> l.Length = r.Length)

let distance (strand1: string) (strand2: string): int option =
    strandsSameLength (strand1, strand2)
    |> Option.bind compareStrands
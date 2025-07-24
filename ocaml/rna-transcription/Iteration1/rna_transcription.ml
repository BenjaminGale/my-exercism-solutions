type dna = [ `A | `C | `G | `T ]
type rna = [ `A | `C | `G | `U ]

let to_rna dna =
  dna |> List.map (fun n ->
    match n with
    | `G -> `C
    | `C -> `G
    | `T -> `A
    | `A -> `U)

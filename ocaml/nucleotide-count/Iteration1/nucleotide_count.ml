open Base

let empty = Map.empty (module Char)

let valid_nucleotides = ['A'; 'C'; 'G'; 'T']

let is_valid_nucleotide c =
  List.mem valid_nucleotides c ~equal:Char.equal

let is_valid_dna_sequence dna =
  String.for_all dna ~f:is_valid_nucleotide

let can_count dna nucleotide =
  is_valid_dna_sequence dna && is_valid_nucleotide nucleotide

let count_nucleotide dna nucleotide =
  if can_count dna nucleotide then
    Ok (String.count dna ~f:(fun c -> Char.equal c nucleotide))
  else
    Error 'X'

let count_nucleotides dna =
  if is_valid_dna_sequence dna then
    let nucleotide_map = List.fold valid_nucleotides ~init:empty ~f:(fun map nucleotide ->
      match count_nucleotide dna nucleotide with
      | Ok count when count > 0 -> Map.set map ~key:nucleotide ~data:count
      | _ -> map
    ) in
    Ok nucleotide_map
  else
    Error 'X'

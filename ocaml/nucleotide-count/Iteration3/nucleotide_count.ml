open Base

let empty_map = Map.empty (module Char)
let all_nucleotides = ['A'; 'C'; 'G'; 'T']

let is_valid_nucleotide c =
  List.mem all_nucleotides c ~equal:Char.equal

let count_nucleotide dna n =
  match is_valid_nucleotide n with
  | false -> Error n
  | true ->
    dna |> String.fold_result ~init:0 ~f:(fun count ch ->
      match is_valid_nucleotide ch with
      | false -> Error ch
      | true when Char.equal ch n -> Ok (count + 1)
      | true -> Ok count)
      
let count_nucleotides dna =
  all_nucleotides
  |> List.map ~f:(fun n -> n, count_nucleotide dna n)
  |> List.fold_result ~init:empty_map ~f:(fun map result ->
      match result with
      | _, Error ch -> Error ch
      | k, Ok count when count > 0 -> Ok (Map.set map ~key:k ~data:count)
      | _ -> Ok map)

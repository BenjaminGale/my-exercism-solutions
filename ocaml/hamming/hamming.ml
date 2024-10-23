type nucleotide = A | C | G | T

let hamming_distance left right =
  match List.length left, List.length right with
  | 0, 0 -> Ok 0
  | 0, _ -> Error "left strand must not be empty"
  | _, 0 -> Error "right strand must not be empty"
  | l, r when l <> r -> Error "left and right strands must be of equal length"
  | _ ->
    List.combine left right
    |> List.map (fun (a, b) -> if a = b then 0 else 1)
    |> List.fold_left (fun acc a -> acc + a) 0
    |> Result.ok

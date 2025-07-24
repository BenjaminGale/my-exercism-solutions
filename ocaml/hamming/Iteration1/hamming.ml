type nucleotide = A | C | G | T

let hamming_distance left right =
  if List.length left = 0 && List.length right = 0 then
    Result.Ok 0
  else if List.length left = 0 then
    Result.error "left strand must not be empty"
  else if List.length right = 0 then
    Result.error "right strand must not be empty"
  else if List.length left <> List.length right then
    Result.error "left and right strands must be of equal length"
  else
    List.combine left right
    |> List.map (fun (a, b) -> if a = b then 0 else 1)
    |> List.fold_left (fun acc a -> acc + a) 0
    |> Result.ok

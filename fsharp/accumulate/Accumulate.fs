module Accumulate

let rec accumulate (func: 'a -> 'b) (input: 'a list): 'b list =
    match input with
    | a :: bs -> (func a) :: (accumulate func bs)
    | [] -> []

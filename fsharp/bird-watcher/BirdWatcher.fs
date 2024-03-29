module BirdWatcher

let lastWeek: int[] =
   [| 0; 2; 5; 3; 7; 8; 4 |]

let yesterday(counts: int[]): int =
  counts[5]

let total(counts: int[]): int =
  counts
  |> Array.sum

let dayWithoutBirds(counts: int[]): bool =
  counts
  |> Array.exists (fun c -> c = 0)

let incrementTodaysCount(counts: int[]): int[] =
  let count = Array.get counts 6
  
  counts
  |> Array.updateAt 6 (count + 1)

let unusualWeek(counts: int[]): bool =
  match counts with
  | [| _; 0; _; 0; _; 0; _; |]    -> true
  | [| _; 10; _; 10; _; 10; _; |] -> true
  | [| 5; _; 5; _; 5; _; 5; |]    -> true
  | _                             -> false

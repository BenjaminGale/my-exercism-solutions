module GuessingGame

let reply (guess: int): string =
    match guess with
    | n when n > 43 -> "Too high"
    | n when n = 41 || n = 43 -> "So close"
    | n when n < 41 -> "Too low"
    | _ -> "Correct"

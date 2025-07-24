module TwoFer

let createMessage (name: string): string =
    name |> sprintf "One for %s, one for me."

let twoFer (input: string option): string =
    input
    |> Option.defaultValue "you"
    |> createMessage
module TwoFer

let createMessage(name: string): string =
    "One for " + name + ", one for me."

let twoFer (input: string option): string =
    match input with
    | Some name -> createMessage(name)
    | None      -> createMessage("you")
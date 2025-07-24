module Yacht

type Category = 
    | Ones
    | Twos
    | Threes
    | Fours
    | Fives
    | Sixes
    | FullHouse
    | FourOfAKind
    | LittleStraight
    | BigStraight
    | Choice
    | Yacht

type Die =
    | One 
    | Two 
    | Three
    | Four 
    | Five 
    | Six

let dieScore die =
    match die with
    | One -> 1
    | Two -> 2
    | Three -> 3
    | Four -> 4
    | Five -> 5
    | Six -> 6

let sum dice target =
    dice
    |> List.map dieScore
    |> List.filter (fun score -> score = target)
    |> List.sum
    
let fullHouse dice =
    let groups = dice |> List.groupBy id
    
    let hasThreeOfAKind = groups |> List.exists (fun (_, group) -> group.Length = 3)
    let hasTwoOfAKind = groups |> List.exists (fun (_, group) -> group.Length = 2)

    if (hasThreeOfAKind && hasTwoOfAKind)
    then dice |> List.sumBy dieScore
    else 0

let fourOfAKind dice =
    dice
    |> List.groupBy id
    |> List.filter (fun (_, group) -> group.Length >= 4)
    |> List.map snd
    |> List.collect id
    |> List.truncate 4
    |> List.sumBy dieScore

let littleStraight dice =
    let orderedDice =
        dice
        |> List.sortBy dieScore

    match orderedDice with
    | [One; Two; Three; Four; Five] -> 30
    | _ -> 0

let bigStraight dice =
    let orderedDice =
        dice
        |> List.sortBy dieScore

    match orderedDice with
    | [Two; Three; Four; Five; Six] -> 30
    | _ -> 0

let choice dice =
    dice
    |> List.map dieScore
    |> List.sum

let yacht dice =
    let isFiveOfAKind =
        dice
        |> List.groupBy id
        |> List.exists (fun (_, group) -> group.Length = 5)

    if isFiveOfAKind then 50 else 0
    
let score category dice =
    match category with
    | Ones -> sum dice 1
    | Twos -> sum dice 2
    | Threes -> sum dice 3
    | Fours -> sum dice 4
    | Fives -> sum dice 5
    | Sixes -> sum dice 6
    | FullHouse -> fullHouse dice
    | FourOfAKind -> fourOfAKind dice
    | LittleStraight -> littleStraight dice
    | BigStraight -> bigStraight dice
    | Choice -> choice dice
    | Yacht -> yacht dice

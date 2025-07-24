module QueenAttack

let isInRange number min max =
    number >= min && number <= max

let isOnBoard number =
    isInRange number 0 7

let create (position: int * int) =
    let x = fst position
    let y = snd position

    isOnBoard x && isOnBoard y

let canAttack (queen1: int * int) (queen2: int * int) =
    let isOnSameRow = fst queen1 = fst queen2
    let isOnSameColumn = snd queen1 = snd queen2
    let isOnSlope = abs (fst queen1 - fst queen2) = abs (snd queen1 - snd queen2)

    isOnSameRow || isOnSameColumn || isOnSlope
    
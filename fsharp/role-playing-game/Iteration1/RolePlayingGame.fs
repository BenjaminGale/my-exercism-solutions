module RolePlayingGame

open System

type Player = { 
    Name: Option<string>
    Level: int
    Health: int
    Mana: Option<int>
}

let introduce (player: Player): string = 
    match player.Name with
    | Some name -> name
    | None -> "Mighty Magician"

let withFullHealth (player: Player): Player =
    { player with Health = 100 }

let withRevivedMana (player: Player): Player =
    { player with Mana = if player.Level >= 10 then (Some 100) else None}

let revive (player: Player): Option<Player> = 
    (Some player)
    |> Option.filter (fun p -> p.Health = 0)
    |> Option.map (withFullHealth >> withRevivedMana)

let castSpell (manaCost: int) (player: Player): Player * int =
    
    let hasEnoughMana =
        player.Mana
        |> Option.filter (fun m -> m >= manaCost)
        |> Option.isSome
        
    let damageMultiplier =
        if hasEnoughMana
        then 2
        else 0

    let newMana =
        player.Mana
        |> Option.map (fun m ->
            if hasEnoughMana
            then (m - manaCost)
            else m
        )

    let newHealth =
        if player.Mana |> Option.isNone
        then Math.Max(player.Health - manaCost, 0)
        else player.Health

    ({ player with Mana = newMana; Health = newHealth }, damageMultiplier * manaCost)

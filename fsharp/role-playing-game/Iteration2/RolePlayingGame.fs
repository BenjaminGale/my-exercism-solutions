module RolePlayingGame

open System

type Player = { 
    Name: Option<string>
    Level: int
    Health: int
    Mana: Option<int>
}

let introduce (player: Player): string =
    player.Name |> Option.defaultValue "Mighty Magician"

let revive (player: Player): Option<Player> =
    if player.Health > 0 then None
    elif player.Level >= 10 then Some { player with Health = 100; Mana = Some 100 }
    else Some { player with Health = 100 }

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

module RolePlayingGame

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
    match player.Mana with
    | None -> { player with Health = max 0 (player.Health - manaCost) }, 0
    | Some mana when mana >= manaCost -> { player with Mana = Some(mana - manaCost) }, 2 * manaCost
    | Some mana -> player, 0

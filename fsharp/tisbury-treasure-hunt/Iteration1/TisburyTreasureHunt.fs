module TisburyTreasureHunt

let getCoordinate (line: string * string): string =
    snd line

let convertCoordinate (coordinate: string): int * char = 
    (int(string coordinate[0]), coordinate[1])

let compareRecords (azarasData: string * string) (ruisData: string * (int * char) * string) : bool = 
    let azarasCoord = convertCoordinate (snd azarasData)
    let (_, ruisCoord, _) = ruisData
    azarasCoord = ruisCoord

let createRecord (azarasData: string * string) (ruisData: string * (int * char) * string) : (string * string * string * string) =
    match compareRecords azarasData ruisData with
    | true ->
        match (azarasData, ruisData) with
        | ((treasure, coordinate), (location, _, quadrant)) -> (coordinate, location, quadrant, treasure)
    | false -> ("", "", "", "")

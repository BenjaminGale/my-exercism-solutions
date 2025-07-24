module CarsAssemble

let carsPerHour = 221

let productionRatePerHour (speed: int): float =
    let basicOutput = float(speed * carsPerHour)

    if (speed >= 1 && speed <= 4) then
        basicOutput
    elif (speed >= 5 && speed <= 8) then
        basicOutput * 0.9
    elif (speed = 9) then
        basicOutput * 0.8
    else
        basicOutput * 0.77

let workingItemsPerMinute(speed: int): int =
    int((productionRatePerHour speed) / 60.0)
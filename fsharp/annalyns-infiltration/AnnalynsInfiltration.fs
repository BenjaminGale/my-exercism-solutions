module AnnalynsInfiltration

let canFastAttack (knightIsAwake: bool): bool =
    not knightIsAwake

let canSpy(knightIsAwake: bool) (archerIsAwake: bool)(prisonerIsAwake: bool): bool =
  knightIsAwake || archerIsAwake || prisonerIsAwake

let canSignalPrisoner(archerIsAwake: bool) (prisonerIsAwake: bool): bool =
    prisonerIsAwake && not archerIsAwake

let canFreePrisoner(knightIsAwake: bool) (archerIsAwake: bool)(prisonerIsAwake: bool)(petDogIsPresent: bool): bool =
    (prisonerIsAwake && not knightIsAwake && not archerIsAwake) ||
    (petDogIsPresent && not archerIsAwake)

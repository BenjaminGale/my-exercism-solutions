
import strutils

type

  Allergies* = object
    score*: int

  Allergen = enum
    eggs
    peanuts
    shellfish
    strawberries
    tomatoes
    chocolate
    pollen
    cats

  AllergenFlags = set[Allergen]

proc toFlags(score: int): AllergenFlags = 
  cast[AllergenFlags](score)

proc isAllergicTo*(allergies: Allergies, allergenInput: string): bool =
  let allergen: Allergen = parseEnum[Allergen](allergenInput)
  allergies.score.toFlags().contains(allergen)

proc lst*(allergies: Allergies): seq[string] =
  for alergen in allergies.score.toFlags():
    result.add($alergen)

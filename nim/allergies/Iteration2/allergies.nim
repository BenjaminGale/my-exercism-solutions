
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

proc flags(allergies: Allergies): AllergenFlags = 
  cast[AllergenFlags](allergies.score)

proc isAllergicTo*(allergies: Allergies, allergenInput: string): bool =
  let allergen: Allergen = parseEnum[Allergen](allergenInput)
  allergies.flags().contains(allergen)

proc lst*(allergies: Allergies): seq[string] =
  for allergen in allergies.flags():
    result.add($allergen)

proc convert*(n: int): string =
  var sound = ""

  if n mod 3 == 0:
    sound &= "Pling"
  if n mod 5 == 0:
    sound &= "Plang"
  if n mod 7 == 0:
    sound &= "Plong"

  if sound == "":
    return $n
  else:
    return sound

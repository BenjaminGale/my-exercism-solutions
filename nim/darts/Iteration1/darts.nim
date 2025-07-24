import std/math
  
proc distanceFromCentre(x, y: float): float =
  sqrt(pow(x, 2.0) + pow(y, 2.0))
  
proc score*(x, y: float): int =
  let dist = distanceFromCentre(x, y);

  if (dist >= 0.0 and dist <= 1.0):
    return 10
  elif (dist >= 1.0 and dist <= 5.0):
    return 5
  elif (dist >= 5.0 and dist <= 10.0):
    return 1
  else:
    return 0

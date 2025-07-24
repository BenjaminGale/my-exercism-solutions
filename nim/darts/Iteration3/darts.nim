import std/math
  
proc distanceFromCentre(x, y: float): float =
  hypot(x, y)
  
proc score*(x, y: float): int =
  let dist = distanceFromCentre(x, y);

  if dist <= 1.0:  return 10
  if dist <= 5.0:  return 5
  if dist <= 10.0: return 1
  
  return 0

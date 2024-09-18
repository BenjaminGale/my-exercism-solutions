
func sum*(target: int, factors: openArray[int]): int =
  for number in 1..target-1:
    for factor in factors:
      if factor == 0: continue
      if (number mod factor) == 0:
        result += number
        break


proc distance*(left: string, right: string): int =
  if left.len != right.len:
    raise newException(ValueError, "DNA sequence lengths must be equal")
  
  for i in 0..<left.len:
    if left[i] != right[i]:
      result += 1
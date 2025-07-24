import std/math
  
proc onSquare*(n: int): uint64 =
  if n <= 0 or n > 64:
    raise newException(ValueError, "")

  pow(2.0, (n - 1).float()).uint64()

proc total*: uint64 =
  for i in 1..64:
    result += i.onSquare()

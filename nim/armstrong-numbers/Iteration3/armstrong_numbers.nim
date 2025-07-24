import math
  
proc isArmstrongNumber*(number: int): bool =
  var digits: seq[int]
  var current = number

  while current != 0:
    digits.add(current mod 10)
    current = current div 10

  var target: int

  for digit in digits:
    target += digit ^ digits.len

  number == target
    
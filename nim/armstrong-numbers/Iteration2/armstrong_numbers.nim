import math
  
proc isArmstrongNumber*(number: int): bool =
  var digits: seq[int]
  var numberOfDigits: int
  var current = number

  while current != 0:
    digits.add(current mod 10)
    numberOfDigits += 1
    current = current div 10

  var total: int

  for digit in digits:
    total += digit ^ numberOfDigits

  number == total
    
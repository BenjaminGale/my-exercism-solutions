import math
  
proc isArmstrongNumber*(number: int): bool =
  var digits: seq[int]
  var count: int
  var current = number

  while current != 0:
    digits.add(current mod 10)
    current = current div 10
    count = count + 1

  var total: int

  for digit in digits:
    total = total + digit ^ count

  number == total
    
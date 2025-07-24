import math
import sequtils
  
proc isArmstrongNumber*(number: int): bool =
  var digits: seq[int]
  var current = number

  while current != 0:
    digits.add(current mod 10)
    current = current div 10

  number == digits.mapIt(it ^ digits.len).sum()
    
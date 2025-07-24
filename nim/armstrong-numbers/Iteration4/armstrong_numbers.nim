import math
import sequtils
import sugar
  
proc isArmstrongNumber*(number: int): bool =
  var digits: seq[int]
  var current = number

  while current != 0:
    digits.add(current mod 10)
    current = current div 10

  number == digits.map(digit => digit ^ digits.len).foldl(a + b, 0)
    
import math
  
type
  ResistorColor * = enum
    Black
    Brown
    Red
    Orange
    Yellow
    Green
    Blue
    Violet
    Grey
    White

proc label*(colors: openArray[ResistorColor]): (int, string) =
  let startValue = (colors[0].ord * 10) + colors[1].ord
  let exponent:float = colors[2].ord.float
  let actualValue = startValue * pow(10f, exponent).int

  if actualValue > 1000:
    (int(actualValue / 1000), "kiloohms")
  else:
    (actualValue, "ohms")
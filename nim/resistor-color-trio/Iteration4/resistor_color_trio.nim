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
  let (band1, band2, band3) = (colors[0].ord, colors[1].ord, colors[2].ord)
  let value = ((band1 * 10) + band2) * 10 ^ band3

  if value > 1000000000:
    (value div 1000000000, "gigaohms")
  elif value > 1000000:
    (value div 1000000, "megaohms")
  elif value > 1000:
    (value div 1000, "kiloohms")
  else:
    (value, "ohms")
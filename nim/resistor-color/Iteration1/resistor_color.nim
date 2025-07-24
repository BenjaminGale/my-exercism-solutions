import sequtils
  
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
  
proc colorCode*(resistorColor: ResistorColor): int =
  ord(resistorColor)

proc colors*(): seq[ResistorColor] =
  toSeq(low(ResistorColor)..high(ResistorColor))
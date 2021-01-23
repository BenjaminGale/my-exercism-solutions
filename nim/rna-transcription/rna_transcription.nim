
proc toRna(c: char): char =
  case c:
    of 'G': 'C'
    of 'C': 'G'
    of 'T': 'A'
    of 'A': 'U'
    else: raise newException(ValueError, "invalid nucleotide")

proc toRna*(str: string): string =
  for c in str:
    result.add(c.toRna())
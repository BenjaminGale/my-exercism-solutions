import std/math
import std/random

randomize()

proc privateKey*(p: int): int =
  rand(2..p-1)

proc publicKey*(p, g, a: int): int =
  int(pow(float(g), float(a)) mod float(p))

proc secret*(p, bPub, a: int): int =
  int(pow(float(bPub), float(a)) mod float(p))

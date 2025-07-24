
import strutils
import unicode

let
  allowedChars: set[char] = { 'a'..'z' }

proc lowerLetters(str: string): set[char] =
  for c in str.toLower():
    if c in allowedChars:
      result.incl(c)

proc isPangram*(input: string): bool =
  input.lowerLetters() == allowedChars
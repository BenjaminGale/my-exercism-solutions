
import strutils
import unicode

var
  lowercaseLetters: set[char] = { 'a'..'z' }
  invalidChars: set[char] = { '.', ' ', '\"' , '_', '0'..'9' }

proc charSet(str: string): set[char] =
  for c in str:
    result.incl(c)

proc isPangram*(input: string): bool =
  let uniqueChars = input.toLower().charSet() - invalidChars
  result = uniqueChars == lowercaseLetters
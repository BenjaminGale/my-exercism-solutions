
import strutils

proc replaceHyphens(input: string): string =
  input.replace(" - ", " ").replace("-", " ")

proc removeUnderscores(input: string): string =
  input.replace("_", "")

proc normalise(input: string): string =
  input.replaceHyphens.removeUnderscores

proc abbreviate*(input: string): string =
  for word in input.normalise.split:
    result.add(word[0].toUpperAscii)

import strutils except strip
import unicode
import sequtils
import sugar

func isSilent(input: string): bool =
  input.isEmptyOrWhitespace

func isShouting(input: string): bool =
  input.toRunes.any(c => c.isAlpha) and
  input.toRunes.filter(c => c.isAlpha).all(c => c.isUpper)

func isQuestion(input: string): bool =
  input.runeAt(input.len - 1) == Rune('?')

func isShoutedQuestion(input: string): bool =
  input.isShouting and input.isQuestion

func hey*(input: string): string =
  let input = input.strip(leading = true, trailing = true)

  if input.isSilent:
    return "Fine. Be that way!"
  elif input.isShoutedQuestion:
    return "Calm down, I know what I'm doing!"
  elif input.isQuestion:
    return "Sure."
  elif input.isShouting:
    return "Whoa, chill out!"
  else:
    return "Whatever."
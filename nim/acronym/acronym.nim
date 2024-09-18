
import strutils
import unicode

const
  separators = { ' ', '-', '_' }

func abbreviate*(input: string): string =
  for word, isSeparator in input.tokenize(separators):
    if not isSeparator:
      result.add(word.runeAt(0).toUpper)
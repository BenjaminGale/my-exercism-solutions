
import unicode
import strutils

const
  invalidChars: set[char] = { '-', ' ' }

func stripInvalidChars(input: string): string =
  for c in input:
    if c notin invalidChars:
      result.add(c)

func toSet[T](input: openArray[T]): set[T] =
  for v in input:
    result.incl(v)

func isIsogram*(input: string): bool =
  let normalisedInput = input.stripInvalidChars.toLower
  normalisedInput.len == normalisedInput.toSet.len
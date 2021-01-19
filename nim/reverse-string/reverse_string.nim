
import unicode

iterator reverseRunes(input: string): Rune =
  let runes = input.toRunes()
  for i in countdown(runes.len, 1):
    yield runes[i - 1]

func reverse*(input: string): string =
  for rune in input.reverseRunes:
    result.add(rune)
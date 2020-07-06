
import strutils
import unicode

const
  englishAlphabet* = "abcdefghijklmnopqrstuvwxyz"
  swedishAlphabet* = "abcdefghijklmnopqrstuvwxyzåäö"

func toSet*[T](input: openArray[T]): set[T] =
  for v in input:
    result.incl v

func isPangram*(input: string, alphabet = englishAlphabet): bool =
  input.toLowerAscii.toSet >= alphabet.toSet
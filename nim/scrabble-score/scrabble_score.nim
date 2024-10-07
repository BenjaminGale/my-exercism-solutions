import std/strutils

const
  lettersThatScoreOne   = { 'a', 'e', 'i', 'o', 'u', 'l', 'n', 'r', 's', 't' }
  lettersThatScoreTwo   = { 'd', 'g' }
  lettersThatScoreThree = { 'b', 'c', 'm', 'p' }
  lettersThatScoreFour  = { 'f', 'h', 'v', 'w', 'y' }
  lettersThatScoreFive  = { 'k' }
  lettersThatScoreEight = { 'j', 'x' }
  lettersThatScoreTen   = { 'q', 'z' }
  
proc score*(word: string): int =
  for character in word:
    let increment = case character.toLowerAscii:
      of lettersThatScoreOne:   1
      of lettersThatScoreTwo:   2
      of lettersThatScoreThree: 3
      of lettersThatScoreFour:  4
      of lettersThatScoreFive:  5
      of lettersThatScoreEight: 8
      of lettersThatScoreTen:   10
      else: 0

    result += increment

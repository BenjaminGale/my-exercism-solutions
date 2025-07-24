import std/strutils
import std/sequtils
import std/algorithm

proc normalise(word: string): seq[char] =
  word.toLowerAscii().toSeq().sorted()
  
proc detectAnagrams*(word: string, candidates: openArray[string]): seq[string] =
  for candidate in candidates:
    if word.len != candidate.len: continue
    if cmpIgnoreCase(word, candidate) == 0: continue

    let sortedWord = normalise(word)

    if sortedWord == normalise(candidate):
      result.add(candidate)
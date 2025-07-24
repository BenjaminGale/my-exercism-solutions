import std/strutils
import std/sequtils
import std/algorithm

proc normalise(word: string): seq[char] =
  word.toLowerAscii().toSeq().sorted()
  
proc detectAnagrams*(word: string, candidates: openArray[string]): seq[string] =
  for candidate in candidates:
    if cmpIgnoreCase(word, candidate) != 0 and word.len == candidate.len:
      if normalise(word) == normalise(candidate):
        result.add(candidate)
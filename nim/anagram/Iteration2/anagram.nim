import std/strutils
import std/sequtils
import std/algorithm
  
proc detectAnagrams*(word: string, candidates: openArray[string]): seq[string] =
  for candidate in candidates:
    if cmpIgnoreCase(word, candidate) != 0 and word.len == candidate.len:
      let wordSet = word.toLowerAscii().toSeq().sorted()
      let candidateSet = candidate.toLowerAscii().toSeq().sorted()
      
      if wordSet == candidateSet:
        result.add(candidate)
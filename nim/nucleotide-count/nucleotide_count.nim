import std/tables
import std/setutils

const
  nucleotides = { 'A', 'C', 'G', 'T' }
  
proc countDna*(dnaSequence: string): CountTable[char] =
  if dnaSequence.toSet > nucleotides:
    raise newException(ValueError, "Sequence contains invalid nucleotides")

  return toCountTable(dnaSequence)

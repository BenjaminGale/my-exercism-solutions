
import strutils

var
  lowercaseLetters: set[char] = {'a'..'z'}
  invalidChars: set[char] = AllChars - lowercaseLetters

proc isPangram*(input: string): bool =
  #[
    I am getting the following compiler error here:
    
      proc removePrefix(s: var string; chars: set[char] = Newlines)
        first type mismatch at position: 1
        required type for s: var string
        but expression 'toLowerAscii(input)' is immutable, not 'var'

    According to the documentation for procedures, arguments are immutable
    by default. The documentation says that to get around this you need to
    create a mutable variable (and that it can have the same name as the 
    argument) however I cannot get this to work.

    I've also tried the following:

    1. Making the argument a var string.
    2. Assigning the input argument to avar string with a different name.

    I'm not sure how to resolve this so any guidance would be appreciated.
  ]#
  var input = input.toLowerAscii.removePrefix(invalidChars)
  not input.isEmptyOrWhitespace and input.allCharsInSet(lowercaseLetters)
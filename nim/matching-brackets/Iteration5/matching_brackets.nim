
const
  openBrackets = { '[', '{', '(' }
  closeBrackets = { ']', '}', ')' }

proc isPaired*(input: string): bool =
  var pairedBrackets: seq[char]

  for c in input:
    case c:
      of openBrackets:
        pairedBrackets.add(c)
      of closeBrackets:

        let target = case c:
          of ']': '['
          of '}': '{'
          of ')': '('
          else: continue

        if pairedBrackets.len > 0 and pairedBrackets[^1] == target:
          discard pairedBrackets.pop()
        else:
          return false
      else: continue
      
  pairedBrackets.len == 0
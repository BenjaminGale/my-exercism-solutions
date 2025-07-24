
const
  openBrackets = ['[', '{', '(']
  
proc isPaired*(input: string): bool =
  var pairedBrackets: seq[char]

  for c in input:
    if c in openBrackets:
      pairedBrackets.add(c)
      continue

    let target = case c:
      of ']': '['
      of '}': '{'
      of ')': '('
      else: c

    if target notin openBrackets:
      continue

    if pairedBrackets.len > 0 and pairedBrackets[^1] == target:
      discard pairedBrackets.pop()
      continue
    else:
      return false
      
  pairedBrackets.len == 0
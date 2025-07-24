
const
  openBrackets = ['[', '{', '(']
  
proc isPaired*(input: string): bool =
  var brackets: seq[char]

  for c in input.items:
    if c in openBrackets:
      brackets.add(c)
      continue

    let target = case c:
      of ']': '['
      of '}': '{'
      of ')': '('
      else: c

    if target notin openBrackets:
      continue

    if brackets.len > 0 and brackets[^1] == target:
      discard brackets.pop()
      continue
    else:
      return false
      
  brackets.len == 0
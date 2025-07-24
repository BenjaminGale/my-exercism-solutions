
func reverse*(input: string): string =
  let length  = input.len
  result = newString(length)

  for i in countup(1, length):
    result[i - 1] = input[length - i]
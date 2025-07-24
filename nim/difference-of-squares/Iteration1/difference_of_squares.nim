
proc sumOfSquares*(number: int): int =
  int((number * (number + 1) * ((2 * number) + 1)) / 6)

proc squareOfSum*(number: int): int =
  let sum = (number * (number + 1)) / 2
  int(sum * sum)

proc difference*(number: int): int =
  squareOfSum(number) - sumOfSquares(number);
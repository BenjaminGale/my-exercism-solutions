proc steps*(n: int): int =
  if (n <= 0):
    raise newException(ValueError, "Number cannot be negative or zero")

  var number = n

  while number > 1:
    if number mod 2 == 0:
      number = int(number / 2)
    else:
      number = (number * 3) + 1

    inc(result)
proc steps*(startValue: int): int =
  if (startValue <= 0):
    raise newException(ValueError, "Number cannot be negative or zero")

  var value = startValue

  while value > 1:
    if value mod 2 == 0: value = int(value / 2)
    else: value = (value * 3) + 1

    inc(result)
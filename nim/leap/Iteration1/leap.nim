
import math

func isDivisibleBy(date: Natural, denominator: Natural): bool =
  (date mod denominator) == 0

func isLeapYear*(date: Natural): bool =
  isDivisibleBy(date, 4) and not isDivisibleBy(date, 100) or isDivisibleBy(date, 400)
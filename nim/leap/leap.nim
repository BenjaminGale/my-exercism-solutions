
import math

func isDivisibleBy(date: Natural, denominator: Natural): bool =
  (date mod denominator) == 0

func isLeapYear*(date: Natural): bool =
  date.isDivisibleBy(4) and not date.isDivisibleBy(100) or date.isDivisibleBy(400)
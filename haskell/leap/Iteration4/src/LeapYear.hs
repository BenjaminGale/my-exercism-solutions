module LeapYear (isLeapYear) where

isLeapYear :: Integer -> Bool
isLeapYear year = isDivisibleBy 4 && not (isDivisibleBy 100) || isDivisibleBy 400
  where
    isDivisibleBy :: Integer -> Bool
    isDivisibleBy divider = year `mod` divider == 0

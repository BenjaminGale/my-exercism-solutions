module LeapYear (isLeapYear) where

-- on every year that is evenly divisible by 4
--   except every year that is evenly divisible by 100
--     unless the year is also evenly divisible by 400

isLeapYear :: Integer -> Bool
isLeapYear year = isDivisibleBy 4 year && not (isDivisibleBy 100 year) || isDivisibleBy 400 year
  where
    isDivisibleBy :: Integer -> Integer -> Bool
    isDivisibleBy divider num = num `mod` divider == 0
module CollatzConjecture (collatz) where

collatz :: Integer -> Maybe Integer
collatz n
  | n <= 0    = Nothing
  | n == 1    = Just 0
  | isEven n  = (+1) <$> collatz (n `div` 2)
  | otherwise = (+1) <$> collatz (3 * n + 1)
  where
    isEven n = n `mod` 2 == 0

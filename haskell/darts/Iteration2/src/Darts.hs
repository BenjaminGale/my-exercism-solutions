module Darts (score) where

score :: Float -> Float -> Int
score x y
  | distance > 10 = 0
  | distance > 5 = 1
  | distance > 1 = 5
  | distance >= 0 = 10
  where
    distance = sqrt ((x ^ 2) + (y ^ 2))

module Darts (score) where

dist :: Float -> Float -> Float
dist x y = sqrt ((x ^ 2) + (y ^ 2))

score :: Float -> Float -> Int
score x y
  | d > 10 = 0
  | d > 5 = 1
  | d > 1 = 5
  | d >= 0 = 10
  where
    d = dist x y

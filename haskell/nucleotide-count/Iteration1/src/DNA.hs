module DNA (nucleotideCounts, Nucleotide(..)) where

import Data.Map (Map, fromListWith)

data Nucleotide = A | C | G | T deriving (Eq, Ord, Show)

fromChar :: Char -> Either String Nucleotide
fromChar c =
  case c of
    'A' -> Right A
    'C' -> Right C
    'G' -> Right G
    'T' -> Right T
    _   -> Left "Invalid nucleotide"

buildFrequencyMap :: (Ord k) => [k] -> Map k Int
buildFrequencyMap xs = fromListWith (+) [(x, 1) | x <- xs]

nucleotideCounts :: String -> Either String (Map Nucleotide Int)
nucleotideCounts = fmap buildFrequencyMap . traverse fromChar

module DNA (nucleotideCounts, Nucleotide(..)) where

import qualified Data.Map as Map

data Nucleotide = A | C | G | T deriving (Eq, Ord, Show)

nucleotideMap :: Map.Map Char Nucleotide
nucleotideMap = Map.fromList [('A', A), ('C', C), ('G', G), ('T', T)]

fromChar :: Char -> Either String Nucleotide
fromChar c =
  case Map.lookup c nucleotideMap of
    Just n  -> Right n
    Nothing -> Left "Invalid nucleotide"

buildFrequencyMap :: (Ord k) => [k] -> Map.Map k Int
buildFrequencyMap xs = Map.fromListWith (+) [(x, 1) | x <- xs]

nucleotideCounts :: String -> Either String (Map.Map Nucleotide Int)
nucleotideCounts = fmap buildFrequencyMap . traverse fromChar

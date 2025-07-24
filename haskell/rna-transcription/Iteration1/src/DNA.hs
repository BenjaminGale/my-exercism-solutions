module DNA (toRNA) where

import Data.Either

toRNA :: String -> Either Char String
toRNA xs = 
  let results = partitionEithers $ fmap mapNucleotide xs
  in case results of
    ([], rna) -> Right rna
    ((a:as), _) -> Left a

mapNucleotide :: Char -> Either Char Char
mapNucleotide n
  | n == 'G' = Right 'C'
  | n == 'C' = Right 'G'
  | n == 'T' = Right 'A'
  | n == 'A' = Right 'U'
  | otherwise = Left n

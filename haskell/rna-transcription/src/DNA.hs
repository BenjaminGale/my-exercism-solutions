module DNA (toRNA) where

toRNA :: String -> Either Char String
toRNA = traverse mapNucleotide
  where
    mapNucleotide :: Char -> Either Char Char
    mapNucleotide n =
      case n of
        'G' -> Right 'C'
        'C' -> Right 'G'
        'T' -> Right 'A'
        'A' -> Right 'U'
        _   -> Left n

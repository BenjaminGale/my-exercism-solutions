module Pangram (isPangram) where

import Data.Char
import qualified Data.Set as Set

isPangram :: String -> Bool
isPangram text = Set.isSubsetOf alphabetCharacters sentence
    where
        sentence           = Set.fromList (map toLower text)
        alphabetCharacters = Set.fromList ['a'..'z']
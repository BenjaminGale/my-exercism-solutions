module Pangram (isPangram) where

import Data.Char
import qualified Data.Set as Set

isPangram :: String -> Bool
isPangram text = allAlphabetCharacters `containedIn` sentence
    where
        sentence              = Set.fromList (map toLower text)
        allAlphabetCharacters = Set.fromList ['a'..'z']
        containedIn           = Set.isSubsetOf
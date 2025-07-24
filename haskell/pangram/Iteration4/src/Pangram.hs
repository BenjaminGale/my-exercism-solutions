module Pangram (isPangram) where

import Data.Char
import qualified Data.Set as Set

isPangram :: String -> Bool
isPangram text = allAlphabetCharacters `memberOf` sentence
    where
        sentence              = Set.fromList (map toLower text)
        allAlphabetCharacters = Set.fromList ['a'..'z']
        memberOf              = Set.isSubsetOf
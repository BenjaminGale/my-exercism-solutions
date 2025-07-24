module Pangram (isPangram) where

import Data.Char
import qualified Data.Set as Set

isPangram :: String -> Bool
isPangram text = sortedChars == checksum
    where
        allowedChars = filter isAllowedChar text
        distinctChars   = Set.fromList allowedChars
        lowercaseChars  = Set.map toLower distinctChars
        sortedChars     = Set.toAscList lowercaseChars

checksum :: String
checksum = ['a'..'z']

isAllowedChar :: Char -> Bool
isAllowedChar c = isAlpha c && isAscii c
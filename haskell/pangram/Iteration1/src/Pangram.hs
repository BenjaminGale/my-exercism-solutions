module Pangram (isPangram) where

import Data.Char
import Data.List

-- Iteration 1:
-- isPangram :: String -> Bool
-- isPangram text = sortedChars == checksum
--     where
--         allChars       = filter allowedChar text
--         distinctChars  = nub allChars
--         lowercaseChars = map toLower distinctChars
--         sortedChars    = sort lowercaseChars

-- Iteration 2
isPangram :: String -> Bool
isPangram text = sort (map toLower (nub (filter allowedChar text))) == checksum

checksum :: String
checksum = "abcdefghijklmnopqrstuvwxyz"

allowedChar :: Char -> Bool
allowedChar c = isAlpha c && isAscii c
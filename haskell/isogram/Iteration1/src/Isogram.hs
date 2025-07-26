module Isogram (isIsogram) where

import Data.Char
import Data.List
import Data.Map (Map)
import qualified Data.Map as Map

isIsogram :: String -> Bool
isIsogram input = all (== 1) (Map.elems letterCounts)
  where
    cleanedInput = filter isLetter (map toLower input)
    updateCount counts c = Map.insertWith (+) c 1 counts
    letterCounts = foldl updateCount Map.empty cleanedInput

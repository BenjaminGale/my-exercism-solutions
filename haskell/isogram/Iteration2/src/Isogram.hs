module Isogram (isIsogram) where

import Data.Char
import Data.List

import Data.Map (Map)
import qualified Data.Map as Map

import qualified Data.Text as T
import           Data.Text (Text)

isIsogram :: Text -> Bool
isIsogram input = all (== 1) (Map.elems letterCounts)
  where
    cleanedInput = T.filter isLetter (T.toLower input)
    updateCount counts c = Map.insertWith (+) c 1 counts
    letterCounts = T.foldl updateCount Map.empty cleanedInput

module Bob (responseFor) where

import Data.Char
import Data.List

responseFor :: String -> String
responseFor phrase
  | isSilence phrase          = "Fine. Be that way!"
  | isShoutingQuestion phrase = "Calm down, I know what I'm doing!"
  | isQuestion phrase         = "Sure."
  | isShouting phrase         = "Whoa, chill out!"
  | otherwise                 = "Whatever."

isShoutingQuestion :: String -> Bool
isShoutingQuestion = (&&) <$> isShouting <*> isQuestion

isQuestion :: String -> Bool
isQuestion = (== '?') . last . dropWhileEnd isSpace

isShouting :: String -> Bool
isShouting = (&&) <$> any isUpper <*> (all isUpper . filter isAlpha)

isSilence :: String -> Bool
isSilence = (||) <$> null <*> all isSpace

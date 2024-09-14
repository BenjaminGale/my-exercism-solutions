module ReverseString (reverseString) where

reverseString :: String -> String
reverseString cs = rev cs []
  where
    rev :: String -> String -> String
    rev [] acc     = acc
    rev (c:cs) acc = rev cs (c:acc)

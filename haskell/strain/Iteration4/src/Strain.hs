module Strain (keep, discard) where

discard :: (a -> Bool) -> [a] -> [a]
discard f = keep (not . f)

keep :: (a -> Bool) -> [a] -> [a]
keep _ []     = []
keep p (a:as)
    | p a       = a : rest
    | otherwise = rest
    where
        rest = keep p as

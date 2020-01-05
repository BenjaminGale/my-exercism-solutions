module Strain (keep, discard) where

discard :: (a -> Bool) -> [a] -> [a]
discard _ []     = []
discard p (a:as)
    | p a       = rest
    | otherwise = a : rest
    where
        rest = discard p as

keep :: (a -> Bool) -> [a] -> [a]
keep _ []     = []
keep p (a:as)
    | p a       = a : rest
    | otherwise = rest
    where
        rest = keep p as
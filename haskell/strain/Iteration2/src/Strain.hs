module Strain (keep, discard) where

discard :: (a -> Bool) -> [a] -> [a]
discard _ []     = []
discard p (a:as)
    | p a       = discard p as
    | otherwise = a : discard p as

keep :: (a -> Bool) -> [a] -> [a]
keep _ []     = []
keep p (a:as)
    | p a       = a : keep p as
    | otherwise = keep p as
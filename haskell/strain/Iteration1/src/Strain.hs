module Strain (keep, discard) where

discard :: (a -> Bool) -> [a] -> [a]
discard _ []     = []
discard p (a:as) =
    if p a
    then discard p as
    else a : discard p as

keep :: (a -> Bool) -> [a] -> [a]
keep _ []     = []
keep p (a:as) =
    if p a
    then a : keep p as
    else keep p as
module LinkedList
    ( LinkedList
    , datum
    , fromList
    , isNil
    , new
    , next
    , nil
    , reverseLinkedList
    , toList
    ) where

data LinkedList a 
    = Empty 
    | Element a (LinkedList a)
    deriving (Eq, Show)

datum :: LinkedList a -> a
datum Empty         = error "empty linked list"
datum (Element a _) = a 

fromList :: [a] -> LinkedList a
fromList = foldr Element Empty

isNil :: LinkedList a -> Bool
isNil Empty = True
isNil _     = False

new :: a -> LinkedList a -> LinkedList a
new = Element

next :: LinkedList a -> LinkedList a
next Empty           = error "grgerger"
next (Element _ lst) = lst

nil :: LinkedList a
nil = Empty

reverseLinkedList :: LinkedList a -> LinkedList a
reverseLinkedList = fromList . reverse . toList

toList :: LinkedList a -> [a]
toList Empty                    = []
toList (Element a lst) = a : toList lst
module Robot
  ( Bearing(East,North,South,West)
  , bearing
  , coordinates
  , mkRobot
  , move
  ) where

data Bearing
  = North
  | East
  | South
  | West
  deriving (Eq, Show, Enum, Bounded)

data Robot = Robot Bearing (Integer, Integer)

bearing :: Robot -> Bearing
bearing (Robot dir _) = dir

coordinates :: Robot -> (Integer, Integer)
coordinates (Robot _  coords) = coords

mkRobot :: Bearing -> (Integer, Integer) -> Robot
mkRobot dir coords = Robot dir coords

move :: Robot -> String -> Robot
move robot []     = robot
move robot (i:is)
  | i == 'R' = move (turnRight robot) is
  | i == 'L' = move (turnLeft robot) is
  | i == 'A' = move (advance robot) is

turnRight :: Robot -> Robot
turnRight (Robot dir coords)
  | dir == maxBound = Robot minBound coords
  | otherwise       = Robot (succ dir) coords

turnLeft :: Robot -> Robot
turnLeft (Robot dir coords)
  | dir == minBound = Robot maxBound coords
  | otherwise       = Robot (pred dir) coords

advance :: Robot -> Robot
advance (Robot dir (x, y))
  | dir == North = Robot dir (x, succ y)
  | dir == South = Robot dir (x, pred y)
  | dir == East  = Robot dir (succ x, y)
  | dir == West  = Robot dir (pred x, y)

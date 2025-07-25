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
mkRobot = Robot

move :: Robot -> String -> Robot
move = foldl step
  where
    step :: Robot -> Char -> Robot
    step robot 'R' = turnRight robot
    step robot 'L' = turnLeft robot
    step robot 'A' = advance robot
    step robot _   = robot

turnRight :: Robot -> Robot
turnRight (Robot dir coords)
  | dir == maxBound = Robot minBound coords
  | otherwise       = Robot (succ dir) coords

turnLeft :: Robot -> Robot
turnLeft (Robot dir coords)
  | dir == minBound = Robot maxBound coords
  | otherwise       = Robot (pred dir) coords

advance :: Robot -> Robot
advance (Robot dir (x, y)) = Robot dir $
  case dir of
    North -> (x    , y + 1)
    South -> (x    , y - 1)
    East  -> (x + 1, y    )
    West  -> (x - 1, y    )

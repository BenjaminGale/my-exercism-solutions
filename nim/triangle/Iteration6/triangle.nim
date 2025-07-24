import sequtils
  
type
  Triangle = array[3, int]

proc side(triangle: Triangle, index: int): int = triangle[index - 1]

proc allSidesPositive(triangle: Triangle): bool =
  all(triangle, proc (side: int): bool = side > 0)

proc allLengthsValid(triangle: Triangle): bool =
  triangle.side(1) + triangle.side(2) >= triangle.side(3) and
  triangle.side(1) + triangle.side(3) >= triangle.side(2) and
  triangle.side(2) + triangle.side(3) >= triangle.side(1)

proc isValid(triangle: Triangle): bool =
  triangle.allSidesPositive and triangle.allLengthsValid

proc isEquilateral*(triangle: Triangle): bool =
  triangle.isValid and
  triangle.side(1) == triangle.side(2) and
  triangle.side(1) == triangle.side(3) and
  triangle.side(2) == triangle.side(3)

proc isIsosceles*(triangle: Triangle): bool =
  triangle.isValid and (
    triangle.side(1) == triangle.side(2) or
    triangle.side(1) == triangle.side(3) or
    triangle.side(2) == triangle.side(3)
  )

proc isScalene*(triangle: Triangle): bool =
  triangle.isValid and
  triangle.side(1) != triangle.side(2) and
  triangle.side(1) != triangle.side(3) and
  triangle.side(2) != triangle.side(3)
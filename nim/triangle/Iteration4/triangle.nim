import sequtils
  
type
  Triangle = array[3, int]

proc side1(triangle: Triangle): int = triangle[0]
proc side2(triangle: Triangle): int = triangle[1]
proc side3(triangle: Triangle): int = triangle[2]

proc allSidesPositive(triangle: Triangle): bool =
  all(triangle, proc (side: int): bool = side > 0)

proc allLengthsValid(triangle: Triangle): bool =
  triangle.side1 + triangle.side2 >= triangle.side3 and
  triangle.side1 + triangle.side3 >= triangle.side2 and
  triangle.side2 + triangle.side3 >= triangle.side1

proc isEquilateral*(triangle: Triangle): bool =
  triangle.allSidesPositive and 
  triangle.allLengthsValid and 
  triangle.side1 == triangle.side2 and
  triangle.side1 == triangle.side3 and
  triangle.side2 == triangle.side3

proc isIsosceles*(triangle: Triangle): bool =
  triangle.allSidesPositive and 
  triangle.allLengthsValid and (
    triangle.side1 == triangle.side2 or
    triangle.side1 == triangle.side3 or
    triangle.side2 == triangle.side3
  )

proc isScalene*(triangle: Triangle): bool =
  triangle.allSidesPositive and 
  triangle.allLengthsValid and
  triangle.side1 != triangle.side2 and
  triangle.side1 != triangle.side3 and
  triangle.side2 != triangle.side3
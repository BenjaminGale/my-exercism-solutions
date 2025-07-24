
type
  Triangle = object
    side1: int
    side2: int
    side3: int

proc toTriangle(input: array[3, int]): Triangle =
  Triangle(side1: input[0], side2: input[1], side3: input[2])

proc allSidesPositive(triangle: Triangle): bool =
  triangle.side1 > 0 and triangle.side2 > 0 and triangle.side3 > 0

proc allLengthsValid(triangle: Triangle): bool =
  triangle.side1 + triangle.side2 >= triangle.side3 and
  triangle.side1 + triangle.side3 >= triangle.side2 and
  triangle.side2 + triangle.side3 >= triangle.side1

proc isEquilateral(triangle: Triangle): bool =
  triangle.allSidesPositive and 
  triangle.allLengthsValid and 
  triangle.side1 == triangle.side2 and
  triangle.side1 == triangle.side3 and
  triangle.side2 == triangle.side3

proc isEquilateral*(input: array[3, int]): bool =
  isEquilateral(input.toTriangle())

proc isIsosceles(triangle: Triangle): bool =
  triangle.allSidesPositive and 
  triangle.allLengthsValid and (
    triangle.side1 == triangle.side2 or
    triangle.side1 == triangle.side3 or
    triangle.side2 == triangle.side3
  )

proc isIsosceles*(input: array[3, int]): bool =
  isIsosceles(input.toTriangle())

proc isScalene(triangle: Triangle): bool =
  triangle.allSidesPositive and 
  triangle.allLengthsValid and
  triangle.side1 != triangle.side2 and
  triangle.side1 != triangle.side3 and
  triangle.side2 != triangle.side3

proc isScalene*(input: array[3, int]): bool =
  isScalene(input.toTriangle())
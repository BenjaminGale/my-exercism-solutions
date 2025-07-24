
proc allSidesNonZero(triangle: array[3, int]): bool =
  triangle[0] > 0 and triangle[1] > 0 and triangle[2] > 0 

proc allLengthsValid(triangle: array[3, int]): bool =
  let side1 = triangle[0]
  let side2 = triangle[1]
  let side3 = triangle[2]

  side1 + side2 >= side3 and side1 + side3 >= side2 and side2 + side3 >= side1

proc isValidTriangle(triangle: array[3, int]): bool =
  allSidesNonZero(triangle) and allLengthsValid(triangle)

proc isEquilateral*(triangle: array[3, int]): bool =
  let side1 = triangle[0]
  let side2 = triangle[1]
  let side3 = triangle[2]

  isValidTriangle(triangle) and side1 == side2 and side1 == side3 and side2 == side3

proc isIsosceles*(triangle: array[3, int]): bool =
  let side1 = triangle[0]
  let side2 = triangle[1]
  let side3 = triangle[2]

  isValidTriangle(triangle) and (side1 == side2 or side1 == side3 or side2 == side3)

proc isScalene*(triangle: array[3, int]): bool =
  let side1 = triangle[0]
  let side2 = triangle[1]
  let side3 = triangle[2]

  isValidTriangle(triangle) and side1 != side2 and side1 != side3 and side2 != side3
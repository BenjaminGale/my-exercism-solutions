proc binarySearch*(a: openArray[int], val: int): int =
  var startIndex = 0
  var endIndex = a.len - 1

  while startIndex <= endIndex:
    let mid = (startIndex + endIndex) div 2

    if a[mid] == val: return mid
    elif val > mid: startIndex = mid + 1
    else: endIndex = mid - 1

  -1

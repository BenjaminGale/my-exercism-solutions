
export const reverseString = (input) => {
  if (input === '') return input
  
  const reversed = [input.length]
  
  for (var i = 0; i < input.length; i++) {
    const reversedIndex = input.length - 1 - i
    reversed[reversedIndex] = input[i]
  }

  return reversed.join('')
};


export const decodedValue = (input) => {
  return (COLORS.indexOf(input[0]) * 10) + COLORS.indexOf(input[1])
};

const COLORS = ['black', 'brown', 'red', 'orange', 'yellow', 'green', 'blue', 'violet', 'grey', 'white']


export function decodedResistorValue(colors: string[]): string {
  const resistorValue = decodedValue(colors);

  var value = resistorValue;
  var numZeros = 0;

  while (resistorValue > 0 && value % 10 == 0) {
    value /= 10;
    numZeros++;
  }
  
  switch (numZeros) {
    case 9: return `${resistorValue/1000000000} gigaohms`;
    case 6: return `${resistorValue/1000000} megaohms`;
    case 3:
    case 4:
      return `${resistorValue/1000} kiloohms`;
    default:
      return `${resistorValue} ohms`;
  }
}

function decodedValue(colors: string[]) {
  const value = colors
    .slice(0, 2)
    .reverse()
    .map((color, index) => COLORS.indexOf(color) * Math.pow(10, index))
    .reduce((accumulated, current) => accumulated + current, 0);

  const numZeros = COLORS.indexOf(colors[2]);

  return Math.pow(10, numZeros) * value;
}

export const COLORS = [
  'black',
  'brown',
  'red',
  'orange',
  'yellow',
  'green',
  'blue',
  'violet',
  'grey',
  'white'
]

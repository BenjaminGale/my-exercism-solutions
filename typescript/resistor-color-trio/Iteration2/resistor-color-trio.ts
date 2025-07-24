
export function decodedResistorValue(colors: string[]): string {
  const resistorValue = decodedValue(colors);

  if (resistorValue > 1000000000) {
    return `${resistorValue/1000000000} gigaohms`;
  }
  else if (resistorValue > 1000000) {
    return `${resistorValue/1000000} megaohms`;
  }
  else if (resistorValue > 1000) {
    return `${resistorValue/1000} kiloohms`;
  }
  else {
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

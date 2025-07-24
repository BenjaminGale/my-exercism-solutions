export function decodedValue(colors: string[]) {
  return colors
    .slice(0, 2)
    .reverse()
    .map((color, index) => COLORS.indexOf(color) * Math.pow(10, index))
    .reduce((accumulated, current) => accumulated + current, 0);
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

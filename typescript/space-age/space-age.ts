export function age(planet: string, seconds: number): number {
  const age = seconds / (orbitalPeriod(planet) * EarthYearInSeconds)
  return Math.round(age * 100) / 100;
}

function orbitalPeriod(planet: string): number {
  switch (planet) {
    case 'mercury':
      return 0.2408467;
    case 'venus':
      return 0.61519726;
    case 'earth':
      return 1;
    case 'mars':
      return 1.8808158;
    case 'jupiter':
      return 11.862615;
    case 'saturn':
      return 29.447498;
    case 'uranus':
      return 84.016846;
    case 'neptune':
      return 164.79132;
    default:
      return 1;
  }
}

const EarthYearInSeconds = 31557600
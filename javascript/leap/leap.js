
export const isLeap = (year) => {
  return isDivisibleBy(year, 4) && (!isDivisibleBy(year, 100) || isDivisibleBy(year, 400))
};

function isDivisibleBy(year, divisor) {
    return (year % divisor) === 0;
}
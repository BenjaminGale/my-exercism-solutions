
const GIGASECOND_IN_MS = Math.pow(10, 9);

export const gigasecond = (date) => {
  var result = new Date(date.getTime());
  result.setUTCSeconds(result.getUTCSeconds() + GIGASECOND_IN_MS);

  return result;
};

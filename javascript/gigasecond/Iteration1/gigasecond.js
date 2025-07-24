
export const gigasecond = (date) => {
  var result = new Date(date.getTime());
  result.setUTCSeconds(result.getUTCSeconds() + 1_000_000_000);

  return result;
};

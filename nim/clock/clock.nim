import std/strformat

const MinutesPerDay: int = 24 * 60;

type
  Clock* = object
    hour*: range[0..23]
    minute*: range[0..59]

  Minutes* = distinct int

proc initClock*(hour, minute: int): Clock =
  var totalMinutes = (hour * 60) + minute
  totalMinutes = (totalMinutes mod (MinutesPerDay) + (MinutesPerDay)) mod (MinutesPerDay);

  Clock(hour: (totalMinutes / 60).int, minute: totalMinutes mod 60)

proc `$`*(c: Clock): string =
  fmt"{c.hour:02}:{c.minute:02}"

proc `+`*(c: Clock, v: Minutes): Clock =
  initClock(c.hour, c.minute + v.int)

proc `-`*(c: Clock, v: Minutes): Clock =
  initClock(c.hour, c.minute - v.int)

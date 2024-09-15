use time::PrimitiveDateTime as DateTime;
use time::Duration;
use std::ops::Add;

const ONE_GIGA_SECOND: i64 = 1_000_000_000;

pub fn after(start: DateTime) -> DateTime {
    start.add(Duration::seconds(ONE_GIGA_SECOND))
}

use time::PrimitiveDateTime as DateTime;
use time::Duration;
use std::ops::Add;

pub fn after(start: DateTime) -> DateTime {
    return start.add(Duration::seconds(1000000000));
}

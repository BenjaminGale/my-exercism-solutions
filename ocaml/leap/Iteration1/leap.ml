
let is_divisible_by year factor =
    year mod factor = 0

let leap_year year = 
    (is_divisible_by year 4) && not (is_divisible_by year 100) || (is_divisible_by year 400)
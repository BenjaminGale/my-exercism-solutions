
pub fn collatz(n: u64) -> Option<u64> {
    if n == 0 { return None };
    
    let mut val = n;
    let mut steps = 0;
    
    while val > 1 {
        if val % 2 == 0 {
            val /= 2;
        } else {
            val = (val * 3) + 1;
        }
        
        steps += 1;
    }

    Some(steps)
}

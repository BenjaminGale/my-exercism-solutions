
pub fn find(array: &[i32], key: i32) -> Option<usize> {
    if array.is_empty() { return None };
    
    let mut start = 0;
    let mut end = array.len() - 1;

    while start <= end {
        let mid = (start + end) / 2;

        if array[mid] == key {
            return Some(mid);
        }

        if mid == 0 {
            return None;
        }

        if key > array[mid] {
            start = mid + 1;
        } else {
            end = mid - 1;
        }
    }
    
    None
}

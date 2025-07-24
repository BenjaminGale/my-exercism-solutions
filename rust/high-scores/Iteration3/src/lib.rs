
// See https://doc.rust-lang.org/book/ch10-03-lifetime-syntax.html for an explanation of
// generic lifetime annotations - in short, the 'a in the struct definition tells the rust
// compiler that any instances of HighScores can't live longer than the slice that it borrows.

#[derive(Debug)]
pub struct HighScores<'a> {
    scores: &'a[u32]
}

impl<'a> HighScores<'a> {
    pub fn new(scores: &'a[u32]) -> Self {
        Self { scores }
    }

    pub fn scores(&self) -> &'a[u32] {
        self.scores
    }

    pub fn latest(&self) -> Option<u32> {
        self.scores.last().copied()
    }

    pub fn personal_best(&self) -> Option<u32> {
        self.scores.iter().max().copied()
    }

    pub fn personal_top_three(&self) -> Vec<u32> {
        let mut results = self.scores.to_vec();
        results.sort_by(|a, b| b.cmp(a));
        results.truncate(3);

        results
    }
}

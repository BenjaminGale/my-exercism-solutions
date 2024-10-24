#[derive(Debug)]
pub struct ChessPosition {
    rank: i32,
    file: i32
}

#[derive(Debug)]
pub struct Queen {
    position: ChessPosition
}

impl ChessPosition {
    
    pub fn new(rank: i32, file: i32) -> Option<Self> {
        if (0..=7).contains(&rank) && (0..=7).contains(&file) {
            return Some(ChessPosition { rank, file })
        }
        
        None
    }
}

impl Queen {
    
    pub fn new(position: ChessPosition) -> Self {
        Queen { position }
    }

    pub fn can_attack(&self, other: &Queen) -> bool {
        self.position.rank == other.position.rank ||
        self.position.file == other.position.file ||
        (self.position.rank - other.position.rank).abs() == (self.position.file - other.position.file).abs()
    }
}

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
        if rank < 0 || rank > 7 { return None }
        if file < 0 || file > 7 { return None }
        
        Some(ChessPosition { rank: rank, file: file })
    }
}

impl Queen {
    pub fn new(position: ChessPosition) -> Self {
        Queen { position: position }
    }

    pub fn can_attack(&self, other: &Queen) -> bool {
        if self.position.rank == other.position.rank { return true }
        if self.position.file == other.position.file { return true }

        (self.position.rank - other.position.rank).abs() == (self.position.file - other.position.file).abs()
    }
}

USING: kernel sequences math math.order math.statistics ;
IN: librarians-ledger

: protected-balance ( opening requests -- balance )
    swap [ + 0 max ] reduce ;

: running-balance ( transactions -- balances )
    cum-sum ;

: least-balance-so-far ( transactions -- worsts )
    running-balance cum-min ;

: halve-until ( principal target -- balances )
    swap [ 2dup < ] [ 2 /i dup ] produce 2nip ;

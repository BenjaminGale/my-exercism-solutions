USING: kernel math combinators ;
IN: joiners-journey

: kerf-amount ( length -- kerf-amount )
    1/50 * ;

: with-kerf ( length -- length+kerf )
    [ kerf-amount ] keep + ;

: kerf-and-finish ( length -- kerf finish )
    [ kerf-amount ] [ 1/20 * ] bi ;

: cut-card ( length -- length kerf finish )
    { [ ] [ kerf-and-finish ] } cleave ;

: per-piece ( bolt-length pieces -- per-piece )
    [ with-kerf ] dip / ;

: compare-bolts ( length-a length-b -- kerf-a kerf-b )
    [ kerf-amount ] bi@ ;

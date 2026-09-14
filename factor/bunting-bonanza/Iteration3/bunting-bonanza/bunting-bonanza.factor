USING: kernel sequences math strings ranges ;
IN: bunting-bonanza

: make-bunting ( range quote -- string )
    map >string ; inline

: alphabet-bunting ( n -- str )
    <iota> [ CHAR: a + ] make-bunting ;

: counting-bunting ( n -- str )
    <iota> [ 10 mod CHAR: 0 + ] make-bunting ;

: stripe-bunting ( n -- str )
    <iota> [ even? [ CHAR: * ] [ CHAR: - ] if ] make-bunting ;

: marker-bunting ( n -- str )
    <iota> [ 5 mod zero? [ CHAR: | ] [ CHAR: . ] if ] make-bunting ;

: valley-bunting ( -- str )
    -5 5 [a..b) [ abs CHAR: 0 + ] make-bunting ;

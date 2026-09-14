USING: kernel sequences math strings ranges ;
IN: bunting-bonanza

: make-bunting ( n quote -- string )
    swap <iota> swap map >string ; inline

: alphabet-bunting ( n -- str )
    [ CHAR: a + ] make-bunting ;

: counting-bunting ( n -- str )
    [ 10 mod CHAR: 0 + ] make-bunting ;

: stripe-bunting ( n -- str )
    [ even? [ CHAR: * ] [ CHAR: - ] if ] make-bunting ;

: marker-bunting ( n -- str )
    [ 5 mod zero? [ CHAR: | ] [ CHAR: . ] if ] make-bunting ;

: valley-bunting ( -- str )
    -5 5 [a..b) [ abs CHAR: 0 + ] map >string ;

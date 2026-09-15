USING: kernel math.functions ;
IN: leap

: leap-year? ( year -- ? )
    [ 400 divisor? ] [ 4 divisor? ] [ 100 divisor? ]  tri
    not and or
    ;
    

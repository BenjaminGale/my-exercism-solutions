USING: kernel ;
USING: math ;
USING: math.order ;
IN: currency-conversion

: exchange-money ( budget exchange-rate -- exchanged )
    / ;

: get-change ( budget exchanging-value -- change )
    - ;

: value-of-bills ( denomination number-of-bills -- value )
    * ;

: number-of-bills ( amount denomination -- bills )
    /i ;

: leftover-of-bills ( amount denomination -- leftover )
    mod ;

: spread-amount ( spread exchange-rate -- spread-amount )
    100 /f * ;

: effective-rate ( spread exchange-rate -- effective-rate )
    tuck spread-amount + ;

: exchangeable-value ( denomination budget spread exchange-rate -- value )
    effective-rate
    exchange-money
    over number-of-bills
    value-of-bills ;

: safe-change ( budget exchanging-value -- change )
    get-change 0 max ;

: cap-spend ( budget price -- spend )
    min ;

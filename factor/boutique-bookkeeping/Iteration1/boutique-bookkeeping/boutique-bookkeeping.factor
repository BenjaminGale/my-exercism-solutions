USING: kernel sorting sequences math math.parser formatting ;
IN: boutique-bookkeeping

: sort-by-price ( inventory -- sorted )
    [ second ] sort-by ;

: with-missing-price ( inventory -- filtered )
    [ second ] reject ;

: expensive-items ( inventory threshold -- count )
    [ swap second < ] curry count ;

: cheapest-item ( inventory -- item )
    [ second ] minimum-by ;

: total-price ( inventory -- sum )
    [ second ] map-sum ;

: format-price-tag ( item -- str )
    "%s: $%d" vsprintf ;

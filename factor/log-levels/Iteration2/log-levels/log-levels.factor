USING: kernel splitting sequences ascii ;
IN: log-levels

: message ( log-line -- message )
    ": " split1 nip [ blank? ] trim ;

: log-level ( log-line -- level )
    "[]" split harvest first >lower ;

: format-log-level ( log-level -- formatted )
    log-level "(" ")" surround ;

: reformat ( log-line -- formatted )
    [ message ] [ format-log-level ] bi " " glue ;

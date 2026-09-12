USING: kernel splitting sequences ascii ;
IN: log-levels

: message ( log-line -- message )
    ": " split1 nip [ blank? ] trim ;

: log-level ( log-line -- level )
    "[]" split harvest first >lower ;

: reformat ( log-line -- formatted )
    [ message ]
    [ log-level "(" ")" surround ]
    bi
    " " glue ;

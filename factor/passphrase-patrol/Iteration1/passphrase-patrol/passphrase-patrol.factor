USING: kernel regexp ;
IN: passphrase-patrol

: badge-regexp ( -- regex )
    R/ [A-Z]{2}-\d{4}/ ;

: valid-badge? ( badge -- ? )
    badge-regexp matches? ;

: badge-codes ( line -- codes )
    badge-regexp all-matching-subseqs ;

: digit-count ( string -- n )
    R/ \d/ count-matches ;

: redact ( line -- line' )
    R/ pass=\S+/ "pass=****" re-replace ;

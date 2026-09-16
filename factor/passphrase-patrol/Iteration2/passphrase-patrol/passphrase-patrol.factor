USING: kernel regexp ;
IN: passphrase-patrol

CONSTANT: badge-regexp    R/ [A-Z]{2}-\d{4}/
CONSTANT: password-regexp R/ pass=\S+/

: valid-badge? ( badge -- ? )
    badge-regexp matches? ;

: badge-codes ( line -- codes )
    badge-regexp all-matching-subseqs ;

: digit-count ( string -- n )
    R/ \d/ count-matches ;

: redact ( line -- line' )
    password-regexp "pass=****" re-replace ;

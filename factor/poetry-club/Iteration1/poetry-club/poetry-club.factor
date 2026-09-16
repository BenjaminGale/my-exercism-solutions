USING: kernel disjoint-sets ;
IN: poetry-club

: new-club ( poets -- club )
    <disjoint-set> [ add-atoms ] keep ;

: collaborate ( poet1 poet2 club -- club )
    [ equate ] keep ;

: circle-of ( poet club -- representative )
    representative ;

: same-circle? ( poet1 poet2 club -- ? )
    [ circle-of ] curry bi@ = ;

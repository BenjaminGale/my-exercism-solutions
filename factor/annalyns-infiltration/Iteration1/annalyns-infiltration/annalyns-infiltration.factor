USING: kernel ;
IN: annalyns-infiltration

: can-do-fast-attack ( knight-awake -- ? )
    not ;

: can-spy ( knight-awake archer-awake prisoner-awake -- ? )
    or or ;

: can-signal-prisoner ( archer-awake prisoner-awake -- ? )
    swap not and ;

:: can-free-prisoner ( archer-awake dog-present prisoner-awake knight-awake -- ? )
    archer-awake not dog-present and 
    knight-awake not archer-awake not and prisoner-awake and
    or ;

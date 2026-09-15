# Librarian's Ledger

Welcome to Librarian's Ledger on Exercism's Factor Track.
If you need help running the tests or submitting your code, check out `HELP.md`.
If you get stuck on the exercise, check out `HINTS.md`, but try and solve it without using those first :)

## Introduction

Sometimes you want to combine a sequence into a single value;
sometimes you want to see *every intermediate value* the
combination produces along the way. Factor splits these into two
tools: `reduce` (in [`sequences`][sequences]) for the single-value fold,
and the cumulative family in [`math.statistics`][math.statistics]
for the running form.

## `reduce` — the general fold

```
reduce ( seq init quot: ( prev elt -- next ) -- result )
```

`reduce` goes through a sequence one item at a time, carrying along a
running result (the *accumulator*) and feeding it to a two-argument
quotation. The quotation receives the running accumulator and the next
element; whatever it leaves on the stack becomes the new accumulator.

```factor
USING: math sequences ;

{ 1 2 3 4 } 0 [ + ] reduce .         ! => 10
{ 1 2 3 4 } 1 [ * ] reduce .         ! => 24
```

A non-zero seed and a custom combiner are the parts of `reduce`
that `sum` and `product` cannot reach. For example, the largest
value in a sequence, with a default if no value beats it:

```factor
USING: math.order ;

{ 3 1 -4 5 -2 } 0 [ max ] reduce .   ! => 5
{ -3 -1 -4 }    0 [ max ] reduce .   ! => 0
```

The seed `0` participates in the comparison: it acts as the
result when every element loses, so a sequence of all-negative
values still produces `0` rather than an arbitrary smallest
value.

## Cumulative reductions

Sometimes you want every intermediate result, not just the
final one. The cumulative family in
[`math.statistics`][math.statistics] returns a sequence the same
length as the input, where each position is the reduction over
the prefix ending at that position:

```
cum-sum     ( seq -- newseq )    ! running total
cum-product ( seq -- newseq )    ! running product
cum-min     ( seq -- newseq )    ! running minimum
cum-max     ( seq -- newseq )    ! running maximum
```

```factor
USING: math.statistics ;

{ 3 1 4 1 5 9 2 6 } cum-sum .        ! => { 3 4 8 9 14 23 25 31 }
{ 1 2 3 4 } cum-product .            ! => { 1 2 6 24 }
{ 3 1 4 1 5 9 2 6 } cum-min .        ! => { 3 1 1 1 1 1 1 1 }
{ 3 1 4 1 5 9 2 6 } cum-max .        ! => { 3 3 4 4 5 9 9 9 }
```

A useful pattern is **chained** cumulative reductions: the
output of one is itself a sequence, ready to feed into another.
That makes "running summary of a running summary" expressible
in two words. The combinations are flexible — pair them up
based on what each step is summarising.

## `produce` — the unfold

`reduce` consumes a sequence into a value. `produce` (in
[`sequences`][sequences]) goes the other way — *generates* a
sequence from a seed by repeatedly testing and stepping:

```
produce ( pred quot -- seq )
```

Each iteration first runs `pred` on the current state; if it
returns truthy, `quot` is called to produce the next element
and update the state. When `pred` returns `f`, iteration stops
and the collected elements are returned.

A classic example is the **Fibonacci sequence** (each number is
the sum of the previous two). The running state is the pair
`(a, b)`. Each step emits `b`, then replaces the pair with
`(b, a + b)`:

```factor
USING: kernel math sequences ;

! Fibonacci numbers strictly below 100:
0 1 [ dup 100 < ] [ tuck + over ] produce 2nip .
! => { 1 1 2 3 5 8 13 21 34 55 89 }
```

The running state spans *two* values, so the body uses `tuck`
(in [`kernel`][kernel]) — the three-element shuffle that copies
the top under the second — to step the pair, and `2nip` (also in
`kernel`, the two-element analogue of `nip`) tidies up at the
end. Reading the call left to right:

- The predicate `[ dup 100 < ]` peeks at the top of the pair
  (the *next* number to be emitted) and continues while it's
  still below the bound.
- The body `[ tuck + over ]` advances the state to
  `(b, a + b)` and emits `b`, leaving three values on the stack
  — the new pair below, the emitted number on top.
- After `produce` stops, the two trailing values (the final
  pair) are discarded with `2nip`, leaving only the produced
  sequence.

`produce` is the exact dual of `reduce`: where `reduce` folds a
sequence down to a value, `produce` unfolds a value up to a
sequence.

[math.statistics]: https://docs.factorcode.org/content/vocab-math.statistics.html
[sequences]: https://docs.factorcode.org/content/vocab-sequences.html
[kernel]: https://docs.factorcode.org/content/vocab-kernel.html

## Instructions

You're the librarian, keeping the patron-accounts ledger. Two
kinds of work land on your desk each week:

- A queue of **requests** — credits a patron asks to apply (book
  returns, paid fines) and new debits the system has logged
  (newly accrued overdue fines). The patron's account is
  *credit-protected*: a credit large enough to push the patron
  into the red is applied only up to what's owed, so the running
  balance never drops below zero.
- A list of **transactions** — entries already recorded against
  the account. Positive amounts are debits (new fines), negative
  amounts are credits (payments).

Each week you tally the books: a final balance after honouring
the requests, a per-day running balance from the transactions,
and a running low-water mark to flag stretches when fines
spiked.

## 1. Honour the request queue

Define `protected-balance` to take an `opening` balance and an
array of `requests` (signed amounts) and return the final
balance after honouring each request in turn. A withdrawal that
would push the balance below zero is honoured only up to the
available amount, so the running balance floors at zero.

```factor
100 { 50 -200 30 } protected-balance .
! => 30

500 { 100 -300 -250 } protected-balance .
! => 50

0 { -10 50 } protected-balance .
! => 50
```

## 2. Running balance

Define `running-balance` to take an array of `transactions` and
return a sequence of the same length whose `i`-th element is the
balance after the first `i+1` transactions (relative to a zero
starting balance).

```factor
{ 50 -30 -20 100 } running-balance .
! => { 50 20 0 100 }
```

## 3. Least balance so far

Define `least-balance-so-far` to take an array of `transactions`
and return a sequence of the same length whose `i`-th element is
the *lowest* running balance seen up to and including position
`i`. This is the running low-water mark — useful for spotting
days when the account looked risky.

```factor
{ 50 -30 -20 100 } least-balance-so-far .
! => { 50 20 0 0 }

{ 200 -50 -100 -200 } least-balance-so-far .
! => { 200 150 50 -150 }
```

## 4. Halve until target

The library is running a fine-amnesty programme: a patron's
outstanding balance is halved each pay period until it falls to
or below a forgiveness threshold. Define `halve-until` to take a
`principal` and a `target`, and return the sequence of halved
values (using integer division) starting from the first halving,
continuing as long as the running value is still strictly above
`target`. The last emitted value will be the first one that
drops to or below `target`.

```factor
100 5 halve-until .
! => { 50 25 12 6 3 }

64 1 halve-until .
! => { 32 16 8 4 2 1 }

3 5 halve-until .
! => { }
```

## Source

### Created by

- @keiravillekode
# Mosaic Mischief

Welcome to Mosaic Mischief on Exercism's Factor Track.
If you need help running the tests or submitting your code, check out `HELP.md`.
If you get stuck on the exercise, check out `HINTS.md`, but try and solve it without using those first :)

## Introduction

Most sequence words you've seen return *new* sequences and
leave their inputs alone — `suffix`, `reverse`, `map`, and so on.
But arrays and vectors also support **in-place mutation**, and
both come up when you want to record state that changes over
time.

## Two flavours of mutable sequence

- **Arrays** (`{ … }`) have a fixed length. `<array> ( n elt --
  array )` (in [`arrays`][arrays]) builds a fresh array of length
  `n` filled with copies of `elt`.
- **Vectors** (`V{ … }`) grow and shrink. Use `V{ } clone` for a
  fresh empty one; `<vector> ( n -- vector )` (in
  [`vectors`][vectors]) preallocates capacity for `n` elements.

```factor
USING: arrays kernel prettyprint vectors ;

5 0 <array> .   ! => { 0 0 0 0 0 }
V{ } clone .    ! => V{ }
```

## Changing a slot

These two work on either kind of sequence — both expect the
sequence after the index:

```
set-nth    ( elt n seq -- )
change-nth ( n seq quot -- )
```

`set-nth` assigns; `change-nth` applies a quotation to the element at position `n`.
Both of these [`sequences`][sequences] words return nothing on the stack — the mutation is the effect.

```factor
USING: arrays kernel math prettyprint sequences ;

5 0 <array>                 ! { 0 0 0 0 0 }
7 2 pick set-nth            ! mutates: position 2 becomes 7
0 over [ 1 + ] change-nth   ! mutates: position 0 += 1
.                           ! => { 1 0 7 0 0 }
```

## Growing and shrinking

These three only make sense on vectors, since arrays can't
change length:

```
push  ( elt seq -- )    ! append to the end
pop   ( seq -- elt )    ! remove and return the last
pop*  ( seq -- )        ! remove the last, discard
```

```factor
USING: kernel sequences vectors ;

V{ } clone              ! a fresh empty vector
"alice" over push       ! V{ "alice" }
"bob"   over push       ! V{ "alice" "bob" }
dup pop .               ! prints "bob"
.                       ! prints V{ "alice" }
```

## Vector → array

When you've built up a vector and want to hand back a fixed-length
array, `>array ( seq -- array )` (in [`arrays`][arrays]) returns a
new array with the same elements:

```factor
USING: arrays kernel prettyprint sequences vectors ;

V{ "alice" "bob" "carol" } >array .
! => { "alice" "bob" "carol" }
```

## `clone` — keep a snapshot

Mutation modifies the sequence in place. If a caller hands you a
sequence and you're about to change it, `clone` (in
[`kernel`][kernel]) gives you a fresh independent copy so the
caller's view doesn't shift under them:

```factor
USING: kernel prettyprint ;

V{ "a" "b" "c" } clone .    ! => V{ "a" "b" "c" }   (a fresh copy)
```

The same precaution applies to `V{ }` and other empty
literals. In some languages, `[]` or `vec![]` allocates a fresh
container each time the expression is evaluated. In Factor, the
literal `V{ }` written in your source is *one* object, shared by
every call site that mentions it. If you `push` onto `V{ }`
directly, the next call sees the leftovers. `V{ } clone` makes
the fresh copy you almost always want.

[arrays]: https://docs.factorcode.org/content/vocab-arrays.html
[vectors]: https://docs.factorcode.org/content/vocab-vectors.html
[sequences]: https://docs.factorcode.org/content/vocab-sequences.html
[kernel]: https://docs.factorcode.org/content/vocab-kernel.html

## Instructions

The community-arts-centre mosaic finished installing last
month, and now Magpie Marg has discovered it. Most days she
swaps a tile or two for shinier ones from her **hoard** nearby,
or plucks a tile out and disappears for an hour.

You're the volunteer who logs each change. The mosaic itself is
a **fixed-size array** — one slot per tile position, holding a
colour string or `f` for "missing". Magpie Marg's hoard is a
**vector** of loose tiles she's stolen.

## 1. Lay out a fresh row

Define `fresh-mosaic` to take a length `n` and return an array
of `n` empty slots (each `f`).

```factor
4 fresh-mosaic .
! => { f f f f }
```

## 2. Place a tile

Define `place-tile` to take a row, a position, and a colour, and
update the row in place so the named position holds that colour.
The word returns nothing.

```factor
5 fresh-mosaic   ! { f f f f f }
dup 2 "ruby" place-tile
.
! => { f f "ruby" f f }
```

## 3. Chip a tile out

Define `chip-tile` to take a row and a position, and update the
row in place so the named position becomes `f` again.

```factor
{ "ruby" "lapis" "jade" } 1 chip-tile .
! => { "ruby" f "jade" }
```

## 4. Re-colour a tile

Define `recolour-tile` to take a row, a position, and a one-arg
quotation, and update the row in place by applying the quotation
to the tile at that position.

```factor
{ "RUBY" "LAPIS" "JADE" } 1 [ >lower ] recolour-tile .
! => { "RUBY" "lapis" "JADE" }
```

## 5. Snapshot before Marg arrives

Define `snapshot-mosaic` to take a row and return an
independent copy that won't be affected by later mutations of
the original.

```factor
{ "ruby" "lapis" "jade" } dup snapshot-mosaic    ! two equal but independent copies
swap 0 "amber" place-tile                        ! mutate the first
.s
! => { "ruby" "lapis" "jade" }                   (the snapshot)
! => { "amber" "lapis" "jade" }                  (the mutated original)
```

## 6. Marg pockets a tile

Define `stash-tile` to take Marg's hoard (a vector) and a colour,
and append the colour to the hoard. Returns nothing.

```factor
V{ } clone   ! a fresh empty hoard
dup "ruby"  stash-tile
dup "lapis" stash-tile
.
! => V{ "ruby" "lapis" }
```

## 7. Marg returns a tile

Define `return-tile` to take Marg's hoard and remove and return
the most recently stashed tile (the one on top).

```factor
V{ "ruby" "lapis" "jade" } clone
dup return-tile .
! => "jade"
.
! => V{ "ruby" "lapis" }
```

## Source

### Created by

- @keiravillekode
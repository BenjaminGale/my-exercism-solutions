# Poetry Club

Welcome to Poetry Club on Exercism's Factor Track.
If you need help running the tests or submitting your code, check out `HELP.md`.
If you get stuck on the exercise, check out `HINTS.md`, but try and solve it without using those first :)

## Introduction

A *disjoint set* (a union-find structure) keeps a collection of values
partitioned into non-overlapping groups, and answers one question
quickly: are these two values in the same group? It lives in the
[`disjoint-sets`][disjoint-sets] vocabulary.

## Building a disjoint set

`<disjoint-set>` builds an empty structure. Values — *atoms* — are
added with `add-atom` one at a time, or with `add-atoms` from a
sequence. Each atom starts in a group by itself.

```
<disjoint-set> ( -- disjoint-set )
add-atom       ( atom disjoint-set -- )
add-atoms      ( seq disjoint-set -- )
```

```factor
USING: disjoint-sets ;

<disjoint-set>
{ 1 2 3 } over add-atoms   ! 1, 2 and 3 each in their own group
```

The disjoint set is *mutable*: `add-atom`, `add-atoms`, and `equate`
change it in place rather than returning a new one. `keep` is handy
when you want the disjoint set back on the stack after one of these
words has consumed it.

## Merging groups

`equate` unions the two groups that contain its atoms. Unioning is
transitive: equate two atoms, then one of them with a third, and all
three end up in one group.

```
equate ( atom1 atom2 disjoint-set -- )
```

## Representatives

Every group has one canonical member, its *representative*.
`representative` returns it, and two atoms belong to the same group
precisely when their representatives are equal.

```
representative ( atom disjoint-set -- representative )
```

```factor
USING: disjoint-sets ;

<disjoint-set>
{ 1 2 3 } over add-atoms
1 2 pick equate
1 over representative .   ! => 1
2 over representative .   ! => 1   (same representative as 1)
3 over representative .   ! => 3   (still on its own)
```

Which atom a group picks as its representative is an internal
detail — never depend on a particular atom being chosen, only on two
atoms in the same group agreeing.

[disjoint-sets]: https://docs.factorcode.org/content/vocab-disjoint-sets.html

## Instructions

The local poetry club is starting a new season. Poets join the club,
and whenever two of them co-write a poem they become part of the same
*writing circle*. The club wants to keep track of who shares a circle
with whom, and you have been asked to write the words that manage it.

A disjoint set is the perfect fit: each poet is an atom, and a writing
circle is a group.

## 1. Open the club

Define `new-club`, taking a sequence of poets and returning a fresh
disjoint set with every poet registered. Each poet starts in a writing
circle of their own.

```factor
{ "Keats" "Byron" "Dickinson" } new-club
! => a disjoint set holding the three poets
```

## 2. Record a collaboration

Define `collaborate`, taking two poets and a club. It merges the two
poets' writing circles and returns the club, so collaborations can be
recorded one after another.

```factor
{ "Keats" "Byron" "Dickinson" } new-club
"Keats" "Byron" rot collaborate
! => the club, with Keats and Byron now in one circle
```

## 3. Find a poet's circle

Define `circle-of`, taking a poet and a club and returning the
representative of that poet's writing circle. Two poets who share a
circle always report the same representative.

```factor
{ "Keats" "Byron" "Dickinson" } new-club
"Dickinson" swap circle-of
! => "Dickinson"   (still in a circle of their own)
```

## 4. Share a circle?

Define `same-circle?`, taking two poets and a club and returning `t`
when both poets belong to the same writing circle and `f` otherwise.
Compare the poets' representatives rather than using a built-in
equivalence test.

```factor
{ "Keats" "Byron" "Dickinson" } new-club
"Keats" "Byron" rot collaborate
dup [ "Keats" "Byron" ] dip same-circle? .      ! => t
    [ "Keats" "Dickinson" ] dip same-circle? .  ! => f
```

## Source

### Created by

- @keiravillekode
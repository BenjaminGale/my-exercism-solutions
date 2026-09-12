# Character Study

Welcome to Character Study on Exercism's Factor Track.
If you need help running the tests or submitting your code, check out `HELP.md`.
If you get stuck on the exercise, check out `HINTS.md`, but try and solve it without using those first :)

## Introduction

Factor characters are integers — Unicode code points — so numeric
`<`, `>`, `=` give you case-sensitive ordering directly. The
[`unicode`][unicode] vocabulary adds Unicode-aware predicates and
single-character case conversion.

## Character predicates

```
LETTER?  ( c -- ? )    ! uppercase letter
letter?  ( c -- ? )    ! lowercase letter
Letter?  ( c -- ? )    ! letter, either case
digit?   ( c -- ? )    ! decimal digit
digit>   ( c -- n )    ! the integer value of a digit char
blank?   ( c -- ? )    ! whitespace
```

```factor
USING: unicode ;

CHAR: A LETTER? .    ! => t
CHAR: a letter? .    ! => t
CHAR: 7 digit?  .    ! => t
CHAR: 7 digit>  .    ! => 7
```

## Case conversion

`ch>upper` and `ch>lower` flip a single character. The string-level
`>upper` and `>lower` apply them across every character of a string.

```factor
CHAR: a ch>upper .   ! => 65   (which is CHAR: A)
"Hello" >upper .     ! => "HELLO"
```

`capitalize` lowercases a whole string and then uppercases its first
character — the title case of a single word:

```factor
"hELLO" capitalize .   ! => "Hello"
```

## Character literals

`CHAR: A` parses to the integer code point of `A`. For named
characters, use the names `space`, `tab`, `\n`, etc.:

```factor
CHAR: A .        ! => 65
CHAR: space .    ! => 32
CHAR: \n .       ! => 10
```

## Symbols

When a word needs to return a tag rather than a value — say,
`yes`/`no`/`maybe` instead of a boolean — declare each tag as a
*symbol*. A symbol is a word that pushes itself when called, and
two symbols compare equal only when they are the same name.

```factor
USING: kernel ;

SYMBOLS: yes no maybe ;

yes .    ! => yes
yes yes = .    ! => t
yes no = .     ! => f
```

`SYMBOL: name` declares one; `SYMBOLS: a b c ;` declares several.

[unicode]: https://docs.factorcode.org/content/vocab-unicode.html

## Instructions

Heidi, a young Forth Alien, needs to get some work done on her
Human alphabets project and asks if you can help her program some
words she will need.

## 1. Compare two characters

Define `compare-chars` to take two characters and return the symbol
`less`, `greater`, or `equal` depending on whether the first is
less than, greater than, or equal to the second. Compare in a
case-sensitive manner.

```factor
CHAR: A CHAR: B compare-chars .   ! => less
CHAR: B CHAR: A compare-chars .   ! => greater
CHAR: A CHAR: A compare-chars .   ! => equal
CHAR: A CHAR: a compare-chars .   ! => less
```

## 2. Determine the size of a character

Heidi needs to know whether a character is "big" (uppercase),
"small" (lowercase), or has no size. Define `size-of-char` to
return `big`, `small`, or `no-size`.

```factor
CHAR: A size-of-char .       ! => big
CHAR: a size-of-char .       ! => small
CHAR: 5 size-of-char .       ! => no-size
CHAR: space size-of-char .   ! => no-size
```

## 3. Change the size of a character

Heidi sometimes needs to flip a character to a different size.
Define `change-size-of-char` to take a character and a desired
size (`big` or `small`) and return the corresponding-case
character.

```factor
CHAR: a big change-size-of-char .     ! => 65   (CHAR: A)
CHAR: A small change-size-of-char .   ! => 97   (CHAR: a)
```

## 4. Determine the type of a character

Heidi also needs to know what *kind* of character it is. Define
`type-of-char` to return:

- `alpha` for any letter (upper or lower)
- `numeric` for a decimal digit
- `space` for the space character
- `newline` for the newline character
- `unknown` otherwise

```factor
CHAR: A type-of-char .       ! => alpha
CHAR: 5 type-of-char .       ! => numeric
CHAR: space type-of-char .   ! => space
CHAR: \n type-of-char .      ! => newline
CHAR: ! type-of-char .       ! => unknown
```

## Source

### Created by

- @keiravillekode
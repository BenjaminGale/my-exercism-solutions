import unittest
import acronym

# version 1.7.0

suite "Acronym":
  test "basic":
    check abbreviate("Portable Network Graphics") == "PNG"

  test "consecutive spaces":
    check abbreviate("Portable  Network    Graphics") == "PNG"

  test "lowercase words":
    check abbreviate("Ruby on Rails") == "ROR"

  test "punctuation":
    check abbreviate("First In, First Out") == "FIFO"

  test "all caps word":
    check abbreviate("GNU Image Manipulation Program") == "GIMP"

  test "punctuation without whitespace":
    check abbreviate("Complementary metal-oxide semiconductor") == "CMOS"

  test "consecutive punctuation without whitespace":
    check abbreviate("Complementary metal---oxide semiconductor") == "CMOS"

  test "very long abbreviation":
    check abbreviate("Rolling On The Floor Laughing So Hard That " &
                     "My Dogs Came Over And Licked Me") == "ROTFLSHTMDCOALM"

  test "consecutive delimiters":
    check abbreviate("Something - I made up from thin air") == "SIMUFTA"

  test "apostrophes":
    check abbreviate("Halley's Comet") == "HC"

  test "underscore emphasis":
    check abbreviate("The Road _Not_ Taken") == "TRNT"

  test "consecutive underccores":
    check abbreviate("The Road __Not__ Taken") == "TRNT"

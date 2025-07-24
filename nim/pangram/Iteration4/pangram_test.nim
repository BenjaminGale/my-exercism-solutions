import unittest
import pangram

# version 2.0.0

suite "Pangram":
  test "empty sentence":
    check isPangram("") == false

  test "perfect lower case":
    check isPangram("abcdefghijklmnopqrstuvwxyz") == true

  test "only lower case":
    check isPangram("the quick brown fox jumps over the lazy dog") == true

  test "missing the letter 'x'":
    check isPangram("a quick movement of the enemy will jeopardize five gunboats") == false

  test "missing the letter 'h'":
    check isPangram("five boxing wizards jump quickly at it") == false

  test "with underscores":
    check isPangram("the_quick_brown_fox_jumps_over_the_lazy_dog") == true

  test "with numbers":
    check isPangram("the 1 quick brown fox jumps over the 2 lazy dogs") == true

  test "missing letters replaced by numbers":
    check isPangram("7h3 qu1ck brown fox jumps ov3r 7h3 lazy dog") == false

  test "mixed case and punctuation":
    check isPangram("\"Five quacking Zephyrs jolt my wax bed.\"") == true

  test "case insensitive":
    check isPangram("the quick brown fox jumps over with lazy FX") == false

  test "(swedish alphabet) empty sentence":
    check isPangram("", swedishAlphabet) == false

  test "(swedish alphabet) perfect lower case":
    check isPangram("abcdefghijklmnopqrstuvwxyzåäö", swedishAlphabet) == true

  test "(swedish alphabet) only lower case":
    check isPangram("yxskaftbud, ge vår wc-zonmö iq-hjälp", swedishAlphabet) == true

  test "(swedish alphabet) missing the letter 'ä'":
    check isPangram("Yxskaftbud, ge vår WC-zonmö IQ-hjlp", swedishAlphabet) == false

  test "(swedish alphabet) missing the letter 'h'":
    check isPangram("Yxskaftbud, ge vår WC-zonmö IQ-jälp", swedishAlphabet) == false

  test "(swedish alphabet) with underscores":
    check isPangram("Yxskaftbud,_ge_vår_WC-zonmö_IQ-hjälp", swedishAlphabet) == true

  test "(swedish alphabet) with numbers":
    check isPangram("Yxskaftbud, 1 ge vår WC-zonmö 2 IQ-hjälp", swedishAlphabet) == true

  test "(swedish alphabet) missing letters replaced by numbers":
    check isPangram("Yxsk7ftbud, 8e vår WC-z1nmö I4-hjälp", swedishAlphabet) == false

  test "(swedish alphabet) mixed case and punctuation":
    check isPangram("\"YxskafTbud, Ge vår WC-zonmö IQ-hjälp.\"", swedishAlphabet) == true

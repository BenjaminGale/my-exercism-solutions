#include "pangram.h"

#include <algorithm>
#include <set>

namespace pangram {

    const std::string AllAlphabetCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
    bool is_pangram(std::string input) {
        std::transform(
            input.begin(),
            input.end(),
            input.begin(),
            [](unsigned char c) { return std::toupper(c); }
        );

        std::set<char> all_alphabet_chars(AllAlphabetCharacters.begin(), AllAlphabetCharacters.end());
        std::set<char> sentence(input.begin(), input.end());
        
        return std::includes(
            sentence.begin(),
            sentence.end(),
            all_alphabet_chars.begin(),
            all_alphabet_chars.end()
        );
    }
}

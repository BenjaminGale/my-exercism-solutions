#include "hexadecimal.h"
#include <string>
#include <algorithm>
#include <assert.h>

namespace hexadecimal 
{
	bool is_hex_number(const char aChar) { return '0' <= aChar && aChar <= '9'; }
	bool is_hex_letter(const char aChar) { return 'a' <= aChar && aChar <= 'f'; }
	bool is_valid(const char aChar) { return is_hex_number(aChar) || is_hex_letter(aChar); }

	int convert_char(const char hexChar)
	{
		if (is_hex_number(hexChar))
			return hexChar - '0';

		if (is_hex_letter(hexChar))
			return hexChar - 'a' + 10;

		assert(false);
	}

	int convert(const std::string& hexString)
	{
		if (std::any_of(hexString.begin(), hexString.end(), [](char aChar) { return !is_valid(aChar); }))
			return 0;

		int result = 0;

		for (const char& hexChar : hexString) 
		{
			result = (result * 16) + convert_char(hexChar);
		}

		return result;
	}

}  // namespace hexadecimal
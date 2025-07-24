#include "hexadecimal.h"
#include <string>
#include <cmath>

namespace hexadecimal {

	int convertChar(char hexChar)
	{
		switch (hexChar)
		{
		case '0': return 0;
		case '1': return 1;
		case '2': return 2;
		case '3': return 3;
		case '4': return 4;
		case '5': return 5;
		case '6': return 6;
		case '7': return 7;
		case '8': return 8;
		case '9': return 9;
		case 'a':
		case 'A': return 10;
		case 'b':
		case 'B': return 11;
		case 'c':
		case 'C': return 12;
		case 'd':
		case 'D': return 13;
		case 'e':
		case 'E': return 14;
		case 'f':
		case 'F': return 15;
		default: return -1;
		}
	}

	int convert(std::string hexString) 
	{
		int result = 0;
		int length = (int)hexString.size();

		for (int i = 0; i < length; ++i)
		{
			char hexChar = hexString[i];
			int value = convertChar(hexChar);

			if (value == -1) return 0;

			int power = length - (i + 1);
			result += (value * std::pow(16, power));
		}

		return result;
	}

}  // namespace hexadecimal

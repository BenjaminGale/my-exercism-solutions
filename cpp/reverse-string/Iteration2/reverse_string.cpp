#include "reverse_string.h"
#include <string>

namespace reverse_string {

	std::string reverse_string(std::string str)
	{
		std::reverse(str.begin(), str.end());
		return str;
	}

}  // namespace reverse_string

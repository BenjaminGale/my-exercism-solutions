#include "reverse_string.h"
#include <string>

namespace reverse_string {

	const char* reverse_string(char* str)
	{
		std::string localStr = std::string(str);
		std::reverse(localStr.begin(), localStr.end());

		// I'm not sure how to return the copied array containing the
		// reversed characters...

		// I can't return localStr.c_str() because it will be released when localStr goes 
		// out of scope at the end of the function. I don't want to allocate localStr on 
		// the heap because I think this would mean that this method would leak memory every 
		// time it was called. If I ensure I delete the heap allocated string then the array 
		// owned by the string will be released which is the same problem I have with the 
		// stack allocated string.
		
		// I've also tried:
		// localStr.copy(str, sizeof str);
		// localStr.copy(str, localStr.size());
		// localStr.copy(str, sizeof str);
		// strcpy(str, localStr.c_str());

		// I get different results depending on the test case.
		// The empty string test case runs but fails. If I use the second test case then I
		// get access violation exceptions.

		// I feel like I'm missing something obvious here so any help would be appreciated...
		
		// I also don't understand why I can't make the first test pass by just returning
		// the function argument. In this case it doesn't seem like it should matter if
		// the == operator used by the tests is using the memory address of the char array
		// or looking at the characters because the first test case does not actually change 
		// anything.

		return str;
	}

}  // namespace reverse_string

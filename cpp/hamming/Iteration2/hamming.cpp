#include "hamming.h"
#include <string>
#include <stdexcept>

namespace hamming {

	int compute(const std::string& first, const std::string& second)
	{
		if (first.length() != second.length())
			throw std::domain_error("string lengths must be equal");

		int distance = 0;

		for (size_t i = 0; i < first.size(); i++)
		{
			if (first[i] != second[i])
				distance++;
		}

		return distance;
	}

}  // namespace hamming

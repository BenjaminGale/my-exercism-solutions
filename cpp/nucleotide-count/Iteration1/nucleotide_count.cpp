#include "nucleotide_count.h"
#include <map>
#include <string>
#include <algorithm>
#include <stdexcept>

namespace nucleotide_count {

	bool isValid(const char& c)
	{
		return c == 'A' || c == 'T' || c == 'C' || c == 'G';
	}

	counter::counter(const std::string& dna) : 
		_nucleotide_counts{ {'A', 0}, {'T', 0}, {'C', 0}, {'G', 0} } 
	{
		if (std::any_of(dna.begin(), dna.end(), [](const char& c) { return !isValid(c); }))
			throw std::invalid_argument("dna string contained invalid characters.");

		for each (const char& nucleotide in dna)
		{
			_nucleotide_counts[nucleotide] ++;
		}
	}

	std::map<char, int> counter::nucleotide_counts() const 
	{
		return _nucleotide_counts;
	}

	int counter::count(const char& nucleotide) const
	{
		if (!isValid(nucleotide))
			throw std::invalid_argument("dna string contained invalid characters.");

		return _nucleotide_counts.at(nucleotide);
	}

}  // namespace nucleotide_count
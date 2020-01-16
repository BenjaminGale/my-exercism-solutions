#include "nucleotide_count.h"
#include <algorithm>
#include <stdexcept>

namespace nucleotide_count {

	bool isValid(char c)
	{
		return c == 'A' || c == 'T' || c == 'C' || c == 'G';
	}

	counter::counter(const std::string& dna)
	{
		if (std::any_of(dna.begin(), dna.end(), [](char c) { return !isValid(c); }))
			throw std::invalid_argument("dna string contained invalid characters.");

		for (char nucleotide : dna)
		{
			_nucleotide_counts[nucleotide] ++;
		}
	}

	std::map<char, int> counter::nucleotide_counts() const 
	{
		return _nucleotide_counts;
	}

	int counter::count(char nucleotide) const
	{
		if (!isValid(nucleotide))
			throw std::invalid_argument("The supplied nucleotide character is not valid.");

		return _nucleotide_counts.at(nucleotide);
	}

}  // namespace nucleotide_count
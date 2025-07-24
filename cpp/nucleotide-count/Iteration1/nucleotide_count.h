#if !defined(NUCLEOTIDE_COUNT_H)
#define NUCLEOTIDE_COUNT_H

#include <string>
#include <map>

namespace nucleotide_count {

	class counter {
	public:
		counter(const std::string& dna);
		std::map<char, int> nucleotide_counts() const;
		int count(const char& nucleotide) const;

	private:
		std::map<char, int> _nucleotide_counts;
	};

}  // namespace nucleotide_count

#endif // NUCLEOTIDE_COUNT_H
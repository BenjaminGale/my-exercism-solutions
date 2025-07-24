#if !defined(NUCLEOTIDE_COUNT_H)
#define NUCLEOTIDE_COUNT_H

#include <string>
#include <map>

namespace nucleotide_count {

	class counter {
	public:
		explicit counter(const std::string& dna);
		std::map<char, int> nucleotide_counts() const;
		int count(char nucleotide) const;

	private:
		std::map<char, int> _nucleotide_counts { {'A', 0}, {'T', 0}, {'C', 0}, {'G', 0} };
	};

}  // namespace nucleotide_count

#endif // NUCLEOTIDE_COUNT_H
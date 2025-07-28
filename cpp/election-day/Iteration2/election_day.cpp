#include <string>
#include <vector>

namespace election {

struct ElectionResult {
    std::string name{};
    int votes{};
};

int vote_count(ElectionResult& result) {
    return result.votes;
}

void increment_vote_count(ElectionResult& result, int number_of_votes) {
    result.votes += number_of_votes;
}

ElectionResult& determine_result(std::vector<ElectionResult>& final_count) {
    ElectionResult* winner = &final_count[0];

    for (ElectionResult& candidate : final_count)
        if (candidate.votes > winner->votes)
            winner = &candidate;

    winner->name = "President " + winner->name;
    return *winner;
}

}  // namespace election

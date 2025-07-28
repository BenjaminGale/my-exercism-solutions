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
    int max_votes = 0;
    int winner_index = 0;

    for (int i = 0; i < final_count.size(); i++) {
        auto result = final_count.at(i);

        if (result.votes > max_votes) {
            max_votes = result.votes;
            winner_index = i;
        }
    }

    final_count.at(winner_index).name = "President " + final_count.at(winner_index).name;
    return final_count.at(winner_index);
}

}  // namespace election
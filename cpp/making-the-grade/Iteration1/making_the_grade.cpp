#include <array>
#include <string>
#include <vector>
#include <algorithm>

std::vector<int> round_down_scores(std::vector<double> student_scores) {
    std::vector<int> rounded_scores;

    while (!student_scores.empty()) {
        rounded_scores.insert(rounded_scores.begin(), (int)student_scores.back());
        student_scores.pop_back();
    }
    
    return rounded_scores;
}

bool is_failing_score (int score) {
    return score <= 40;
}

int count_failed_students(std::vector<int> student_scores) {
    return count_if(student_scores.begin(), student_scores.end(), is_failing_score);
}

std::array<int, 4> letter_grades(int highest_score) {
    auto interval = (highest_score - 40) / 4;
    auto current = 41;
    std::array<int, 4> grades;
    
    for (int i = 0; i <= 3; i ++) {
        grades[i] = current;
        current += interval;
    }
    
    return grades;
}

std::vector<std::string> student_ranking(std::vector<int> student_scores, std::vector<std::string> student_names) {
    std::vector<std::string> results;
    
    for (auto i = 0; i < student_scores.size(); i++) {
        auto count = i + 1;
        auto name = student_names[i];
        auto score = student_scores[i];

        char buffer[50];
        std::snprintf(buffer, sizeof(buffer), "%d. %s: %d", count, name.c_str(), score);
        
        results.emplace_back(buffer);
    }
    
    return results;
}

std::string perfect_score(std::vector<int> student_scores, std::vector<std::string> student_names) {
    for (auto i = 0; i < student_scores.size(); i++)
        if (student_scores[i] == 100)
            return student_names[i];

    return "";
}

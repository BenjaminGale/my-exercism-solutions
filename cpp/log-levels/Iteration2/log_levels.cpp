#include <string>

namespace log_line {
    std::string message(std::string line) {
        return line.substr(line.find(": ") + 2);
    }

    std::string log_level(std::string line) {
        int start = line.find("[") + 1;
        int end = line.find("]") - 1;
        
        return line.substr(start, end);
    }

    std::string reformat(std::string line) {
        char buffer[100];

        snprintf(
            buffer, sizeof(buffer),
            "%s (%s)",
            message(line).c_str(), log_level(line).c_str()
        );
        
        return std::string(buffer);
    }
}

namespace hellmath {

enum class AccountStatus {
    troll,
    guest,
    user,
    mod
};

enum class Action {
    read,
    write,
    remove
};

bool display_post(AccountStatus poster, AccountStatus viewer) {
    return (viewer == AccountStatus::troll && poster == AccountStatus::troll) || poster != AccountStatus::troll;
}
    
bool permission_check(Action action, AccountStatus accountStatus) {    
    switch (action) {
        case Action::read:
            return true;
        case Action::write:
            return accountStatus != AccountStatus::guest;
        case Action::remove:
            return accountStatus == AccountStatus::mod;
        default:
            return false;
    }
}

bool valid_player_combination(AccountStatus player1, AccountStatus player2) {
    return (player1 != AccountStatus::guest && player2 != AccountStatus::guest) &&
           ((player1 == AccountStatus::troll && player2 == AccountStatus::troll) ||
            (player1 != AccountStatus::troll && player2 != AccountStatus::troll));
}

bool has_priority(AccountStatus first, AccountStatus second) {
    return first > second;
}

}  // namespace hellmath
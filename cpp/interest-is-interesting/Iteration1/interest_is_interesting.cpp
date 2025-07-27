
double interest_rate(double balance) {
    if      (balance >= 5000) { return 2.475; }
    else if (balance >= 1000) { return 1.621; }
    else if (balance >= 0   ) { return 0.5;   }
    else                      { return 3.213; }
}

double yearly_interest(double balance) {
    return (balance / 100) * interest_rate(balance);
}

double annual_balance_update(double balance) {
    return balance + yearly_interest(balance);
}

int years_until_desired_balance(double balance, double target_balance) {
    int years = 0;
    
    while (balance < target_balance) {
        balance = annual_balance_update(balance);
        years++;
    }

    return years;
}

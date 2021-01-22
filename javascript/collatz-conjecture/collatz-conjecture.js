
export const steps = (number) => {
    if (number <= 0) {
        throw 'Only positive numbers are allowed'
    }

    var numberOfSteps = 0;

    while (number !== 1) {
        number = isEven(number) ? number / 2 : (3 * number) + 1;
        numberOfSteps++;
    }

    return numberOfSteps;
};

function isEven(number) {
    return (number % 2) === 0;
}


export const toRna = (input) => {
  
    let result = [];

    for (let i = 0; i < input.length; i++) {
        result.push(mapChar(input[i]));
    }

    return result.join('');
}

function mapChar(c) {
    switch (c) {
        case 'G':
            return 'C';
            break;
        case 'C':
            return 'G';
            break;
        case 'T':
            return 'A';
            break;
        case 'A':
            return 'U';
            break;
        default:
            ''
    }
}
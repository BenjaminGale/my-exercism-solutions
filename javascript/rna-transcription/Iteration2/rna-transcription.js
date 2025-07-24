
let nucleotideMap = new Map(); 

nucleotideMap.set('G', 'C');
nucleotideMap.set('C', 'G');
nucleotideMap.set('T', 'A');
nucleotideMap.set('A', 'U');

export const toRna = (input) => {
    return input
        .split('')
        .map((n) => transformNucleotide(n))
        .join('');
}

function transformNucleotide(c) {
    return nucleotideMap.has(c) ? nucleotideMap.get(c) : '';
}
export function toRna(nucleotides: string): string {

  let result = '';
  for (let nucleotide of nucleotides) {
    if (!AllowedDna.includes(nucleotide))
      throw new Error('Invalid input DNA.');
    
    result += RnaNucleotides[DnaNucleotides.indexOf(nucleotide)];
  }
  
  return result;
}

const DnaNucleotides = ['G', 'C', 'T', 'A']
const RnaNucleotides = ['C', 'G', 'A', 'U']

const AllowedDna = DnaNucleotides.join('')

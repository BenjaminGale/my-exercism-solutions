#include "rna_transcription.h"
#include <string.h>
#include <stdlib.h>

static char map_nucleotide(char nucleotide) {
    switch (nucleotide) {
        case 'G': return 'C';
        case 'C': return 'G';
        case 'T': return 'A';
        case 'A': return 'U';
        default: return nucleotide;
    }
}

char *to_rna(const char *dna) {
    int len = strlen(dna);
    char *rna = malloc(len * sizeof(char));

    for (int i = 0; i < len; i++) {
        rna[i] = map_nucleotide(dna[i]);
    }

    return rna;
}

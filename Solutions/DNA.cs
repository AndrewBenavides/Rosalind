﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Rosalind.Core;

namespace Rosalind.Solutions {
    public class DNA {
        [Fact]
        public void DNA_Solve() {
            var sequence = "AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC"; //sample
            sequence = "TTAGGATATTAATTACGACGAATCAAACGGTTTTGGCCAATCTATTTGATCCAACCTGAAGGGCCGTACCCTATATGACAAGATTAGATGATGGTGGATGATCCACCGACAGAACATTAACGTCACGGGGGAAACCCCGGATACTAATGCCATGGGATGGTCCTCTACTTTCTTCACGAAGAACCTAGTTGCCGATGAATATCTACTTGCGCATGTAAAGATTAGAATAACATGTTTCGGGGTCCAACCTCATCGTGAACTAGTAGTGATTCCCTGTCGCACGTTATTACGCGGGGTGCCAAGCTACGCGTCGGCGTGCGATTGATATAGCCTGTCAGGCATACGGGTGGACTCACGGTCGCCGTGGATTCCCCAACCGCCCGAAGCGTATTGAATAGGCCCGGACTAGCTGTGGTACACGCTCTCGTGCCGCCGGGGCGGAGTGGTTAGATTTCAAAACGACACAAAGTGAGCGTTTACCAACTCTCGTAATCTTGCGGAATGAGTACCCTCAATGGTGAGCCCGAATTCGTACATTTAGGCGTCCGTGTATCATTGAAACGGTTAAAATCACCCCTATTGGTCAAAGAAAGCCATTCAGTCGTATAGCCTATAGTGTACCAGGGCATACTTGAAATGGACTTCTCTAAGGCTTCGGGGGAGGAAGGAGGTTTACTTCAATATCTTGGAGGGACTCTATAGTCCGATAGTAATAAGATTCTTCAAGTAACGTGGGGAAGTATGTATGGGCGGAGGAACCGTTATTCACTAGATCGAGTGCCGTATTGCAAGTACTACGCGGTGCCGACCGGCGTGGGCTGGATCTCAGACCGAAGACAATATTACGCCTCTGAGCATATGATGTCATTGTCTATCCGTCTTGGTGAGCGGGCTGGAGAATTAGGTCTGGCCACTTGGCAAGTAAGATGCTTAGGGAACATTCAAAAGTGTTCTGTAGCTGGTGATAAAGACATCGAAGGACTACTACTGTAGTTGTAA";
            var dnaString = new DnaString(sequence);
            var answer = dnaString.GetNucleotideCounts();
        }
    }
}

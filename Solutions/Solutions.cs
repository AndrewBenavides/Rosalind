﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Rosalind.Core;

namespace Rosalind.Solutions {
    public class Solutions {
        [Fact]
        public void DNA() {
            DNA_Solve("AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC", "20 12 17 21");
            DNA_Solve("TTAGGATATTAATTACGACGAATCAAACGGTTTTGGCCAATCTATTTGATCCAACCTGAAGGGCCGTACCCTATATGACAAGATTAGATGATGGTGGATGATCCACCGACAGAACATTAACGTCACGGGGGAAACCCCGGATACTAATGCCATGGGATGGTCCTCTACTTTCTTCACGAAGAACCTAGTTGCCGATGAATATCTACTTGCGCATGTAAAGATTAGAATAACATGTTTCGGGGTCCAACCTCATCGTGAACTAGTAGTGATTCCCTGTCGCACGTTATTACGCGGGGTGCCAAGCTACGCGTCGGCGTGCGATTGATATAGCCTGTCAGGCATACGGGTGGACTCACGGTCGCCGTGGATTCCCCAACCGCCCGAAGCGTATTGAATAGGCCCGGACTAGCTGTGGTACACGCTCTCGTGCCGCCGGGGCGGAGTGGTTAGATTTCAAAACGACACAAAGTGAGCGTTTACCAACTCTCGTAATCTTGCGGAATGAGTACCCTCAATGGTGAGCCCGAATTCGTACATTTAGGCGTCCGTGTATCATTGAAACGGTTAAAATCACCCCTATTGGTCAAAGAAAGCCATTCAGTCGTATAGCCTATAGTGTACCAGGGCATACTTGAAATGGACTTCTCTAAGGCTTCGGGGGAGGAAGGAGGTTTACTTCAATATCTTGGAGGGACTCTATAGTCCGATAGTAATAAGATTCTTCAAGTAACGTGGGGAAGTATGTATGGGCGGAGGAACCGTTATTCACTAGATCGAGTGCCGTATTGCAAGTACTACGCGGTGCCGACCGGCGTGGGCTGGATCTCAGACCGAAGACAATATTACGCCTCTGAGCATATGATGTCATTGTCTATCCGTCTTGGTGAGCGGGCTGGAGAATTAGGTCTGGCCACTTGGCAAGTAAGATGCTTAGGGAACATTCAAAAGTGTTCTGTAGCTGGTGATAAAGACATCGAAGGACTACTACTGTAGTTGTAA", "263 216 264 256");
        }

        private void DNA_Solve(string input, string answer) {
            var dnaString = new DnaString(input);
            var result = dnaString.GetNucleotideCounts();
            Assert.Equal(answer, result);
        }
        
        [Fact]
        public void RNA() {
            RNA_Solve("GATGGAACTTGACTACGTAAATT", "GAUGGAACUUGACUACGUAAAUU");
            RNA_Solve("CTCAGGCCAGCTGGTGCCACATTAAAACAGCCATGGGCATCAGTCCCCACTCCGGCGGAAGTTTAATATGGAAACAATCACTTGGACAGAATGCTAAGTTTCGTCAAGTCAACCCAATCGCGTCGAATAGTCGTATAAGGATACTACACGGTGCGTGACGAGACTCTGGTCTTCAGGTTGCGCATTGTCGGTATTGTGCGGCTGGACGTGCGCGCCTTGCTTATAATCGTGTGGGCTCGTAGAACGATTCACGATTCCCATTTAAGTCTTGGTCGCACTGTAACTGTAGTGCACAGCTTCGCTCTGGACTGCTTTGTTCAGATAAAGCGGCAATGCAGGTGCTCAAGCGCAGATATGGATGACGATCGTGGAGTTAATAGGCCATACAACGGACTAATGGCTAGAACCCGCTGGTCGATGGAGCCTGATCACCGTCTAAGCTTACGGTATTGGCGGGGATCACATCTGGGTAATCGCTGGCTATAGTGCGCGCCCTATCATCCACTTGCGGCCGTCATGGTAAATACGAATTGACTCAAGACGGCCGATACGCACAAGTGCACTAGAGCCGTGTCAGCCGACGGATACGGCTGTGATTGCGCCACATATCCTGTCCAGGCCGGTTCGGTGATTTACCAGATGGCTCTCGTCCACCCCCCTTGTACTCAAGCATGCTTCTCGCTACCCTGGCCGTTTAAGTATGGGGTTATTCATTGAGTCGCAGCAGAGCTTTACGCGGGCCCTACGTTGTATTGGGAGATGCTTGTCCGTCCCAGCTACCTACTGACCTGGGACCTTGAGCGGTAGTCGCGTCGTGACGCTCGGGCTCAGGGATAACATTCCTACCTACGGTCGTCGCTGAATCTAAAGACTGTCCTGCAGCCGGCGTGGGAAAACCGGCGGCCAAGCGACTACTGACATCGTATGTTTGGGGGTA", "CUCAGGCCAGCUGGUGCCACAUUAAAACAGCCAUGGGCAUCAGUCCCCACUCCGGCGGAAGUUUAAUAUGGAAACAAUCACUUGGACAGAAUGCUAAGUUUCGUCAAGUCAACCCAAUCGCGUCGAAUAGUCGUAUAAGGAUACUACACGGUGCGUGACGAGACUCUGGUCUUCAGGUUGCGCAUUGUCGGUAUUGUGCGGCUGGACGUGCGCGCCUUGCUUAUAAUCGUGUGGGCUCGUAGAACGAUUCACGAUUCCCAUUUAAGUCUUGGUCGCACUGUAACUGUAGUGCACAGCUUCGCUCUGGACUGCUUUGUUCAGAUAAAGCGGCAAUGCAGGUGCUCAAGCGCAGAUAUGGAUGACGAUCGUGGAGUUAAUAGGCCAUACAACGGACUAAUGGCUAGAACCCGCUGGUCGAUGGAGCCUGAUCACCGUCUAAGCUUACGGUAUUGGCGGGGAUCACAUCUGGGUAAUCGCUGGCUAUAGUGCGCGCCCUAUCAUCCACUUGCGGCCGUCAUGGUAAAUACGAAUUGACUCAAGACGGCCGAUACGCACAAGUGCACUAGAGCCGUGUCAGCCGACGGAUACGGCUGUGAUUGCGCCACAUAUCCUGUCCAGGCCGGUUCGGUGAUUUACCAGAUGGCUCUCGUCCACCCCCCUUGUACUCAAGCAUGCUUCUCGCUACCCUGGCCGUUUAAGUAUGGGGUUAUUCAUUGAGUCGCAGCAGAGCUUUACGCGGGCCCUACGUUGUAUUGGGAGAUGCUUGUCCGUCCCAGCUACCUACUGACCUGGGACCUUGAGCGGUAGUCGCGUCGUGACGCUCGGGCUCAGGGAUAACAUUCCUACCUACGGUCGUCGCUGAAUCUAAAGACUGUCCUGCAGCCGGCGUGGGAAAACCGGCGGCCAAGCGACUACUGACAUCGUAUGUUUGGGGGUA");
        }

        private void RNA_Solve(string input, string answer) {
            var dnaString = new DnaString(input);
            var result = dnaString.TranscribeToRna();
            Assert.Equal(answer, result);
        }

        [Fact]
        public void REVC() {
            REVC_Solve("AAAACCCGGT", "ACCGGGTTTT");
            REVC_Solve("TCTCGATGAATGTTAACTTTGCATCCCGGTCGTACCTGCACTCACACTGATCTCATTTAAATCGCCATTAACCCTGTTCCCGAATCAAAGGGAATATTTTATAAATATTTGGTGTCTCCCACAAACCCCCCTGCCGCACACGATGATTCTGTGCAAGGCAGACCGGCAATGGAGGCCTGTCAGTCCATGCGCCGCCCTGTGTGCACGATAGACAGATTGATCCGCCCTTGTTGTATGCGTCGTTACTGGTTCACGCCTTTCTGTCAAACGCCGTGTCAAACACGTATGTATCCGACAAGGGCCAGATTTTTGCCTCTGATCTTGACTGTGGAACCAACAATCACGGGCCCCATGTTATTTGTGGTGAAACTATCTGACGGGCTCTCCGGTCGGCCGCCAGGTTAAAGGCACCTTCGAGAACAGCTGCGGGGTGGTCACAGTGCAAGATCTACTAGCAACATGCACTCGTGTCACAAACAACCTACTTACCCTTAGCCGACTCCTCTTGTAATGATCCCGTATTCCGGCAATTCCTGTTCGACTCAAAGCACTGCCGGTAGTTCTTAACGGAGTTTGGGAGTGGCAGTATCCTTGGGAGGCTGTCCCTCCTAGAGTCCAACGATTTTGTCTACCACAATACGTAACCGCGAATCATAAGATTTGTACCGCCGCAAAATCCCGAGTATTCAATTAAAAGCGCGCTAAGTATTACTGATATGTCGCATGCCGACGTCTGATGTCATAACTGACCAAACGTCGCGTAGGTAGGGAAACAATAGACTCAACAACTGGGGAAGAGGTGTAGGTGCATAAGTACCTTGTCTCGCTTGACAGGCAGCGTCAGCAGGGTGTTATTGT", "ACAATAACACCCTGCTGACGCTGCCTGTCAAGCGAGACAAGGTACTTATGCACCTACACCTCTTCCCCAGTTGTTGAGTCTATTGTTTCCCTACCTACGCGACGTTTGGTCAGTTATGACATCAGACGTCGGCATGCGACATATCAGTAATACTTAGCGCGCTTTTAATTGAATACTCGGGATTTTGCGGCGGTACAAATCTTATGATTCGCGGTTACGTATTGTGGTAGACAAAATCGTTGGACTCTAGGAGGGACAGCCTCCCAAGGATACTGCCACTCCCAAACTCCGTTAAGAACTACCGGCAGTGCTTTGAGTCGAACAGGAATTGCCGGAATACGGGATCATTACAAGAGGAGTCGGCTAAGGGTAAGTAGGTTGTTTGTGACACGAGTGCATGTTGCTAGTAGATCTTGCACTGTGACCACCCCGCAGCTGTTCTCGAAGGTGCCTTTAACCTGGCGGCCGACCGGAGAGCCCGTCAGATAGTTTCACCACAAATAACATGGGGCCCGTGATTGTTGGTTCCACAGTCAAGATCAGAGGCAAAAATCTGGCCCTTGTCGGATACATACGTGTTTGACACGGCGTTTGACAGAAAGGCGTGAACCAGTAACGACGCATACAACAAGGGCGGATCAATCTGTCTATCGTGCACACAGGGCGGCGCATGGACTGACAGGCCTCCATTGCCGGTCTGCCTTGCACAGAATCATCGTGTGCGGCAGGGGGGTTTGTGGGAGACACCAAATATTTATAAAATATTCCCTTTGATTCGGGAACAGGGTTAATGGCGATTTAAATGAGATCAGTGTGAGTGCAGGTACGACCGGGATGCAAAGTTAACATTCATCGAGA");
        }

        private void REVC_Solve(string input, string answer) {
            var dnaString = new DnaString(input);
            var result = dnaString.GetReverseComplement();
            Assert.Equal(answer, result);
        }

        [Fact]
        public void FIB() {
            FIB_Solve("5 3", 19, 1);
            FIB_Solve("9 3", 508, 1);
            FIB_Solve("32 3", 108412748857, 1);
            FIB_Solve("34 4", 18788331166609, 1);
            FIB_Solve("33 5", 112316396483406, 1);
        }

        private void FIB_Solve(string input, long answer, int start) {
            var n = int.Parse(input.Split(' ')[0]);
            var k = int.Parse(input.Split(' ')[1]);
            var result = Fibonacci.Solve(n, k, start);
            Assert.Equal(answer, result);
        }
    }
}

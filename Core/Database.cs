using System;
using System.Collections.Generic;
using System.Linq;

namespace Rosalind.Core {
    public class Database : Dictionary<string, DnaString> {
        private Database(Dictionary<string, DnaString> dictionary) : base(dictionary) { }

        public static Database Parse(string databaseString) {
            var remove = StringSplitOptions.RemoveEmptyEntries;
            var sets = databaseString.Split(new char[] { '>' }, remove);
            var sequences = sets
                .Select(s => {
                    var lines = s.Split(new char[] { '\r', '\n' }, remove);
                    var label = lines.First();
                    var sequence = Sequence.Parse(lines.Skip(1).Concatenate());
                    return DnaString.Create(label, sequence);
                });
            return new Database(sequences
                .ToDictionary(s => s.Label, s => s));
        }
    }
}

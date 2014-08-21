using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Rosalind.Solutions {
    public class DataService {
        private static Dictionary<int, DataEntry> GetEntries(string setName) {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Resources", setName);
            var entries = Directory.EnumerateFiles(path)
                .Where(f => f.Contains("_dataset"))
                .OrderBy(f => f)
                .Select((f, i) => new DataEntry(setName, i, path))
                .ToDictionary(e => e.ID, e => e);
            return entries;
        }

        public static void SolveUsing(Action<DataEntry> solver, [CallerMemberName] string setName = "") {
            if (string.IsNullOrWhiteSpace(setName)) throw new InvalidOperationException("setName parameter was not provided.");
            var entries = GetEntries(setName);
            if (!entries.Any()) throw new InvalidOperationException("No entries found.");
            foreach (var entry in entries.Values) {
                solver(entry);
            }
        }
    }
    
    public class DataEntry {
        private const string datasetTemplate = "rosalind_{0}_{1}_dataset.txt";
        private const string outputTemplate = "rosalind_{0}_{1}_output.txt";

        public FileInfo Dataset { get; set; }
        public DirectoryInfo Directory { get; set; }
        public int ID { get; set; }
        public FileInfo Output { get; set; }
        public string SetName { get; set; }

        public DataEntry(string setName, int id, string directoryPath) {
            this.SetName = setName;
            this.ID = id;
            this.Directory = new DirectoryInfo(directoryPath);
            this.Dataset = GetFileInfo(datasetTemplate);
            this.Output = GetFileInfo(outputTemplate);
        }

        private FileInfo GetFileInfo(string template) {
            var fileName = string.Format(template, this.SetName.ToLower(), this.ID);
            return new FileInfo(Path.Combine(this.Directory.FullName, fileName));
        }

        private static string Read(FileInfo fileInfo) {
            using (var reader = fileInfo.OpenText()) {
                return reader.ReadToEnd().Trim();
            }
        }

        public string ReadDataset() {
            return Read(this.Dataset);
        }

        public string ReadOrWriteOutput(object output) {
            if (!this.Output.Exists) WriteOutput(output);
            return Read(this.Output);
        }

        public void WriteOutput(object output) {
            using (var writer = new StreamWriter(this.Output.OpenWrite())) {
                writer.Write(output);
            }
        }
    }
}

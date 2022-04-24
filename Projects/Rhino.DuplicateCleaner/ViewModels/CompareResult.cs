using Rhino.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace Rhino.DuplicateCleaner.ViewModels
{
    public class CompareResult
    {
        public static Dictionary<string, CompareResult> _compareResults = new Dictionary<string, CompareResult>();

        public string MD5 { get; set; }

        public long FileSize { get; set; }

        public int Count => Files.Count;

        private List<DeleteFile> _files = null;
        public List<DeleteFile> Files => _files ?? (_files = new List<DeleteFile>());

        public CompareResult(string md5, string file)
        {
            MD5 = md5;
            Files.Add(new DeleteFile(md5, file));
        }

        public static bool TryGetValue(string key, out CompareResult value) => _compareResults.TryGetValue(key, out value);

        public static void Add(string file)
        {
            if (string.IsNullOrEmpty(file)) { return; }
            if (!File.Exists(file)) { return; }

            var md5 = file.GetMD5FromFile();
            if (string.IsNullOrEmpty(md5)) { return; }
            var length = new FileInfo(file).Length;

            if (_compareResults.TryGetValue(md5, out CompareResult result))
            {
                if (result.FileSize == length)
                {
                    result.Files.Add(new DeleteFile(md5, file));
                }
            }
            else
            {
                result = new CompareResult(md5, file) { FileSize = length, };
                _compareResults.Add(md5, result);
            }
        }

        public static void Remove(DeleteFile deleteFile)
        {
            if (_compareResults.TryGetValue(deleteFile.MD5, out CompareResult result))
            {
                result.Files.Remove(deleteFile);
                if (result.Count == 1)
                {
                    result.Files[0].CanDelete = false;
                }
            }
        }

        public static void Clear() => _compareResults.Clear();

        public static ObservableCollection<CompareResult> ToObservableCollection()
        {
            ObservableCollection<CompareResult> results = new ObservableCollection<CompareResult>();

            foreach (var item in _compareResults)
            {
                if (item.Value.Count < 2) { continue; }
                results.Add(item.Value);
            }
            return results;
        }
    }
}
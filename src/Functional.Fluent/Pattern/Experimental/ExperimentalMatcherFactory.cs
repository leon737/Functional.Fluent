using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Functional.Fluent.Pattern.Experimental
{
    public class MatcherFactory
    {
        private static readonly Lazy<MatcherFactory> _Instance = new Lazy<MatcherFactory>(() => new MatcherFactory());

        private readonly IDictionary<MatcherCacheIndex, object> _matchers = new ConcurrentDictionary<MatcherCacheIndex, object>();

        private readonly object _syncLock = new object();

        private MatcherFactory() { }

        public static MatcherFactory Instance => _Instance.Value;

        public Func<TV, TU> MakeMatcher<TV, TU>(Func<Matcher<TV, TU>, Func<TV, TU>> constructor,
        [System.Runtime.CompilerServices.CallerFilePath] string filePath = "",
        [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            var index = new MatcherCacheIndex(filePath, sourceLineNumber);

            object matcher;
            if (!_matchers.TryGetValue(index, out matcher))
            {
                matcher = constructor(new Matcher<TV, TU>());
                lock (_syncLock)
                {
                    if (!_matchers.ContainsKey(index))
                        _matchers.Add(index, matcher);
                }
            }
            return (Func<TV, TU>) matcher;
        }
    }

    internal class MatcherCacheIndex
    {
        public string FilePath;

        public int SourceLineNumber;

        public MatcherCacheIndex(string filePath, int sourceLineNumber)
        {
            FilePath = filePath;
            SourceLineNumber = sourceLineNumber;
        }

        public override int GetHashCode()
        {
            return FilePath.GetHashCode() ^ SourceLineNumber;
        }

        public override bool Equals(object obj)
        {
            var other = obj as MatcherCacheIndex;
            if (other == null) return false;
            return FilePath == other.FilePath && SourceLineNumber == other.SourceLineNumber;
        }
    }
}
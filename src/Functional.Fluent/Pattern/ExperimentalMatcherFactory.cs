using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Functional.Fluent.Pattern
{
    public class ExperimentalMatcherFactory
    {
        private static readonly Lazy<ExperimentalMatcherFactory> _Instance = new Lazy<ExperimentalMatcherFactory>(() => new ExperimentalMatcherFactory());

        private readonly IDictionary<string, object> _matchers = new ConcurrentDictionary<string, object>();

        private readonly object _syncLock = new object();

        private ExperimentalMatcherFactory() { }

        public static ExperimentalMatcherFactory Instance => _Instance.Value;

        public Func<TV, TU> MakeMatcher<TV, TU>(Func<ExperimentalMatcher<TV, TU>, Func<TV, TU>> constructor,
        [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
        [System.Runtime.CompilerServices.CallerFilePath] string filePath = "",
        [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            var index = $"{filePath}:{memberName}@{sourceLineNumber}";

            object matcher;
            if (!_matchers.TryGetValue(index, out matcher))
            {
                matcher = constructor(new ExperimentalMatcher<TV, TU>());
                lock (_syncLock)
                {
                    if (!_matchers.ContainsKey(index))
                        _matchers.Add(index, matcher);
                }
            }
            return (Func<TV, TU>) matcher;
        }
    }
}
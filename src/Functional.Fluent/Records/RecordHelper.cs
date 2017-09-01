using System;
using Functional.Fluent.Records.Factories;
using Functional.Fluent.Records.FuncComposers;

namespace Functional.Fluent.Records
{
    public static class RecordHelper<T>
    {
        private static Func<Record<T>, int> _GetHashCodeFunc;

        private static Func<Record<T>, Record<T>, bool> _EqualityFunc;

        private static Func<Record<T>, string> _ToStringFunc;
        
        static RecordHelper()
        {
            _GetHashCodeFunc = new FuncComposer<T, Func<Record<T>, int>>(new GetHashCodeFuncFactory()).Compose().Compile();
            _ToStringFunc = new FuncComposer<T, Func<Record<T>, string>>(new ToStringFuncFactory()).Compose().Compile();
            _EqualityFunc = new FuncComposer<T, Func<Record<T>, Record<T>, bool>>(new EqualityFuncFactory()).Compose().Compile();
        }

        public static Func<Record<T>, int> ComposeGetHashCodeFunc() => _GetHashCodeFunc;

        public static Func<Record<T>, Record<T>, bool> ComposeEqualityFunc() => _EqualityFunc;

        public static Func<Record<T>, string> ComposeToStringFunc() => _ToStringFunc;
    }
}
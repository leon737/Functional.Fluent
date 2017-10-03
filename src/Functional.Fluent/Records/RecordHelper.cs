using System;
using Functional.Fluent.Records.Factories;
using Functional.Fluent.Records.FuncComposers;

namespace Functional.Fluent.Records
{
    internal static class RecordHelper<T>
    {
        private static readonly Func<Record<T>, int> _GetHashCodeFunc;

        private static readonly Func<Record<T>, Record<T>, bool> _EqualityFunc;

        private static readonly Func<Record<T>, string> _ToStringFunc;

        private static readonly Func<Record<T>, Record<T>, T> _MergeFunc;

        static RecordHelper()
        {
            _GetHashCodeFunc = MakeFunc<Func<Record<T>, int>>(new GetHashCodeFuncFactory());
            _ToStringFunc = MakeFunc<Func<Record<T>, string>>(new ToStringFuncFactory());
            _EqualityFunc = MakeFunc<Func<Record<T>, Record<T>, bool>>(new EqualityFuncFactory());
            _MergeFunc = MakeFunc<Func<Record<T>, Record<T>, T>>(new MergeFuncFactory());
        }
        
        public static Func<Record<T>, int> ComposeGetHashCodeFunc() => _GetHashCodeFunc;

        public static Func<Record<T>, Record<T>, bool> ComposeEqualityFunc() => _EqualityFunc;

        public static Func<Record<T>, string> ComposeToStringFunc() => _ToStringFunc;

        public static Func<Record<T>, Record<T>, T> ComposeMergeFunc() => _MergeFunc;

        private static TFunc MakeFunc<TFunc>(IFuncFactory factory) => new FuncComposer<T, TFunc>(factory).Compose().Compile();

    }
}
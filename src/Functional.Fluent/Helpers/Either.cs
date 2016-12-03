using System;

namespace Functional.Fluent.Helpers
{

    public static class Either
    {
        public static Either<L, R> Create<L, R>(Func<L> left) => () => left();

        public static Either<L, R> Create<L, R>(Func<R> right) => () => right();
    }

    public struct EitherPair<L, R>
    {
        public readonly L Left;

        public readonly R Right;

        public readonly bool HasLeft;

        public readonly bool HasRight;

        public EitherPair(L left)
        {
            Left = left;
            Right = default(R);
            HasLeft = true;
            HasRight = false;
        }

        public EitherPair(R right)
        {
            Left = default(L);
            Right = right;
            HasLeft = false;
            HasRight = true;
        }

        public static implicit operator EitherPair<L, R>(L left) => new EitherPair<L, R>(left);

        public static implicit operator EitherPair<L, R>(R right) => new EitherPair<L, R>(right);
    }


    public delegate EitherPair<L, R> Either<L, R>();

}
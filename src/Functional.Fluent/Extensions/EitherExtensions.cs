using System;
using Functional.Fluent.Helpers;

namespace Functional.Fluent.Extensions
{
    public static class EitherExtensions
    {
        public static Either<L, B> Bind<L, R, B>(this Either<L, R> e, Func<R, Either<L, B>> func) =>
            e.HasLeft() ? (() => e.Left()) : func(e.Right());

        public static Either<L, S> Select<L, R, S>(this Either<L, R> e, Func<R, S> func) =>
            e.HasLeft() ? (() => e.Left()) : new Either<L, S>(() => func(e.Right()));

        public static Either<L, P> SelectMany<L, R, S, P>(this Either<L, R> e, Func<R, Either<L, S>> select,
            Func<R, S, P> project)
        {
            if (e.HasLeft()) return () => e.Left();

            var s = select(e.Right());
            if (s.HasLeft()) return () => s.Left();

            return () => project(e.Right(), s.Right());
        }

        public static bool HasLeft<L, R>(this Either<L, R> e) => e().HasLeft;

        public static bool HasRight<L, R>(this Either<L, R> e) => e().HasRight;

        public static L Left<L, R>(this Either<L, R> e) => e().Left;

        public static R Right<L, R>(this Either<L, R> e) => e().Right;
    }
}
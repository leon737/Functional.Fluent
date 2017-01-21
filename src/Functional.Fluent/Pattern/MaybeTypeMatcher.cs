using System;
using System.Linq.Expressions;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Pattern
{
    public class MaybeTypeMatcher<TV, TU> : TypeMatcher<TU>
    {
        private readonly MonadicValue<TV> contextValue;

        public MaybeTypeMatcher(MonadicValue<TV> contextValue )
        {
            this.contextValue = contextValue;
        }

        public MaybeTypeMatcher<TV, TU> With<TZ>(Expression<Func<object, TZ>> predicate, Expression<Func<TZ, TU>> func)
        {
            Add(predicate, func);
            return this;
        }

        public MaybeTypeMatcher<TV, TU> With<TZ>(Expression<Func<object, TZ>> predicate, TU returnValue)
        {
            Add(predicate, _ => returnValue);
            return this;
        }

        public MaybeTypeMatcher<TV, TU> WithThrow<TZ, TE>(Expression<Func<object, TZ>> predicate, TE exception) where TE : Exception
        {
            Add(predicate, exception);
            return this;
        }

        public MaybeTypeMatcher<TV, TU> With<TZ>(Expression<Func<object, TZ>> predicate, Expression<Func<TZ, bool>> whenPredicate, Expression<Func<TZ, TU>> func)
        {
            Add(predicate, whenPredicate, func);
            return this;
        }

        public MaybeTypeMatcher<TV, TU> With<TZ>(Expression<Func<object, TZ>> predicate, Expression<Func<TZ, bool>> whenPredicate, TU returnValue)
        {
            Add(predicate, whenPredicate, _ => returnValue);
            return this;
        }

        public MaybeTypeMatcher<TV, TU> With<TZ, TE>(Expression<Func<object, TZ>> predicate, Expression<Func<TZ, bool>> whenPredicate, TE exception)
            where TE : Exception
        {
            Add(predicate, whenPredicate, exception);
            return this;
        }

        public MaybeTypeMatcher<TV, TU> Else(Expression<Func<TV, TU>> func)
        {
            elseExpression = func;
            return this;
        }

        public MaybeTypeMatcher<TV, TU> Else(TU returnValue)
        {
            elseExpression = (Expression< Func<TV,TU>>)(_ => returnValue);
            return this;
        }

        public MaybeTypeMatcher<TV, TU> ElseThrow<TE>() where TE:Exception, new()
        {
            elseExpression = BuildThrowExpression(new TE());
            return this;
        }

        public MaybeTypeMatcher<TV, TU> ElseThrow<TE>(TE exception) where TE : Exception
        {
            elseExpression = BuildThrowExpression(exception);
            return this;
        }

        public TU Do() => Match(contextValue.Value);
    }
}
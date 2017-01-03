using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Pattern.Experimental
{
    public class Matcher<TV, TU> : IEnumerable<TU>
    {
        protected readonly List<Tuple<Expression<Func<TV, bool>>, Expression<Func<TV, TU>>>>  List = new List<Tuple<Expression<Func<TV, bool>>, Expression<Func<TV, TU>>>>();

        protected MonadicValue<TV> ContextValue;

        public Matcher()
        {
            ContextValue = null;
        }

        public Matcher(MonadicValue<TV> contextValue )
        {
            ContextValue = contextValue;
        }

        public void Add(Expression<Func<TV, bool>> predicate, Expression<Func<TV, TU>> func)
        {
            Add(predicate, func, true);
        }

        protected void Add(Expression<Func<TV, bool>> predicate, Expression<Func<TV, TU>> func, bool nullSafe)
        {
            var finalPredicate = nullSafe && ContextValue is Maybe<TV>
                ? AddNullCheck(predicate)
                : predicate;
            List.Add(Tuple.Create(finalPredicate, func));
        }

        public void Add(TV value, Expression<Func<TV, TU>> func)
        {
            Expression<Func<TV, bool>> predicate = MakeConstantPredicate(value);
            List.Add(Tuple.Create(predicate, func));
        }
        
        public void Add(IEnumerable<TV> values, Expression<Func<TV, TU>> func)
        {
            Expression<Func<TV, bool>> predicate = MakeConstantPredicate(values.ToArray());
            List.Add(Tuple.Create(predicate, func));
        }

        public Matcher<TV, TU> With(Expression<Func<TV, bool>> predicate, Expression<Func<TV, TU>> func)
        {
            Add(predicate, func);
            return this;
        }

        public Matcher<TV, TU> WithThrow<TE>(Expression<Func<TV, bool>> predicate) where TE : Exception, new() =>
          With(predicate, MakeThrowExceptionExpression<TE>());

        public Matcher<TV, TU> WithThrow<TE>(Expression<Func<TV, bool>> predicate, TE exception) where TE : Exception =>
            With(predicate, MakeThrowExceptionExpression(exception));

        public Matcher<TV, TU> With(Expression<Func<TV, bool>> predicate, TU resultValue)
        {
            Add(predicate, MakeConstantResultExpression(resultValue));
            return this;
        }

        public Matcher<TV, TU> With(TV value, Expression<Func<TV, TU>> func)
        {
            Add(value, func);
            return this;
        }

        public Matcher<TV, TU> With(TV value, TU resultValue)
        {
            Add(value, MakeConstantResultExpression(resultValue));
            return this;
        }

        public Matcher<TV, TU> WithThrow<TE>(TV value, TE exception) where TE : Exception =>
           With(value, MakeThrowExceptionExpression(exception));

        public Matcher<TV, TU> WithThrow<TE>(TV value) where TE : Exception, new() =>
           With(value, MakeThrowExceptionExpression<TE>());

        public Matcher<TV, TU> With(TV value, TV value2, Expression<Func<TV, TU>> func)
        {
            Add(new[] { value, value2 }, func);
            return this;
        }

        public Matcher<TV, TU> With(TV value, TV value2, TU resultValue)
        {
            Add(new[] { value, value2 }, MakeConstantResultExpression(resultValue));
            return this;
        }

        public Matcher<TV, TU> With(TV value, TV value2, TV value3, Expression<Func<TV, TU>> func)
        {
            Add(new[] { value, value2, value3 }, func);
            return this;
        }

        public Matcher<TV, TU> With(TV value, TV value2, TV value3, TU resultValue)
        {
            Add(new[] { value, value2, value3 }, MakeConstantResultExpression(resultValue));
            return this;
        }

        public Matcher<TV, TU> With(TV value, TV value2, TV value3, TV value4, Expression<Func<TV, TU>> func)
        {
            Add(new[] { value, value2, value3, value4 }, func);
            return this;
        }

        public Matcher<TV, TU> With(TV value, TV value2, TV value3, TV value4, TU resultValue)
        {
            Add(new[] { value, value2, value3, value4 }, MakeConstantResultExpression(resultValue));
            return this;
        }

        public Matcher<TV, TU> With(TV value, TV value2, TV value3, TV value4, TV value5, Expression<Func<TV, TU>> func)
        {
            Add(new[] { value, value2, value3, value4, value5 }, func);
            return this;
        }

        public Matcher<TV, TU> With(TV value, TV value2, TV value3, TV value4, TV value5, TU resultValue)
        {
            Add(new[] { value, value2, value3, value4, value5 }, MakeConstantResultExpression(resultValue));
            return this;
        }

        public Matcher<TV, TU> With(IEnumerable<TV>values , Expression<Func<TV, TU>> func)
        {
            Add(values, func);
            return this;
        }

        public Matcher<TV, TU> With(IEnumerable<TV> values, TU resultValue)
        {
            Add(values, MakeConstantResultExpression(resultValue));
            return this;
        }


        public Matcher<TV, TU> Null(Expression<Func<TV, TU>> func)
        {
            Add(x => x == null, func, false);
            return this;
        }

        public Matcher<TV, TU> Null(TU resultValue)
        {
            Add(x => x == null, MakeConstantResultExpression(resultValue), false);
            return this;
        }

        public Matcher<TV, TU> NullThrow<TE>() where TE : Exception, new()
        {
            Add(x => x == null, MakeThrowExceptionExpression<TE>(), false);
            return this;
        }

        public Matcher<TV, TU> NullThrow<TE>(TE exception) where TE : Exception
        {
            Add(x => x == null, MakeThrowExceptionExpression(exception), false);
            return this;
        }

        public Matcher<TV, TU> Else(Expression<Func<TV, TU>> func)
        {
            Add(x => true, func, false);
            return this;
        }
        
        public Matcher<TV, TU> Else(TU resultValue)
        {
            Add(x => true, MakeConstantResultExpression(resultValue), false);
            return this;
        }

        public Matcher<TV, TU> ElseThrow<TE>() where TE : Exception, new()
        {
            Add(x => true, MakeThrowExceptionExpression<TE>(), false);
            return this;
        }

        public Matcher<TV, TU> ElseThrow<TE>(TE exception) where TE : Exception
        {
            Add(x => true, MakeThrowExceptionExpression(exception), false);
            return this;
        }

        public TU Do() => Match(ContextValue.Value);

        public virtual TU Match(TV value) => Compile()(value);

        public Func<TV, TU> ToFunc () => Match;

        public IEnumerator<TU> GetEnumerator()
        {
            throw new InvalidOperationException();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public Func<TV, TU> Compile() => new MatcherCompiler<TV, TU>(List).Compile();

        private Expression<Func<TV, bool>> AddNullCheck(Expression<Func<TV, bool>> expression)
        {
            var p = expression.Parameters.First();
            var condition = Expression.IfThenElse(Expression.NotEqual(p, Expression.Constant(null)), expression, Expression.Constant(false));
            return Expression.Lambda<Func<TV, bool>>(condition, p);
        }
        
        private Expression<Func<TV, bool>> MakeConstantPredicate(params TV[] values)
        {
            if (values == null || !values.Any())
                throw new ArgumentException(nameof(values));
            var p = Expression.Parameter(typeof(TV));
            var mi = typeof(TV).GetMethods().First(x => x.Name == nameof(Equals));
            var type = typeof(TV);
            Expression cond = null;
            foreach (var value in values)
            {
                var predicate = type.IsPrimitive
                    ? (Expression) Expression.Equal(p, Expression.Constant(value))
                    : Expression.Call(p, mi, Expression.Constant(value));

                cond = cond == null ? predicate : Expression.OrElse(cond, predicate);
            }

            var condition = (type.IsClass || Nullable.GetUnderlyingType(type) != null)
                ? Expression.AndAlso(Expression.NotEqual(p, Expression.Constant(null)), cond)
                :cond;

            return Expression.Lambda<Func<TV, bool>>(condition, p);
        }

        private Expression<Func<TV, TU>> MakeConstantResultExpression(TU value)
        {
            var constant = Expression.Constant(value, typeof(TU));
            var p = Expression.Parameter(typeof(TV));
            return Expression.Lambda<Func<TV, TU>>(constant, p);
        }

        private Expression<Func<TV, TU>> MakeThrowExceptionExpression<TE>() where TE : Exception, new() => 
            MakeThrowExceptionExpression((Expression)Expression.New(typeof(TE)));

        private Expression<Func<TV, TU>> MakeThrowExceptionExpression<TE>(TE exception) where TE : Exception => 
            MakeThrowExceptionExpression((Expression)Expression.Constant(exception, typeof(TE)));

        private Expression<Func<TV, TU>> MakeThrowExceptionExpression(Expression expr)
        {
            var ex = Expression.Throw(expr);
            var block = Expression.Block(ex, Expression.Constant(default(TU), typeof(TU)));
            var p = Expression.Parameter(typeof(TV));
            return Expression.Lambda<Func<TV, TU>>(block, p);
        }
    }
}

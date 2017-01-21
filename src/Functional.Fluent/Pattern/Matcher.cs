using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Pattern
{
    public partial class Matcher<TV, TU> : IEnumerable<TU>
    {
        protected readonly List<Tuple<Predicate<TV>, Func<TV, TU>>>  list = new List<Tuple<Predicate<TV>, Func<TV, TU>>>();

        protected MonadicValue<TV> contextValue;

        public Matcher()
        {
            contextValue = null;
        }

        public Matcher(MonadicValue<TV> contextValue )
        {
            this.contextValue = contextValue;
        }

        public void Add(Predicate<TV> predicate, Func<TV, TU> func)
        {
            Add(predicate, func, true);
        }

        protected void Add(Predicate<TV> predicate, Func<TV, TU> func, bool nullSafe)
        {
            var finalPredicate = nullSafe && contextValue is Maybe<TV>
                ? v => v != null && predicate(v)
                : predicate;
            list.Add(Tuple.Create(finalPredicate, func));
        }

        public void Add(TV value, Func<TV, TU> func)
        {
            Predicate<TV> predicate = x => x?.Equals(value) ?? false;
            list.Add(Tuple.Create(predicate, func));
        }

        public void Add(IEnumerable<TV> values, Func<TV, TU> func)
        {
            foreach (var value in values)
            {
                TV local = value;
                Predicate<TV> predicate = x => x?.Equals(local) ?? false;
                list.Add(Tuple.Create(predicate, func));    
            }
        }

        public Matcher<TV, TU> With(Predicate<TV> predicate, Func<TV, TU> func)
        {
            Add(predicate, func);
            return this;
        }

        
        public Matcher<TV, TU> WithThrow<TE>(Predicate<TV> predicate) where TE : Exception, new() =>
           With(predicate, _ =>
           {
               throw new TE();
           });

        public Matcher<TV, TU> WithThrow<TE>(Predicate<TV> predicate, TE exception) where TE : Exception =>
            With(predicate, _ =>
            {
                throw exception;
            });

        public Matcher<TV, TU> With(Predicate<TV> predicate, TU resultValue)
        {
            Add(predicate, _ => resultValue);
            return this;
        }
        
        public Matcher<TV, TU> With(TV value, Func<TV, TU> func)
        {
            Add(value, func);
            return this;
        }
        
        public Matcher<TV, TU> With(TV value, TU resultValue)
        {
            Add(value, _ => resultValue);
            return this;
        }

        public Matcher<TV, TU> WithThrow<TE>(TV value, TE exception) where TE : Exception =>
            With(value, _ =>
            {
                throw exception;
            });

        public Matcher<TV, TU> WithThrow<TE>(TV value) where TE : Exception, new() =>
           With(value, _ =>
           {
               throw new TE();
           });
        
        public Matcher<TV, TU> With(IEnumerable<TV>values , Func<TV, TU> func)
        {
            Add(values, func);
            return this;
        }

        public Matcher<TV, TU> With(IEnumerable<TV> values, TU resultValue)
        {
            Add(values, _ => resultValue);
            return this;
        }

        public Matcher<TV, TU> WithThrow<TE>(IEnumerable<TV> values, TE exception) where TE : Exception =>
           With(values, _ =>
           {
               throw exception;
           });

        public Matcher<TV, TU> WithThrow<TE>(IEnumerable<TV> values) where TE : Exception, new() =>
           With(values, _ =>
           {
               throw new TE();
           });
        

        public Matcher<TV, TU> Null(Func<TV, TU> func)
        {
            Add(x => x == null, func, false);
            return this;
        }

        public Matcher<TV, TU> Null(TU resultValue)
        {
            Add(x => x == null, _ => resultValue, false);
            return this;
        }

        public Matcher<TV, TU> NullThrow<TE>() where TE : Exception, new()
        {
            Add(x => x == null, _ =>
            {
                throw new TE();
            }, false);
            return this;
        }

        public Matcher<TV, TU> NullThrow<TE>(TE exception) where TE : Exception
        {
            Add(x => x == null, _ =>
            {
                throw exception;
            }, false);
            return this;
        }

        public Matcher<TV, TU> Else(Func<TV, TU> func)
        {
            Add(x => true, func, false);
            return this;
        }
        
        public Matcher<TV, TU> Else(TU resultValue)
        {
            Add(x => true, _ => resultValue, false);
            return this;
        }

        public Matcher<TV, TU> ElseThrow<TE>() where TE : Exception, new()
        {
            Add(x => true, _ =>
            {
                throw new TE();
            }, false);
            return this;
        }

        public Matcher<TV, TU> ElseThrow<TE>(TE exception) where TE : Exception
        {
            Add(x => true, _ =>
            {
                throw exception;
            }, false);
            return this;
        }

        public TU Do()
        {
            return Match(contextValue.Value);
        }

        public virtual TU Match(TV value)
        {
            foreach (var item in list)
            {
                if (item.Item1(value))
                    return item.Item2(value);
            }
            return default (TU);
        }

        public static implicit operator Func<TV, TU>(Matcher<TV, TU> matcher)
        {
            return matcher.Match;
        }

        public Func<TV, TU> ToFunc ()
        {
            return Match;
        }

        public IEnumerator<TU> GetEnumerator()
        {
            throw new InvalidOperationException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    
}

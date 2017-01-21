


using System;
using System.Linq.Expressions;

namespace Functional.Fluent.Pattern
{
	public partial class Matcher<TV, TU>
    {
	
			
		public Matcher<TV, TU> With( TV value0,  TV value1, Func<TV, TU> func)
        {
            Add(new[] {  value0,  value1 }, func);
            return this;
        }

        public Matcher<TV, TU> With( TV value0,  TV value1, TU resultValue)
        {
            Add(new[] { value0,  value1 }, _ => resultValue);
            return this;
        }

        public Matcher<TV, TU> WithThrow<TE>( TV value0,  TV value1, TE exception) where TE : Exception =>
           With( value0,  value1, _ =>
           {
               throw exception;
           });

        public Matcher<TV, TU> WithThrow<TE>( TV value0,  TV value1) where TE : Exception, new() =>
           With( value0,  value1, _ =>
           {
               throw new TE();
           });

			
		public Matcher<TV, TU> With( TV value0,  TV value1,  TV value2, Func<TV, TU> func)
        {
            Add(new[] {  value0,  value1,  value2 }, func);
            return this;
        }

        public Matcher<TV, TU> With( TV value0,  TV value1,  TV value2, TU resultValue)
        {
            Add(new[] { value0,  value1,  value2 }, _ => resultValue);
            return this;
        }

        public Matcher<TV, TU> WithThrow<TE>( TV value0,  TV value1,  TV value2, TE exception) where TE : Exception =>
           With( value0,  value1,  value2, _ =>
           {
               throw exception;
           });

        public Matcher<TV, TU> WithThrow<TE>( TV value0,  TV value1,  TV value2) where TE : Exception, new() =>
           With( value0,  value1,  value2, _ =>
           {
               throw new TE();
           });

			
		public Matcher<TV, TU> With( TV value0,  TV value1,  TV value2,  TV value3, Func<TV, TU> func)
        {
            Add(new[] {  value0,  value1,  value2,  value3 }, func);
            return this;
        }

        public Matcher<TV, TU> With( TV value0,  TV value1,  TV value2,  TV value3, TU resultValue)
        {
            Add(new[] { value0,  value1,  value2,  value3 }, _ => resultValue);
            return this;
        }

        public Matcher<TV, TU> WithThrow<TE>( TV value0,  TV value1,  TV value2,  TV value3, TE exception) where TE : Exception =>
           With( value0,  value1,  value2,  value3, _ =>
           {
               throw exception;
           });

        public Matcher<TV, TU> WithThrow<TE>( TV value0,  TV value1,  TV value2,  TV value3) where TE : Exception, new() =>
           With( value0,  value1,  value2,  value3, _ =>
           {
               throw new TE();
           });

			
		public Matcher<TV, TU> With( TV value0,  TV value1,  TV value2,  TV value3,  TV value4, Func<TV, TU> func)
        {
            Add(new[] {  value0,  value1,  value2,  value3,  value4 }, func);
            return this;
        }

        public Matcher<TV, TU> With( TV value0,  TV value1,  TV value2,  TV value3,  TV value4, TU resultValue)
        {
            Add(new[] { value0,  value1,  value2,  value3,  value4 }, _ => resultValue);
            return this;
        }

        public Matcher<TV, TU> WithThrow<TE>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4, TE exception) where TE : Exception =>
           With( value0,  value1,  value2,  value3,  value4, _ =>
           {
               throw exception;
           });

        public Matcher<TV, TU> WithThrow<TE>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4) where TE : Exception, new() =>
           With( value0,  value1,  value2,  value3,  value4, _ =>
           {
               throw new TE();
           });

			
		public Matcher<TV, TU> With( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5, Func<TV, TU> func)
        {
            Add(new[] {  value0,  value1,  value2,  value3,  value4,  value5 }, func);
            return this;
        }

        public Matcher<TV, TU> With( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5, TU resultValue)
        {
            Add(new[] { value0,  value1,  value2,  value3,  value4,  value5 }, _ => resultValue);
            return this;
        }

        public Matcher<TV, TU> WithThrow<TE>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5, TE exception) where TE : Exception =>
           With( value0,  value1,  value2,  value3,  value4,  value5, _ =>
           {
               throw exception;
           });

        public Matcher<TV, TU> WithThrow<TE>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5) where TE : Exception, new() =>
           With( value0,  value1,  value2,  value3,  value4,  value5, _ =>
           {
               throw new TE();
           });

			
		public Matcher<TV, TU> With( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6, Func<TV, TU> func)
        {
            Add(new[] {  value0,  value1,  value2,  value3,  value4,  value5,  value6 }, func);
            return this;
        }

        public Matcher<TV, TU> With( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6, TU resultValue)
        {
            Add(new[] { value0,  value1,  value2,  value3,  value4,  value5,  value6 }, _ => resultValue);
            return this;
        }

        public Matcher<TV, TU> WithThrow<TE>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6, TE exception) where TE : Exception =>
           With( value0,  value1,  value2,  value3,  value4,  value5,  value6, _ =>
           {
               throw exception;
           });

        public Matcher<TV, TU> WithThrow<TE>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6) where TE : Exception, new() =>
           With( value0,  value1,  value2,  value3,  value4,  value5,  value6, _ =>
           {
               throw new TE();
           });

			
		public Matcher<TV, TU> With( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7, Func<TV, TU> func)
        {
            Add(new[] {  value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7 }, func);
            return this;
        }

        public Matcher<TV, TU> With( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7, TU resultValue)
        {
            Add(new[] { value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7 }, _ => resultValue);
            return this;
        }

        public Matcher<TV, TU> WithThrow<TE>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7, TE exception) where TE : Exception =>
           With( value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7, _ =>
           {
               throw exception;
           });

        public Matcher<TV, TU> WithThrow<TE>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7) where TE : Exception, new() =>
           With( value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7, _ =>
           {
               throw new TE();
           });

			
		public Matcher<TV, TU> With( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7,  TV value8, Func<TV, TU> func)
        {
            Add(new[] {  value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7,  value8 }, func);
            return this;
        }

        public Matcher<TV, TU> With( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7,  TV value8, TU resultValue)
        {
            Add(new[] { value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7,  value8 }, _ => resultValue);
            return this;
        }

        public Matcher<TV, TU> WithThrow<TE>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7,  TV value8, TE exception) where TE : Exception =>
           With( value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7,  value8, _ =>
           {
               throw exception;
           });

        public Matcher<TV, TU> WithThrow<TE>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7,  TV value8) where TE : Exception, new() =>
           With( value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7,  value8, _ =>
           {
               throw new TE();
           });

			
		public Matcher<TV, TU> With( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7,  TV value8,  TV value9, Func<TV, TU> func)
        {
            Add(new[] {  value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7,  value8,  value9 }, func);
            return this;
        }

        public Matcher<TV, TU> With( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7,  TV value8,  TV value9, TU resultValue)
        {
            Add(new[] { value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7,  value8,  value9 }, _ => resultValue);
            return this;
        }

        public Matcher<TV, TU> WithThrow<TE>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7,  TV value8,  TV value9, TE exception) where TE : Exception =>
           With( value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7,  value8,  value9, _ =>
           {
               throw exception;
           });

        public Matcher<TV, TU> WithThrow<TE>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7,  TV value8,  TV value9) where TE : Exception, new() =>
           With( value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7,  value8,  value9, _ =>
           {
               throw new TE();
           });

			
		public Matcher<TV, TU> With( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7,  TV value8,  TV value9,  TV value10, Func<TV, TU> func)
        {
            Add(new[] {  value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7,  value8,  value9,  value10 }, func);
            return this;
        }

        public Matcher<TV, TU> With( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7,  TV value8,  TV value9,  TV value10, TU resultValue)
        {
            Add(new[] { value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7,  value8,  value9,  value10 }, _ => resultValue);
            return this;
        }

        public Matcher<TV, TU> WithThrow<TE>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7,  TV value8,  TV value9,  TV value10, TE exception) where TE : Exception =>
           With( value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7,  value8,  value9,  value10, _ =>
           {
               throw exception;
           });

        public Matcher<TV, TU> WithThrow<TE>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7,  TV value8,  TV value9,  TV value10) where TE : Exception, new() =>
           With( value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7,  value8,  value9,  value10, _ =>
           {
               throw new TE();
           });

	
	}

	public partial class MatcherContext<TV>
	{
	
	
		public Matcher<TV, TU> With<TU>( TV value0,  TV value1, Func<TV, TU> func) =>
            new Matcher<TV, TU>(contextValue) { { new[] {  value0,  value1 }, func } };

        public Matcher<TV, TU> With<TU>( TV value0,  TV value1, TU resultValue) =>
            With( value0,  value1, _ => resultValue);

        public MatcherMemberAccessor<TV, TC, TM> Member<TC, TM>( TV value0,  TV value1, Expression<Func<TC, TM>> expression) =>
            Member(new[] { value0,  value1}, expression);

        public Matcher<TV, TU> WithThrow<TU, TE>( TV value0,  TV value1) where TE : Exception, new() =>
            With<TU>( value0,  value1, _ =>
            {
                throw new TE();
            });

        public Matcher<TV, TU> WithThrow<TU, TE>( TV value0,  TV value1, TE exception) where TE : Exception =>
            With<TU>( value0,  value1, _ =>
            {
                throw exception;
            });

	
		public Matcher<TV, TU> With<TU>( TV value0,  TV value1,  TV value2, Func<TV, TU> func) =>
            new Matcher<TV, TU>(contextValue) { { new[] {  value0,  value1,  value2 }, func } };

        public Matcher<TV, TU> With<TU>( TV value0,  TV value1,  TV value2, TU resultValue) =>
            With( value0,  value1,  value2, _ => resultValue);

        public MatcherMemberAccessor<TV, TC, TM> Member<TC, TM>( TV value0,  TV value1,  TV value2, Expression<Func<TC, TM>> expression) =>
            Member(new[] { value0,  value1,  value2}, expression);

        public Matcher<TV, TU> WithThrow<TU, TE>( TV value0,  TV value1,  TV value2) where TE : Exception, new() =>
            With<TU>( value0,  value1,  value2, _ =>
            {
                throw new TE();
            });

        public Matcher<TV, TU> WithThrow<TU, TE>( TV value0,  TV value1,  TV value2, TE exception) where TE : Exception =>
            With<TU>( value0,  value1,  value2, _ =>
            {
                throw exception;
            });

	
		public Matcher<TV, TU> With<TU>( TV value0,  TV value1,  TV value2,  TV value3, Func<TV, TU> func) =>
            new Matcher<TV, TU>(contextValue) { { new[] {  value0,  value1,  value2,  value3 }, func } };

        public Matcher<TV, TU> With<TU>( TV value0,  TV value1,  TV value2,  TV value3, TU resultValue) =>
            With( value0,  value1,  value2,  value3, _ => resultValue);

        public MatcherMemberAccessor<TV, TC, TM> Member<TC, TM>( TV value0,  TV value1,  TV value2,  TV value3, Expression<Func<TC, TM>> expression) =>
            Member(new[] { value0,  value1,  value2,  value3}, expression);

        public Matcher<TV, TU> WithThrow<TU, TE>( TV value0,  TV value1,  TV value2,  TV value3) where TE : Exception, new() =>
            With<TU>( value0,  value1,  value2,  value3, _ =>
            {
                throw new TE();
            });

        public Matcher<TV, TU> WithThrow<TU, TE>( TV value0,  TV value1,  TV value2,  TV value3, TE exception) where TE : Exception =>
            With<TU>( value0,  value1,  value2,  value3, _ =>
            {
                throw exception;
            });

	
		public Matcher<TV, TU> With<TU>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4, Func<TV, TU> func) =>
            new Matcher<TV, TU>(contextValue) { { new[] {  value0,  value1,  value2,  value3,  value4 }, func } };

        public Matcher<TV, TU> With<TU>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4, TU resultValue) =>
            With( value0,  value1,  value2,  value3,  value4, _ => resultValue);

        public MatcherMemberAccessor<TV, TC, TM> Member<TC, TM>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4, Expression<Func<TC, TM>> expression) =>
            Member(new[] { value0,  value1,  value2,  value3,  value4}, expression);

        public Matcher<TV, TU> WithThrow<TU, TE>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4) where TE : Exception, new() =>
            With<TU>( value0,  value1,  value2,  value3,  value4, _ =>
            {
                throw new TE();
            });

        public Matcher<TV, TU> WithThrow<TU, TE>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4, TE exception) where TE : Exception =>
            With<TU>( value0,  value1,  value2,  value3,  value4, _ =>
            {
                throw exception;
            });

	
		public Matcher<TV, TU> With<TU>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5, Func<TV, TU> func) =>
            new Matcher<TV, TU>(contextValue) { { new[] {  value0,  value1,  value2,  value3,  value4,  value5 }, func } };

        public Matcher<TV, TU> With<TU>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5, TU resultValue) =>
            With( value0,  value1,  value2,  value3,  value4,  value5, _ => resultValue);

        public MatcherMemberAccessor<TV, TC, TM> Member<TC, TM>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5, Expression<Func<TC, TM>> expression) =>
            Member(new[] { value0,  value1,  value2,  value3,  value4,  value5}, expression);

        public Matcher<TV, TU> WithThrow<TU, TE>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5) where TE : Exception, new() =>
            With<TU>( value0,  value1,  value2,  value3,  value4,  value5, _ =>
            {
                throw new TE();
            });

        public Matcher<TV, TU> WithThrow<TU, TE>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5, TE exception) where TE : Exception =>
            With<TU>( value0,  value1,  value2,  value3,  value4,  value5, _ =>
            {
                throw exception;
            });

	
		public Matcher<TV, TU> With<TU>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6, Func<TV, TU> func) =>
            new Matcher<TV, TU>(contextValue) { { new[] {  value0,  value1,  value2,  value3,  value4,  value5,  value6 }, func } };

        public Matcher<TV, TU> With<TU>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6, TU resultValue) =>
            With( value0,  value1,  value2,  value3,  value4,  value5,  value6, _ => resultValue);

        public MatcherMemberAccessor<TV, TC, TM> Member<TC, TM>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6, Expression<Func<TC, TM>> expression) =>
            Member(new[] { value0,  value1,  value2,  value3,  value4,  value5,  value6}, expression);

        public Matcher<TV, TU> WithThrow<TU, TE>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6) where TE : Exception, new() =>
            With<TU>( value0,  value1,  value2,  value3,  value4,  value5,  value6, _ =>
            {
                throw new TE();
            });

        public Matcher<TV, TU> WithThrow<TU, TE>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6, TE exception) where TE : Exception =>
            With<TU>( value0,  value1,  value2,  value3,  value4,  value5,  value6, _ =>
            {
                throw exception;
            });

	
		public Matcher<TV, TU> With<TU>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7, Func<TV, TU> func) =>
            new Matcher<TV, TU>(contextValue) { { new[] {  value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7 }, func } };

        public Matcher<TV, TU> With<TU>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7, TU resultValue) =>
            With( value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7, _ => resultValue);

        public MatcherMemberAccessor<TV, TC, TM> Member<TC, TM>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7, Expression<Func<TC, TM>> expression) =>
            Member(new[] { value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7}, expression);

        public Matcher<TV, TU> WithThrow<TU, TE>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7) where TE : Exception, new() =>
            With<TU>( value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7, _ =>
            {
                throw new TE();
            });

        public Matcher<TV, TU> WithThrow<TU, TE>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7, TE exception) where TE : Exception =>
            With<TU>( value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7, _ =>
            {
                throw exception;
            });

	
		public Matcher<TV, TU> With<TU>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7,  TV value8, Func<TV, TU> func) =>
            new Matcher<TV, TU>(contextValue) { { new[] {  value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7,  value8 }, func } };

        public Matcher<TV, TU> With<TU>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7,  TV value8, TU resultValue) =>
            With( value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7,  value8, _ => resultValue);

        public MatcherMemberAccessor<TV, TC, TM> Member<TC, TM>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7,  TV value8, Expression<Func<TC, TM>> expression) =>
            Member(new[] { value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7,  value8}, expression);

        public Matcher<TV, TU> WithThrow<TU, TE>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7,  TV value8) where TE : Exception, new() =>
            With<TU>( value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7,  value8, _ =>
            {
                throw new TE();
            });

        public Matcher<TV, TU> WithThrow<TU, TE>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7,  TV value8, TE exception) where TE : Exception =>
            With<TU>( value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7,  value8, _ =>
            {
                throw exception;
            });

	
		public Matcher<TV, TU> With<TU>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7,  TV value8,  TV value9, Func<TV, TU> func) =>
            new Matcher<TV, TU>(contextValue) { { new[] {  value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7,  value8,  value9 }, func } };

        public Matcher<TV, TU> With<TU>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7,  TV value8,  TV value9, TU resultValue) =>
            With( value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7,  value8,  value9, _ => resultValue);

        public MatcherMemberAccessor<TV, TC, TM> Member<TC, TM>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7,  TV value8,  TV value9, Expression<Func<TC, TM>> expression) =>
            Member(new[] { value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7,  value8,  value9}, expression);

        public Matcher<TV, TU> WithThrow<TU, TE>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7,  TV value8,  TV value9) where TE : Exception, new() =>
            With<TU>( value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7,  value8,  value9, _ =>
            {
                throw new TE();
            });

        public Matcher<TV, TU> WithThrow<TU, TE>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7,  TV value8,  TV value9, TE exception) where TE : Exception =>
            With<TU>( value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7,  value8,  value9, _ =>
            {
                throw exception;
            });

	
		public Matcher<TV, TU> With<TU>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7,  TV value8,  TV value9,  TV value10, Func<TV, TU> func) =>
            new Matcher<TV, TU>(contextValue) { { new[] {  value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7,  value8,  value9,  value10 }, func } };

        public Matcher<TV, TU> With<TU>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7,  TV value8,  TV value9,  TV value10, TU resultValue) =>
            With( value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7,  value8,  value9,  value10, _ => resultValue);

        public MatcherMemberAccessor<TV, TC, TM> Member<TC, TM>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7,  TV value8,  TV value9,  TV value10, Expression<Func<TC, TM>> expression) =>
            Member(new[] { value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7,  value8,  value9,  value10}, expression);

        public Matcher<TV, TU> WithThrow<TU, TE>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7,  TV value8,  TV value9,  TV value10) where TE : Exception, new() =>
            With<TU>( value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7,  value8,  value9,  value10, _ =>
            {
                throw new TE();
            });

        public Matcher<TV, TU> WithThrow<TU, TE>( TV value0,  TV value1,  TV value2,  TV value3,  TV value4,  TV value5,  TV value6,  TV value7,  TV value8,  TV value9,  TV value10, TE exception) where TE : Exception =>
            With<TU>( value0,  value1,  value2,  value3,  value4,  value5,  value6,  value7,  value8,  value9,  value10, _ =>
            {
                throw exception;
            });

		
	}

}
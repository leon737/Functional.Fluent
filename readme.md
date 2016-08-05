# Functional.Fluent

Functional.Fluent is a set of extension methods and classes to provide 
a more flexible and convinient way to write functional style code in C# apps.

The library supports the following:

- Maybe monad (XLinq support included)
- Result monad
- Pattern matching
- IDisposable objects `using` chaining

## Maybe monad

The monad allows the specify something that may be not there.
The library support of the monad is divided by the three parts: basic, advanced and specialized.

## Basic support of Maybe monad

To turn a value into the monadic value use the `.ToMaybe()` extension method. 
It takes the value of any type and returns the monadic value of Maybe<> type.

For example, to make Maybe type of string: `"the simple string".ToMaybe()`. 
The same works for value types as well: `5.ToMaybe()`.
The most valuable use of this approach is when the user types come into the way:

	class MyClass
	{
		public string StringField;
		public string StringField2;
		public int IntField;
	}

	new MyClass {StringField = "hello"}.ToMaybe()

You can access the members of the wrapped value by using `Value` property. 
To check wheither the monadic value contains the wrapped value or nothing you
can call `HasValue` property.

To chain the calls to the members of the wrapped value you can use the fluent syntax with
`With` and `Return` methods. 
For example: 

	new MyClass {StringField = "hello"}.ToMaybe()
		.With(x => x.StringField)
		.With(x => x.Length)
		.Value

`Return` allows to specify the default value for the case if monadic value doesn't contain the value:
	
	new MyClass().ToMaybe()
		.With(x => x.StringField)
		.Return(x => x.Length, -1)
		.Value

or even use the lambda: 
	
	new MyClass { StringField = "hello" }.ToMaybe()
		.With(x => x.StringField)
		.Return(x => x.Length, () => -1)
		.Value

You can turn code of the imperative style into the more functional way. 

To substitute the `if` statement use the `If` method:
	
	new MyClass {StringField = "hello", IntField = 10}.ToMaybe()
		.If(x => x.IntField > 5).Return(x => x.StringField, "").Value

Or `Unless` method, that is similar to `If` but invokes the function when
condition returns negative result:

	new MyClass { StringField = "hello", IntField = 10 }.ToMaybe()
		.Unless(x => x.IntField <= 5).Return(x => x.StringField, "").Value


`Do` methods behaves like `With` but it returns initial monadic value:

	int result = 0;
    new MyClass {StringField = "hello"}.ToMaybe()
		.With(x => x.StringField)
       .Do(x => result = x.Length);


`Do` can perform any number of actions one by one:

	int result = 0;
    string s = "";
    new MyClass { StringField = "hello" }.ToMaybe()
		.With(x => x.StringField)
       .Do(x => result = x.Length, x => s = new string(x.Reverse().ToArray()));


To conditionally apply some function to the monadic value use `ApplyIf` and `ApplyUnless` methods:

	new MyClass { StringField = "hello!" }.ToMaybe().
		.With(x => x.StringField)
       .ApplyIf(x => x.Length > 5, x => new string(x.Reverse().ToArray()))
       .IsNull("");

	  new MyClass { StringField = "hello" }.ToMaybe()
		.With(x => x.StringField)
       .ApplyUnless(x => x.Length > 5, x => new string(x.Reverse().ToArray()))
       .IsNull("");

To get default value in case of the monadic value does not contain the wrapped value, then you can use
`Return` method as described above or use simplified version named `IsNull`:

	new MyClass().ToMaybe()
		.With(x => x.StringField)
       .IsNull("default")

Or pass a lambda as parameter:

	new MyClass().ToMaybe().
		.With(x => x.StringField)
       .IsNull(() => "default")

Consider a set of monadic values, any of them contain wrapped value. The task is take this set and put
the first wrapped value into the processing workflow. This can be solved with use of `SelectOne` method:

    new MyClass {StringField = "hello", StringField2 = "world"}.ToMaybe()
        .SelectOne(x => x.With(z => z.StringField), x => x.With(z => z.StringField2))
        .IsNull("default");
    new MyClass { StringField2 = "world" }.ToMaybe()
        .SelectOne(x => x.With(z => z.StringField), x => x.With(z => z.StringField2))
        .IsNull("default");

## Advanced features of Maybe monad support

This section describes the advanced features like support of lists, query syntax, etc.

If you have a list of monadic values you can `lift` this list, `list of Maybe -> Maybe of list`.

    var list = new[]{ 1, 2, 3, 4, 5 };
    var maybes = list.Select(v => v.ToMaybe());
    var lifted = maybes.ToMaybe().Lift();

To access wrapped value you can use the query syntax:
            
    var o = new TestFooClass() { sValue = "test"};
    var m = o.ToMaybe();
    var r = from v in m
        from x in v.sValue
        select x.Length;

If you wrap the list in the monadic value, then you can easily iterate through the list items:

    var i = Enumerable.Range(1, 10);
    var m = i.ToMaybe();
    foreach (var e in m)
    {
       some code
    }

The monadic value that wraps the list allows to specify the filters, sorting or anything else 
that can be applied to usual `IEnumerable` value:

    var i = Enumerable.Range(1, 10);
    var m = i.ToMaybe();
    foreach (var e in m.Where(x => x % 2 == 0))
    {
        Assert.IsTrue(e % 2 == 0);
    }
   





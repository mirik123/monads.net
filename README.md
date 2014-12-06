Monads for .NET
===============

This project is forked from [sergun's monad.net](https://github.com/sergun/monads.net) project with removed excessive functionality that duplicates LINQ features or isn't necessary in read world scenarios.

**Monads for .NET** is helpers for C# which makes easier every day of your developer life. Now supports .NET 3.5-4.0, Silverlight 3-5 and Windows Phone 7.

In functional programming, a monad is a programming structure that represents computations. Monads are a kind of abstract data type constructor that encapsulate program logic instead of data in the domain model. A defined monad allows the programmer to chain actions together to build a pipeline to process data in various steps, in which each action is decorated with additional processing rules provided by the monad. Programs written in functional style can make use of monads to structure procedures that include sequenced operations, or to define some arbitrary control flows (like handling concurrency, continuations, side effects such as input/output, or exceptions).

More information about monads at <a href="http://en.wikipedia.org/wiki/Monad_(functional_programming)">Wikipedia</a>.

## Installing

1. Just copy **"Monads.cs"** file and add **"using Monads;"** to your code.
2. Install via **nuget**.

## Contribution

I'm glad to see your contributions for Monads.NET.
Just fork the project and pull request when you're ready.

## License
Released under the [MIT license](http://www.opensource.org/licenses/MIT).

## Benefits (code samples)

Before
<pre>string workPhoneCode;

if (person != null)
{
  if (person.Work != null)
  {
    if (person.Work.Phone != null)
    {
       workPhoneCode = person.Work.Phone.Code;
    }
  }
}</pre>

After
<pre>string workPhoneCode = person.With(p=>p.Work).With(w=>w.Phone).With(p=>p.Code);</pre>

## Features


Operation|Value type/Nullable value type|Reference type
---------|------------------------------|--------------
|With|When the **selector** function is not null it is executed against the source and the result is returned. When the **selector** is null then the **nullselector** is executed and the result is returned – there is no valuable reason for such scenario. It can be used as a LINQ Select analogue for single element.|**Selector** is executed only when the source is not null. When the source is null then the **nullselector** is executed. When the source is null and the **nullselector** doesn't exist the null value is returned. It can be used to eliminate if/then blocks when the source can be null and write code in one line, and also for executing an alternative action when the source is null.|
|If|Not available/No reason|When the source is not null and **condition** is true the source is returned, when **condition** is false the null value is returned.|
|Do|Not available/No reason|**Action** is executed against the source when they both are not null. When the source is null and **nullaction** exists – it is executed. In all cases the source is returned (or null value when it is null).|
|ForEachNull|When source collection is not null or empty the **action** is executed against every its element. In opposite case the **nullaction** is executed. In all cases the source collection is returned back.|When source collection is not null or empty the **action** is executed against every non null element. In opposite case when the source collection is null the **nullaction** is executed. In all cases the source collection is returned back.|
|Try|Not available/No reason|When the source is not null the **action** is executed against source inside try/catch block. When error is thrown the Tuple with source and caught Exception object returns. When everything goes fine the Tuple returns without exception.|
|Catch|Not available/No reason|Collects Tuple from Try clause and executes **handler** for Exception object when exception exists. The original source is then returned (or null if error occurred).|

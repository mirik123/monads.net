/**
 * function programming helpers for .NET LINQ
 * Copyright (c) 2015, Mark Babayev
 * MIT license
**/ 


using System;
using System.Collections.Generic;
using System.Linq;

namespace Monads
{
    public static class Monads
    {
        public static TResult With<TSource, TResult>(this TSource source, Func<TSource, TResult> selector, Func<TResult> nullselector = null) 
        {
            if (source != null && selector != null)
                return selector(source);
            else if (nullselector != null)
                return nullselector();
            else
                return default(TResult);
        }

        public static TSource If<TSource>(this TSource source, Func<TSource, bool> condition) where TSource : class
        {
            if (source != null && condition(source))
                return source;
            else
                return null;
        }

        public static TSource Do<TSource>(this TSource source, Action<TSource> action, Action nullaction = null) where TSource : class
        {
            if (source != null && action != null)
                action(source);
            else if (nullaction != null)
                nullaction();

            return source;
        }

        public static IEnumerable<TSource> ForEachNull<TSource>(this IEnumerable<TSource> source, Action<TSource> action, Action nullaction = null)
        {
            if (source != null && source.Count() > 0)
                foreach (var itm in source)
                {
                    if (itm != null)
                        action(itm);
                }
            else if (nullaction != null)
                nullaction();

            return source;
        }

        public static Tuple<TSource, Exception> Try<TSource>(this TSource source, Action<TSource> action) where TSource : class
        {
            if (source != null)
            {
                try
                {
                    action(source);
                }
                catch (Exception ex)
                {
                    return new Tuple<TSource, Exception>(source, ex);
                }

                return new Tuple<TSource, Exception>(source, null);
            }
            else
                return new Tuple<TSource, Exception>(null, null);
        }

        public static TSource Catch<TSource>(this Tuple<TSource, Exception> source, Action<Exception> handler) where TSource : class
        {
            if (source.Item2 != null)
                handler(source.Item2);

            return source.Item1;
        }
    }
}

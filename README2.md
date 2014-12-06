This project is based on sergun's monad.net with removed excessive functionality that duplicates LINQ features or isn't necessary in read world scenarios.

Operation
Value type/Nullable value type
Reference type
With
When the selector function is not null it is executed against the source and the result is returned. When the selector is null then the nullselector is executed and the result is returned – there is no  valuable reason for such scenario.

It can be used as a LINQ Select analogue for single element.
Selector is executed only when the source is not null. When the source is null then the nullselector is executed. 
When the source is null and the nullselector doesn't exist the null value is returned.

It can be used to eliminate if/then blocks when the source can be null and write code in one line, and also for executing an alternative action when the source is null.
If
Not available/No reason
When the source is not null and condition is true the source is returned, when condition is false the null value is returned.
Do
Not available/No reason
Action is executed against the source when they both are not null. When the source is null and nullaction exists – it is executed. In all cases the source is returned (or null value when it is null).
ForEachNull
When source collection is not null or empty the action is executed against every its element. In opposite case the nullaction is executed. In all cases the source collection is returned back.
When source collection is not null or empty the action is executed against every non null element. In opposite case when the source collection is null the nullaction is executed. In all cases the source collection is returned back.
Try
Not available/No reason
When the source is not null the action is executed against source inside try/catch block. When error is thrown the Tuple with source and caught Exception object returns. When everything goes fine the Tuple returns without exception.
Catch
Not available/No reason
Collects Tuple from Try clause and executes handler for Exception object when exception exists. The original source is then returned (or null if error occurred).


# Strategy
Encapsulates an algorithm inside a class
- Making each algorithm replaceable by others
- All the algorithms can work with the same data transparently
- The client can transparently work with each algorithm


![Strategy](./media/strategy.gif)

## Intent
- Define a family of algorithms, encapsulate each one, and make them interchangeable. Strategy lets the algorithm vary independently from the clients that use it.
- Capture the abstraction in an interface, bury implementation details in derived classes.

## Discussion
One of the dominant strategies of object-oriented design is the "open-closed principle". Encapsulate interface details in a base class, and bury implementation details in derived classes. Clients can then couple themselves to an interface, and not have to experience the upheaval associated with change: no impact when the number of derived classes changes, and no impact when the implementation of a derived class changes.

A generic value of the software community for years has been, "maximize cohesion and minimize coupling". The object-oriented design approach shown in figure is all about minimizing coupling. Since the client is coupled only to an abstraction (i.e. a useful fiction), and not a particular realization of that abstraction, the client could be said to be practicing "abstract coupling" . an object-oriented variant of the more generic exhortation "minimize coupling".

A more popular characterization of this "abstract coupling" principle is "Program to an interface, not an implementation".

Clients should prefer the "additional level of indirection" that an interface (or an abstract base class) affords. The interface captures the abstraction (i.e. the "useful fiction") the client wants to exercise, and the implementations of that interface are effectively hidden.

## Structure
The Interface entity could represent either an abstract base class, or the method signature expectations by the client. In the former case, the inheritance hierarchy represents dynamic polymorphism. In the latter case, the Interface entity represents template code in the client and the inheritance hierarchy represents static polymorphism.

## Rules of thumb
- Strategy is like Template Method except in its granularity.
- State is like Strategy except in its intent.
- Strategy lets you change the guts of an object. Decorator lets you change the skin.
- State, Strategy, Bridge (and to some degree Adapter) have similar solution structures. They all share elements of the 'handle/body' idiom. They differ in intent - that is, they solve different problems.
- Strategy has 2 different implementations, the first is similar to State. The difference is in binding times (Strategy is a bind-once pattern, whereas State is more dynamic).
- Strategy objects often make good Flyweights.

## Implementation
1. Identify an algorithm (i.e. a behavior) that the client would prefer to access through a "flex point".
1. Specify the signature for that algorithm in an interface.
1. Bury the alternative implementation details in derived classes.
1. Clients of the algorithm couple themselves to the interface.

## Example
A Strategy defines a set of algorithms that can be used interchangeably. Modes of transportation to an airport is an example of a Strategy. Several options exist such as driving one's own car, taking a taxi, an airport shuttle, a city bus, or a limousine service. For some airports, subways and helicopters are also available as a mode of transportation to the airport. Any of these modes of transportation will get a traveler to the airport, and they can be used interchangeably. The traveler must chose the Strategy based on trade-offs between cost, convenience, and time.
```
abstract class SortStrategy 
{
   public abstract void Sort(IList<object> list);
}

class QuickSort : SortStrategy 
{
   public override void Sort(IList<object> list) { ... }
}

class MergeSort : SortStrategy 
{
   public override void Sort(IList<object> list) { ... }
}

class SortedList 
{
   private IList<object> list = new List<object>();

   public void Sort(SortStrategy strategy) {
      // sortStrategy can be passed in constructor, i.e Dependency Injection
      sortStrategy.Sort(list);
   }
}

```
# Adapter
Converts the given class' interface into another class requested by the client.
- Wraps an existing class with a new interface
- Impedance match an oldcomponent to a new system

Allows classes to work together when this is impossible due to incompatible interfaces.
In languages with multipleinheritance it is possible toadapt to more than oneclass (a.k.a. class adapters)


![Adapter](./media/adapter.png)

## Intent
- Convert the interface of a class into another interface clients expect. Adapter lets classes work together that couldn't otherwise because of incompatible interfaces.
- Wrap an existing class with a new interface.
- Impedance match an old component to a new system

## Discussion
Reuse has always been painful and elusive. One reason has been the tribulation of designing something new, while reusing something old. There is always something not quite right between the old and the new. It may be physical dimensions or misalignment. It may be timing or synchronization. It may be unfortunate assumptions or competing standards.

It is like the problem of inserting a new three-prong electrical plug in an old two-prong wall outlet – some kind of adapter or intermediary is necessary.

Adapter is about creating an intermediary abstraction that translates, or maps, the old component to the new system. Clients call methods on the Adapter object which redirects them into calls to the legacy component. This strategy can be implemented either with inheritance or with aggregation.

Adapter functions as a wrapper or modifier of an existing class. It provides a different or translated view of that class.

## Structure
A legacy Rectangle component's display() method expects to receive "x, y, w, h" parameters. But the client wants to pass "upper left x and y" and "lower right x and y". This incongruity can be reconciled by adding an additional level of indirection – i.e. an Adapter object.
The Adapter could also be thought of as a "wrapper".

## Rules of thumb
- Adapter makes things work after they're designed; Bridge makes them work before they are.
- Bridge is designed up-front to let the abstraction and the implementation vary independently. Adapter is retrofitted to make unrelated classes work together.
- Adapter provides a different interface to its subject. Proxy provides the same interface. Decorator provides an enhanced interface.
- Adapter is meant to change the interface of an existing object. Decorator enhances another object without changing its interface. Decorator is thus more transparent to the application than an adapter is. As a consequence, Decorator supports recursive composition, which isn't possible with pure Adapters.
- Facade defines a new interface, whereas Adapter reuses an old interface. Remember that Adapter makes two existing interfaces work together as opposed to defining an entirely new one.

## Implementation
1. Identify the players: the component(s) that want to be accommodated (i.e. the client), and the component that needs to adapt (i.e. the adaptee).
1. Identify the interface that the client requires.
1. Design a "wrapper" class that can "impedance match" the adaptee to the client.
1. The adapter/wrapper class "has a" instance of the adaptee class.
1. The adapter/wrapper class "maps" the client interface to the adaptee interface.
1. The client uses (is coupled to) the new interface

## Example
The Adapter pattern allows otherwise incompatible classes to work together by converting the interface of one class into an interface expected by the clients. Socket wrenches provide an example of the Adapter. A socket attaches to a ratchet, provided that the size of the drive is the same.
```
 internal class ChemicalDatabank
    {
        // The databank 'legacy API'
        public float GetCriticalPoint(string compound, string point)
        {
            if (point == "M")
            {
                // Melting Point
            }
            else
            {
                // Boiling Point
            }
        }

        public string GetMolecularStructure(string compound)
        {
            // Returns the compound's molecular sign
        }

        public double GetMolecularWeight(string compound)
        {
            // Returns the compound's molecular weight
        }
        }
    }

internal interface ICompound
    {
        void Display();
    }

internal class RichCompound : ICompound
    {
        private readonly string chemical;

        private readonly float boilingPoint;
        private readonly float meltingPoint;
        private readonly double molecularWeight;
        private readonly string molecularFormula;

        public RichCompound(string chemical)
        {
            this.chemical = chemical;
            var bank = new ChemicalDatabank();

            this.boilingPoint = bank.GetCriticalPoint(this.chemical, "B");
            this.meltingPoint = bank.GetCriticalPoint(chemical, "M");
            this.molecularWeight = bank.GetMolecularWeight(chemical);
            this.molecularFormula = bank.GetMolecularStructure(chemical);
        }

        public void Display()
        {
            // ...
        }
    }
```
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.Animal
{
    abstract class FourLegsAnimal : IAnimal
    {
        public abstract string GetName();
    }
}

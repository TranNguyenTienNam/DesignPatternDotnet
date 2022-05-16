using FactoryMethod.Animal;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.AbstractFactory
{
    interface IAnimalFactory
    {
        IAnimal createAnimal();
    }
    abstract class AbstractAnimalFactory : IAnimalFactory
    {
        public abstract IAnimal createAnimal();
    }
}

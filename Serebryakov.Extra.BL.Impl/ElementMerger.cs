using System;
using System.Collections.Generic;
using System.Linq;
using Serebryakov.Extra.BL.Abstraction;

namespace Serebryakov.Extra.BL.Impl
{
    public class ElementMerger : IElementMerger
    {
        private ElementMerger() { }
        public static readonly ElementMerger Instance = new ElementMerger();
        public static ElementMerger Get()
        {
            return Instance;
        }

        public IEnumerable<IElement> MergeElements(IEnumerable<IElement> elements, IElement newElement)
        {
            IEnumerable<IElement> newElements = elements.SkipWhile(e => e.Number < newElement.Number)
                                .OrderBy(e => e.Number); // вторая часть коллекции, которая будет смещаться

            var prev = newElement;
            foreach(var current in newElements)
            {
                if (current.Number != prev.Number)
                {
                    break; // смещаем только до первого пропуска
                }
                current.Number++;
                prev = current;
            }

            return elements.TakeWhile(e => e.Number < newElement.Number).Append(newElement).Concat(newElements); // слияние первой части коллекции, нового элемента и смещенной части
        }
    }
}

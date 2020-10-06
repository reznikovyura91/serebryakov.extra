using System.Collections.Generic;

namespace Serebryakov.Extra.BL.Abstraction
{
    public interface IElementMerger
    {
        IEnumerable<IElement> MergeElements(IEnumerable<IElement> elements, IElement newElement);
    }
}

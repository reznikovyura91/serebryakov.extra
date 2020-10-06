using Serebryakov.Extra.BL.Abstraction;

namespace Serebryakov.Extra.BL.Impl
{
    public class Element : IElement
    {
        public int Number { get; set; }
        public string Body { get; }

        public Element(int number, string body)
        {
            Number = number;
            Body = body;
        }
    }
}

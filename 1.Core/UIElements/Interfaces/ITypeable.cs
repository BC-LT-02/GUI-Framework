namespace Todoly.Core.UIElements.Interfaces
{
    public interface ITypeable : IElement
    {
        public void Type(string keys);

        public void Clear();
    }
}

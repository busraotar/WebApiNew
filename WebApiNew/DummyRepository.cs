using WebApiNew.Interfaces;

namespace WebApiNew
{
    internal class DummyRepository : IDummyRepository
    {
        public string GetName()
        {
            throw new System.NotImplementedException();
        }
    }
}
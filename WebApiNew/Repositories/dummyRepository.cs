using WebApiNew.Interfaces;

namespace WebApiNew.Repositories
{
    public class dummyRepository : IDummyRepository 
    {
        public string GetName()
        {
            return "Yavuz";

        }
    }
}

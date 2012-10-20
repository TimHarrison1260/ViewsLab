using System.Collections.Generic;

namespace ViewsLab.Domain
{
    public interface IUserRepository
    {
        IEnumerable<User> Get();

        IEnumerable<User> Get(int pageSzie, int page, string sort);

        int Count();
    }
}

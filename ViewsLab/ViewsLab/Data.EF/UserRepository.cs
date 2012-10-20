using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ViewsLab.Domain;

namespace ViewsLab.Data.EF
{
    public class UserRepository : IUserRepository
    {
        private GCUToursCeContext context = new GCUToursCeContext();

        // All users
        public IEnumerable<User> Get()
        {
            return context.Users;
        }

        // Users with paging and sorting
        public IEnumerable<User> Get(int pageSize, int page, string sort)
        {
            // set default sort if invalid value or null supplied
            string[] sorts = { "username", "firstname", "lastname" };
            if (!sorts.Any(s => s == sort))
                sort = "username";

            // dynamically construct sort expression for OrderBy 
            var param = Expression.Parameter(typeof(User), "user");
            var sortExpression = Expression.Lambda<Func<User, object>>(Expression.Property(param, sort), param);

            return context.Users.OrderBy(sortExpression).Skip(pageSize * page).Take(pageSize);  
        }

        // Total number of users
        public int Count()
        {
            return context.Users.Count();
        }
    }

}
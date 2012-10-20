using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ViewsLab.Domain;
using ViewsLab.Models;

using System;

namespace ViewsLab.Controllers
{
    public class UserController : Controller
    {
        IUserRepository repository;

        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }

        //
        // GET: /User/

        public ActionResult Index(string pageSize, string page, string sort)
        {
            // TODO: complete this method
            //  Pass the parameter to the view in the ViewBag dictionary
            ViewBag.pageSize = pageSize;
            ViewBag.page = page;
            ViewBag.sort = sort;

            return View();
        }

        public ActionResult UserGrid(string pageSize, string page, string sort)
        {
            // TODO: complete this method
            //  Assign Default values to parameters if null.
            int pSize = (pageSize == null ? 5 : Convert.ToInt32(pageSize));

            //  The 'page' value passed in is obtained from the page bar at
            //  the bottom of the WebGrid, this is the absolute page number.
            //  However, the repository uses it as a Zero based index number
            //  as does the WebGrid, therefore, we must adjust this absolute
            //  page passed in to match the index.
            int p = (page == null ? 0 : (Convert.ToInt32(page) - 1));     
            
            //  get the page of users and the total number of users 
            //  from the repository
            var users = repository.Get(pSize, p, sort);
            int usersCount = repository.Count();
            
            //  Construct the ViewModel for the UserGrid
            var usersView = new UserGridModel()
            {
                Users = users,
                PageSize = pSize,
                CurrentPage = p,    
                RowCount = usersCount
            };
            //  Return the view model
            return PartialView(usersView);
        }

        public ActionResult UserDetail(string username)
        {
            ViewBag.Username = username;
            return View();
        }
  
    }
}

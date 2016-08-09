using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JonathanRobbins.xTendingxDB.Interfaces;

namespace JonathanRobbins.xTendingxDB.Controllers
{
    public class CommentController : Controller
    {
        private ICommentContext _commentContext;

        public CommentController(ICommentContext commentContext)
        {
            _commentContext = commentContext;
        }

        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }
    }
}
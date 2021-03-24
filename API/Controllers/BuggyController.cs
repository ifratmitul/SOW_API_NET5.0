using Infrastructure.data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var things = _context.Players.Find(42);
            if (things == null)
            {
                return NotFound();
            }

            return Ok();

        }


        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var things = _context.Players.Find(42);
            var thingsToReturn = things.ToString();
            return Ok();

        }


        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest();
        }


        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequestById(int id)
        {
            return BadRequest();


        }

    }
}
using AdoSwiggerOdev_Pastane.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdoSwiggerOdev_Pastane.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UstaController : ControllerBase
    {
        DB db = new DB();
        [HttpGet]
        public List<Usta> Index()
        {
            return db.uList();
        }
        [HttpPost]
        public string AddUsta(Usta usta)
        {
            return db.uCrud(usta);
        }
        [HttpPut("{id}")]
        public string UpdateUsta(int id,Usta usta)
        {
            usta.UstaID = id;
            return db.uCrud(usta);
        }
        [HttpDelete("{id}")]
        public string DeleteUsta(int id, Usta usta)
        {
            usta.UstaID = id;
            usta.type = "delete";
            return db.uCrud(usta);
        }
    }
}

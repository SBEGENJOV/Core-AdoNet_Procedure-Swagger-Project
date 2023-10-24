using AdoSwiggerOdev_Pastane.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdoSwiggerOdev_Pastane.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TatliController : ControllerBase
    {
        DB db=new DB();
        [HttpGet]
        public List<Tatli> Index()
        {
            return db.tList();
        }
        [HttpPost]
        public string AddTatli(Tatli tatli)
        {
            return db.tCrud(tatli);
        }
        [HttpPut("{id}")]
        public string UpdateTatli(int id,Tatli tatli)
        {
            tatli.TatliID = id;
            return db.tCrud(tatli);
        }
        [HttpDelete("{id}")]
        public string DeleteTatli(int id, Tatli tatli)
        {
            tatli.TatliID = id;
            tatli.type = "delete";
            return db.tCrud(tatli);
        }
    }
}

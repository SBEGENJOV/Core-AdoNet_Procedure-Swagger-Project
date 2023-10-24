using AdoSwiggerOdev_Pastane.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdoSwiggerOdev_Pastane.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MalzemeController : ControllerBase
    {
        DB db=new DB();
        [HttpGet]
        public List<Malzeme> Index()
        {
            return db.mList();
        }
        [HttpPost]
        public string AddMalzeme(Malzeme malzeme)
        {
            return db.mCrud(malzeme);
        }
        [HttpPut("{id}")]
            public string UpdateMalzeme(Malzeme malzeme,int id)
        {
            malzeme.MalzemeID = id;
            return db.mCrud(malzeme);
        }
        [HttpDelete("{id}")]
        public string DeleteMalzeme(int id,Malzeme malzeme)
        {
            malzeme.MalzemeID=id;
            malzeme.type = "delete";
            return db.mCrud(malzeme);
        }
    }
}

using AdoSwiggerOdev_Pastane.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace AdoSwiggerOdev_Pastane.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PastaneController : ControllerBase
    {
        DB db=new DB();
        [HttpGet]
        public List<Pastane> Index()
        {
            return db.pList();
        }
        [HttpPost]
        public string AddPastane(Pastane pastane)
        {
            return db.pCrud(pastane);
        }
        [HttpPut("{id}")]
        public string PutPastane(int id,Pastane pastane)
        {
            pastane.PastaneID = id;
            return db.pCrud(pastane);
        }
        [HttpDelete("{id}")]
        public string DeletePastane(int id,Pastane pastane)
        {
            pastane.PastaneID=id;
            pastane.type = "delete";
            return db.pCrud(pastane);
        }
    }
}

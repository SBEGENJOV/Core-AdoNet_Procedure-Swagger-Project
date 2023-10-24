using System.Data.SqlClient;
using System.Data;

namespace AdoSwiggerOdev_Pastane.Models
{
    public class DB
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-5K7HMBT\\SQLEXPRESS;Database=PastaneCoreApiDb;Integrated Security=true;");

        public string pCrud(Pastane pastane)
        {
            string islem = "";
            con.Open();
            using (SqlCommand cmd=new SqlCommand("pCrud", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("PastaneID", pastane.PastaneID);
                cmd.Parameters.AddWithValue("PastaneAD", pastane.PastaneAD);
                cmd.Parameters.AddWithValue("PastaneAdres", pastane.PastaneAdres);
                cmd.Parameters.AddWithValue("PastaneCalSay", pastane.PastaneCalSay);
                cmd.Parameters.AddWithValue("@type", pastane.type);
                cmd.ExecuteNonQuery();
            }
            con.Close();
            return islem;
        }
        public List<Pastane> pList()
        {
            List<Pastane> plist = new List<Pastane>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection= con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "pList";
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Pastane pastane = new Pastane();
                pastane.PastaneID = Convert.ToInt32(dataReader["PastaneID"]);
                pastane.PastaneAD = dataReader["PastaneAD"].ToString();
                pastane.PastaneAdres = dataReader["PastaneAdres"].ToString();
                pastane.PastaneCalSay = Convert.ToInt32(dataReader["PastaneCalSay"]);
                plist.Add(pastane);
            }
            con.Close();
            return plist;
        }
        public string uCrud(Usta usta)
        {
            string islem = "";
            con.Open();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.CommandText = "uCrud";
                cmd.Parameters.AddWithValue("UstaID", usta.UstaID);
                cmd.Parameters.AddWithValue("UstaAd", usta.UstaAd);
                cmd.Parameters.AddWithValue("UstaGorev", usta.UstaGorev);
                cmd.Parameters.AddWithValue("UstaMaas", usta.UstaMaas);
                cmd.Parameters.AddWithValue("PastaneID", usta.PastaneID);
                cmd.Parameters.AddWithValue("@type", usta.type);
                cmd.ExecuteNonQuery();
            }
            con.Close();
            return islem;
        }
        public List<Usta> uList()
        {
            List<Usta> ulist= new List<Usta>();
            SqlCommand cmd=new SqlCommand("uList",con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Usta usta = new Usta();
                usta.UstaID = Convert.ToInt32(dr["UstaID"]);
                usta.UstaAd = dr["UstaAd"].ToString();
                usta.UstaGorev = dr["UstaGorev"].ToString();
                usta.UstaMaas = Convert.ToInt32(dr["UstaMaas"]);
                usta.PastaneID = Convert.ToInt32(dr["PastaneID"]);
                ulist.Add(usta);
            }
            con.Close();
            return ulist;
        }
        public string tCrud(Tatli tatli)
        {
            string islem = "";
            con.Open();
            using(SqlCommand cmd = new SqlCommand("tCrud",con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("TatliID", tatli.TatliID);
                cmd.Parameters.AddWithValue("TatliAd", tatli.TatliAd);
                cmd.Parameters.AddWithValue("TatliFiyat", tatli.TatliFiyat);
                cmd.Parameters.AddWithValue("UstaID", tatli.UstaID);
                cmd.Parameters.AddWithValue("@type", tatli.type);
                cmd.ExecuteNonQuery();
            }
            con.Close();
            return islem;
        }
        public List<Tatli> tList()
        {
            SqlCommand cmd = new SqlCommand("tList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            List<Tatli> tatlis = new List<Tatli>();
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Tatli tatli = new Tatli();
                tatli.TatliID = Convert.ToInt32(dr["TatliID"]);
                tatli.TatliAd = dr["TatliAd"].ToString();
                tatli.TatliFiyat = Convert.ToInt32(dr["TatliFiyat"]);
                tatli.UstaID = Convert.ToInt32(dr["UstaID"]);
                tatlis.Add(tatli);
            }
            con.Close() ;
            return tatlis;
        }
        public string mCrud(Malzeme malzeme)
        {
            string islem = "";
            con.Open();
            using (SqlCommand cmd=new SqlCommand("mCrud",con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("MalzemeID",malzeme.MalzemeID);
                cmd.Parameters.AddWithValue("MalzemeListe", malzeme.MalzemeListe);
                cmd.Parameters.AddWithValue("MalzemeFiyat", malzeme.MalzemeFiyat);
                cmd.Parameters.AddWithValue("TatliID", malzeme.TatliID);
                cmd.Parameters.AddWithValue("@type", malzeme.type);
                cmd.ExecuteNonQuery();

            }
            con.Close();
            return islem;
        }
        public List<Malzeme> mList()
        {
            List<Malzeme> malzemes = new List<Malzeme>();
            SqlCommand cmd = new SqlCommand("mList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr= cmd.ExecuteReader();
            while (dr.Read())
            {
                Malzeme malzeme = new Malzeme();
                malzeme.MalzemeID = Convert.ToInt32(dr["MalzemeID"]);
                malzeme.MalzemeListe = dr["MalzemeListe"].ToString();
                malzeme.MalzemeFiyat = Convert.ToInt32(dr["MalzemeFiyat"]);
                malzeme.TatliID = Convert.ToInt32(dr["TatliID"]);
                malzemes.Add(malzeme);
            }
            con.Close();
            return malzemes;
        }
    }
}

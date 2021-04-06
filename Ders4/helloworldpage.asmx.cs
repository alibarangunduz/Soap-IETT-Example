using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
using System.Collections;

namespace Ders4
{
    /// <summary>
    /// Summary description for helloworldpage
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class helloworldpage : System.Web.Services.WebService
    {
        string[] province = { "Adana", "Adıyaman", "Afyon", "Ağrı", "Amasya", "Ankara", "Antalya", "Artvin", "Aydın", "Balıkesir",
        "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Edirne",
        "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkari", "Hatay", "Isparta",
        "İçel", "İstanbul", "İzmir", "Kars", "Kastamonu", "Kayseri", "Kırklareli", "Kırşehir", "Kocaeli", "Konya", "Kütahya",
        "Malatya", "Manisa", "Kahramanmaraş", "Mardin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Rize", "Sakarya",
        "Samsun", "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Şanlıurfa", "Uşak", "Van",
        "Yozgat", "Zonguldak", "Aksaray", "Bayburt", "Karaman", "Kırıkkale", "Batman", "Şırnak", "Bartın", "Ardahan",
        "Iğdır", "Yalova", "Karabük", "Kilis", "Osmaniye", "Düzce"
        };

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int addtwonumbers(int a, int b)
        {
            return a + b;
        }
        [WebMethod]
        public string returnCityName(int cityCode)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mytest"].ConnectionString);
            conn.Open();
            string checkuser = "select cityname from tblCity where zipCode= " + cityCode.ToString();
            SqlCommand cmd = new SqlCommand(checkuser, conn);
            string cityname = cmd.ExecuteScalar().ToString();
            conn.Close();
            return cityname;
        }
        [WebMethod]
        public DataSet getAllCities()
        {
            string sqlCties = "select cityname from tblCity";
            SqlDataAdapter da = new SqlDataAdapter(sqlCties, ConfigurationManager.ConnectionStrings["mytest"].ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        [WebMethod]
        public string getProvinceName(int monthIndex)
        {
            if (monthIndex >81 || monthIndex < 0) return "";
            return province[monthIndex-1];
        }
        [WebMethod]
        public city cityXml(int zipCode)
        {
            var sehir = new city();



            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mytest"].ConnectionString);
            conn.Open();
            string sqlCity = "select * from tblCity where zipCode=" + zipCode.ToString();
            SqlCommand cmd = new SqlCommand(sqlCity, conn);


            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                sehir.id = Int32.Parse(dr["Id"].ToString());
                sehir.zipCode = dr["zipCode"].ToString();
                sehir.cityName = dr["cityname"].ToString();
            }

            dr.Close();
            conn.Close();
            return sehir;
        }
        [WebMethod]
        public ArrayList cityListXml()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mytest"].ConnectionString);
            conn.Open();
            string sqlCity = "select * from tblCity";
            SqlCommand cmd = new SqlCommand(sqlCity, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            ArrayList sehirler = new ArrayList();
            while (dr.Read())
            {
                var sehir = new city();

                sehir.id = Int32.Parse(dr["Id"].ToString());
                sehir.zipCode = dr["zipCode"].ToString();
                sehir.cityName = dr["cityname"].ToString();
                sehir.bolge = dr["bolge"].ToString();

                sehirler.Add(sehir);
            }
            dr.Close();
            conn.Close();
            return sehirler;
        }
    }
    public class city
    {
        public int id { get; set; }
        public string cityName { get; set; }
        public string zipCode { get; set; }
        public string bolge { get; set; }
    }
}

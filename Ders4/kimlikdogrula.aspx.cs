using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ders4
{
    public partial class kimlikdogrula : System.Web.UI.Page
    {
        private bool returnValue;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Gonder_Click(object sender, EventArgs e)
        {
            NVIService.KPSPublicSoapClient tcservis = new NVIService.KPSPublicSoapClient();
            returnValue = tcservis.TCKimlikNoDogrula(Int64.Parse(txtTCKimlikNo.Value), txtAd.Value, txtSoyad.Value, Int16.Parse(txtDogumYili.Value));

            if(returnValue)
            {
                txtresult.InnerHtml = "Doğru";

            } 
            else
            {
                txtresult.InnerHtml = "Yanlış";
            }


        }
    }
}
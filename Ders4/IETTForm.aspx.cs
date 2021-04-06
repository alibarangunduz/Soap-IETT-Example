using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ders4
{
    public partial class IETTForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void HandleDurak(object sender, EventArgs e)
        {
            IETTService.ibbSoapClient  HatService = new IETTService.ibbSoapClient();
            System.Xml.Linq.XElement xElement = HatService.DurakDetay_GYY(txtGetDurak.Value);

            string XmlToString = xElement.ToString();

            StringReader ReaderXml = new StringReader(XmlToString);

            DataSet DataSetFromXml = new DataSet();

            DataSetFromXml.ReadXml(ReaderXml);

            if(DataSetFromXml.Tables.Count != 0)
            {
                DataTable dt = DataSetFromXml.Tables[0];
                txtresult.InnerHtml = ConvertDataTableToHtml(dt);
            }
            else
            {
                txtresult.InnerHtml = "Böyle bir Otobüs bilgisi bulunmamaktadır.";
            }

        }
        public static string ConvertDataTableToHtml(DataTable dt)
        {
            string html = "<table>";
            html += "<tr>";
            for(int i = 0; i<dt.Columns.Count; i++)
            {
                html += "<td>" + dt.Columns[i].ColumnName + "</td>";
            }
            html += "</tr>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "<tr>";
                for(int j = 0; j<dt.Columns.Count; j++)
                {
                    html += "<td>" + dt.Rows[i].ItemArray[j] + "</td>";
                }
                html += "</tr>";
                
            }
            html += "</table>";
            
            return html;
        }
    }
}
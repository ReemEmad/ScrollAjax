using ScrollAjax.pococlass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScrollAjax
{
    public partial class City1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {

         //   var id = Request.QueryString["id"];

            var start = int.Parse(Request.QueryString["start"]);
            // if(start!= null)
            //  {
            //    Response.Write("start is " + start);
            //  }
             var end = int.Parse(Request.QueryString["end"]);
            // if(end!=null)
            // {
            //    Response.Write("end is " + end);
            // }

            CityManager cm = new CityManager();

            var cities = cm.GetAll();

            // var city = cm.GetById(int.Parse(id));

            var Rcities = cm.getRange(start, end);

            var cityDto = Rcities.Select(c => new CityDTO
            {
                Id = c.id,
                Name =  c.name,
                Country = c.Country.name,
               
            }); 

            var serializer = new JavaScriptSerializer();
            var serializedResult = serializer.Serialize(cityDto);
          
            Response.Write(serializedResult);
        }
    }
}
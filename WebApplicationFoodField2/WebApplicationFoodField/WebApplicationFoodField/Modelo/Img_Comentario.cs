using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationFoodField.Modelo
{
    public class Img_Comentario
    {
        public string img_url { get; set; }
        public string comentario { get; set; }
        public DateTime data { get; set; }

        public Img_Comentario(string aurl, string aComen, DateTime aData)
        {
            this.img_url = aurl;
            this.comentario = aComen;
            this.data = aData;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationFoodField.Modelo
{
    public class Comentario
    {
        public int id { get; set; }
        public string comentario { get; set; }
        public int pacote_id { get; set; }
        public int cliente_id { get; set; }
        public DateTime data { get; set; }

        public Comentario()
        {
            this.id = 0;
            this.comentario = "";
            this.pacote_id = 0;
            this.cliente_id = 0;
            this.data = DateTime.Now.Date;
        }

        public Comentario(int aid, string aComen, int aPacote, int aCliente, DateTime aData)
        {
            this.id = aid;
            this.comentario = aComen;
            this.pacote_id = aPacote;
            this.cliente_id = aCliente;
            this.data = aData;
        }
    }
}
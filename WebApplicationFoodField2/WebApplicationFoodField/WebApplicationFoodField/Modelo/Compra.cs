using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationFoodField.Modelo
{
    public class Compra
    {
        public int id { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Pacote { get; set; }
        public DateTime Data_da_compra { get; set; }

        public Compra()
        {
            this.id = 0;
            this.Id_Cliente = 0;
            this.Id_Pacote = 0;
            this.Data_da_compra = DateTime.Now;
        }

        public Compra(int aid, int acliente, int apacote, DateTime adata)
        {
            this.id = aid;
            this.Id_Cliente = acliente;
            this.Id_Pacote = apacote;
            this.Data_da_compra = adata;
        }
    }
}
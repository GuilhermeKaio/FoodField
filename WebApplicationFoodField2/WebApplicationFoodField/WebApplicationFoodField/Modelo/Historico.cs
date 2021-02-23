using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationFoodField.Modelo
{
    public class Historico
    {
        public int id { get; set; }
        public DateTime Data_Compra { get; set; }
        public double Preco { get; set; }
        public double Saldo { get; set; }
        public int id_Cliente { get; set; }
        public int id_Pacote { get; set; }

        public Historico()
        {
            this.id = 0;
            this.Data_Compra = DateTime.Now;
            this.Preco = 0;
            this.Saldo = 0;
            this.id_Cliente = 0;
            this.id_Pacote = 0;
        }
        public Historico(int aid, DateTime adata, double apreco, double asaldo, int acliente, int apacote)
        {
            this.id = aid;
            this.Data_Compra = adata;
            this.Preco = apreco;
            this.Saldo = asaldo;
            this.id_Cliente = acliente;
            this.id_Pacote = apacote;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationFoodField.Modelo
{
    public class Avaliacao
    {
        public int id { get; set; }
        public int Nota { get; set; }
        public int id_Pacote{ get; set; }
        public int id_Cliente { get; set; }

        public Avaliacao()
        {
            this.id = 0;
            this.Nota = 0;
            this.id_Pacote = 0;
            this.id_Cliente = 0;
        }

        public Avaliacao(int aid, int aNota, int aPacote, int aCliente )
        {
            this.id = aid;
            this.Nota = aNota;
            this.id_Pacote = aPacote;
            this.id_Cliente = aCliente;
        }
    }
}
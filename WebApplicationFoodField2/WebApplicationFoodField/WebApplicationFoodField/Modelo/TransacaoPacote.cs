using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationFoodField.Modelo
{
    public class TransacaoPacote
    {
        public int id { get; set; }
        public int Pacote_id { get; set; }
        public int Cliente_id { get; set; }

        public TransacaoPacote()
        {
            this.id = 0;
            this.Pacote_id = 0;
            this.Cliente_id = 0;
        }

        public TransacaoPacote(int aid, int apacote, int acliente)
        {
            this.id = aid;
            this.Pacote_id = apacote;
            this.Cliente_id = acliente;
        }
    }
}
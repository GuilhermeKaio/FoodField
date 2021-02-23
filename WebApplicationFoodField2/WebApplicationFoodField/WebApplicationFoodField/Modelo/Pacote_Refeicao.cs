using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationFoodField.Modelo
{
    public class Pacote_Refeicao
    {
        public int id { get; set; }
        public int id_Pacote { get; set; }
        public int id_Refeicao { get; set; }

        public Pacote_Refeicao()
        {
            this.id = 0;
            this.id_Pacote = 0;
            this.id_Refeicao = 0;
        }

        public Pacote_Refeicao(int aid, int apacote, int arefeicao)
        {
            this.id = aid;
            this.id_Pacote = apacote;
            this.id_Refeicao = arefeicao;
        }
    }
}
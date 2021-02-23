using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationFoodField.Modelo
{
    public class Refeicao
    {
        public int id { get; set; }
        public string Ingredientes { get; set; }
        public string ModoPreparo { get; set; }
        public string Url_Imagem { get; set; }
        public string Nome { get; set; }

        public Refeicao()
        {
            //this.id = Convert.ToInt32("");
            this.id = 0;
            this.Ingredientes = "";
            this.ModoPreparo = "";
            this.Url_Imagem = "";
            this.Nome = "";
        }

        public Refeicao(int aid, string aingredientes, string amodoprepararo, string aimagem, string anome)
        {
            this.id = aid;
            this.Ingredientes = aingredientes;
            this.ModoPreparo = amodoprepararo;
            this.Url_Imagem = aimagem;
            this.Nome = anome;
        }
    }
}
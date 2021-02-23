using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationFoodField.Modelo
{
    public class Pacote
    {
            public int id { get; set; }
            public string Nome { get; set; }
            public double Preco { get; set; }
            public string Descricao { get; set; }
            public string Url_Imagem { get; set; }

            public Pacote()
            {
                //this.id = Convert.ToInt32("");
                this.id = 0;
                this.Nome = "";
                this.Preco = 0;
                this.Descricao = "";
                this.Url_Imagem = "";
            }

            public Pacote(int aid, string anome, double apreco, string adescricao, string aimg)
            {
                this.id = aid;
                this.Nome = anome;
                this.Preco = apreco;
                this.Descricao = adescricao;
                this.Url_Imagem = aimg;
            }
    }
}
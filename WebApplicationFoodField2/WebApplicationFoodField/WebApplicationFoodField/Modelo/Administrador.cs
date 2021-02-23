using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationFoodField.Modelo
{
    public class Administrador
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }

        public Administrador()
        {
            //this.id = Convert.ToInt32("");
            this.id = 0;
            this.Nome = "";
            this.Telefone = "";
            this.Email = "";
            this.Login = "";
            this.Senha = "";
            this.DataNascimento = DateTime.Now;
        }

        public Administrador( int aid, string anome, string atelefone, string aemail, string alogin, string asenha, DateTime adatanascimento)
        {
            this.id = aid;
            this.Nome = anome;
            this.Telefone = atelefone;
            this.Email = aemail;
            this.Login = alogin;
            this.Senha = asenha;
            this.DataNascimento = adatanascimento;
        }

    }
}
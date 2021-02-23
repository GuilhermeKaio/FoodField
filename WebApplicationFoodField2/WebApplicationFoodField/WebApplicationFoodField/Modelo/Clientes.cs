using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationFoodField.Modelo
{
    public class Clientes
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Login{ get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public double Saldo { get; set; }
        public string Url_Imagem { get; set; }

        public Clientes()
        {
            this.id = 0;
            this.Nome = "";
            this.CPF = "";
            this.Telefone = "";
            this.Email = "";
            this.Login = "";
            this.Senha = "";
            this.DataCadastro = DateTime.Now;
            this.Saldo = 0;
            this.Url_Imagem = "";
        }

        public Clientes(int aid, string anome, string aCPF, string atelefone, string aemail, string alogin, string asenha, DateTime acadastro, Double asaldo, string aurl)
        {
            this.id = aid;
            this.Nome = anome;
            this.Telefone = atelefone;
            this.Email = aemail;
            this.Login = alogin;
            this.Senha = asenha;
            this.CPF = aCPF;
            this.DataCadastro = acadastro;
            this.Saldo = asaldo;
            this.Url_Imagem = aurl;
        }
    }
}
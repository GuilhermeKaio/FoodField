using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationFoodField.Modelo
{
    public class Endereco
    {
        public int id { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public int Id_Cliente { get; set; }

        public Endereco()
        {
            this.id = 0;
            this.Rua = "";
            this.Numero = "";
            this.CEP = "";
            this.Bairro = "";
            this.Cidade = "";
            this.UF = "";
            this.Id_Cliente = 0;
        }

        public Endereco(int aid, string arua, string anum, string acep, string abairro, string acidade, string auf, int acliente)
        {
            this.id = aid;
            this.Rua = arua;
            this.Numero = anum;
            this.CEP = acep;
            this.Bairro = abairro;
            this.Cidade = acidade;
            this.UF = auf;
            this.Id_Cliente = acliente;
        }
    }
}
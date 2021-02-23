using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationFoodField
{
    public class Metodos_Gerais
    {
        public bool VerifyCpf(string cpf)

        {

            // Caso coloque todos os numeros iguais

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf;

            string digito;

            int soma;

            int resto;



            cpf = cpf.Trim();

            cpf = cpf.Replace(".", "").Replace("-", "");



            if (cpf.Length != 11)

                return false;



            tempCpf = cpf.Substring(0, 9);

            soma = 0;

            for (int i = 0; i < 9; i++)

                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];



            resto = soma % 11;

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;



            digito = resto.ToString();



            tempCpf = tempCpf + digito;



            soma = 0;

            for (int i = 0; i < 10; i++)

                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];



            resto = soma % 11;

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;



            digito = digito + resto.ToString();



            return cpf.EndsWith(digito);

        }
        public bool IsNull(string s)
        {
            if (s.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool validateRg(string rg)
        {
            //Elimina da string os traços, pontos e virgulas,
            rg = rg.Replace("-", "").Replace(".", "").Replace(",", "");

            //Verifica se o tamanho da string é 9
            if (rg.Length == 9)
            {
                int[] n = new int[9];

                //obtém cada um dos caracteres do rg
                n[0] = Convert.ToInt32(rg.Substring(0, 1));
                n[1] = Convert.ToInt32(rg.Substring(1, 1));
                n[2] = Convert.ToInt32(rg.Substring(2, 1));
                n[3] = Convert.ToInt32(rg.Substring(3, 1));
                n[4] = Convert.ToInt32(rg.Substring(4, 1));
                n[5] = Convert.ToInt32(rg.Substring(5, 1));
                n[6] = Convert.ToInt32(rg.Substring(6, 1));
                n[7] = Convert.ToInt32(rg.Substring(7, 1));
                n[8] = Convert.ToInt32(rg.Substring(8, 1));

                //Valida o RG
                int somaFinal = n[0] + n[1] + n[2] + n[3] + n[4] + n[5] + n[6] + n[7] + n[8];
                if (somaFinal > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        public void VerficarL(int a)
        {
            if (a == 0)
            {
                HttpContext.Current.Response.Redirect("~/WebForm2.aspx", true);
            }
        }
        public void VerificarUL(int a)
        {
            if (a > 0)
            {
                HttpContext.Current.Response.Redirect("~/WebFormPacotesListar.aspx", true);
            }
        }
        public string GetTypeImg(string s)
        {
            int a;
            a = s.Length - 1;
            while (a >= 0)
            {
                if (s.Substring(a, 1) == ".")
                {
                    s = s.Substring(a, s.Length - a);
                    a = -1;
                }
                else
                {
                    a += -1;
                }
            }
            return s;
        }

        public string VerificarDouble(double a)
        {
            if (a == Math.Round(a))
            {
                return "R$ " + a.ToString() + ",00";
            }
            else
            {
                return "R$ " + a.ToString();
            }
        }
    }
}
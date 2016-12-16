using MelhorLocadora.Dominio;
using MelhorLocadora.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelhorLocadora.App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Digite o endereço de um arquivo válido e aperte o enter.");
                Console.WriteLine(string.Format("exemplo : {0}", Path.Combine(Environment.CurrentDirectory, "ArquivoExemplo.txt")));
                string[] fileContent = File.ReadAllText(Console.ReadLine()).Trim().Split(':');
                TipoCliente tipoCliente = (TipoCliente)Enum.Parse(typeof(TipoCliente), fileContent[0].Trim());
                int qtdPassageiros = Convert.ToInt32(fileContent[1].Trim());
                var teste = fileContent[2].Split(',').Select(o => o.Trim().Split(' ').First());
                List <DateTime> datas = fileContent[2].Split(',').Select(o => DateTime.ParseExact(o.Trim().Split(' ').First(), "ddMMMyyyy", CultureInfo.InvariantCulture)).ToList();
                Console.Write(UoW.Instance.LocadoraBusiness.CalculaMelhorLocadora(tipoCliente, qtdPassageiros, datas).ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}

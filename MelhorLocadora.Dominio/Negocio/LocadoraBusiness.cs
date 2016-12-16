using MelhorLocadora.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelhorLocadora.Dominio.Negocio
{
    /// <summary>
    /// Implementação da camada de negócio das locadoras
    /// </summary>
    public class LocadoraBusiness : ILocadoraBusiness
    {
        /// <summary>
        /// Representa o repositório de Locadoras disponíveis
        /// </summary>
        List<Locadora> Locadoras = new List<Locadora>();

        /// <summary>
        /// Representa o repositório com os tipos de carro x quantidade máxima de passageiros 
        /// </summary>
        Dictionary<TipoCarro, int> TiposDeCarro = new Dictionary<TipoCarro, int>()
        {
            { TipoCarro.Esportivo, 2 },
            { TipoCarro.Compacto, 4 },
            { TipoCarro.SUV, 7 }
        };

        public LocadoraBusiness()
        {
            InicializarLocadoras();
        }

        /// <summary>
        /// Calcula qual é a melhor locadora dado um tipo de cliente, quantidade de passageiros e datas da locacao
        /// </summary>
        public Locadora CalculaMelhorLocadora(TipoCliente tipoCliente, int QuantidadePassageiros, List<DateTime> Datas)
        {
            //Executa as validações
            ValidaQuantidadePassageiros(QuantidadePassageiros);

            //Filtra as locadoras possíveis
            IEnumerable<Locadora> LocadorasPossiveis = Locadoras.Where(o => TiposDeCarro[o.TipoCarro] >= QuantidadePassageiros);

            //Calcula o preços das locadora possíveis
            Dictionary<Locadora, double> precoLocadoras = new Dictionary<Locadora, double>();

            foreach (Locadora locadoraPossivel in LocadorasPossiveis)
            {
                if (tipoCliente == TipoCliente.Normal)
                    precoLocadoras.Add(locadoraPossivel, Datas.Sum(o => locadoraPossivel.TaxasComum[o.DayOfWeek]));
                else if (tipoCliente == TipoCliente.Premium)
                    precoLocadoras.Add(locadoraPossivel, Datas.Sum(o => locadoraPossivel.TaxasPremium[o.DayOfWeek]));
            }

            //Retorna a de menor preço, se houver
            if (precoLocadoras.Count() > 0)
                return precoLocadoras.OrderBy(o => o.Value).First().Key;
            else
                return null;
        }

        private void ValidaQuantidadePassageiros(int QuantidadePassageiros)
        {
            if (QuantidadePassageiros < 1 || TiposDeCarro.Values.Max() < QuantidadePassageiros)
                throw new ArgumentOutOfRangeException("Não existe tipo de carro que suporte esta quantidade de passageiros");
        }

        private void InicializarLocadoras()
        {
            Locadora southCar = new Locadora();
            southCar.Carro = "FIAT UNO";
            southCar.Nome = "SouthCar";
            southCar.TipoCarro = TipoCarro.Compacto;
            AtualizaTaxa(southCar.TaxasComum, 210, 200);
            AtualizaTaxa(southCar.TaxasPremium, 150, 90);

            Locadora westCar = new Locadora();
            westCar.Carro = "FERRARI";
            westCar.Nome = "WestCar";
            westCar.TipoCarro = TipoCarro.Esportivo;
            AtualizaTaxa(westCar.TaxasComum, 530, 200);
            AtualizaTaxa(westCar.TaxasPremium, 150, 90);

            Locadora northCar = new Locadora();
            northCar.Carro = "NAVIGATOR";
            northCar.Nome = "NorthCar";
            northCar.TipoCarro = TipoCarro.SUV;
            AtualizaTaxa(northCar.TaxasComum, 630, 600);
            AtualizaTaxa(northCar.TaxasPremium, 580, 590);

            Locadoras.Add(southCar);
            Locadoras.Add(westCar);
            Locadoras.Add(northCar);
        }

        private static void AtualizaTaxa(Dictionary<DayOfWeek, double> taxas, double precoDiaDeSemana, double precoFds)
        {
            taxas[DayOfWeek.Monday] = precoDiaDeSemana;
            taxas[DayOfWeek.Tuesday] = precoDiaDeSemana;
            taxas[DayOfWeek.Wednesday] = precoDiaDeSemana;
            taxas[DayOfWeek.Thursday] = precoDiaDeSemana;
            taxas[DayOfWeek.Friday] = precoDiaDeSemana;
            taxas[DayOfWeek.Saturday] = precoFds;
            taxas[DayOfWeek.Sunday] = precoFds;
        }
    }
}

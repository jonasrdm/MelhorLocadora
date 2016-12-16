using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelhorLocadora.Dominio.Entidade
{
    /// <summary>
    /// Classe que representa uma locadora
    /// </summary>
    public class Locadora
    {
        /// <summary>
        /// Nome da Locadora
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Carro disponível na locadora
        /// </summary>
        public string Carro { get; set; }

        /// <summary>
        /// Taxas para cliente comum
        /// </summary>
        public Dictionary<DayOfWeek, double> TaxasComum { get; set; }

        /// <summary>
        /// Taxas para cliente premium (cartão fidelidade)
        /// </summary>
        public Dictionary<DayOfWeek, double> TaxasPremium { get; set; }

        /// <summary>
        /// Tipo do carro
        /// </summary>
        public TipoCarro TipoCarro { get; set; }

        public Locadora()
        {
            InicializaTaxas();
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Carro, Nome);
        }

        private void InicializaTaxas()
        {
            TaxasComum = new Dictionary<DayOfWeek, double>();
            TaxasPremium = new Dictionary<DayOfWeek, double>();

            foreach (DayOfWeek dayOfWeek in Enum.GetValues(typeof(DayOfWeek)))
            {
                TaxasComum.Add(dayOfWeek, 0);
                TaxasPremium.Add(dayOfWeek, 0);
            }
        }
    }
}

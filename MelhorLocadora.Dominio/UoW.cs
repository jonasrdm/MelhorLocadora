using MelhorLocadora.Dominio.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelhorLocadora.Dominio
{
    /// <summary>
    /// Unidade de trabalho que agrupa as entidades de negócio
    /// </summary>
    public class UoW
    {
        /// <summary>
        /// Camada de negócio das locadoras
        /// </summary>
        public ILocadoraBusiness LocadoraBusiness { get; }

        private static UoW Instancia = null;
        private UoW()
        {
            LocadoraBusiness = new LocadoraBusiness();
        }

        /// <summary>
        /// Singleton
        /// </summary>
        public static UoW Instance
        {
            get
            {
                if (Instancia == null)
                {
                    Instancia = new UoW();
                }
                return Instancia;
            }
        }
    }
}

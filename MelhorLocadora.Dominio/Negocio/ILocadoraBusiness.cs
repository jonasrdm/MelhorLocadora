using MelhorLocadora.Dominio.Entidade;
using System;
using System.Collections.Generic;

namespace MelhorLocadora.Dominio.Negocio
{
    /// <summary>
    /// Intercade da camada de negócio de locadoras
    /// </summary>
    public interface ILocadoraBusiness
    {
        /// <summary>
        /// Calcula qual é a melhor locadora
        /// </summary>
        Locadora CalculaMelhorLocadora(TipoCliente TipoCliente, int QuantidadePassageiros, List<DateTime> Datas);
    }
}
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MelhorLocadora.Dominio;
using MelhorLocadora.Dominio.Entidade;
using System.Globalization;
using System.Collections.Generic;

namespace MelhorLocadora.Teste
{
    /// <summary>
    /// Classe de testes unitários da camada de negócio de locadoras
    /// </summary>
    [TestClass]
    public class LocadoraBusinessTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Não existe tipo de carro que suporte esta quantidade de passageiros")]
        public void TestaQuantidadePassageiros()
        {
            UoW.Instance.LocadoraBusiness.CalculaMelhorLocadora(TipoCliente.Normal, -1, new List<DateTime>() { DateTime.Now });
        }

        [TestMethod]
        public void TestaInputExemplo1()
        {
            List<DateTime> datas = ConvertDateStrings("16/03/2009", "17/03/2009", "18/03/2009");
            Locadora locadora = UoW.Instance.LocadoraBusiness.CalculaMelhorLocadora(TipoCliente.Normal, 1, datas);
            Assert.AreEqual(locadora.ToString(), "FIAT UNO: SouthCar");
        }

        [TestMethod]
        public void TestaInputExemplo2()
        {
            List<DateTime> datas = ConvertDateStrings("01/09/2009", "02/09/2009");
            Locadora locadora = UoW.Instance.LocadoraBusiness.CalculaMelhorLocadora(TipoCliente.Premium, 6, datas);
            Assert.AreEqual(locadora.ToString(), "NAVIGATOR: NorthCar");
        }

        public static List<DateTime> ConvertDateStrings(params string[] dateStrings)
        {
            List<DateTime> datas = new List<DateTime>();

            foreach (string dateString in dateStrings)
                datas.Add(DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture));

            return datas;
        }
    }
}

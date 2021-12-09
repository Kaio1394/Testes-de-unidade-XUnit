using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.LeilaoOnline.ConsoleApp
{
    public class LeilaoTeste
    {
        [Theory] //Passando dados de entrada
        [InlineData(1300, new double[]{1000, 1200, 1210, 1300})] //Dados de entrada 1
        [InlineData(1100, new double[]{1000, 1200, 1210, 1100})] //Dados de entrada 2
        [InlineData(800, new double[] {800})] //Dados de entrada 3
        public void LeitaoCOmTresClientes(
            double valorEsperado,
            double[] ofertas)
        {
            //Arranje - cenário
            //Dado leilão com pelo menos 1 lance..
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fuladno", leilao);
            var maria = new Interessada("Maria", leilao);
            var kaio = new Interessada("Kaio", leilao);

            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(fulano, valor);
            }        

            //Act - método sob teste
            //Quando o pregão termina.
            leilao.TerminaPregao();

            //Assert
            //Então o valor eseprado é o maior valor dado.
            //      E o cliente ganhador é o que deu o maior lance.

            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }
       
    }
}

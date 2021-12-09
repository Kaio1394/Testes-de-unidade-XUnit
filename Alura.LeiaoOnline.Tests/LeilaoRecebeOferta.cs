using Alura.LeilaoOnline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.LeiaoOnline.Tests
{
    public class LeilaoRecebeOferta
    {
        [Fact]
        public void NaoAceitaProximoLanceDadoMesmoClienteRealizouUltimoLance()
        {
            //Arranje - cenário
            var leilao = new Leilao("Van Gogh");
            leilao.IniciaPregao();
            var fulano = new Interessada("Fuladno", leilao);
          
            //Act - método sob teste
            leilao.RecebeLance(fulano, 900);
            
            //Quando o pregão termina.
            leilao.TerminaPregao();

            //Assert
            //Então o valor eseprado é o maior valor dado.
            //      E o cliente ganhador é o que deu o maior lance.
            var valorEsperado = 1;
            var valorObtido = leilao.Lances.Count();
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LancaInvalidOperationExceptionDadoPregaoNaoIniciado()
        {
            //Arranje - cenário
            //Dado leilão com pelo menos 1 lance..
            var leilao = new Leilao("Van Gogh");

            //Act - método sob teste
            //Quando o pregão termina.
            //Assert para excessão.
            Assert.Throws<InvalidOperationException>(
                () => leilao.TerminaPregao()  
            );

            //Assert
            //Então o valor eseprado é o maior valor dado.
            //      E o cliente ganhador é o que deu o maior lance.

            var valorObtido = leilao.Ganhador.Valor;
        }

        [Theory]
        [InlineData(4, new double[] {1000, 1200, 1400, 1300})]
        [InlineData(2, new double[] {800, 900})]
        public void NaoPermiteNovosLancesDadoAposLeilaoFinalizado(int qtdeEsperada, double[] ofertas )
        {
            //Arranje - cenário
            var leilao = new Leilao("Van Gogh");
            leilao.IniciaPregao();
            var fulano = new Interessada("Fuladno", leilao);
            var kaio = new Interessada("Kaio", leilao);

            for (int i = 0; i < ofertas.Length; i++)
            {
                if(i%2 == 0)
                {
                    leilao.RecebeLance(fulano, ofertas[i]);
                }
                else
                {
                    leilao.RecebeLance(kaio, ofertas[i]);
                }
            }

            leilao.TerminaPregao();
            //Act - método sob teste
            //Quando o pregão termina.
            leilao.RecebeLance(fulano, 1000);

            //Assert
            //Então o valor eseprado é o maior valor dado.
            //      E o cliente ganhador é o que deu o maior lance.
            var qtdeObtido = leilao.Lances.Count();
            Assert.Equal(qtdeEsperada, qtdeObtido);
        }
    }
}

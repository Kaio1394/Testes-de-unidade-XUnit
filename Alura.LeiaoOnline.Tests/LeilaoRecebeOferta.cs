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
        public void NaoPermiteNovosLancesDadoAposLeilaoFinalizado()
        {
            //Arranje - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fuladno", leilao);
            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(fulano, 900);
            

            leilao.TerminaPregao();
            //Act - método sob teste
            //Quando o pregão termina.
            leilao.RecebeLance(fulano, 1000);

            //Assert
            //Então o valor eseprado é o maior valor dado.
            //      E o cliente ganhador é o que deu o maior lance.
            var valorEsperado = 2;
            var valorObtido = leilao.Lances.Count();
            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}

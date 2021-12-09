using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Arranje - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fuladno", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert
            var esperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;
            Console.WriteLine(leilao.Ganhador.Valor);
        }
        
    }
}

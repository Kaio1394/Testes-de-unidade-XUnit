using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline
{
    public class Leilao
    {
        public enum EstadoLeilao
        {
            LeilaoAntesDoPregao,
            LeilaoEmAndamento,
            LeilaoFInalizado
        }
        private IList<Lance> _lances;
        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }
        public EstadoLeilao Estado { get; private set; }
        private Interessada _ultimoCliente; 

        public Leilao(string peca)
        {
            Peca = peca;
            _lances = new List<Lance>();
            Estado = EstadoLeilao.LeilaoAntesDoPregao;
        }
        private bool LanceAceito(Interessada cliente, double valor)
        {
            return Estado == EstadoLeilao.LeilaoEmAndamento && cliente != _ultimoCliente;
        }
        public void RecebeLance(Interessada cliente, double valor)
        {
            if (LanceAceito(cliente, valor))
            {
                _lances.Add(new Lance(cliente, valor));
                _ultimoCliente = cliente;
            }
            
        }

        public void IniciaPregao()
        {
            Estado = EstadoLeilao.LeilaoEmAndamento;
        }

        public void TerminaPregao()
        {
            if(Estado != EstadoLeilao.LeilaoEmAndamento)
            {
                throw new InvalidOperationException();
            }
            Ganhador = Lances
                .DefaultIfEmpty(new Lance(null, 0))
                .OrderBy(l => l.Valor)
                .LastOrDefault();
            Estado = EstadoLeilao.LeilaoFInalizado;
        }
    }
}

using System;
using tabuleiro;


namespace xadrez
{
    class Partida
    {

        public Tabuleiro tab { get;  private set; }
        private int turno;
        private Cor jogadorAtual;
        public bool terminada { get; private set; }

        public Partida()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            colocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQtdMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
        }

        private void colocarPecas()
        {
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c',1).ToPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('a', 2).ToPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('d', 5).ToPosicao());
            tab.colocarPeca(new  Torre(tab, Cor.Branca), new PosicaoXadrez('a', 6).ToPosicao());
        }
    }
}

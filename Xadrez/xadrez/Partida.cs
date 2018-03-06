using System;
using tabuleiro;


namespace xadrez
{
    class Partida
    {

        public Tabuleiro tab { get; private set; }
        public int turno {get; private set;}
        public Cor jogadorAtual { get; private set; }
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

        private void realizaJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino);
            turno++;
            mudaJogador();
            
        }

        public void validarPosicaodeOrigem(Posicao pos)
        {
            if (tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição escolhida");
            }
            if (jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("A peça escolhida não é sua");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos Possiveis");
            }            

        }

        public void validarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).podeMoverDestino(destino))
            {
                throw new TabuleiroException("Posição de destino inváçida");
            }
        }

        private void mudaJogador()
        {
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
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

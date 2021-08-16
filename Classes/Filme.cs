using System;

namespace DIO.Series
{
    public class Filme : EntidadeBase
    {
        //Atributos da Classe
        private Genero Genero { get; set; }
        private string Nome { get; set; }
        private string AtorPrincipal { get; set; }
        private string AtrizPrincipal { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }
        //Metodos da Classe

        public Filme(int id, Genero genero, string nome, string atorPrincipal, string atrizPrincipal, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Nome = nome;
            this.AtorPrincipal = atorPrincipal;
            this.AtrizPrincipal = atrizPrincipal;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "               Gênero: " + this.Genero + Environment.NewLine;
            retorno += "                 Nome: " + this.Nome + Environment.NewLine;
            retorno += "       Ator Principal: " + this.AtorPrincipal + Environment.NewLine;
            retorno += "      Atriz Principal: " + this.AtrizPrincipal + Environment.NewLine;
            retorno += "        Ano de Inicio: " + this.Ano + Environment.NewLine;
            retorno += "             Excluido: " + this.Excluido;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Nome;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }
        public void excluir()
        {
            this.Excluido = true;
        }
    }
}
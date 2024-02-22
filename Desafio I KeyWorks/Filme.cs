using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_I_KeyWorks
{
    public class Filme
    {
        public Filme(string titulo, string genero, string ano, string avaliacao)
        {
            Titulo = ValidarTitulo(titulo);    
            Genero = ValidarGenero(genero); 
            Ano = ValidarAno(ano);
            Avaliacao = ValidarAvaliacao(avaliacao);
        }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int Ano { get; set; }
        public double Avaliacao { get; set; }

        public static string ValidarTitulo(string titulo)
        {
            if (string.IsNullOrWhiteSpace(titulo))
            throw new Exception("Insira um título válido!");
            return titulo;
        }
        public static string ValidarGenero(string genero)
        {
            if (string.IsNullOrWhiteSpace(genero))
                throw new Exception("Insira um gênero válido!");
            return genero;
        }
        public static int ValidarAno(string entrada)
        {
            var anoValido = int.TryParse(entrada, out int ano);
            if (anoValido) return ano;
            throw new Exception("O ano inserido não é válido, insira um ano válido!");
        }
        public static int ValidarAvaliacao(string entrada)
        {
            var avaliacaoValida = int.TryParse(entrada, out int avaliacao);
            if (avaliacaoValida && avaliacao > 0 && avaliacao < 6) return avaliacao;
            throw new Exception("Insira uma avaliação entre 1 e 5!");
        }
    }
}

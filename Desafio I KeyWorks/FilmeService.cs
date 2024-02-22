using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Desafio_I_KeyWorks
{
    public class FilmeService
    {
        public List<Filme> listaDeFilmes = new();

        public void Adicionar()
        {
            Console.Write("Digite o Título do filme: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite o gênero do filme: ");
            string genero = Console.ReadLine();

            Console.Write("Digite o ano de lançamento do filme: ");
            string ano = Console.ReadLine();

            Console.Write("Digite a avaliação do filme: ");
            string avaliacao = Console.ReadLine();

            Filme novoFilme = new(titulo, genero, ano, avaliacao);
            listaDeFilmes.Add(novoFilme);
            Console.Clear();
            Console.WriteLine("Filme adicionado com sucesso!\n");
        }

        public void Listar()
        {
            string filmes = JsonConvert.SerializeObject(listaDeFilmes, Formatting.Indented);
            Console.WriteLine(filmes);
        }

        public void Atualizar()
        {
            Console.Write("Digite o nome do filme que deseja atualizar: ");
            string titulo = Console.ReadLine();
            var filme = listaDeFilmes.FirstOrDefault(filme => filme.Titulo == titulo);

            if (filme == null)
                throw new Exception("Filme não encontrado");

            Console.Write("Digite o novo Título do filme: ");
            string novoTitulo = Console.ReadLine();

            Console.Write("Digite o novo gênero do filme: ");
            string novoGenero = Console.ReadLine();

            Console.Write("Digite o novo ano de lançamento do filme: ");
            string novoAno = Console.ReadLine();

            Console.Write("Digite a nova avaliação do filme: ");
            string novaAvaliacao = Console.ReadLine();


            listaDeFilmes = listaDeFilmes
                .Select(filme =>
                {
                    if (filme.Titulo == titulo)
                    {
                        filme.Titulo = Filme.ValidarTitulo(novoTitulo);
                        filme.Genero = Filme.ValidarGenero(novoGenero);
                        filme.Ano = Filme.ValidarAno(novoAno);
                        filme.Avaliacao = Filme.ValidarAvaliacao(novaAvaliacao);
                    }
                    return filme;
                })
                .ToList();
        }
        
        public void Excluir()
        {
            Console.Write("Insira o nome do filme que você deseja excluir: ");
            string titulo = Console.ReadLine();
            var filme = listaDeFilmes.FirstOrDefault(filme => filme.Titulo == titulo);
            if (filme == null)
                throw new Exception("Filme não encontrado");
            listaDeFilmes.Remove(filme);
            Console.Clear();
            Console.WriteLine("Filme removido com sucesso");
        }

        public void Pesquisar()
        {
            Console.Write("Insira o nome do filme que você deseja pesquisar: ");
            string titulo = Console.ReadLine();
            var filme = listaDeFilmes.FirstOrDefault(filme => filme.Titulo == titulo);
            if (filme == null)
                throw new Exception("Filme não encontrado");
            string filmeEncontrado = JsonConvert.SerializeObject(filme, Formatting.Indented);
            Console.Clear();
            Console.WriteLine(filmeEncontrado);
        }      
    }
}

//Desafio KeyWorks
using Desafio_I_KeyWorks;

int ValidarEntrada(string entrada)
{
    var opcaoValida = int.TryParse(entrada, out int opcao);
    if (opcaoValida && opcao > 0 && opcao < 6) return opcao;
    throw new Exception("Opção inválida");
}

FilmeService filmeService = new();
void ExibirMenu()
{
    Console.WriteLine("==== Streamberry ====\n");
    Console.WriteLine("Digite o número da opção desejada");

    Console.WriteLine("\n1. Adicionar");
    Console.WriteLine("2. Listar");
    Console.WriteLine("3. Atualizar");
    Console.WriteLine("4. Deletar");
    Console.WriteLine("5. Pesquisar\n");

    string entrada = Console.ReadLine();
    try
    {
        int opcao = ValidarEntrada(entrada);
        switch (opcao)
        {
            case 1:
                try
                {
                    filmeService.Adicionar();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                };
                ExibirMenu();
                break;
            case 2:
                try
                {
                    filmeService.Listar();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                };
                ExibirMenu();
                break;
            case 3:
                try
                {
                    filmeService.Atualizar();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                };
                ExibirMenu();
                break;
            case 4:
                try
                {
                    filmeService.Excluir();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                };
                ExibirMenu();
                break;
            case 5:
                try
                {
                    filmeService.Pesquisar();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                };
                ExibirMenu();
                break;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message + "\n");
        ExibirMenu();
    };

}

ExibirMenu();

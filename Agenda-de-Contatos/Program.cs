using System.Runtime.CompilerServices;

class Contato
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public Contato (string nome, string telefone) 
    {
        Nome = nome;
        Telefone = telefone;
    }
}
class Agenda
{
    public List<Contato> ListaContato = new List<Contato>();
    public void AdicionarContato()
    {
        int opcao;
        while (true) 
        {
            try
            {
                Console.WriteLine("Informe o nome do contato que deseja adicionar ou 0 para voltar");
                string nome = Console.ReadLine();
                if (nome == "0")
                {
                    Console.Clear();
                    break;
                }
                Console.WriteLine("Informe o número do contato que deseja adicionar");
                string telefone = Console.ReadLine();
                Contato novocontato = new Contato(nome, telefone);
                ListaContato.Add(novocontato);
                Console.WriteLine("Contato salvo com sucesso!");
                Pausa.Pausar();
                break;
            }
            catch (Exception ex) 
            {
                Erro.ErroCatch(ex);
                continue;
            }
        }
    }
    public void ListarContato()
    {
        string nome;
        string telefone;
        Console.WriteLine("| Nome | Numero |");
        foreach (var contato in ListaContato)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine($"| {contato.Nome} | {contato.Telefone}");
            Console.WriteLine("----------------------------");
        }
        Pausa.Pausar();
    }
    public void BuscarContato()
    {
        string opcao;
        while (true)
        {
            try
            {
                bool encontrado = false;
                Console.WriteLine("Informe o nome do contato que deseja pesquisar ou digite 0 para voltar");
                opcao = Console.ReadLine();
                if(opcao == "0")
                {
                    Console.Clear();
                    break;
                }
                foreach (var contato in ListaContato)
                {
                    if (opcao == contato.Nome)
                    {
                        encontrado = true;
                        Console.WriteLine("Contato encontrado!");
                        Console.WriteLine($"| {contato.Nome} | {contato.Telefone} |");
                        Pausa.Pausar();
                        break;
                    }
                }
                if (encontrado == false)
                {
                    Erro.ErroValorNaoEncontrado();
                    Pausa.Pausar();
                    continue;
                }
                break;
            }
            catch (Exception ex)
            {
                Erro.ErroCatch(ex);
                continue;
            }
        }
    }
    public void RemoverContato()
    {
        string opcao;
        while (true)
        {
            try
            {
                bool encontrado = false;
                Console.WriteLine("Informe o nome do contato que deseja remover ou 0 para voltar");
                opcao = Console.ReadLine();
                if (opcao == "0")
                {
                    Console.Clear();
                    break;
                }
                for (int i = ListaContato.Count - 1; i >= 0; i--)
                {
                    if (opcao == ListaContato[i].Nome)
                    {
                        encontrado = true;
                        Console.WriteLine($"Contato {ListaContato[i].Nome} e telefone {ListaContato[i].Telefone} removido com sucesso!");
                        ListaContato.RemoveAt(i);
                        Pausa.Pausar();
                        break;
                    }
                }
                if (encontrado == false)
                {
                    Erro.ErroValorNaoEncontrado();
                    Pausa.Pausar();
                    continue;
                }
                break;
            }
            catch (Exception ex)
            {
                Erro.ErroCatch(ex);
                continue;
            }
        }
    }
}

class Erro
{
    public static void ErroCatch(Exception ex)
    {
        Console.WriteLine($"Erro: {ex.Message}");
        Console.WriteLine("Por favor tente novamente");
        Pausa.Pausar();
    }
    public static void ErroValorNaoEncontrado()
    {
        Console.WriteLine("Informe um valor válido!");
        Pausa.Pausar();
    }
}

class Sair
{
    public static void SairDoApp()
    {
        Console.WriteLine("Volte sempre!");
        Environment.Exit(0);
    }
}

class Pausa
{
    public static void Pausar()
    {
        Console.Write("Pressione qualquer tecla para prosseguir...");
        Console.ReadKey();
        Console.Clear();
    }
}

class Menu
{
    public static void ExibirMenu()
    {
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("0 - Sair");
        Console.WriteLine("1 - Adicionar Contato");
        Console.WriteLine("2 - Ver Contatos");
        Console.WriteLine("3 - Buscar Contato");
        Console.WriteLine("4 - Remover Contato");
        Console.WriteLine("----------------------------------------------");
    }
}

class Program
{
    static void Main()
    {
        Agenda agenda = new Agenda();
        int opcao;
        while (true)
        {
            try
            {
                Console.WriteLine("==================== Seja bem-vindo ====================");
                Menu.ExibirMenu();
                Console.WriteLine("Informe o número relacionado a opção que deseja");
                opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 0:
                        Console.Clear();
                        Sair.SairDoApp();
                        break;

                    case 1:
                        Console.Clear();
                        agenda.AdicionarContato();
                        break;

                    case 2:
                        Console.Clear();
                        agenda.ListarContato();
                        break;

                    case 3:
                        Console.Clear();
                        agenda.BuscarContato();
                        break;

                    case 4:
                        Console.Clear();
                        agenda.RemoverContato();
                        break;

                    default:
                        Console.WriteLine("Informe um valor correto");
                        Pausa.Pausar();
                        continue;
                }
            }
            catch (Exception ex) 
            {
                Erro.ErroCatch(ex);
                continue;
            }
            
        }
        
    }
}
using ConsoleApp1.Entidades.Enums;
using ConsoleApp1.Entidades;


//int status1 = (int) StatusPedido.Processando;
//string status2 = StatusPedido.Enviado.ToString();
//StatusPedido status3 = (StatusPedido) 3;
//StatusPedido status4 = Enum.Parse<StatusPedido>("Cancelado");

//Console.WriteLine(status);
//Console.WriteLine($"Codigo do status Processando: {status1}");
//Console.WriteLine($"Status 2: {status2}");
//Console.WriteLine($"Status 3: {status3}");
//Console.WriteLine($"Status 4: {status4}");

//Pedido pedido = new Pedido()
//{
//    Id = 1,
//    DataPedido = DateTime.Now,
//    Valor = 235.8,
//    Status = StatusPedido.AguardandoPagamento,
//    Pagamento = FormaPagamento.CartaoDebito
//};

//Console.WriteLine(pedido);

List<Produto> produtos = new List<Produto>();
List<Vendedor> vendedores = new List<Vendedor>();
List<Pedido> pedidos = new List<Pedido>();
List<Gerente> gerentes = new List<Gerente>();
List<Funcionario> funcionarios = new List<Funcionario>();

int opcao = 0;

do
{
    Console.WriteLine("1 - Cadastrar Produto");
    Console.WriteLine("2 - Cadastrar Funcionario");
    Console.WriteLine("3 - Efetuar Venda");
    Console.WriteLine("4 - Listar Produtos");
    Console.WriteLine("5 - Listar Funcionarios");
    Console.WriteLine("6 - Listar Pedidos");
    Console.WriteLine("7 - Calcular Pagamento de Funcionario");
    Console.WriteLine("8 - Sair");
    Console.Write("Opcao: ");

    opcao = int.Parse(Console.ReadLine());

    Console.Clear();

    switch (opcao)
    {
        case 1:
            Console.WriteLine("Cadastrar Produto");
            Produto produto = new Produto();

            Console.Write("Id: ");
            produto.Id = int.Parse(Console.ReadLine());

            Console.Write("Nome: ");
            produto.Nome = Console.ReadLine();

            Console.Write("Valor: ");
            produto.Valor = double.Parse(Console.ReadLine());

            produtos.Add(produto);
            break;

        case 2:
            Console.WriteLine("Digite V para vendedor: " +
                              "Digite G para Gerente: ");

            string TipoFuncioanrio = Console.ReadLine().ToUpper();
            
            Console.Write("Nome: ");
            string Nome = Console.ReadLine();

            Console.Write("Matricula: ");
            string Matricula = Console.ReadLine();

            Console.Write("Salario: ");
            double Salario = double.Parse(Console.ReadLine());

            if (TipoFuncioanrio == "V")
            {
                Vendedor vendedor = new Vendedor(Nome, Matricula, Salario);
                funcionarios.Add(vendedor);
            }
            if (TipoFuncioanrio == "G")
            {
                Gerente gerente = new Gerente(Nome, Matricula, Salario);
                funcionarios.Add(gerente);

            }
            //else
            //{
            //    Console.WriteLine("Digite V para vendedor: " +
            //                  "Digite G para Gerente: ");
            //}          

            break;

        case 3:
            Console.WriteLine("Efetuar Venda");
            Pedido pedido = new Pedido();

            Console.Write("Matricula do Funcionario: ");
            string matriculaFuncionario = (Console.ReadLine());

            pedido.Funcionario = funcionarios.Find(funcionario => funcionario.Matricula == matriculaFuncionario);

            Console.Write("Quantos itens irão compor o pedido? ");
            int qtdItens = int.Parse(Console.ReadLine());

            for (int i=0; i<qtdItens; i++)
            {
                ItemPedido item = new ItemPedido();

                Console.Write($"Id do Produto {i + 1}: ");
                int idProduto = int.Parse(Console.ReadLine());

                item.Produto = produtos.Find(produto => produto.Id == idProduto);
                item.Valor = item.Produto.Valor;

                Console.Write($"Quantidade do Produto {i+1}: ");
                item.Quantidade = int.Parse(Console.ReadLine());

                pedido.AdicionarItem(item);
            }

            pedido.DataPedido = DateTime.Now;

            pedidos.Add(pedido);

            break;

        case 4:
            Console.WriteLine("Listar Produtos");

            produtos.ForEach(produto =>
            {
                Console.WriteLine(produto);
            });

            break;

        case 5:
            Console.WriteLine("Listar Funcionarios");

            funcionarios.ForEach(funcionario =>
            {
                Console.WriteLine(funcionario);
            });
           
            break;

        case 6:
            Console.WriteLine("Listar Pedidos");

            pedidos.ForEach(pedido =>
            {
                Console.WriteLine(pedido);
            });

            break;
        case 7:
            Console.WriteLine("Digite sua matricula: ");            
            string MatriculaDigitada = Console.ReadLine();
            funcionarios.AddRange(gerentes);
            funcionarios.AddRange(vendedores);
            Funcionario funcionario = funcionarios.Find(funcionarioLista=> funcionarioLista.Matricula == MatriculaDigitada);
            double pagamento = funcionario.CalcularPagamento(pedidos);

            Console.WriteLine(pagamento);
            break;
    }

    Console.ReadKey();
    Console.Clear();
} while (opcao != 8);
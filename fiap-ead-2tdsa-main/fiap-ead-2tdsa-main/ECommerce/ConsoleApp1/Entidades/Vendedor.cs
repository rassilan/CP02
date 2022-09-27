namespace ConsoleApp1.Entidades
{
    internal class Vendedor : Funcionario
    {


        public Vendedor(string nome, string matricula, double salario) : base(nome, matricula, salario)
        {
        }


        public override double CalcularPagamento(List<Pedido> listaPedidos)
        {
            double pagamentoVendedor = 0;
            foreach (var pedido in listaPedidos)
            {
                if (pedido.Funcionario.Matricula == Matricula)
                {
                    pagamentoVendedor = Salario + (pedido.Valor * 0.10);
                }
            }

            return pagamentoVendedor;
        }
    }
}
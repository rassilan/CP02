namespace ConsoleApp1.Entidades
{
    internal class Gerente : Funcionario
    {
        public Gerente(string nome, string matricula, double salario) : base(nome, matricula, salario)
        {
        }

        public override double CalcularPagamento(List<Pedido> listaPedidos)
        {
            double pagamentoGerente = 0;
            foreach (var pedido in listaPedidos)
            {
                pagamentoGerente = Salario + (pedido.Valor * 0.05);
            }         
            
            return pagamentoGerente;    
        }       
    }
}

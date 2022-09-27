namespace ConsoleApp1.Entidades
{
    internal abstract class Funcionario
    {       
        public String Nome { get; set; }
        public String Matricula { get; set; }
        public double Salario { get; set; }
        
        public Funcionario(string nome , string matricula, double salario)
        {
            Nome = nome;
            Matricula = matricula;
            Salario = salario;
        }

        public override string ToString()
        {
            return $" | {Nome} | {Matricula} | {Salario}";
        }

        public abstract double CalcularPagamento(List <Pedido> listaPedidos);            

    }
}

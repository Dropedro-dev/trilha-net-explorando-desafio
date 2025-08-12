namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva()
        {
            Hospedes = new List<Pessoa>();
            Suite = new Suite();
            DiasReservados = 0;
        }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            bool capacidadeSuficiente = hospedes.Count <= Suite.Capacidade;
            if (capacidadeSuficiente)
            {
                Hospedes = hospedes;
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                throw new Exception("Capacidade insuficiente para o número de hóspedes.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            if (Hospedes != null)
            {
                return Hospedes.Count;
            }
            return 0;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            decimal valorDiaria = Suite.ValorDiaria;
            decimal valorTotal = DiasReservados * valorDiaria;
            decimal valor = valorTotal;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            bool desconto = DiasReservados >= 10;
            if (desconto)
            {
                valor = valorTotal - (valorTotal * 0.1m); // Aplicando 10% de desconto
            }

            return valor;
        }
    }
}
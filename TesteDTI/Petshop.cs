namespace TesteDTI
{
    class Petshop
    {
        //Atributos necessarios para armazenar as informações dos petshops e resultado de nossos calculos
        public string Nome { get; set; }
        public double DistanciaMetros { get; set; }
        public double PreçoPequenoSemana { get; set; }
        public double PreçoGrandeSemana { get; set; }
        public double PreçoPequenoFimSemana { get; set; }
        public double PreçoGrandeFimSemana { get; set; }
        public double ValorTotal { get; set; }

        //Metodo que realiza o calculo dos valores a pagar de acordo com os parametros informados pelo usuário.
        public void CalcularValorAPagar(int tipoDia, int numPetsPequenos, int numeroPetsGrandes)
        {

            if (tipoDia == 1)
                ValorTotal = (numPetsPequenos * PreçoPequenoFimSemana) + (numeroPetsGrandes * PreçoGrandeFimSemana);
            else
                ValorTotal = (numPetsPequenos * PreçoPequenoSemana) + (numeroPetsGrandes * PreçoGrandeSemana);
        }
    }
}

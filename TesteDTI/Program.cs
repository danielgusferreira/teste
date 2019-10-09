using System;
using System.Collections.Generic;
using System.Linq;

namespace TesteDTI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Continuando o sistema até que o usuário queira finalizar a execução
            while (true)
            {
                //Declarando variaveis que serão utilizadas durante o processo
                string dadosInformados = "";
                DateTime dataMarcacao = DateTime.Now;
                int quantidadePetsPequenos = 0;
                int quantidadePetsGrandes = 0;
                int verificacao = 0;

                //Solicitando informações necessarias para o calculo do melhor valor
                Console.WriteLine("Por favor, insira os seguintes dados:");
                Console.WriteLine($"Dia do banho, quantidade animais pequenos e quantidade animais grandes.    ex: {DateTime.Now.ToShortDateString()} 4 5");
                dadosInformados = Console.ReadLine();

                //Tentando realizar a leitura dos dados informados pelo cliente
                try
                {
                    //Atribuindo as variaveis auxiliares os dados informados separadamente. 
                    dataMarcacao = Convert.ToDateTime(dadosInformados.Split(' ')[0]);
                    quantidadePetsPequenos = Convert.ToInt32(dadosInformados.Split(' ')[1]);
                    quantidadePetsGrandes = Convert.ToInt32(dadosInformados.Split(' ')[2]);

                    //Verificando se os dois valores informados foram 0 para solicitarmos ao usuário que informe esses valores.
                    if(quantidadePetsPequenos == 0 && quantidadePetsGrandes == 00)
                    {
                        Console.Clear();
                        Console.WriteLine("Informe valores diferentes de zero na quantidade de pets pequenos e grandes.");
                        //Voltando ao inicio do while para solicitar as informações novamente.
                        continue;
                    }
                       
                    //Retornando a lista de petshops criada para realizarmos o restante dos processos 
                    List<Petshop> petshops = CriarPetshops();

                    //percorrendo todos os petshops criados afim de inserir na classe o valor a pagar para cada um   
                    foreach (var item in petshops)
                    {
                        //Verificando qual o dia da semana o dia informado se encontra para chamarmos os metodos de calculo
                        //Foi passado o codigo do enumarable para que seja feito o processo interno 
                        if (dataMarcacao.DayOfWeek == DayOfWeek.Saturday || dataMarcacao.DayOfWeek == DayOfWeek.Sunday)
                            item.CalcularValorAPagar((int)enumDiasSemana.finalSemana, quantidadePetsPequenos, quantidadePetsGrandes);
                        else
                            item.CalcularValorAPagar((int)enumDiasSemana.diaSemana, quantidadePetsPequenos, quantidadePetsGrandes);
                    }

                    //Para retornarmos o melhor Petshop, selecionaremos o petshop com o menor valor e também aquele com menor distancia caso haja empate entre petshops.    
                    var melhorPetshop = petshops.OrderBy(t => t.ValorTotal).ThenBy(t => t.DistanciaMetros).FirstOrDefault();

                    //Exibindo resultados ao usuario
                    Console.WriteLine("\n");
                    Console.WriteLine($"O melhor PetShop para levar seus bichinhos é o: {melhorPetshop.Nome}");
                    Console.WriteLine($@"Lá você irá pagar o valor de: {melhorPetshop.ValorTotal.ToString("C2")} no banho de seus {(quantidadePetsPequenos + quantidadePetsGrandes)} pets!!");

                    //verificando se o mesmo deseja continuar com suas verificações.
                    Console.WriteLine("\n");
                    Console.WriteLine("Deseja fazer uma nova verificação?");
                    Console.WriteLine("Digite 0 para continuar ou qualquer outra letra para sair");
                    //Verificando os valores informados para sabermos se o programa irá continuar ou ser finalizado.
                    if (int.TryParse(Console.ReadLine(), out verificacao) && verificacao == 0)
                            Console.Clear();
                    else
                        Environment.Exit(0);
                }
                catch
                {
                    //Caso o sistema não consiga realizar as operações necessarias, informar ao usuário e solicitar que informe novamente os dados.
                    Console.Clear();
                    Console.WriteLine("Os valores informados não se encontram no padrão esperado, verifique o exemplo abaixo.");
                }
            }
        }


        //Metodo que realiza o processo de criação de um petshop com as informações providas no documento do projeto
        public static List<Petshop> CriarPetshops()
        {
            //Cria uma lista com os petshops que serão criados
            List<Petshop> petshops = new List<Petshop>();

            //Adicionando petshops
            //obs: as distancias foram convertidas para metro para ficarem na mesma medida
            petshops.Add(new Petshop()
            {
                Nome = "Meu Canino Feliz",
                DistanciaMetros = 2000,
                PreçoPequenoSemana = 20,
                PreçoGrandeSemana = 40,
                PreçoPequenoFimSemana = 20 + ((20.00 / 100) * 20), //realizando calculo de porcentagem
                PreçoGrandeFimSemana = 40 + ((20.00 / 100) * 40)   //realizando calculo de porcentagem
            });

            petshops.Add(new Petshop()
            {
                Nome = "Vai Rex",
                DistanciaMetros = 1700,
                PreçoPequenoSemana = 15,
                PreçoGrandeSemana = 50,
                PreçoPequenoFimSemana = 20,
                PreçoGrandeFimSemana = 55
            });

            petshops.Add(new Petshop()
            {
                Nome = "ChowChawgas",
                DistanciaMetros = 800,
                PreçoPequenoSemana = 30,
                PreçoGrandeSemana = 45,
                PreçoPequenoFimSemana = 30,
                PreçoGrandeFimSemana = 45
            });

            //Retornando lista dos petshops para nosso metodo principal
            return petshops;
        }

        //Enum criado para informarmos os valores de dias de semana e finais de semana que são utilizados no processo de calculo
        public enum enumDiasSemana
        {
            finalSemana = 1,
            diaSemana = 2
        }
    }
}

===============================================================================================================
===============================================================================================================

Abaixo serão dadas as informações necessarias para o entendimento do projeto criado.

===============================================================================================================
===============================================================================================================


===============================================================================================================
======================================= Como executar o projeto ===============================================
===============================================================================================================

Para executar o projeto acesse a seguinte pasta:

..\TesteDTI\TesteDTI\bin\Debug\TesteDTI.exe

===============================================================================================================
===============================================================================================================
===============================================================================================================



===============================================================================================================
======================================== Observações do projeto ===============================================
===============================================================================================================

Foi criado um sistema utilizando a tecnologia .net framework com a aplicação do tipo console.


O projeto é dividido em 2 classes.
--Program.cs
	Na classe principal de nosso sistema foi realizado a criação de três metodos:
	
	--Main(): 
		Responsavel por toda a interação com o usuário e chamada de outros metodos criados no sistema.
			--Premissas: Foi criado um sistema de loop que faz com que o usuário consiga realizar mais de uma consulta ao sistema.
				     Foram feitas validações no sistema para evitar erros de digitação do usuário.

	--CriarPetshops(): 
		Nesse metodo foi realizado a inserção em uma lista da classe petshop as informações que foram 
	  	repassadas no documento inicial do projeto.
			--Premissas: - Foi realizado a conversão automatica da distancia dos petshops em metros para que todos fiquem com a mesma escala de medição.
				     - O cálculo de % dos valores dos petshops também foi feito manualmente para gravarmos o valor já convertido. 
	
	--enumDiasSemana:
		Foi criado um Enum que conterá o tipo de dia(Dia de Semana ou Final de Semana) e o seu respectivo codigo que serão utilizados no momento do calculo 
		do valor total.

 
Petshop.cs
	Na classe auxiliar de Petshop contem todos os atributos responsaveis pela criação do mesmo. Essas informações foram obtidas no documento de escopo do projeto.
		--Premissas: Também foi criado um atributo de resultado que irá gravar o valor total a pagar daquela consulta que está sendo feita.
	
	--CalcularValorAPagar():
		Neste metodo é realizado o processo de calculo do valor a pagar da consulta de pets que estã sendo feita.

		Como parametros do metodo recebemos o tipo de dia que no caso seria o codigo do Enum criado, quantidade de pets pequenos e quantidade de pets grandes.
		Com essas informações são feitos os calculos dos valores a pagar.
		Ao final é adicionado o valor final ao atributo da classe.


===============================================================================================================
===============================================================================================================
===============================================================================================================






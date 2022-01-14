# Testes de unidade com XUnit 

Repositório criado com o intuito didático para futuras consultas relacionadas a testes de unidade com XUnit.
Primeiramente é criado uma aplicação de leilão, contendo:
- A criação do objeto a ser rematado;
- O método Interessada() apra o cadastro de pessoas participantes do leilão;
- O método RecebeLance() para a realização dos lances de determinado objeto.

Fazendo uso da sintáxe do XUnit, é preparado os dados de entrada para a realização dos testes:
```C#
[Theory] //Passando dados de entrada
[InlineData(1300, new double[]{1000, 1200, 1210, 1300})] //Dados de entrada 1
[InlineData(1210, new double[]{1000, 1200, 1210, 1100})] //Dados de entrada 2
[InlineData(800, new double[] {800})] //Dados de entrada 3
```

Criação do objeto a ser leiloado:
 ```C#
 var leilao = new Leilao("Van Gogh");
 ```
 
 O cadastro de pelo menos uma pessoa através da classe ```Interessada()  ```.
  ```C#
var fulano = new Interessada("Fulano", leilao);
```

Um ```for``` percorrer o array de ofertas e realizar os lances.
 ```C#
foreach (var valor in ofertas)
{
    leilao.RecebeLance(fulano, valor);
}
```

Em seguido é feito o encerramento do leilao com o método ```TerminaPregao()``` e o uso do ```Assert.Equal()``` para realizar a comparação do valor esperado com o valor obitido.
 ```C#
 leilao.TerminaPregao();

//Assert
//Então o valor eseprado é o maior valor dado.
//      E o cliente ganhador é o que deu o maior lance.

var valorObtido = leilao.Ganhador.Valor;
Assert.Equal(valorEsperado, valorObtido);
        
```

E o resultado obtido dos testes:

```========== Compilar: 1 com êxito, 0 com falha, 2 atualizados, 0 ignorados ==========```

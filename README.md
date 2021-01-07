# Rock Project

Projeto desenvolvido para um desafio para a Stone (daí o nome do projeto), com o objetivo de gerar uma divisão de lucros, a partir de regras pré-estabelecidas, para os funcionários dessa empresa.

## Usabilidade

Ao executar a aplicação (API Rest), a mesma está configurada para ser executada nas seguintes condições:

- URL Inicial (caso use IIS): http://localhost:63392/swagger/index.html
    - Endereço: http://localhost
    - Porta: 63392

No Swagger inicial, é possível testar todas as rotas em tempo de execução.

## Rotas

### Employee

Employee é o nome dado a classe de Funcionários, as rotas que fazem parte desse grupo são:

#### /employee/list  
Rota responsável por listar todos os funcionários cadastrados.

   - URL local: http://localhost:63392/employee/list

   - Request: 
      - POST
      - Body: No parameters

   - Response: 

     - Em caso de sucesso:
         - Response code: 200 - Success
         - Body, caso haja algum item: 
			 - Exemplo:
			```json
			[
			  {
				"area": "Diretoria",
				"cargo": "Diretor Financeiro",
				"data_de_admissao": "2012-01-05",
				"salario_bruto": "R$ 12.696,20",
				"matricula": "0009968",
				"nome": "Victor Wilson"
			  }
			]
			```
				
     - Em caso de erro:				
         - Response code: 500 - Internal Server Error

#### /employee/save/list

Rota responsável por cadastrar os funcionários.

   - URL local: http://localhost:63392/employee/list
   
   - Regras:
        - Não são permitidos campos com caracteres vazios; 
        - Valor do salario_bruto ser negativo; 
        - Data de admissão futura ao dia de hoje;


   - Request: 
       - POST
       - Body: JSON c/ lista de funcionários
		   
      Onde:
        - area: area que o funcionário pertence;
        - cargo: cargo que o funcionário exerce;
        - salario_bruto: salário do funcionário;
        - matricula: nº de matricula do funcionário;
        - nome: nome do funcionário;
			
		   - Exemplo:
		   
           ```json
			[
			  {
				"area": "Diretoria",
				"cargo": "Diretor Financeiro",
				"data_de_admissao": "2012-01-05",
				"salario_bruto": "R$ 12.696,20",
				"matricula": "0009968",
				"nome": "Victor Wilson"
			  },
			  {
				"matricula": "0004468",
				"nome": "Flossie Wilson",
				"area": "Contabilidade",
				"cargo": "Auxiliar de Contabilidade",
				"salario_bruto": "R$ 1.396,52",
				"data_de_admissao": "2015-01-05"
			  }
			]
			```
			
	- Response:
	
Para essa rota, foram criadas duas listas:
- employeesRegistered: que contem todos os funcionários com os campos validados e corretos, e inseridos no banco de dados;
- employeesNotRegistered: que contem todos os funcionários com os campos validados e incorretos, que não foram inseridos no banco de dados;
	
    - Response code: 200 - Success
		- Body: 
				
		```json
		{
		  "employeesRegistered": [
			{
			  "area": "Diretoria",
			  "cargo": "Diretor Financeiro",
			  "data_de_admissao": "2012-01-05",
			  "salario_bruto": "R$ 12.696,20",
			  "matricula": "0009968",
			  "nome": "Victor Wilson"
			},
			{
			  "area": "Contabilidade",
			  "cargo": "Auxiliar de Contabilidade",
			  "data_de_admissao": "2015-01-05",
			  "salario_bruto": "R$ 1.396,52",
			  "matricula": "0004468",
			  "nome": "Flossie Wilson"
			}
		  ],
		  "employeesNotRegistered": []
		}
		```
    
    
### OccupationAreaWeight

OccupationAreaWeight é o nome dado para as métricas de calculo de Area de Atuação.

#### /weight/occupation-area/get 
Rota responsável por listar todas as regras para métricas referentes a Area de Atuação.

- URL local: http://localhost:63392/weight/occupation-area/get

- Request: 
    - GET
    - Body: No parameters

- Response:
   - Response code: 200 - Success
   - Body:

      ```json
       [
         {
           "id": 1,
           "occupationArea": "Diretoria",
           "weight": 1
         },
      ]
      ```

Onde:
  - id: nº de identificação da regra;
  - occupationArea: Area de Atuação que a regra pertence;
  - Weight: peso pela Area de Atuação; 
  
### SalaryWeight

SalaryWeight é o nome dado para as métricas de calculo de Salário.

#### /weight/salary/get
Rota responsável por listar todas as regras para métricas referentes a Salário.

- URL local: http://localhost:63392/weight/salary/get

- Request: 
    - GET
    - Body: No parameters

- Response:
   - Response code: 200 - Success
   - Body:

      ```json
       [
         {
           "id": 4,
           "salaryMin": 5,
           "salaryMax": 8,
           "weight": 3,
           "occupationPositionException": []
         }
      ]
      ```

Onde:
  - id: nº de identificação da regra;
  - salaryMin: valor mínimo para definir até quantos salários mínimos que pertence essa regra (nº que será multiplicado ao valor do salário mínimo);
  - salaryMax: valor máximo para definir até quantos salários mínimos que pertence essa regra (nº que será multiplicado ao valor do salário mínimo);
  - occupationPositionException: lista contendo todos os Cargos que pertencem a essa regra, independente do valor do salário;
  - Weight: peso pela Salário; 

### WorkYearsWeight

WorkYearsWeighté o nome dado para as métricas de calculo de Tempo de Empresa.

#### /weight/work-years/get
Rota responsável por listar todas as regras para métricas referentes a Tempo de Empresa.

- URL local: http://localhost:63392/weight/work-years/get

- Request: 
    - GET
    - Body: No parameters

- Response:
   - Response code: 200 - Success
   - Body:

      ```json
       [
         {
           "id": 3,
           "yearMin": 3,
           "yearMax": 8,
           "weight": 3
         },
      ]
      ```

Onde:
  - id: nº de identificação da regra;
  - yearMin: quantidade de anos mínimos para definir se o funcionário pertence essa regra;
  - salaryMax: quantidade de anos máximos para definir se o funcionário pertence essa regra;
  - Weight: peso pela Tempo de Empresa. 


### Profit

Profit é o nome dado para o cálculo de PLRs.

O salário mínimo levado em consideração para os calculos foi de R$ 1088,00, e o mesmo pode ser alterado no appsettings (referenciado como MinimumSalary).

#### /profit/get
Rota responsável por listar todas as regras para métricas referentes a Tempo de Empresa.

- URL local: http://localhost:63392/weight/work-years/get

- Request: 
    - POST
    - Body: 

       ```json
       [
         {
           "expectedProfit": 1000
         },
       ]
      ```

- Response:
   - Response code: 200 - Success
   - Body:

      ```json
       {
         "saldo_total_disponibilizado": "-R$ 299.132,96",
         "total_disponibilizado": "R$ 1.000,00",
         "total_de_funcionarios": "2",
         "total_distribuido": "R$ 300.132,96",
         "participacoes": [
             {
              "valor_da_participacao": "R$ 182.825,28",
              "matricula": "0009968",
              "nome": "Victor Wilson"
            },
            {
              "valor_da_participacao": "R$ 117.307,68",
              "matricula": "0004468",
              "nome": "Flossie Wilson"
           }
        ]
      }
      ```

Onde:
  - saldo_total_disponibilizado: valor da subtração entre o total_disponibilizado e o total_distribuido;
  - total_disponibilizado: valor total disponibilizado para PLR;
  - total_distribuido: valor ideal para a distribuição correta - caso fosse seguida a regra de distribuição;
  - total_de_funcionarios: nº de funcionários que foram contabilizados para a distribuição da PLR.
  - participacoes: lista de funcionários que foram contabilizados para calculo.
  - valor_da_participacao: valor da participação do funcionário;
  - matricula: nº de matricula do funcionário;
  - nome: nome do funcionário;



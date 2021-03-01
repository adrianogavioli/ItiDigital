# ItiDigital
 
Solução Asp.Net Core 3.1 concebida para validar senhas conforme especificações abaixo.<br />
Considere uma senha sendo válida quando possuir as seguintes definições:<br />
<ul>
 <li>Nove ou mais caracteres</li>
 <li>Ao menos 1 dígito</li>
 <li>Ao menos 1 letra minúscula</li>
 <li>Ao menos 1 letra maiúscula</li>
 <li>Ao menos 1 caractere especial</li>
 <li>Considere como especial os seguintes caracteres: <b>!@#$%^&*()-+</b></li>
 <li>Não possuir caracteres repetidos dentro do conjunto</li>
 <li>Espaços em branco não devem ser considerados como caracteres válidos.</li>
</ul>

Para garantir todos os pontos de atenção propostos no projeto, optei por dividir a solução nas seguintes camadas:<br /><br />
<b>ItiDigital.Core:</b> núcleo compartilhado (Shared Kernel), contempla os objetos comuns da solução, está organizada em duas pastas, a “DomainObjects” que contém a classe abstrata “ValueObject” utilizada para identificar a entidade de domínio e a pasta “Notifications”, responsável por padronizar as notificações lançadas durante o request.<br /><br />
<b>ItiDigital.Domain:</b> camada de domínio que contém a entidade Password com suas propriedades e métodos, sua validação se dá através do “FluentValidation” onde as notificações de erros são declaradas através de variáveis estáticas para viabilizar os testes de unidades.<br /><br />
<b>ItiDigital.Application:</b> responsável por realizar a integração entre a camada de domínio e a API. É composta por uma “ViewModel” para evitar a exposição da entidade de domínio, o mapeamento entre as classes é feito através do “AutoMapper”. Para a ação de validação da senha, optei por utilizar um comando através do “MediatR”.<br /><br />
<b>ItiDigial.Api:</b> oferece o “endpoint” para validações de senhas. Contém uma pasta denominada “Configurations” composta por classes de extensões das interfaces “IServiceCollection” e “IApplicationBuilder” para adicionar “middlewares” sem poluir a classe Startup. A documentação se dá através do “Swagger”, para visualizá-la basta executar a aplicação que uma página será aberta no browser, você poderá testar a API diretamente na página, não será necessário utilizar o Postman.<br /><br />

<i>Estou muito feliz por participar desse processo, obrigado pela oportunidade.</i><br />
<i>Coloco-me a disposição e desejo sucesso!</i>

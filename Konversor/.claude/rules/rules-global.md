# Konversor — Global Rules

## 1. Propósito

Este arquivo define as regras globais que devem orientar qualquer agente de IA atuando no projeto **Konversor**.

Estas regras têm precedência sobre preferências ou abordagens genéricas sugeridas pelo agente. O agente deve sempre considerar o contexto, o escopo e a arquitetura do Konversor antes de propor ou implementar qualquer solução.

O Konversor é uma aplicação **ASP.NET Core MVC em .NET 8**, construída de forma leve e pragmática para realizar **cálculos stateless**, sem persistência de dados.

O projeto não possui banco de dados e, portanto, não possui uma camada de persistência ou Infrastructure relacionada a acesso a dados.

---

## 2. Princípios fundamentais

O agente deve seguir, nesta ordem, os seguintes princípios:

1. **Preservar a intenção e as regras de negócio existentes.**
2. **Não inventar informações ausentes.**
3. **Questionar o desenvolvedor quando houver ambiguidade relevante.**
4. **Respeitar a arquitetura existente.**
5. **Priorizar simplicidade e pragmatismo.**
6. **Evitar overengineering e abstrações prematuras.**
7. **Aplicar SOLID quando for viável e fizer sentido para o contexto.**
8. **Reutilizar código e componentes existentes sempre que possível.**
9. **Evitar duplicação de código.**
10. **Não realizar alterações fora do escopo solicitado.**

Uma solução tecnicamente sofisticada não deve ser escolhida simplesmente por ser mais sofisticada. O agente deve buscar a solução mais simples que satisfaça corretamente os requisitos.

---

## 3. Arquitetura

O Konversor utiliza uma arquitetura MVC leve, organizada em camadas horizontais adequadas ao escopo da aplicação:

* Controller
* Service
* ViewModel
* View

A arquitetura deve permanecer simples e proporcional ao problema que o projeto resolve.

Não devem ser introduzidas camadas, padrões ou abstrações adicionais sem necessidade concreta.

Exemplos de elementos que não devem ser introduzidos automaticamente:

* Repository;
* Unit of Work;
* Infrastructure;
* CQRS;
* Mediator;
* Domain Events;
* abstrações genéricas;
* camadas adicionais;
* padrões arquiteturais complexos.

A ausência desses elementos é intencional enquanto não houver necessidade real.

### Alterações arquiteturais

O agente pode identificar oportunidades de melhoria arquitetural, mas **não deve realizar alterações arquiteturais automaticamente**.

Quando considerar uma mudança arquitetural necessária ou significativamente benéfica:

1. explique o problema identificado;
2. apresente a proposta;
3. explique brevemente os benefícios e impactos;
4. aguarde autorização explícita do desenvolvedor;
5. somente então realize a alteração.

---

## 4. Stack principal

O projeto utiliza:

* .NET 8;
* C# 12;
* ASP.NET Core MVC;
* Razor Views;
* Bootstrap;
* Dependency Injection nativa do ASP.NET Core;
* xUnit para testes;
* NSubstitute para substituição/mocking em testes;
* Docker.

Não existe banco de dados ou ORM no projeto.

As operações realizadas pelo sistema são stateless.

---

## 5. Responsabilidades das camadas

### Controller

Controllers são responsáveis por lidar com o fluxo HTTP e coordenar a interação entre a requisição, os Services e as Views.

A lógica de negócio não deve ser criada nos Controllers quando ela puder pertencer naturalmente aos Services.

Controllers devem permanecer simples e legíveis.

### Service

As **regras de negócio devem permanecer nos Services**.

Cálculos, validações e decisões relacionadas ao comportamento da aplicação devem ser implementados nos Services quando constituírem regras de negócio.

O agente não deve deslocar regras de negócio para outras camadas apenas para seguir padrões arquiteturais genéricos.

### ViewModel

Os ViewModels devem representar os dados necessários para comunicação entre as camadas apropriadas e as Views.

Somente os modelos definidos pelas convenções do projeto devem ser utilizados automaticamente.

A introdução de novos tipos de modelos ou abstrações deve ser justificada e, quando representar uma mudança relevante na estrutura do projeto, previamente autorizada pelo desenvolvedor.

### View

As Views utilizam Razor.

Bootstrap é obrigatório para a construção das interfaces visuais.

JavaScript deve ser utilizado apenas para funcionalidades relacionadas à experiência do usuário, como:

* tooltips;
* validações de formulário;
* interações de interface.

**Regras de negócio não devem ser implementadas em JavaScript.**

---

## 6. Regras de negócio

Regras de negócio existentes devem ser preservadas.

O agente **nunca deve alterar uma regra de negócio existente sem consultar o desenvolvedor previamente**.

Quando uma regra de negócio estiver ausente, ambígua ou puder ser interpretada de mais de uma maneira:

> **Pergunte ao desenvolvedor antes de implementar.**

Não é permitido assumir silenciosamente comportamentos de negócio.

O agente também não deve criar regras de negócio simplesmente para completar uma implementação.

---

## 7. Incerteza e tomada de decisão

Quando o agente não possuir informação suficiente para tomar uma decisão tecnicamente segura, deve **perguntar ao desenvolvedor**.

O agente não deve:

* inventar requisitos;
* inventar regras de negócio;
* inventar APIs;
* inventar classes;
* inventar métodos;
* inventar endpoints;
* inventar estruturas que não foram definidas;
* assumir comportamentos importantes sem confirmação.

Quando existirem múltiplas soluções tecnicamente válidas e a escolha puder afetar a arquitetura ou o comportamento do sistema, o agente deve apresentar as alternativas ao desenvolvedor antes de tomar uma decisão relevante.

---

## 8. Análise antes da implementação

O agente deve evitar investigação desnecessária do projeto.

Entretanto, antes de criar ou modificar um componente, deve verificar o **contexto mínimo necessário** para evitar:

* duplicação de código;
* conflito com componentes existentes;
* quebra de convenções;
* inconsistência arquitetural;
* criação de abstrações desnecessárias.

O código existente deve ser reutilizado sempre que possível.

Se já existir um Service, ViewModel, componente ou mecanismo adequado para determinada responsabilidade, prefira reutilizá-lo em vez de criar uma nova implementação equivalente.

---

## 9. SOLID e qualidade de código

O princípio SOLID deve ser considerado durante o desenvolvimento.

Sua aplicação deve ser **pragmática**.

Não introduza abstrações apenas para satisfazer formalmente um princípio.

O agente deve buscar:

* responsabilidades bem definidas;
* baixo acoplamento;
* alta coesão;
* código testável;
* dependências explícitas;
* facilidade de manutenção.

SOLID não deve ser utilizado como justificativa para transformar uma aplicação simples em uma arquitetura excessivamente complexa.

---

## 10. Simplicidade e overengineering

**Simplicidade é uma regra global do projeto.**

O agente deve evitar:

* abstrações prematuras;
* generalizações desnecessárias;
* padrões de projeto sem necessidade;
* camadas artificiais;
* frameworks ou bibliotecas desnecessárias;
* código preparado para cenários hipotéticos;
* otimizações prematuras.

Implemente apenas aquilo que é necessário para resolver o problema atual de forma correta e sustentável.

---

## 11. Dependências externas

Bootstrap é uma dependência obrigatória para construção das Views.

Outras bibliotecas ou dependências externas **não devem ser adicionadas automaticamente**.

Caso o agente identifique uma biblioteca que possa solucionar adequadamente um problema:

1. explique por que ela seria necessária;
2. informe brevemente o que ela adicionaria ao projeto;
3. solicite autorização do desenvolvedor;
4. somente depois adicione a dependência.

A introdução de uma biblioteca deve ter justificativa concreta.

---

## 12. Dependency Injection

Utilize a **Dependency Injection nativa do ASP.NET Core**.

As interfaces devem seguir a convenção:

```csharp
IUserService
```

A implementação correspondente deve seguir a nomenclatura convencional:

```csharp
UserService
```

Não existe um lifetime obrigatório para todos os serviços. O agente deve utilizar o lifetime que considerar tecnicamente mais apropriado para a responsabilidade do componente.

Service Locator e acesso direto ao `IServiceProvider` não são proibidos por estas regras, mas não devem ser utilizados sem uma justificativa técnica.

---

## 13. Código C#

Utilize as convenções idiomáticas do C# e do .NET.

`var` pode ser utilizado quando melhorar a legibilidade e estiver alinhado ao contexto.

Evite:

* métodos excessivamente grandes;
* classes excessivamente grandes;
* complexidade desnecessária;
* duplicação;
* abstrações sem propósito.

### Async/Await

Utilize `async/await` quando houver necessidade real de operações assíncronas.

Não introduza assincronicidade artificialmente.

### CancellationToken

`CancellationToken` não deve ser introduzido automaticamente.

Caso o agente considere que seu uso seja necessário ou vantajoso para determinada implementação, deve consultar o desenvolvedor antes de introduzi-lo.

### Exceções

Exceções devem ser utilizadas de maneira apropriada para representar situações excepcionais.

Mensagens de erro destinadas ao usuário devem ser **amigáveis e sempre escritas em inglês**.

Detalhes técnicos não devem ser expostos ao usuário.

---

## 14. Tratamento de erros

O sistema deve apresentar mensagens de erro amigáveis ao usuário.

Nunca exponha diretamente ao usuário:

* stack traces;
* nomes de classes internas;
* detalhes de implementação;
* informações de infraestrutura;
* mensagens técnicas;
* dados sensíveis.

Mensagens técnicas não devem fazer parte da interface apresentada ao usuário.

Por padrão, o projeto não utiliza logging como requisito funcional.

Não introduza uma infraestrutura de logging sem necessidade concreta e sem autorização quando isso representar uma mudança estrutural no projeto.

---

## 15. Segurança

O Konversor não possui autenticação ou autorização.

Não introduza mecanismos de autenticação, autorização ou gerenciamento de identidade sem solicitação ou autorização do desenvolvedor.

Secrets, passwords, tokens, connection strings ou quaisquer credenciais nunca devem ser armazenados diretamente no código-fonte.

Não inclua dados sensíveis em mensagens de erro.

---

## 16. JavaScript

JavaScript existe exclusivamente como suporte à experiência do usuário.

É permitido utilizá-lo para:

* validação de formulário;
* tooltips;
* interações de interface;
* comportamentos relacionados à UX.

Não implemente regras de negócio em JavaScript.

Quando uma regra representa comportamento de negócio, ela deve permanecer no backend, nos Services apropriados.

---

## 17. Testes

O framework de testes utilizado é **xUnit**.

Para substituição de dependências, utilize **NSubstitute**.

Não existe meta de cobertura de código.

Não existem categorias de funcionalidades que obrigatoriamente precisam possuir testes.

O agente deve **perguntar ao desenvolvedor antes de criar testes automaticamente** como parte de uma nova implementação.

Quando testes forem solicitados, eles devem refletir o comportamento esperado e não apenas a implementação interna.

---

## 18. Alterações no código

O agente possui autonomia para modificar arquivos existentes quando isso estiver dentro do escopo solicitado.

Entretanto:

> **Nunca realize alterações fora do escopo solicitado.**

Se durante uma tarefa o agente encontrar outro problema não relacionado à tarefa atual:

1. não corrija automaticamente;
2. informe o problema;
3. explique brevemente seu impacto, quando relevante;
4. pergunte ao desenvolvedor se deseja que ele seja corrigido.

---

## 19. Alterações de grande impacto

Antes de realizar uma alteração significativa, o agente deve apresentar um plano ao desenvolvedor.

O plano deve explicar de forma objetiva:

* o que será alterado;
* quais arquivos/componentes serão afetados;
* qual abordagem será utilizada;
* eventuais impactos relevantes.

A implementação deve ocorrer após a aprovação do plano quando a alteração representar uma mudança significativa.

Alterações pequenas e diretamente relacionadas à tarefa podem ser realizadas normalmente.

---

## 20. Preservação de padrões existentes

O agente deve respeitar padrões e convenções já estabelecidos no projeto.

Mesmo que exista uma abordagem teoricamente superior, não substitua automaticamente um padrão existente.

Quando identificar uma melhoria plausível:

1. preserve o padrão atual durante a tarefa;
2. apresente a melhoria como proposta separada;
3. explique brevemente o motivo;
4. aguarde autorização antes de realizar uma mudança estrutural.

---

## 21. Documentação

Quando uma alteração modificar comportamento relevante do sistema, a documentação correspondente deve ser atualizada.

Comentários no código devem ser utilizados **somente quando necessários**.

Não adicione comentários que simplesmente descrevam código óbvio.

Prefira código claro e autoexplicativo.

---

## 22. Git e commits

O agente não deve realizar commits automaticamente.

Antes de criar um commit, deve perguntar ao desenvolvedor.

Não existe uma convenção de mensagens de commit obrigatória definida atualmente.

O agente não deve assumir uma convenção de commits sem autorização.

---

## 23. Contestação técnica

O agente não deve executar cegamente uma solicitação.

Antes de implementar uma solução, deve verificar se ela é consistente com:

* a arquitetura do Konversor;
* as regras deste arquivo;
* as regras de negócio conhecidas;
* a simplicidade esperada pelo projeto;
* as boas práticas aplicáveis ao contexto.

Se a solicitação do desenvolvedor apresentar um problema técnico relevante, o agente deve **contestá-la tecnicamente**.

A contestação deve ser objetiva e apresentar:

1. o problema identificado;
2. o motivo técnico;
3. uma alternativa, quando aplicável.

A decisão final permanece com o desenvolvedor, exceto quando a implementação violaria explicitamente uma regra deste arquivo.

---

## 24. Escopo das alterações

Cada tarefa deve ser tratada com escopo controlado.

O agente deve:

* modificar somente o necessário;
* evitar refatorações oportunistas;
* evitar alterações não solicitadas;
* não corrigir problemas independentes automaticamente;
* não adicionar funcionalidades não solicitadas;
* não alterar regras de negócio sem autorização.

Uma tarefa de implementação não deve se transformar espontaneamente em uma refatoração geral do projeto.

---

## 25. Regra contra duplicação

Antes de criar uma nova implementação, considere se uma implementação existente pode ser reutilizada ou adaptada.

Evite duplicar:

* regras de negócio;
* cálculos;
* validações;
* componentes;
* métodos;
* Services;
* ViewModels;
* comportamentos equivalentes.

Entretanto, não crie uma abstração genérica apenas para eliminar poucas linhas duplicadas quando isso tornar o código mais complexo.

O objetivo é **eliminar duplicação sem criar overengineering**.

---

## 26. Performance

Não realize otimizações prematuras.

O foco inicial deve ser:

1. correção;
2. clareza;
3. simplicidade;
4. manutenibilidade.

Otimizações de performance devem ser aplicadas quando houver evidência de necessidade ou quando o custo da otimização for praticamente irrelevante e a solução permanecer simples.

---

## 27. Comunicação com o desenvolvedor

A comunicação do agente deve ser:

* objetiva;
* técnica;
* direta.

Evite explicações excessivamente longas quando uma explicação curta for suficiente.

Explique decisões arquiteturais importantes sempre que julgar necessário para que o desenvolvedor compreenda a solução e seus impactos.

Quando uma pergunta ao desenvolvedor for necessária, seja específico sobre a informação que está faltando.

Não faça perguntas genéricas quando for possível formular uma pergunta objetiva.

---

## 28. Hierarquia de decisão

Ao tomar uma decisão durante o desenvolvimento, o agente deve considerar a seguinte ordem:

1. Requisitos explícitos da tarefa;
2. Regras de negócio existentes;
3. Regras deste `rules-global.md`;
4. Arquitetura existente do Konversor;
5. Padrões existentes no código;
6. Boas práticas de .NET/C# aplicáveis ao contexto;
7. Simplicidade e manutenibilidade.

Quando houver conflito entre uma preferência genérica de desenvolvimento e uma regra específica do Konversor, **a regra específica do Konversor prevalece**.

---

## 29. Regra final

O agente deve agir como um colaborador técnico do projeto, e não como um gerador autônomo de código.

Antes de implementar, deve compreender o problema.

Durante a implementação, deve respeitar o contexto existente.

Depois da implementação, deve evitar alterações desnecessárias.

Em caso de dúvida relevante, deve perguntar.

Em caso de conflito técnico, deve explicar.

Em caso de mudança arquitetural, deve propor antes de executar.

Em todos os casos, deve buscar a solução **mais simples, correta, sustentável e coerente com o Konversor**.

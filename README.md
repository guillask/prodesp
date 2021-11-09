# prodesp
Para rodar o projeto, executar os seguintes comandos abaixo:

-- Ao abrir o projeto, abrir o arquivo "appsettings.json" e alterar a connectionString apontando para a sua maquina local.

-- Após a alteração da connectionString, ir na aba Tools -> NuGet Package Manager -> Package Manager Console e digite os seguintes comandos:
Copiar o que está dentro [ ]
[add-migration Inicial] enter:
irá exibir as seguintes mensagens abaixo:
Build started...
Build succeeded.
To undo this action, use Remove-Migration.
Após isso digitar: 
[update-database] enter:
irá exibir as seguintes mensagens abaixo:
Build started...
Build succeeded.
Done.

Aparecendo essas mensagens o banco foi criado e a tabela também, só dar F5 para executar o projeto.

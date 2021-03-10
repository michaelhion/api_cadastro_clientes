## Passos para executada a WebApi 

- 1- Baixe o repositório na sua maquina.
- 2- Entre no CMD  e acesso a pasta do arquivo HENRIQUE H .SILVA entre nela.
- 3- Execute o comando docker-compose build 
- 4- Após executar o comando  docker-compose up, caso o container da WebApi cair você dar um ctrl + c e executar denovo.
- 5- Agora só usar a WebApi.

## Passos para executar o teste unitário

-1 Abra solução de Goiabinha_WebApi no Visual Studio, entre no arquivo Goiabinha_WebApi.csproj. 
-2- Insirar 
<packagereference include="microsoft.aspnetcore.all"version="2.1.3" />
na linha 14 do csproj sem excluir nada.
-3- Após isso execute os testes em XUnitTest_Goiabeira




PASSO 1
----------------------------- 
SERVIDOR DE DADOS - SQL SERVER

- Criar no servidor de Dados o banco DDD e rodar nele o script abaixo

USE [DDD]
GO
 
/****** Object:  Table [dbo].[Rodadas]    Script Date: 16/05/2021 20:11:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[Rodadas](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[dado] [int] NULL,
	[mensagem] [varchar](500) NULL,
 CONSTRAINT [PK_Rodada] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


-----------------------------
2- Carregue o projeto no Visual Studio  

BackEnd
API Rest desenvolvida em .NET C# ASP.NET CORE WEBAPI E SWAGGER
Construida e Modelada em DDD
Utilizando bibliotecas como Dapper
e SeriLog para monitoramento.

Atualize no arquivo appsettings.js e no ConnectionStrings coloque a Conexão de um banco Sql Server local.

 "ConnectionStrings": {
    "SensorDataServer": "server=DESKTOP-TKT2S2J\\NEWSQL;database=DDD;user=sa;password=321654987"
  }



-------------------------------
3- RODE A API NO POSTMAN
 
Postman 
* Necessário possuir o Postman instalado para rodar e testar a API nas chamadas de dos dois EndPoint's criados.

   - Abra o Postman. 
   - Clique em File, clique em Importe e indique a pasta Postman o arquivo Jogo.postman_collection.json 
   - Clique em Collections, clique em Jogo e logo abaixo aparecerão os 2 EndPoint's criados.
   - Execute os verbos importados para chamar os EndPoint's criados


Verbos

- Post (que ao ser executado gera automaticamente uma rodada do jogo 
        e inclui no no banco os valores dos dados e a mensagem totalizando 
        e indicando qual categoria alcançou e a pontuação).

- Get (que apresenta todos registros da tabela de rodadas do jogo). 

Os dois endpoint's já possibilitam ver o funcionamento da API REST


 


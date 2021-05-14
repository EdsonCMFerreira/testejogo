
PASSO 1
----------------------------- 
SERVIDOR DE DADOS - SQL SERVER

- Criar no servidor de Dados o banco DB e rodar nele o script abaixo

USE [Db]
GO

/****** Object:  Table [dbo].[Rodada]    Script Date: 14/05/2021 15:30:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[Rodada](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[createdAt] [datetime] NULL,
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

ALTER TABLE [dbo].[Rodada] ADD  CONSTRAINT [DF_Rodada_createdAt]  DEFAULT (getdate()) FOR [createdAt]
GO


-----------------------------

2- Carregue o projeto no Visual Studio  

BackEnd
API Rest desenvolvida em .NET C# ASP.NET CORE WEBAPI
Construida e Modelada em DDD
Utilizando bibliotecas como Dapper
e SeriLog para monitoramento.

Atualize no arquivo appsettings.js e no ConnectionStrings coloque a Conexão de um banco Sql Server local.

 "ConnectionStrings": {
    "SensorDataServer": "server=DESKTOP-TKT2S2J\\NEWSQL;database=db;user=sa;password=321654987"
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



-------------------------------
4- CARREGUE O FRONT NO NAVEGADOR (MANTENHA O VISUAL STUDIO CARREGANDO A APLICAÇÃO PARA QUE AS API'S RESPONDAM AO FRONTEND).

Frontend
Foi desenvolvido com Framework Next.Js React
* O Frontend é executado no prompt de comando.

Para desenvolvimento:
npm run dev

Para produção:
npm run start 

Optei por aprensentar em Next.Js React pois o front já fiz em .NET C#, mas podria também apresentar seus dados consumindo a API com seus EndPoint's.


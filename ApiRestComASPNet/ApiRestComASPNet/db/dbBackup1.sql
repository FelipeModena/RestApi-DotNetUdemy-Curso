-- --------------------------------------------------------
-- Servidor:                     127.0.0.1
-- Versão do servidor:           8.0.25 - MySQL Community Server - GPL
-- OS do Servidor:               Win64
-- HeidiSQL Versão:              11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Copiando estrutura do banco de dados para sd_website_dashboard
CREATE DATABASE IF NOT EXISTS `sd_website_dashboard` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `sd_website_dashboard`;

-- Copiando estrutura para tabela sd_website_dashboard.adminstrador
CREATE TABLE IF NOT EXISTS `adminstrador` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `usuario` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `password` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela sd_website_dashboard.adminstrador: ~1 rows (aproximadamente)
/*!40000 ALTER TABLE `adminstrador` DISABLE KEYS */;
INSERT INTO `adminstrador` (`Id`, `usuario`, `password`) VALUES
	(1, 'modena', 'admin123');
/*!40000 ALTER TABLE `adminstrador` ENABLE KEYS */;

-- Copiando estrutura para tabela sd_website_dashboard.componente
CREATE TABLE IF NOT EXISTS `componente` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `tipo_componente` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `pagina_id` bigint NOT NULL DEFAULT '0',
  `cor_botao_1` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `cor_sub_titulo` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `cor_titulo` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `sub_titulo` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `texto` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `titulo` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `txt_botao_1` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `url_botao_1` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `url_direcionamento_paginas` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `url_imagem` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_componente_pagina_id` (`pagina_id`),
  CONSTRAINT `FK_componente_pagina_pagina_id` FOREIGN KEY (`pagina_id`) REFERENCES `pagina` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela sd_website_dashboard.componente: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `componente` DISABLE KEYS */;
INSERT INTO `componente` (`Id`, `tipo_componente`, `pagina_id`, `cor_botao_1`, `cor_sub_titulo`, `cor_titulo`, `sub_titulo`, `texto`, `titulo`, `txt_botao_1`, `url_botao_1`, `url_direcionamento_paginas`, `url_imagem`) VALUES
	(1, 'banner', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
/*!40000 ALTER TABLE `componente` ENABLE KEYS */;

-- Copiando estrutura para tabela sd_website_dashboard.contato
CREATE TABLE IF NOT EXISTS `contato` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `endereco` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `cidade` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `bairro` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `estado` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `complemento` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `whatsapp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `telefone` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `facebook` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `instagram` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `linkedin` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `youtube` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `modificacao` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela sd_website_dashboard.contato: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `contato` DISABLE KEYS */;
INSERT INTO `contato` (`Id`, `endereco`, `cidade`, `bairro`, `estado`, `complemento`, `whatsapp`, `telefone`, `email`, `facebook`, `instagram`, `linkedin`, `youtube`, `modificacao`) VALUES
	(1, 'Rua Pedro Cardoso n 56', 'São Paulo', 'Vila Industrial', 'SP', 'Predio Azul', '(11) 97640-3292', '(14) 4292-3492', 'sharkdata.comercial@gmail.com.br', 'link', 'link Istagram', 'link Linkedin', NULL, '2021-07-15 16:53:25.912721');
/*!40000 ALTER TABLE `contato` ENABLE KEYS */;

-- Copiando estrutura para tabela sd_website_dashboard.log
CREATE TABLE IF NOT EXISTS `log` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `data` datetime(6) NOT NULL,
  `table` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `error` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela sd_website_dashboard.log: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `log` DISABLE KEYS */;
/*!40000 ALTER TABLE `log` ENABLE KEYS */;

-- Copiando estrutura para tabela sd_website_dashboard.pagina
CREATE TABLE IF NOT EXISTS `pagina` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `nome_pagina` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ordem` int NOT NULL,
  `ativa` tinyint(1) NOT NULL DEFAULT '0',
  `modificacao` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000',
  `url` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela sd_website_dashboard.pagina: ~5 rows (aproximadamente)
/*!40000 ALTER TABLE `pagina` DISABLE KEYS */;
INSERT INTO `pagina` (`Id`, `nome_pagina`, `ordem`, `ativa`, `modificacao`, `url`) VALUES
	(1, 'quemSomos', 1, 1, '2021-07-15 13:53:55.706854', NULL),
	(2, 'portfolio', 4, 0, '2021-07-15 13:53:55.706864', NULL),
	(3, 'produtos', 5, 0, '2021-07-15 13:53:55.706864', NULL),
	(4, 'contato', 3, 0, '2021-07-15 13:53:55.706861', NULL),
	(5, 'inicio', 2, 0, '2021-07-15 13:53:55.706859', NULL);
/*!40000 ALTER TABLE `pagina` ENABLE KEYS */;

-- Copiando estrutura para tabela sd_website_dashboard.rodape
CREATE TABLE IF NOT EXISTS `rodape` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `rodape_ativo` tinyint(1) NOT NULL,
  `cor_fundo` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `icones_redes_sociais` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `logo` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `modificacao` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela sd_website_dashboard.rodape: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `rodape` DISABLE KEYS */;
INSERT INTO `rodape` (`Id`, `rodape_ativo`, `cor_fundo`, `icones_redes_sociais`, `logo`, `modificacao`) VALUES
	(1, 1, '#9f5656', 'white', 'img.jpg', '2021-07-15 17:23:03.074586');
/*!40000 ALTER TABLE `rodape` ENABLE KEYS */;

-- Copiando estrutura para tabela sd_website_dashboard.__efmigrationshistory
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela sd_website_dashboard.__efmigrationshistory: ~13 rows (aproximadamente)
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
	('20210706160445_Initial', '5.0.7'),
	('20210708154317_addFkComponente', '5.0.7'),
	('20210708154726_addFkComponenteRebase', '5.0.7'),
	('20210712114741_update_tabela_componente', '5.0.7'),
	('20210712120907_update_tabela_componente_couluna_nomeComponente', '5.0.7'),
	('20210712125923_update_tabela_componente_couluna_nomeComponent', '5.0.7'),
	('20210712131605_update_tabela_componente_couluna_nomeComponen', '5.0.7'),
	('20210712133131_update_tabela_componente_couluna_nomeCompone', '5.0.7'),
	('20210712134903_update_tabela_componente_couluna_nomeCompon', '5.0.7'),
	('20210712153410_pagina_addAtiva', '5.0.7'),
	('20210713200527_LogRodapeConfiguracao', '5.0.7'),
	('20210713210723_ConfigVarErraa', '5.0.7'),
	('20210714131232_updateTableConfiguracaoToContato', '5.0.7'),
	('20210714131323_updateTableConfiguracaoToContatoo', '5.0.7'),
	('20210715205459_updatePAginaUrl', '5.0.7');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;

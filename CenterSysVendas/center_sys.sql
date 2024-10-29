-- --------------------------------------------------------
-- Servidor:                     127.0.0.1
-- Versão do servidor:           8.0.27 - MySQL Community Server - GPL
-- OS do Servidor:               Win64
-- HeidiSQL Versão:              12.6.0.6765
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Copiando estrutura do banco de dados para centersys
CREATE DATABASE IF NOT EXISTS `centersys` /*!40100 DEFAULT CHARACTER SET utf8 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `centersys`;

-- Copiando estrutura para tabela centersys.assinaturas
CREATE TABLE IF NOT EXISTS `assinaturas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `cliente_id` int NOT NULL,
  `venda_id` int NOT NULL,
  `data_inicio` datetime NOT NULL,
  `status` varchar(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `cliente_id` (`cliente_id`),
  KEY `venda_id` (`venda_id`),
  CONSTRAINT `assinaturas_ibfk_1` FOREIGN KEY (`cliente_id`) REFERENCES `cliente` (`id`),
  CONSTRAINT `assinaturas_ibfk_2` FOREIGN KEY (`venda_id`) REFERENCES `vendas` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela centersys.assinaturas: ~0 rows (aproximadamente)

-- Copiando estrutura para tabela centersys.cidade
CREATE TABLE IF NOT EXISTS `cidade` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(250) NOT NULL,
  `codigo_ibge` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `uf_sigla` varchar(2) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `codigo_ibge_UNIQUE` (`codigo_ibge`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela centersys.cidade: ~0 rows (aproximadamente)
INSERT INTO `cidade` (`id`, `nome`, `codigo_ibge`, `uf_sigla`) VALUES
	(4, 'Belo Horizonte', '3106200', 'MG'),
	(5, 'Divinópolis', '3122306', 'MG');

-- Copiando estrutura para tabela centersys.cliente
CREATE TABLE IF NOT EXISTS `cliente` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nome_cliente` varchar(250) NOT NULL,
  `cpf` varchar(45) NOT NULL,
  `dat_nascimento` date NOT NULL,
  `cep` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `logradouro` varchar(250) DEFAULT NULL,
  `numero` varchar(45) DEFAULT NULL,
  `cidade_id` int NOT NULL,
  `usuarios_id` int unsigned NOT NULL,
  `situacao` int NOT NULL DEFAULT '1' COMMENT '0 - inativo\\n1 - ativo',
  `complemento` varchar(50) DEFAULT NULL,
  `bairro` varchar(250) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  UNIQUE KEY `cpf_UNIQUE` (`cpf`),
  KEY `fk_cliente_cidade1_idx` (`cidade_id`),
  KEY `fk_cliente_usuarios1_idx` (`usuarios_id`),
  CONSTRAINT `fk_cliente_cidade1` FOREIGN KEY (`cidade_id`) REFERENCES `cidade` (`id`),
  CONSTRAINT `fk_cliente_usuarios1` FOREIGN KEY (`usuarios_id`) REFERENCES `usuarios` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela centersys.cliente: ~2 rows (aproximadamente)
INSERT INTO `cliente` (`id`, `nome_cliente`, `cpf`, `dat_nascimento`, `cep`, `logradouro`, `numero`, `cidade_id`, `usuarios_id`, `situacao`, `complemento`, `bairro`) VALUES
	(5, 'Eduardo Rodrigues', '062.757.326-60', '1984-02-24', '30770-550', 'Rua Belmiro Braga', '585', 4, 1, 1, 'Casa', 'Caiçaras'),
	(6, 'Cliente Inativo', '875.662.430-12', '2024-01-01', '35501-010', 'Rua Padre Eustáquio', '179', 5, 1, 0, 'Casa', 'Esplanada');

-- Copiando estrutura para tabela centersys.configuracoes
CREATE TABLE IF NOT EXISTS `configuracoes` (
  `id` int NOT NULL,
  `dat_last_rec` datetime DEFAULT NULL,
  `usuarios_id` int unsigned NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_configuracoes_usuarios_idx` (`usuarios_id`),
  CONSTRAINT `fk_configuracoes_usuarios` FOREIGN KEY (`usuarios_id`) REFERENCES `usuarios` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela centersys.configuracoes: ~0 rows (aproximadamente)

-- Copiando estrutura para tabela centersys.forma_pagamento
CREATE TABLE IF NOT EXISTS `forma_pagamento` (
  `id` int NOT NULL AUTO_INCREMENT,
  `des_forma_pagamento` varchar(250) DEFAULT NULL,
  `vlr_diferenca` decimal(10,2) DEFAULT NULL,
  `tipo` int DEFAULT NULL COMMENT '0 - Nenhum      1 - Acréscimo       2 - Desconto',
  `tipocredito` int DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela centersys.forma_pagamento: ~0 rows (aproximadamente)
INSERT INTO `forma_pagamento` (`id`, `des_forma_pagamento`, `vlr_diferenca`, `tipo`, `tipocredito`) VALUES
	(1, 'Boleto À Vista', 0.00, 0, 0),
	(2, 'Cartão de Crédito ', 0.00, 0, 1),
	(5, 'Boleto Com Taxa', 5.00, 1, 0);

-- Copiando estrutura para tabela centersys.produtos
CREATE TABLE IF NOT EXISTS `produtos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nome_produto` varchar(250) DEFAULT NULL,
  `preco_final` decimal(10,2) DEFAULT NULL,
  `plano_recorrente` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela centersys.produtos: ~1 rows (aproximadamente)
INSERT INTO `produtos` (`id`, `nome_produto`, `preco_final`, `plano_recorrente`) VALUES
	(2, 'Youtube Premium', 45.00, 1);

-- Copiando estrutura para tabela centersys.usuarios
CREATE TABLE IF NOT EXISTS `usuarios` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `nome` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `login` varchar(10) NOT NULL,
  `senha` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ativo` int NOT NULL,
  `perfil` int NOT NULL COMMENT '1 - Administrador\\n2 - Usuário',
  PRIMARY KEY (`id`),
  UNIQUE KEY `login_UNIQUE` (`login`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela centersys.usuarios: ~1 rows (aproximadamente)
INSERT INTO `usuarios` (`id`, `nome`, `login`, `senha`, `ativo`, `perfil`) VALUES
	(1, 'administrador', 'adm', 'e2259fa93c920449f067d16d687320e8', 1, 1);

-- Copiando estrutura para tabela centersys.vendas
CREATE TABLE IF NOT EXISTS `vendas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `data_venda` datetime DEFAULT NULL,
  `cliente_id` int NOT NULL,
  `vlr_total` decimal(10,2) NOT NULL,
  `forma_pagamento_id` int NOT NULL,
  `recorrente` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `fk_vendas_cliente1_idx` (`cliente_id`),
  KEY `fk_vendas_forma_pagamento1_idx` (`forma_pagamento_id`),
  CONSTRAINT `fk_vendas_cliente1` FOREIGN KEY (`cliente_id`) REFERENCES `cliente` (`id`),
  CONSTRAINT `fk_vendas_forma_pagamento1` FOREIGN KEY (`forma_pagamento_id`) REFERENCES `forma_pagamento` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela centersys.vendas: ~10 rows (aproximadamente)
INSERT INTO `vendas` (`id`, `data_venda`, `cliente_id`, `vlr_total`, `forma_pagamento_id`, `recorrente`) VALUES
	(1, '2024-10-29 03:02:11', 5, 45.00, 1, 1),
	(2, '2024-10-29 03:33:26', 5, 45.00, 2, 1),
	(3, '2024-10-29 03:36:20', 5, 45.00, 2, 1),
	(4, '2024-10-29 03:37:58', 5, 45.00, 2, 1),
	(5, '2024-10-29 03:39:26', 5, 45.00, 2, 1),
	(6, '2024-10-29 03:40:36', 5, 45.00, 2, 1),
	(7, '2024-10-29 04:18:28', 5, 45.00, 1, 1),
	(8, '2024-10-29 04:19:46', 5, 45.00, 1, 1),
	(9, '2024-10-29 04:20:23', 5, 45.00, 1, 1),
	(10, '2024-10-29 04:22:10', 5, 45.00, 1, 1),
	(11, '2024-10-29 06:00:05', 5, 45.00, 2, 1),
	(12, '2024-10-29 06:27:07', 5, 45.00, 1, 1),
	(13, '2024-10-29 06:37:13', 5, 45.00, 1, 1),
	(14, '2024-10-29 06:45:13', 5, 45.00, 1, 1),
	(15, '2024-10-29 06:47:59', 5, 45.00, 1, 1),
	(16, '2024-10-29 13:12:39', 5, 45.00, 2, 1),
	(17, '2024-10-29 13:13:29', 5, 45.00, 2, 1);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;

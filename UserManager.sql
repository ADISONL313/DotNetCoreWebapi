-- MySQL dump 10.13  Distrib 8.0.37, for Win64 (x86_64)
--
-- Host: localhost    Database: UserManager
-- ------------------------------------------------------
-- Server version	8.0.37

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `user_id` varchar(36) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '用户ID（主键，建议使用UUID）',
  `username` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `email` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '电子邮箱',
  `password` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '密码（存储哈希值，不存储明文）',
  `phone` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT '' COMMENT '手机号码',
  `gender` varchar(10) COLLATE utf8mb4_unicode_ci DEFAULT '' COMMENT '性别（例如：男/女/未知）',
  `user_role` varchar(20) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT 'USER' COMMENT '用户角色（例如：ADMIN/USER）',
  `created_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `uk_email` (`email`),
  KEY `idx_user_role` (`user_role`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='用户表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES ('23b22cd7-834e-4540-a486-27cac3a01bd6','x小王','14347653427@qq.com','$2a$11$7I6rd8iX1LXitApljutCzupFXbM9PEzrAQ3AkRheTp6oXxYI9k.Ue','13347653426','女','管理员','2025-07-17 09:59:29'),('24d58d1c-d19e-42b6-8a36-138ca3d845eb','41234','1423437@qq.com','$2a$11$WEUUZXFOBbLV6n7X0jsx7eAwUHp89Gn1rAcr9/Db95LS4DAa81nrS','13347653426','男','普通用户','2025-07-17 09:59:46'),('35787e7d-d6f5-4d13-8f57-582d426e48a1','41234','143473427@qq.com','$2a$11$3u.F5Xe360/SQZkPlFCbLOeAVVxvUvM704Bl.9zRgjrcMTfSf23uG','13347653426','男','普通用户','2025-07-17 09:59:32'),('3689dd8e-4c1f-4122-bdf3-402b188ced92','41234','14373427@qq.com','$2a$11$5I9DCepT.Uku6WSS/uYre.wm/gaJJURVWetAf78hVexxsnvvzX6Ba','13347653426','男','普通用户','2025-07-17 09:59:34'),('52c2af7e-9049-45a3-841c-80f040f99b0b','111','1112@qq.com','$2a$11$BPDIa8cMDAfFAoxZ2dOJFuDO6MKP7yYadjwhFiVX1IDUGszn6Hn9K','17447653427','男','普通用户','2025-07-17 09:58:57'),('5861c929-99dd-4e4e-9d35-8b08d3332d80','41234','14237@qq.com','$2a$11$2bDRP2z.W3zKE6Q1/DUmRO28/o3.dok75tlHBigOAMTXTJtz6apz.','13347653426','男','普通用户','2025-07-17 09:59:41'),('60f8c4a8-008e-4e9d-8ca4-2bcb427cf382','刘成毅','324@qq.com','$2a$11$Qx.jmEFYxjK9JGtIvOXPPudE1pEiC/KcRuIHJx6Ixyq3KONITVFiW','','','普通用户','2025-07-17 17:57:14'),('667360ca-4b76-4784-b5c6-77ecd5be2361','41234','143427@qq.com','$2a$11$EH1GISuySJKWNs6JmT.UpOLR34KDFyZ4f9xf35ca3783JTmpAiTKi','13347653426','男','普通用户','2025-07-17 09:59:37'),('6a2257b1-6081-4ae4-8b88-b0ffb791ff1d','41234','1427@qq.com','$2a$11$UVdYU131/ajUgVujx.MQ4.eWMCfMP2s//fc.EO3od2NImJGufCL3i','13347653426','男','普通用户','2025-07-17 09:59:39'),('6dc9545a-5909-40b8-ade3-1edf62aaac6d','41234','14233437@qq.com','$2a$11$/c771eCPfOz7yBusOwdEFOMq6X9SzaoYr4ugXkvJMV27SwjYzJP6u','13347653426','男','普通用户','2025-07-17 09:59:50'),('96f12ca1-4fbb-47e8-9905-2e1de17876df','小王1231','431@163.com','$2a$11$bhJx1bmGsBMPcV6eqdk7iumjYOSOSYCZpcKDo7qNXqL8H5QBSiNdm','17265439876','女','普通用户','2025-07-17 12:06:59'),('aa0f76f2-c8ba-41f6-aa33-1b895d01c94c','41234','12347653427@qq.com','$2a$11$bzQ2Antp38VhSiKbC3rbkuf9jfQwxY4o8PpbXyaE5E4EUwF1jvmUu','13347653427','男','普通用户','2025-07-17 09:59:21'),('bb416864-0934-477d-89cc-1ab001910035','string','user@example.com','$2a$11$e4LvGo49VcgKXMYp3dOKkukJC5je5GtPbCmqhMbeIVTA04mfUTGhu','string','string','string','2025-07-17 15:00:50'),('e653fd9b-8929-4754-9400-cf949ef24dc2','小儿','321@qq.com','$2a$11$j1KMjHq..K9R2I31gNF9luzB2fa6nuzEDgs0pBPSv6DdeWmSzn5ZK','','','普通用户','2025-07-16 23:01:21'),('ec7dd856-4433-4aa9-bb1b-d600c9cf7b03','test','313670@qq.com','$2a$11$X7yRi3ngCRSxLbcmXzIH2OikTMULPYjoxobVgOWI6rs.HHSjjp20G','18723657890','男','普通用户','2025-07-17 17:59:47'),('f298dec3-0700-4f5c-a2e5-d07a997439de','41234','142337@qq.com','$2a$11$fEhavpjpXq/UvjwSQD/6cewbYyLt6dz2YDR17GSa.sTZMwJ5CpdQu','13347653426','男','普通用户','2025-07-17 09:59:44'),('f7ddc4eb-036e-414a-9610-ed9575d7a78e','ww','31231@qq.com','$2a$11$PQIrdacNAaQJPKrjeiim0OOt7nBEVX393iWZvfzGLur0nUb9Y.iTm','16579823465','女','普通用户','2025-07-17 11:27:02');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-07-18 22:26:33

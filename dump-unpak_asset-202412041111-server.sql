-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: unpak_asset
-- ------------------------------------------------------
-- Server version	5.5.5-10.4.32-MariaDB-log

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
-- Table structure for table `asset`
--

DROP TABLE IF EXISTS `asset`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `asset` (
  `id` varchar(36) NOT NULL,
  `nama` varchar(255) DEFAULT NULL,
  `tanggal_terdaftar` date DEFAULT NULL,
  `kondisi` varchar(100) DEFAULT NULL,
  `kode_aset` varchar(100) DEFAULT NULL,
  `id_group` varchar(36) DEFAULT NULL,
  `id_sub_group` varchar(36) DEFAULT NULL,
  `id_location` varchar(36) DEFAULT NULL,
  `po` varchar(255) DEFAULT NULL,
  `harga_per_unit` int(11) DEFAULT NULL,
  `total_unit` int(11) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `asset`
--

LOCK TABLES `asset` WRITE;
/*!40000 ALTER TABLE `asset` DISABLE KEYS */;
INSERT INTO `asset` VALUES ('78d0b4c2-3023-46d6-a806-e767327559c7','string','2021-01-01','baru','A001','1','1','','-',1000,1,NULL,NULL),('806cacad-5f38-4c4c-a9b3-27e659adb3ec','pupen','2021-01-01','baru','A001','','','1','-',1000,1,NULL,NULL);
/*!40000 ALTER TABLE `asset` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `asset_barcode`
--

DROP TABLE IF EXISTS `asset_barcode`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `asset_barcode` (
  `id` char(36) NOT NULL,
  `id_asset` char(36) DEFAULT NULL,
  `barcode` varchar(255) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `asset_barcode`
--

LOCK TABLES `asset_barcode` WRITE;
/*!40000 ALTER TABLE `asset_barcode` DISABLE KEYS */;
/*!40000 ALTER TABLE `asset_barcode` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `asset_image`
--

DROP TABLE IF EXISTS `asset_image`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `asset_image` (
  `id` char(36) NOT NULL,
  `id_asset` char(36) DEFAULT NULL,
  `url` text DEFAULT NULL,
  `file` text DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `asset_image`
--

LOCK TABLES `asset_image` WRITE;
/*!40000 ALTER TABLE `asset_image` DISABLE KEYS */;
/*!40000 ALTER TABLE `asset_image` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `assign_asset`
--

DROP TABLE IF EXISTS `assign_asset`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `assign_asset` (
  `id` varchar(36) NOT NULL,
  `kode_fakultas` varchar(100) DEFAULT NULL,
  `kode_prodi` varchar(100) DEFAULT NULL,
  `kode_unit` varchar(100) DEFAULT NULL,
  `nidn` varchar(100) DEFAULT NULL,
  `nip` varchar(100) DEFAULT NULL,
  `id_asset_barcode` char(36) DEFAULT NULL,
  `isChange` tinyint(1) DEFAULT 0,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `assign_asset`
--

LOCK TABLES `assign_asset` WRITE;
/*!40000 ALTER TABLE `assign_asset` DISABLE KEYS */;
INSERT INTO `assign_asset` VALUES ('9a740d89-e1de-4b08-9539-0686d9fc3637','2','3','1','','','123123',0,NULL,NULL);
/*!40000 ALTER TABLE `assign_asset` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `disposal_asset`
--

DROP TABLE IF EXISTS `disposal_asset`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `disposal_asset` (
  `id` char(36) NOT NULL,
  `id_ticket` char(36) DEFAULT NULL,
  `type` varchar(100) DEFAULT NULL,
  `pic` varchar(100) DEFAULT NULL,
  `id_group` char(36) DEFAULT NULL,
  `id_sub_group` char(36) DEFAULT NULL,
  `id_location` char(36) DEFAULT NULL,
  `informasi` text DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `disposal_asset`
--

LOCK TABLES `disposal_asset` WRITE;
/*!40000 ALTER TABLE `disposal_asset` DISABLE KEYS */;
/*!40000 ALTER TABLE `disposal_asset` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `disposal_asset_detail`
--

DROP TABLE IF EXISTS `disposal_asset_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `disposal_asset_detail` (
  `id` char(36) NOT NULL,
  `id_disposal` char(36) DEFAULT NULL,
  `id_asset_barcode` char(36) DEFAULT NULL,
  `type` varchar(100) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `disposal_asset_detail`
--

LOCK TABLES `disposal_asset_detail` WRITE;
/*!40000 ALTER TABLE `disposal_asset_detail` DISABLE KEYS */;
/*!40000 ALTER TABLE `disposal_asset_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `group`
--

DROP TABLE IF EXISTS `group`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `group` (
  `id` varchar(36) NOT NULL,
  `nama` varchar(255) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `group`
--

LOCK TABLES `group` WRITE;
/*!40000 ALTER TABLE `group` DISABLE KEYS */;
INSERT INTO `group` VALUES ('8fe51358-27ba-4ddc-ad76-1eab173c5045','tetap',NULL,NULL);
/*!40000 ALTER TABLE `group` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `location`
--

DROP TABLE IF EXISTS `location`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `location` (
  `id` varchar(36) NOT NULL,
  `nama` varchar(255) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `location`
--

LOCK TABLES `location` WRITE;
/*!40000 ALTER TABLE `location` DISABLE KEYS */;
INSERT INTO `location` VALUES ('7f0d0b0f-d693-467f-b84f-fd3502b5290f','beta',NULL,NULL);
/*!40000 ALTER TABLE `location` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `move_asset`
--

DROP TABLE IF EXISTS `move_asset`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `move_asset` (
  `id` varchar(36) NOT NULL,
  `id_ticket` varchar(36) DEFAULT NULL,
  `type` varchar(100) DEFAULT NULL COMMENT 'group, location, personal',
  `pic` varchar(100) DEFAULT NULL COMMENT 'id_user yg mencangkup nidn, nip atau bukan keduanya',
  `id_group` varchar(36) DEFAULT NULL,
  `id_sub_group` varchar(36) DEFAULT NULL,
  `id_location` varchar(36) DEFAULT NULL,
  `id_group_target` varchar(36) DEFAULT NULL,
  `id_sub_group_target` varchar(36) DEFAULT NULL,
  `id_location_target` varchar(36) DEFAULT NULL,
  `user_target` varchar(36) DEFAULT NULL COMMENT 'khususu personal',
  `informasi` text DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `move_asset`
--

LOCK TABLES `move_asset` WRITE;
/*!40000 ALTER TABLE `move_asset` DISABLE KEYS */;
/*!40000 ALTER TABLE `move_asset` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `move_asset_detail`
--

DROP TABLE IF EXISTS `move_asset_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `move_asset_detail` (
  `id` char(36) NOT NULL,
  `id_move_asset` char(36) DEFAULT NULL,
  `id_asset_barcode` char(36) DEFAULT NULL,
  `scanedBy` varchar(100) DEFAULT NULL COMMENT 'pakai id_user',
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `move_asset_detail`
--

LOCK TABLES `move_asset_detail` WRITE;
/*!40000 ALTER TABLE `move_asset_detail` DISABLE KEYS */;
/*!40000 ALTER TABLE `move_asset_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `physical_asset`
--

DROP TABLE IF EXISTS `physical_asset`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `physical_asset` (
  `id` char(36) NOT NULL,
  `tipe` varchar(100) DEFAULT NULL,
  `tanggal_mulai` date DEFAULT NULL,
  `tanggal_akhir` date DEFAULT NULL,
  `pic` varchar(100) DEFAULT NULL,
  `id_group` char(36) DEFAULT NULL,
  `id_sub_group` char(36) DEFAULT NULL,
  `id_location` char(36) DEFAULT NULL,
  `informasi` text DEFAULT NULL,
  `created_at` date DEFAULT NULL,
  `updated_at` date DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `physical_asset`
--

LOCK TABLES `physical_asset` WRITE;
/*!40000 ALTER TABLE `physical_asset` DISABLE KEYS */;
/*!40000 ALTER TABLE `physical_asset` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `physical_asset_detail`
--

DROP TABLE IF EXISTS `physical_asset_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `physical_asset_detail` (
  `id` char(36) NOT NULL,
  `id_physical` char(36) DEFAULT NULL,
  `id_asset_barcode` char(36) DEFAULT NULL,
  `status` varchar(100) DEFAULT NULL,
  `catatan` text DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `physical_asset_detail`
--

LOCK TABLES `physical_asset_detail` WRITE;
/*!40000 ALTER TABLE `physical_asset_detail` DISABLE KEYS */;
/*!40000 ALTER TABLE `physical_asset_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `repair_asset`
--

DROP TABLE IF EXISTS `repair_asset`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `repair_asset` (
  `id` char(36) NOT NULL,
  `id_ticket` char(36) DEFAULT NULL,
  `type` varchar(100) DEFAULT NULL,
  `pic` varchar(100) DEFAULT NULL,
  `id_group` char(36) DEFAULT NULL,
  `id_sub_group` char(36) DEFAULT NULL,
  `id_location` char(36) DEFAULT NULL,
  `informasi` text DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `repair_asset`
--

LOCK TABLES `repair_asset` WRITE;
/*!40000 ALTER TABLE `repair_asset` DISABLE KEYS */;
/*!40000 ALTER TABLE `repair_asset` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `repair_asset_detail`
--

DROP TABLE IF EXISTS `repair_asset_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `repair_asset_detail` (
  `id` char(36) NOT NULL,
  `id_repair` char(36) DEFAULT NULL,
  `id_asset_barcode` char(36) DEFAULT NULL,
  `type` varchar(100) DEFAULT NULL,
  `total_harga` varchar(100) DEFAULT NULL,
  `struk` text DEFAULT NULL,
  `tanggal_mulai` date DEFAULT NULL,
  `estimasi_tanggal_selesai` date DEFAULT NULL,
  `tanggal_selesai` date DEFAULT NULL,
  `catatan_kerusakan` text DEFAULT NULL,
  `catatan_keterlambatan` text DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `repair_asset_detail`
--

LOCK TABLES `repair_asset_detail` WRITE;
/*!40000 ALTER TABLE `repair_asset_detail` DISABLE KEYS */;
/*!40000 ALTER TABLE `repair_asset_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sub_group`
--

DROP TABLE IF EXISTS `sub_group`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sub_group` (
  `id` char(36) NOT NULL,
  `nama` varchar(255) DEFAULT NULL,
  `id_group` char(36) NOT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sub_group`
--

LOCK TABLES `sub_group` WRITE;
/*!40000 ALTER TABLE `sub_group` DISABLE KEYS */;
/*!40000 ALTER TABLE `sub_group` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ticket`
--

DROP TABLE IF EXISTS `ticket`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ticket` (
  `id` char(36) NOT NULL,
  `nidn` varchar(100) DEFAULT NULL,
  `nip` varchar(100) DEFAULT NULL,
  `type` varchar(100) DEFAULT NULL,
  `catatan` text DEFAULT NULL,
  `status` varchar(100) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ticket`
--

LOCK TABLES `ticket` WRITE;
/*!40000 ALTER TABLE `ticket` DISABLE KEYS */;
/*!40000 ALTER TABLE `ticket` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'unpak_asset'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-12-04 11:11:59

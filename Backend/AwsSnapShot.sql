CREATE DATABASE  IF NOT EXISTS `TestingLab` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `TestingLab`;
-- MySQL dump 10.13  Distrib 8.0.25, for macos11 (x86_64)
--
-- Host: traininglab.cwnie53k7o0m.ap-south-1.rds.amazonaws.com    Database: TestingLab
-- ------------------------------------------------------
-- Server version	8.0.25

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
SET @MYSQLDUMP_TEMP_LOG_BIN = @@SESSION.SQL_LOG_BIN;
SET @@SESSION.SQL_LOG_BIN= 0;

--
-- GTID state at the beginning of the backup 
--

SET @@GLOBAL.GTID_PURGED=/*!80000 '+'*/ '';

--
-- Table structure for table `CourseDetails`
--

DROP TABLE IF EXISTS `CourseDetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `CourseDetails` (
  `CourseID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  PRIMARY KEY (`CourseID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `CourseDetails`
--

LOCK TABLES `CourseDetails` WRITE;
/*!40000 ALTER TABLE `CourseDetails` DISABLE KEYS */;
INSERT INTO `CourseDetails` VALUES (1,'C# for BackEnd'),(2,'ReactJS for FrontEnd');
/*!40000 ALTER TABLE `CourseDetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `EventActiveUser`
--

DROP TABLE IF EXISTS `EventActiveUser`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `EventActiveUser` (
  `userName` varchar(32) NOT NULL,
  `EventID` varchar(32) NOT NULL,
  `Panelist` tinyint NOT NULL DEFAULT '0',
  `Active` tinyint NOT NULL DEFAULT '0',
  PRIMARY KEY (`userName`,`EventID`),
  KEY `EventID` (`EventID`),
  CONSTRAINT `EventID` FOREIGN KEY (`EventID`) REFERENCES `EventList` (`EventID`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `userName2` FOREIGN KEY (`userName`) REFERENCES `UserAuthentication` (`userName`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `EventActiveUser`
--

LOCK TABLES `EventActiveUser` WRITE;
/*!40000 ALTER TABLE `EventActiveUser` DISABLE KEYS */;
/*!40000 ALTER TABLE `EventActiveUser` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `EventList`
--

DROP TABLE IF EXISTS `EventList`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `EventList` (
  `EventID` varchar(32) NOT NULL,
  `Name` varchar(45) NOT NULL,
  `StartTime` datetime NOT NULL,
  `Active` tinyint NOT NULL DEFAULT '0',
  `EventURL` varchar(258) NOT NULL,
  `EndTime` datetime NOT NULL,
  PRIMARY KEY (`EventID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `EventList`
--

LOCK TABLES `EventList` WRITE;
/*!40000 ALTER TABLE `EventList` DISABLE KEYS */;
INSERT INTO `EventList` VALUES ('TESTEVENT1','Testing Event with Bollywood','2021-06-20 17:15:00',1,'https://www.youtube.com/watch?v=A_VYgPvMp0E','2021-07-20 17:15:00');
/*!40000 ALTER TABLE `EventList` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `InviteList`
--

DROP TABLE IF EXISTS `InviteList`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `InviteList` (
  `email` varchar(32) NOT NULL,
  PRIMARY KEY (`email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `InviteList`
--

LOCK TABLES `InviteList` WRITE;
/*!40000 ALTER TABLE `InviteList` DISABLE KEYS */;
INSERT INTO `InviteList` VALUES ('abh1abii101@gmail.com'),('abhi@gmail.com'),('admin@abiistudio.com');
/*!40000 ALTER TABLE `InviteList` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `LevelSlab`
--

DROP TABLE IF EXISTS `LevelSlab`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `LevelSlab` (
  `LevelNo` int NOT NULL AUTO_INCREMENT,
  `LevelName` varchar(45) NOT NULL,
  `MinimumScore` float NOT NULL,
  PRIMARY KEY (`LevelNo`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `LevelSlab`
--

LOCK TABLES `LevelSlab` WRITE;
/*!40000 ALTER TABLE `LevelSlab` DISABLE KEYS */;
INSERT INTO `LevelSlab` VALUES (1,'Amateur',0),(2,'Novice',30),(3,'Intermediate',60),(4,'Expert',120),(5,'AntiSocial',260);
/*!40000 ALTER TABLE `LevelSlab` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `SubCourseDetails`
--

DROP TABLE IF EXISTS `SubCourseDetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `SubCourseDetails` (
  `SubCourseID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `SubCourseURL` varchar(258) NOT NULL,
  `CourseID` int NOT NULL,
  `Title` varchar(45) DEFAULT 'Title',
  `Desc` varchar(258) DEFAULT 'Desc',
  PRIMARY KEY (`SubCourseID`),
  KEY `CourseID2_idx` (`CourseID`),
  CONSTRAINT `CourseID2` FOREIGN KEY (`CourseID`) REFERENCES `CourseDetails` (`CourseID`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `SubCourseDetails`
--

LOCK TABLES `SubCourseDetails` WRITE;
/*!40000 ALTER TABLE `SubCourseDetails` DISABLE KEYS */;
INSERT INTO `SubCourseDetails` VALUES (1,'An Introduction to C# learning cycle.','https://prespectify-traininglab.s3.ap-south-1.amazonaws.com/C%23_for_BackEnd/01.An_Introduction_To_The_C%23_Learning_Cycle.mp4',1,'Title','Desc'),(2,'How To Install Visual Studio-2019','https://prespectify-traininglab.s3.ap-south-1.amazonaws.com/C%23_for_BackEnd/02.How_To_Install_Visual_Studio-2019.mp4',1,'How To Install Visual Studio-2019','Desc'),(3,' Intro to Visual Studio 2019, What\'s New?','https://prespectify-traininglab.s3.ap-south-1.amazonaws.com/C%23_for_BackEnd/03.Intro_to_Visual_Studio_2019-What\'s_New%2C_What\'s_Better%2C_and_Why_You_Should_Upgrade.mp4',1,' Intro to Visual Studio 2019, What\'s New?','Desc'),(4,'Top 10 Hidden Gems in Visual Studio','https://prespectify-traininglab.s3.ap-south-1.amazonaws.com/C%23_for_BackEnd/04.Top_10_Hidden_Gems_in_Visual_Studio-Speed_Up_Development_Without_Increasing_Your_Costs.mp4',1,' Top 10 Hidden Gems in Visual Studio ','Desc'),(5,'Visual Studio Editor Tips','https://prespectify-traininglab.s3.ap-south-1.amazonaws.com/C%23_for_BackEnd/05.15_Visual_Studio_Editor_Tips_including_Intellicode_and_EditorConfig.mp4',1,'Visual Studio Editor Tips','Desc'),(6,'Getting help online as a Developer','https://prespectify-traininglab.s3.ap-south-1.amazonaws.com/C%23_for_BackEnd/06.How_to_Get_Help_Online_as_a_Software_Developer.mp4',1,'Getting help online as a Developer ','Desc'),(7,'Debugging and Breakpoints','https://prespectify-traininglab.s3.ap-south-1.amazonaws.com/C%23_for_BackEnd/07.C%23_Debugging__Breakpoints.mp4',1,'Debugging and Breakpoints ','Desc'),(8,'Handling Exceptions','https://prespectify-traininglab.s3.ap-south-1.amazonaws.com/C%23_for_BackEnd/08.Handling_Exceptions_in_C%23_-_When_to_catch_them%2C_where_to_catch_them%2C_and_how_to_catch_them.mp4',1,'Handling Exceptions ','Desc'),(9,'Finding and Fixing Problems','https://prespectify-traininglab.s3.ap-south-1.amazonaws.com/C%23_for_BackEnd/09.Debugging_in_C%23_-_Finding_and_Fixing_Problems_in_Your_Application.mp4',1,'Finding and Fixing Problems ','Desc'),(10,'Refactoring in C#','https://prespectify-traininglab.s3.ap-south-1.amazonaws.com/C%23_for_BackEnd/10.Refactoring_in_C%23_-_Improving_an_Existing_Application.mp4',1,'Refactoring in C# ','Desc'),(11,'Introduction','https://prespectify-traininglab.s3.ap-south-1.amazonaws.com/ReactJS_for_FrontEnd/01.ReactJS_Tutorial_-_1_-_Introduction.mp4',2,'Introduction ','Desc'),(12,'Hello World','https://prespectify-traininglab.s3.ap-south-1.amazonaws.com/ReactJS_for_FrontEnd/02.ReactJS_Tutorial_-_2_-_Hello_World.mp4',2,'Hello World ','Desc'),(13,'Folder Structure','https://prespectify-traininglab.s3.ap-south-1.amazonaws.com/ReactJS_for_FrontEnd/03.ReactJS_Tutorial_-_3_-_Folder_Structure.mp4',2,'Folder Structure ','Desc'),(14,'Components','https://prespectify-traininglab.s3.ap-south-1.amazonaws.com/ReactJS_for_FrontEnd/04.ReactJS_Tutorial_-_4_-_Components.mp4',2,'Components ','Desc'),(15,'Functional Components','https://prespectify-traininglab.s3.ap-south-1.amazonaws.com/ReactJS_for_FrontEnd/05.ReactJS_Tutorial_-_5_-_Functional_Components.mp4',2,'Functional Components ','Desc'),(16,'Class Components','https://prespectify-traininglab.s3.ap-south-1.amazonaws.com/ReactJS_for_FrontEnd/06.ReactJS_Tutorial_-_6_-_Class_Components.mp4',2,'Class Components ','Desc'),(17,'Hooks Update','https://prespectify-traininglab.s3.ap-south-1.amazonaws.com/ReactJS_for_FrontEnd/07.ReactJS_Tutorial_-_7_-_Hooks_Update.mp4',2,'Hooks Update ','Desc');
/*!40000 ALTER TABLE `SubCourseDetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TestDetails`
--

DROP TABLE IF EXISTS `TestDetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `TestDetails` (
  `TestID` int NOT NULL AUTO_INCREMENT,
  `TestName` varchar(45) NOT NULL,
  `CourseID` int NOT NULL,
  `TestURL` varchar(258) NOT NULL,
  PRIMARY KEY (`TestID`),
  KEY `CourseID_idx` (`CourseID`),
  CONSTRAINT `CourseID` FOREIGN KEY (`CourseID`) REFERENCES `CourseDetails` (`CourseID`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TestDetails`
--

LOCK TABLES `TestDetails` WRITE;
/*!40000 ALTER TABLE `TestDetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `TestDetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `UserActivityLog`
--

DROP TABLE IF EXISTS `UserActivityLog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `UserActivityLog` (
  `userName` varchar(32) NOT NULL,
  `LogInTime` datetime NOT NULL,
  `LogOutTime` datetime DEFAULT NULL,
  `LogID` int NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`LogID`),
  KEY `userName` (`userName`),
  CONSTRAINT `userName` FOREIGN KEY (`userName`) REFERENCES `UserAuthentication` (`userName`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `UserActivityLog`
--

LOCK TABLES `UserActivityLog` WRITE;
/*!40000 ALTER TABLE `UserActivityLog` DISABLE KEYS */;
INSERT INTO `UserActivityLog` VALUES ('abh1abii','2021-06-13 17:30:45','2021-06-13 17:32:45',1),('admin','2021-06-13 17:27:45','2021-06-13 17:30:45',2);
/*!40000 ALTER TABLE `UserActivityLog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `UserAuthentication`
--

DROP TABLE IF EXISTS `UserAuthentication`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `UserAuthentication` (
  `userName` varchar(32) NOT NULL,
  `Admin` tinyint NOT NULL DEFAULT '0',
  `password` varchar(258) NOT NULL,
  `email` varchar(32) NOT NULL,
  PRIMARY KEY (`userName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `UserAuthentication`
--

LOCK TABLES `UserAuthentication` WRITE;
/*!40000 ALTER TABLE `UserAuthentication` DISABLE KEYS */;
INSERT INTO `UserAuthentication` VALUES ('abh1abii',0,'ff53ac5fa36921dfea21f422b056461e59be6ce1214acb1fa63c9ace84bf1e98','abh1abii101@gmail.com'),('admin',1,'8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918','admin@abiistudio.com');
/*!40000 ALTER TABLE `UserAuthentication` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `UserLevel`
--

DROP TABLE IF EXISTS `UserLevel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `UserLevel` (
  `userName` varchar(32) NOT NULL,
  `TestScore` float NOT NULL DEFAULT '0',
  PRIMARY KEY (`userName`),
  CONSTRAINT `userName4` FOREIGN KEY (`userName`) REFERENCES `UserAuthentication` (`userName`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `UserLevel`
--

LOCK TABLES `UserLevel` WRITE;
/*!40000 ALTER TABLE `UserLevel` DISABLE KEYS */;
INSERT INTO `UserLevel` VALUES ('abh1abii',0),('admin',0);
/*!40000 ALTER TABLE `UserLevel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `UserProgress`
--

DROP TABLE IF EXISTS `UserProgress`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `UserProgress` (
  `userName` varchar(32) NOT NULL,
  `Score` float NOT NULL DEFAULT '0',
  `TestID` int NOT NULL,
  PRIMARY KEY (`TestID`,`userName`),
  KEY `userName3_idx` (`userName`),
  CONSTRAINT `TestID` FOREIGN KEY (`TestID`) REFERENCES `TestDetails` (`TestID`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `userName3` FOREIGN KEY (`userName`) REFERENCES `UserAuthentication` (`userName`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `UserProgress`
--

LOCK TABLES `UserProgress` WRITE;
/*!40000 ALTER TABLE `UserProgress` DISABLE KEYS */;
/*!40000 ALTER TABLE `UserProgress` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `blacklisttokens`
--

DROP TABLE IF EXISTS `blacklisttokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `blacklisttokens` (
  `token` varchar(258) NOT NULL,
  `entrytime` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `blacklisttokens`
--

LOCK TABLES `blacklisttokens` WRITE;
/*!40000 ALTER TABLE `blacklisttokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `blacklisttokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `refreshtokens`
--

DROP TABLE IF EXISTS `refreshtokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `refreshtokens` (
  `username` varchar(20) NOT NULL,
  `refreshtoken` varchar(258) NOT NULL,
  `expirationdate` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `refreshtokens`
--

LOCK TABLES `refreshtokens` WRITE;
/*!40000 ALTER TABLE `refreshtokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `refreshtokens` ENABLE KEYS */;
UNLOCK TABLES;
SET @@SESSION.SQL_LOG_BIN = @MYSQLDUMP_TEMP_LOG_BIN;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-06-30 12:34:39

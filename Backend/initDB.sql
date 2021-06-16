Create Database TestingLab;
CREATE TABLE `TestingLab`.`UserAuthentication` (
  `userName` VARCHAR(32) NOT NULL,
  `Admin` TINYINT NOT NULL DEFAULT 0,
  `password` VARCHAR(258) NOT NULL,
  `email` VARCHAR(32) NOT NULL,
  PRIMARY KEY (`userName`));

CREATE TABLE `TestingLab`.`EventList` (
  `EventID` VARCHAR(32) NOT NULL,
  `Name` VARCHAR(45) NOT NULL,
  `StartTime` DATETIME NOT NULL,
  `Active` TINYINT NOT NULL DEFAULT 0,
  `EventURL` VARCHAR(258) NOT NULL,
  `EndTime` DATETIME NOT NULL,
  PRIMARY KEY (`EventID`));

CREATE TABLE `TestingLab`.`UserActivityLog` (
  `userName` varchar(32) NOT NULL,
  `LogInTime` datetime NOT NULL,
  `LogOutTime` datetime DEFAULT NULL,
  `LogID` int NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`LogID`),
  KEY `userName` (`userName`),
  CONSTRAINT `userName` FOREIGN KEY (`userName`) REFERENCES `UserAuthentication` (`userName`) ON DELETE RESTRICT ON UPDATE CASCADE
);

CREATE TABLE `TestingLab`.`EventActiveUser` (
  `userName` VARCHAR(32) NOT NULL,
  `EventID` VARCHAR(32) NOT NULL,
  `Panelist` TINYINT NOT NULL DEFAULT 0,
  `Active` TINYINT NOT NULL DEFAULT 0,
  PRIMARY KEY (`userName`, `EventID`),
  CONSTRAINT `userName2`
    FOREIGN KEY (`userName`)
    REFERENCES `UserAuthentication` (`userName`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `EventID`
    FOREIGN KEY (`EventID`)
    REFERENCES `EventList` (`EventID`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE);

CREATE TABLE `TestingLab`.`CourseDetails` (
  `CourseID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  PRIMARY KEY (`CourseID`)
);

CREATE TABLE `TestingLab`.`TestDetails` (
  `TestID` INT NOT NULL AUTO_INCREMENT,
  `TestName` VARCHAR(45) NOT NULL,
  `CourseID` INT NOT NULL,
  `TestURL` VARCHAR(258) NOT NULL,
  PRIMARY KEY (`TestID`),
  INDEX `CourseID_idx` (`CourseID` ASC) VISIBLE,
  CONSTRAINT `CourseID`
    FOREIGN KEY (`CourseID`)
    REFERENCES `CourseDetails` (`CourseID`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE);

CREATE TABLE `TestingLab`.`SubCourseDetails` (
  `SubCourseID` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NOT NULL,
  `SubCourseURL` VARCHAR(258) NOT NULL,
  `CourseID` INT NOT NULL,
  PRIMARY KEY (`SubCourseID`),
  INDEX `CourseID2_idx` (`CourseID` ASC) VISIBLE,
  CONSTRAINT `CourseID2`
    FOREIGN KEY (`CourseID`)
    REFERENCES `CourseDetails` (`CourseID`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE);

CREATE TABLE `TestingLab`.`UserProgress` (
  `userName` VARCHAR(32) NOT NULL,
  `Score` FLOAT NOT NULL DEFAULT 0.0,
  `TestID` INT NOT NULL,
  PRIMARY KEY (`TestID`, `userName`),
  INDEX `userName3_idx` (`userName` ASC) VISIBLE,
  CONSTRAINT `userName3`
    FOREIGN KEY (`userName`)
    REFERENCES `UserAuthentication` (`userName`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `TestID`
    FOREIGN KEY (`TestID`)
    REFERENCES `TestDetails` (`TestID`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE);

CREATE TABLE `TestingLab`.`UserLevel` (
  `userName` VARCHAR(32) NOT NULL,
  `TestScore` FLOAT NOT NULL DEFAULT 0.0,
  PRIMARY KEY (`userName`),
  CONSTRAINT `userName4`
    FOREIGN KEY (`userName`)
    REFERENCES `UserAuthentication` (`userName`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE);

CREATE TABLE `TestingLab`.`LevelSlab` (
  `LevelNo` INT NOT NULL AUTO_INCREMENT,
  `LevelName` VARCHAR(45) NOT NULL,
  `MinimumScore` FLOAT NOT NULL,
  PRIMARY KEY (`LevelNo`));

CREATE TABLE `TestingLab`.`InviteList` (
  `email` VARCHAR(32) NOT NULL,
  PRIMARY KEY (`email`));

CREATE TABLE `TestingLab`.`blacklisttokens` (
  `token` VARCHAR(258) NOT NULL,
  `entrytime` datetime not null);

CREATE TABLE `TestingLab`.`refreshtokens` (
  `username` VARCHAR(258) NOT NULL,
  `refreshtoken` datetime not null,
  `expirationdate` datetime not null);
  
  
INSERT INTO UserAuthentication (`userName`,`Admin`,`password`,`email`) VALUES ('abh1abii',0,'ff53ac5fa36921dfea21f422b056461e59be6ce1214acb1fa63c9ace84bf1e98','abh1abii101@gmail.com');
INSERT INTO UserAuthentication (`userName`,`Admin`,`password`,`email`) VALUES ('admin',1,'8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918','admin@abiistudio.com');

insert into UserActivityLog(userName,LogInTime,LogOutTime) Values("abh1abii",'2021-06-13 17:30:45.000','2021-06-13 17:32:45.000' );
insert into UserActivityLog(userName,LogInTime,LogOutTime) Values("admin",'2021-06-13 17:27:45.000','2021-06-13 17:30:45.000' );

insert into EventList Values("EVTST1","Test Event 1",'2021-06-13 17:30:45.000',1,"localhost/event/event1",'2021-06-23 17:30:45.000' );
insert into EventList Values("EVTST2","Test Event 2",'2021-06-13 17:35:45.000',1,"localhost/event/event2",'2021-06-23 18:30:45.000' );

insert into CourseDetails(Name) Values("REACT JS");
insert into CourseDetails(Name) Values("NodeJS");

insert into SubCourseDetails(Name,SubCourseURL,CourseID) Values("Setup","localhost/ReactJS/Setup",1);
insert into SubCourseDetails(Name,SubCourseURL,CourseID) Values("Setup","localhost/NodeJS/Setup",2);

insert into UserLevel (userName) Values("admin");
insert into UserLevel (userName) Values("abh1abii");

insert into InviteList Values ("abh1abii101@gmail.com");
insert into InviteList Values ("admin@abiistudio.com");
insert into InviteList Values ("abhi@gmail.com");

insert into LevelSlab Values(1,"Amateur",0);
insert into LevelSlab Values(2,"Novice",30);
insert into LevelSlab Values(3,"Intermediate",60);
insert into LevelSlab Values(4,"Expert",120);
insert into LevelSlab Values(5,"AntiSocial",260);

ALTER TABLE `TrainingLab`.`UserAuthentication` 
ADD COLUMN `FirstName` VARCHAR(45) NULL AFTER `email`,
ADD COLUMN `LastName` VARCHAR(45) NULL AFTER `FirstName`;

ALTER TABLE `TrainingLab`.`SubCourseDetails`
ADD COLUMN `Title` VARCHAR(45) Default "Title" AFTER `CourseID`,
ADD COLUMN `Desc` VARCHAR(120) DEFAULT "DESC" AFTER `Title`;

Select * from CourseDetails;
Select * from EventActiveUser;
Select * from EventList;
Select * from InviteList;
Select * from LevelSlab;
Select * from SubCourseDetails;
Select * from TestDetails;
Select * from UserActivityLog;
Select * from UserAuthentication where username = "admin";
Select * from UserLevel;
Select * from UserProgress;

delete from invitelist where email = "abhi@gmail.com";

desc blacklisttokens;
 

update useractivitylog set logouttime= now() where logid = 8;
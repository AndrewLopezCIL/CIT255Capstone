CREATE DATABASE `swendiverfinalproject`;

CREATE TABLE `accounts` (
  `playerUsername` varchar(75) DEFAULT NULL,
  `playerPassword` varchar(75) DEFAULT NULL,
  `id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id`)
);

CREATE TABLE `userproperties` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `playerUsername` varchar(75) DEFAULT NULL,
  `gold` varchar(75) DEFAULT NULL,
  `playerX` varchar(75) DEFAULT NULL,
  `playerY` varchar(75) DEFAULT NULL,
  `weapon` varchar(75) DEFAULT NULL,
  `health` varchar(75) DEFAULT NULL,
  `shield` varchar(75) DEFAULT NULL,
  `class` varchar(75) DEFAULT NULL,
  `playerLevel` varchar(75) DEFAULT NULL,
  `playerXP` varchar(75) DEFAULT NULL,
  `isAlive` varchar(75) DEFAULT NULL,
  `playerShieldMax` varchar(75) DEFAULT NULL,
  `playerHealthMax` varchar(75) DEFAULT NULL,
  `basicAttack` varchar(75) DEFAULT NULL,
  `storyPart` varchar(75) DEFAULT NULL,
  `storySection` varchar(75) DEFAULT NULL,
  `storyDialogue` varchar(75) DEFAULT NULL,
  PRIMARY KEY (`id`)
);

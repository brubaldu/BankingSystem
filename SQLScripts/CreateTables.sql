DROP TABLE IF EXISTS `currencies`;
CREATE TABLE `currencies` (
  `CurrencyId` int(11) NOT NULL AUTO_INCREMENT,
  `Code` longtext,
  `Symbol` longtext,
  `Description` longtext,
  PRIMARY KEY (`CurrencyId`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

insert into currencies values (1,'UYU','$','Uruguayo');
insert into currencies values (2,'USD','U$S','Dólar Estadounidense');
insert into currencies values (3,'EUR','€','Euro');

DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `UserId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` longtext,
  `EmailAddress` longtext,
  PRIMARY KEY (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
DROP TABLE IF EXISTS `accounts`;
CREATE TABLE `accounts` (
  `AccountId` int(11) NOT NULL AUTO_INCREMENT,
  `Balance` double NOT NULL,
  `AccountUser_UserId` int(11) DEFAULT NULL,
  `Currency_CurrencyId` int(11) DEFAULT NULL,
  PRIMARY KEY (`AccountId`),
  KEY `IX_AccountUser_UserId` (`AccountUser_UserId`),
  KEY `IX_Currency_CurrencyId` (`Currency_CurrencyId`),
  CONSTRAINT `FK_Accounts_Currencies_Currency_CurrencyId` FOREIGN KEY (`Currency_CurrencyId`) REFERENCES `currencies` (`CurrencyId`),
  CONSTRAINT `FK_Accounts_Users_AccountUser_UserId` FOREIGN KEY (`AccountUser_UserId`) REFERENCES `users` (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=69 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `transactions`;
CREATE TABLE `transactions` (
  `TransactionId` int(11) NOT NULL AUTO_INCREMENT,
  `AccountFromId` int(11) NOT NULL,
  `AccountToId` int(11) NOT NULL,
  `DateAndTime` datetime NOT NULL,
  `Description` longtext,
  `Amount` double NOT NULL,
  PRIMARY KEY (`TransactionId`),
  KEY `IX_AccountFromId` (`AccountFromId`),
  KEY `IX_AccountToId` (`AccountToId`),
  CONSTRAINT `FK_Transactions_Accounts_AccountFromId` FOREIGN KEY (`AccountFromId`) REFERENCES `accounts` (`AccountId`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_Transactions_Accounts_AccountToId` FOREIGN KEY (`AccountToId`) REFERENCES `accounts` (`AccountId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=44 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;



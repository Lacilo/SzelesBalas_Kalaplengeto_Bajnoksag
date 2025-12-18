-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2025. Dec 18. 07:38
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `szbk_verseny`
--
CREATE DATABASE IF NOT EXISTS `szbk_verseny` DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
USE `szbk_verseny`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `versenyzok`
--

CREATE TABLE IF NOT EXISTS `versenyzok` (
  `Id` int(100) NOT NULL AUTO_INCREMENT,
  `Nev` varchar(255) NOT NULL,
  `Pont1` int(11) NOT NULL,
  `Ido1` float NOT NULL,
  `Pont2` int(11) NOT NULL,
  `Ido2` float NOT NULL,
  `Pont3` int(11) NOT NULL,
  `Ido3` float NOT NULL,
  `IdoL` float NOT NULL,
  `PontL` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

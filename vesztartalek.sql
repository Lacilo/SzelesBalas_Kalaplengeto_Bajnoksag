-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2025. Dec 11. 11:19
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
  `PontLegjobb` int(11) NOT NULL,
  `Helyezes` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `versenyzok`
--

INSERT INTO `versenyzok` (`Id`, `Nev`, `Pont1`, `Ido1`, `Pont2`, `Ido2`, `Pont3`, `Ido3`, `IdoL`, `PontLegjobb`, `Helyezes`) VALUES
(16, 'Kiss Péter', 8, 2, 7, 3.1, 9, 1.1, 1.1, 9, 1),
(17, 'Nagy Ádám', 7, 3, 6, 4.2, 8, 2.1, 2.1, 8, 2),
(18, 'Szabó Lilla', 6, 3.8, 7, 2.7, 6, 4.1, 2.7, 7, 3),
(19, 'Tóth Eszter', 10, 0.4, 9, 1.2, 9, 0.9, 0.4, 10, 1),
(20, 'Horváth Márton', 5, 5.1, 4, 6.3, 7, 3, 3, 7, 4),
(21, 'Varga Dániel', 9, 0.9, 8, 1.5, 9, 1.1, 0.9, 9, 1),
(22, 'Lakatos Milán', 4, 6.1, 5, 5.2, 6, 4.9, 4.9, 6, 5),
(23, 'Molnár Réka', 7, 2.9, 8, 2.1, 7, 3, 2.1, 8, 3),
(24, 'Farkas Noémi', 3, 7, 4, 6.9, 5, 6.2, 6.2, 5, 6),
(25, 'Jakab Olivér', 6, 2.7, 6, 3.3, 6, 2.9, 2.7, 6, 4);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

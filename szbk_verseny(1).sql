-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2025. Dec 17. 21:45
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
) ENGINE=InnoDB AUTO_INCREMENT=444 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `versenyzok`
--

INSERT INTO `versenyzok` (`Id`, `Nev`, `Pont1`, `Ido1`, `Pont2`, `Ido2`, `Pont3`, `Ido3`, `IdoL`, `PontL`) VALUES
(387, 'Farkas Eszter', 11, 12, 13, 12.5, 12, 11.8, 12, 12),
(390, 'Varga Dániel Gábor', 0, 10.9, 499, 11.5, 12, 11.7, 11.8, 13),
(410, 'Lakatos Tímea', 13, 11.3, 14, 11.6, 10, 12.1, 11.5, 13),
(413, 'Kovács Péter', 10, 12.5, 15, 11.2, 8, 13, 10.5, 9),
(414, 'Nagy Anna', 12, 11.8, 14, 12.1, 9, 14.3, 11, 10),
(416, 'Tóth László', 14, 10.5, 12, 11, 11, 12.2, 11.5, 13),
(417, 'Farkas Eszter', 11, 12, 13, 12.5, 12, 11.8, 12, 12),
(418, 'Molnár Zoltán', 13, 11.3, 14, 11.9, 10, 12.6, 11.2, 14),
(422, 'Papp Attila', 14, 11, 15, 10.8, 13, 11.2, 10.9, 14),
(429, 'Szőke Lajos', 13, 11.5, 14, 11.8, 10, 12.2, 11.6, 13),
(433, 'Rácz Tamás', 14, 11.1, 15, 10.9, 13, 11.3, 11, 14),
(435, 'Csák Szilárd', 13, 11.4, 14, 11.9, 10, 12, 11.7, 13),
(436, 'Orbán Edit', 12, 12.2, 13, 12.8, 11, 12.5, 12.3, 12),
(438, 'Hegedűs Ágnes', 14, 10.6, 15, 11, 13, 11.4, 11.1, 14),
(440, 'Lakatos Tímea', 13, 11.3, 14, 11.6, 10, 12.1, 11.5, 13),
(442, 'Tóth Réka', 15, 10.9, 13, 11.3, 14, 11.7, 11.4, 15),
(443, '1', 2, 3, 4, 5, 6, 7, 3, 6);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

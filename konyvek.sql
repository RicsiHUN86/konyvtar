-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Nov 22. 12:47
-- Kiszolgáló verziója: 10.4.20-MariaDB
-- PHP verzió: 7.3.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `konyvtar`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `konyvek`
--

DROP TABLE IF EXISTS `konyvek`;
CREATE TABLE IF NOT EXISTS `konyvek` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Konyvnev` varchar(255) DEFAULT NULL,
  `Helye` varchar(100) DEFAULT NULL,
  `Kolcsonzes` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `konyvek`
--

INSERT INTO `konyvek` (`Id`, `Konyvnev`, `Helye`, `Kolcsonzes`) VALUES
(1, 'Harry Potter és a bölcsek köve', 'Polc 1, Szekrény 3', '2024-11-01 00:00:00'),
(2, 'A Mester és Margarita', 'Polc 2, Szekrény 1', '2024-11-05 00:00:00'),
(3, '1984', 'Polc 3, Szekrény 2', '2024-11-10 00:00:00'),
(4, 'A Szél Árnyéka', 'Polc 4, Szekrény 2', '2024-11-12 00:00:00'),
(5, 'A Tejútrendszer Túloldalán', 'Polc 5, Szekrény 1', '2024-11-15 00:00:00'),
(6, 'A Világítótorony Titka', 'Polc 6, Szekrény 3', '2024-11-17 00:00:00');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

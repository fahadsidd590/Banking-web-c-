-- phpMyAdmin SQL Dump
-- version 5.1.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 04, 2022 at 12:25 AM
-- Server version: 10.4.22-MariaDB
-- PHP Version: 7.4.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bank`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `id` int(11) NOT NULL,
  `adminname` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`id`, `adminname`, `password`) VALUES
(1, 'tommy', 'tommy123');

-- --------------------------------------------------------

--
-- Table structure for table `client`
--

CREATE TABLE `client` (
  `id` int(11) NOT NULL,
  `firstname` varchar(100) NOT NULL,
  `lastname` varchar(100) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(50) NOT NULL,
  `accounttype` varchar(100) NOT NULL,
  `accountnum` varchar(30) NOT NULL,
  `totalamount` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `client`
--

INSERT INTO `client` (`id`, `firstname`, `lastname`, `username`, `password`, `accounttype`, `accountnum`, `totalamount`) VALUES
(1, 'john', 'english', 'john english', 'john123', 'current account', '12345667', 884.4725),
(2, 'john', 'english', 'john english', 'john1234', 'saving account', '1234566723', 711.6),
(3, 'fahad', 'mujtaba', 'fahad mujtaba', 'fahad123', 'saving account', '13245677', 2347.5275);

-- --------------------------------------------------------

--
-- Table structure for table `transcations`
--

CREATE TABLE `transcations` (
  `id` int(11) NOT NULL,
  `fromacc` varchar(50) NOT NULL,
  `toacc` varchar(50) NOT NULL,
  `date` date NOT NULL,
  `amount` double NOT NULL,
  `currency` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `transcations`
--

INSERT INTO `transcations` (`id`, `fromacc`, `toacc`, `date`, `amount`, `currency`) VALUES
(1, '346269923', '2347923023', '2022-04-13', 233, 'euro'),
(2, '12345667', 'e23123', '2022-05-03', 123, 'GBP'),
(3, '12345667', '357252173815', '2022-05-04', 123, 'EURO'),
(4, '12345667', '1234566723', '2022-05-04', 123, 'USdollar'),
(5, '12345667', '1234566723', '2022-05-04', 1, 'GBP'),
(6, '12345667', '1234566723', '2022-05-04', 2, 'GBP'),
(7, '12345667', '1234566723', '2022-05-04', 2, 'GBP'),
(8, '12345667', '13245677', '2022-05-04', 3, 'EURO'),
(9, '12345667', '', '2022-04-06', 12, 'USdollar');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `client`
--
ALTER TABLE `client`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `transcations`
--
ALTER TABLE `transcations`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `admin`
--
ALTER TABLE `admin`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `client`
--
ALTER TABLE `client`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `transcations`
--
ALTER TABLE `transcations`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

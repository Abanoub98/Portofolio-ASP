-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Oct 03, 2021 at 10:41 PM
-- Server version: 8.0.26
-- PHP Version: 7.4.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `portofoliodb`
--

-- --------------------------------------------------------

--
-- Table structure for table `aspnetroleclaims`
--

CREATE TABLE `aspnetroleclaims` (
  `Id` int NOT NULL,
  `RoleId` int NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ClaimValue` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetroles`
--

CREATE TABLE `aspnetroles` (
  `Id` int NOT NULL,
  `Name` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `NormalizedName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `aspnetroles`
--

INSERT INTO `aspnetroles` (`Id`, `Name`, `NormalizedName`, `ConcurrencyStamp`) VALUES
(1, 'Admin', 'ADMIN', '6af3986d-5642-4317-859d-5b6dcd74d36a');

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserclaims`
--

CREATE TABLE `aspnetuserclaims` (
  `Id` int NOT NULL,
  `UserId` int NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ClaimValue` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserlogins`
--

CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProviderKey` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProviderDisplayName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `UserId` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserroles`
--

CREATE TABLE `aspnetuserroles` (
  `UserId` int NOT NULL,
  `RoleId` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `aspnetuserroles`
--

INSERT INTO `aspnetuserroles` (`UserId`, `RoleId`) VALUES
(59, 1),
(66, 1);

-- --------------------------------------------------------

--
-- Table structure for table `aspnetusers`
--

CREATE TABLE `aspnetusers` (
  `Id` int NOT NULL,
  `ImagePath` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT '~/img/avatar.png',
  `CreatedAt` datetime(6) NOT NULL,
  `UpdatedAt` datetime(6) NOT NULL,
  `UserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '',
  `NormalizedUserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Email` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '',
  `NormalizedEmail` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SecurityStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PhoneNumber` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT 'Not Assigned',
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int NOT NULL,
  `Specialization` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `aspnetusers`
--

INSERT INTO `aspnetusers` (`Id`, `ImagePath`, `CreatedAt`, `UpdatedAt`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`, `Specialization`) VALUES
(1, 'img/avatar.png', '2021-08-23 19:15:22.000000', '2021-08-23 19:15:22.000000', 'Prof. Hershel Schuppe', NULL, 'caitlyn.towne@bins.com', NULL, 0, '289-23-5783', NULL, '07f6f2c4-db7d-408e-a5ca-015f1e14c838', '+201206784139', 0, 0, NULL, 0, 0, 'Backend Developer'),
(2, 'img/avatar.png', '2021-08-23 19:15:22.000000', '2021-08-23 19:15:22.000000', 'Arch Hilpert', NULL, 'mylene.brekke@cruickshank.biz', NULL, 0, '396-74-9235', NULL, '3056e139-6ec7-4866-8f04-d2362f157035', '+201206784139', 0, 0, NULL, 0, 0, 'Backend Developer'),
(4, 'img/avatar.png', '2021-08-23 19:15:22.000000', '2021-08-23 19:15:22.000000', 'Mabel Mills DDS', NULL, 'jeanie_schuppe@ernserpfannerstill.co.uk', NULL, 0, '603-05-4173', NULL, '36b287f9-bfd5-4b5b-8ca4-69537a5e0f94', '+201206784139', 0, 0, NULL, 0, 0, 'Backend Developer'),
(5, 'img/avatar.png', '2021-08-23 19:15:22.000000', '2021-08-23 19:15:22.000000', 'Leonie Donnelly', NULL, 'madalyn@kirlin.co.uk', NULL, 0, '069-78-4929', NULL, '6dc4d89e-2eb2-45e1-b56e-ebd66d6ed340', '+201206784139', 0, 0, NULL, 0, 0, 'Backend Developer'),
(8, 'img/avatar.png', '2021-08-23 19:15:22.000000', '2021-08-23 19:15:22.000000', 'Ms. Kristofer O\'Reilly', NULL, 'jacey@krajcik.uk', NULL, 0, '029-84-5182', NULL, '912712dd-c60f-48a7-be5e-a5f449fb277d', '+201206784139', 0, 0, NULL, 0, 0, 'Backend Developer'),
(9, 'img/avatar.png', '2021-08-23 19:15:22.000000', '2021-08-23 19:15:22.000000', 'Mr. Graham Malvina Stamm I', NULL, 'leo@bruen.biz', NULL, 0, '575-49-8358', NULL, '6cd426b3-d519-4ac5-b0b9-9b3469c4cdef', '+201206784139', 0, 0, NULL, 0, 0, 'Backend Developer'),
(10, 'img/avatar.png', '2021-08-23 19:15:22.000000', '2021-08-23 19:15:22.000000', 'Clark Watsica', NULL, 'jessy_schaden@kochcummings.biz', NULL, 0, '108-94-6663', NULL, '572cf113-d9b0-49c9-b273-4815ee056e6f', '+201206784139', 0, 0, NULL, 0, 0, 'Backend Developer'),
(11, 'img/avatar.png', '2021-08-23 19:15:22.000000', '2021-08-23 19:15:22.000000', 'Prof. Lance Eugenia Kohler I', NULL, 'margie_anderson@mills.co.uk', NULL, 0, '', NULL, '26f44475-72a3-425e-afc2-7afd44d584d5', '+201206784139', 0, 0, NULL, 0, 0, 'Backend Developer'),
(59, 'images\\475c9636-1a28-49e4-b79f-62bb66b695453a698033-7fcd-4b5c-b4a4-dc8f9889ff7bbebo.jpg', '2021-08-25 09:43:57.410932', '2021-08-25 10:06:31.125981', 'Abanoub Rafaat', 'ABANOUB RAFAAT', 'bebo@gmail.com', 'BEBO@GMAIL.COM', 0, 'AQAAAAEAACcQAAAAEI0EOfH1O2tXFqQdVcimXqERyOWQ0PfFSw40x3UQVnuA46L1TTp25z/gD6yETHWmyg==', 'XH65JIPI74YRRFLH6YQYE5KYWODWCSNK', '224c4efd-85db-4531-9d5d-2dd7efe90e90', '+201282692682', 0, 0, NULL, 1, 0, 'Front End Developer'),
(61, 'img/avatar.png', '2021-08-26 14:41:44.306244', '2021-08-26 14:41:44.306239', 'Gergis Hanna', 'GERGIS HANNA', 'gergishanna@gmail.com', 'GERGISHANNA@GMAIL.COM', 0, 'AQAAAAEAACcQAAAAEL97ILlfTPgqFfqfp+Wnviei7mJ7pGe8qC/ikBpFxyz/3hcvX1A4D8ACE1Q5iz+rxw==', 'Q5USBUTN5ATNJ5U2U2IZYJMV2RUAP464', '01823e59-7159-4e70-a471-4901adbb9971', NULL, 0, 0, NULL, 1, 0, 'Back End Developer'),
(66, 'images\\fe7cab3c-cc08-48c4-a225-01f31e1e6666kiro.jpeg', '2021-09-22 14:41:44.306244', '2021-10-03 17:11:01.412453', 'Kirollos Hany', 'KIROLLOS HANY', 'kirolloshany9999@gmail.com', 'KIROLLOSHANY9999@GMAIL.COM', 0, 'AQAAAAEAACcQAAAAEH2smken8iztt7DljRfbkKTpeJni5Ctqekt8ljs95/0zEsKA9XoF81R4g3vfcok6bQ==', 'CKRCWI7Y5IFWFCPH6XYTGXHEFD2AG72F', 'b8df94ba-9529-4ab9-9e01-e46919ba351f', '+201206784139', 0, 0, NULL, 0, 0, 'Back End Developer'),
(67, 'img/avatar.png', '2021-09-28 11:09:11.310974', '2021-09-28 12:43:11.326378', 'Test', 'TEST', 'test@gmail.com', 'TEST@GMAIL.COM', 0, 'AQAAAAEAACcQAAAAENOd2BZcCByqtQ8r+RbOB4IY/P2wrNsEJJf5tmak7xqUWENZOJzrJqapbcoHWhjHXg==', 'OJBLN4YC7Q6TE6J5HOVICRCKMK2BNJMA', 'e910e66c-4113-4035-a5ae-a066f7d93141', '+201206784139', 0, 0, NULL, 1, 0, 'Software Engineer'),
(68, 'img/avatar.png', '2021-09-28 18:58:28.363513', '2021-09-28 18:58:28.363509', 'TestUser', 'TESTUSER', 'test2@gmail.com', 'TEST2@GMAIL.COM', 0, 'AQAAAAEAACcQAAAAEPjmTLxNoPcigt1ypuOAKmFhmc+bRslblYsCzExPvW1Yr338jLw7IXs/ED9vMPXj1w==', '34YDV64BT2LJHQJZKUUEGQX6ZDMF5WU3', '557457ff-66d4-458c-9ef2-4666bfdaaaec', NULL, 0, 0, NULL, 1, 0, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `aspnetusertokens`
--

CREATE TABLE `aspnetusertokens` (
  `UserId` int NOT NULL,
  `LoginProvider` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Value` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `contacts`
--

CREATE TABLE `contacts` (
  `Id` int NOT NULL,
  `StatusId` int NOT NULL,
  `ContactName` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Phone` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Email` varchar(320) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Message` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedAt` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `contacts`
--

INSERT INTO `contacts` (`Id`, `StatusId`, `ContactName`, `Phone`, `Email`, `Message`, `CreatedAt`, `UpdatedAt`) VALUES
(2, 1, 'Miss Neha Littel', '+201206784139', 'herminio@morissette.info', 'Animi rerum saepe repellat ut sed vitae nisi. Deserunt in facere consequatur voluptate sint minus. Et est omnis est magnam dignissimos.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(3, 1, 'Madalyn Labadie', '+201206784139', 'zora@labadie.ca', 'Magni laudantium modi non omnis id alias. Fugiat alias optio deleniti saepe reprehenderit. Non laborum quibusdam aut animi. Eligendi amet est doloremque assumenda minus harum. Iste aut iusto voluptatem.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(5, 3, 'Jazmyne Brakus', '+201206784139', 'millie@harber.us', 'Impedit et est laudantium eum. A fugiat sint facilis aut occaecati necessitatibus error sed. Ea ea accusantium molestiae autem non autem id aliquid. Et architecto tempore aut recusandae quia.', '2021-08-23 19:15:22', '2021-09-28 12:22:52'),
(6, 1, 'Hiram Hyatt', '+201206784139', 'winifred_stroman@brekke.uk', 'Sint qui dolores eligendi voluptas debitis magnam aut. Voluptatibus tempora qui minus. Asperiores asperiores error odit sequi. Est error dolor eum quisquam ut porro eaque quidem. Adipisci id placeat cum aut vel et.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(7, 1, 'Cordell Bogan', '+201206784139', 'cassie@barton.name', 'Ratione aliquid corrupti sed distinctio consequatur quo aut. Sint possimus dignissimos porro porro occaecati est quaerat. Explicabo reiciendis enim rerum praesentium totam reprehenderit ipsum aperiam. Tempora omnis officia excepturi itaque rerum sequi officia fugiat quae.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(8, 1, 'Abbie Bernhard Sr.', '+201206784139', 'josiah@bruenoconner.com', 'Voluptatibus et sunt et molestias quos et sint. Tempora consequuntur quo sed nobis neque. Odit ea tempora assumenda et. Rerum totam vel dolore. Labore sit voluptatem in.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(9, 1, 'Mr. Kaleigh Bradtke V', '+201206784139', 'odell.friesen@batz.com', 'Odio error dolores sint et. Sit est quia vel quam ad fuga sint nesciunt voluptatibus. Deserunt optio non ut dolores corrupti rerum quia vel blanditiis. Exercitationem tempora voluptas distinctio ut laborum nulla eum.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(10, 1, 'Dr. Emmanuel Cecil Haag', '+201206784139', 'crawford@keeling.name', 'Ipsum eveniet dignissimos atque consequatur aut. Quaerat ut fugiat maiores et veniam et magnam quibusdam. Perferendis architecto voluptatem corporis impedit libero odit sit nulla suscipit. Qui voluptas facere nihil quia fuga nihil vel non. Sapiente numquam repellendus repudiandae omnis alias aspernatur.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(11, 1, 'Meaghan Spinka III', '+201206784139', 'wilfredo_daniel@carroll.co.uk', 'Qui et eos officia nobis distinctio et. Nam eaque consequatur doloribus non aut eum enim non. Molestiae maiores molestiae nam aut atque expedita. Aut repellat maiores officia tempora sit a. Labore voluptas excepturi fugit laborum natus.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(12, 1, 'Miss Kylee Yesenia Luettgen V', '+201206784139', 'marietta.daniel@feeney.name', 'Ut eos molestiae ut eaque et fugit quo. Reprehenderit dolorem aut nesciunt omnis laborum molestiae autem sunt explicabo. Deleniti modi nisi sint culpa est in. Cumque ipsum provident laboriosam totam nam doloribus. Est distinctio consequatur dolorem veniam est dolores.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(13, 1, 'Colt Eichmann', '+201206784139', 'jessica@armstrong.com', 'Ea rem ab ut quibusdam dolor quod ex quis quisquam. Tenetur sed dignissimos at et iure. Totam et debitis doloremque enim dolor.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(14, 1, 'Ms. Vivien Kenneth Gulgowski III', '+201206784139', 'halle.stracke@ortiz.co.uk', 'Sed minima id voluptates non dolorem autem. Recusandae explicabo distinctio reprehenderit voluptatibus at qui omnis pariatur enim.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(15, 1, 'Calista Keven Toy DDS', '+201206784139', 'elmer@zieme.co.uk', 'Ratione saepe ut quis dolores voluptate earum soluta laborum. Qui consectetur nemo et provident assumenda fugit quasi repellendus.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(16, 1, 'Mrs. Eugene Veum V', '+201206784139', 'esperanza@vandervort.biz', 'Autem reprehenderit ipsam neque sapiente corrupti et molestias et recusandae. Dignissimos nihil beatae odit ullam ut sapiente dolores dignissimos similique.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(17, 1, 'Adaline Pollich', '+201206784139', 'kolby_homenick@kub.uk', 'Blanditiis repudiandae reprehenderit ut natus. Sit dignissimos et aut ducimus est iste officia corrupti voluptatem. Voluptas ipsam dicta ut incidunt esse dolor ab. Aut esse necessitatibus quam molestiae quia nam harum maiores.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(18, 1, 'Oleta Kirlin', '+201206784139', 'alford@hermiston.com', 'Nesciunt dolorem quibusdam facere ex fugit similique tenetur. Et optio distinctio tempore tempore aut vel vel eveniet dicta. Eaque hic aliquam voluptatem.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(19, 1, 'Matilde Cole', '+201206784139', 'nichole@stantoncorkery.com', 'Tenetur praesentium molestiae sed. Laboriosam iure nihil et consequatur similique. Distinctio necessitatibus aut impedit quibusdam.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(20, 1, 'Dr. Rudy Reichel', '+201206784139', 'kris@hermistonluettgen.biz', 'Vel dolor omnis et facere ex quibusdam in quae. Molestiae atque ut doloremque consequatur autem voluptas. Voluptas nobis quod quibusdam facere.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(21, 1, 'Mr. Ocie Ariel Lehner', '+201206784139', 'sandra@lindgren.biz', 'Quo sequi placeat non quasi tenetur nostrum nesciunt. Quasi aliquam officiis nesciunt inventore sapiente. Omnis qui eos tempore illum architecto facilis autem mollitia et.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(22, 1, 'Rodrick Langworth', '+201206784139', 'jessica@lowewilliamson.info', 'Minima commodi et sit distinctio voluptatem ab quo. Officiis unde rerum eligendi quisquam voluptatem quia. Deserunt ea aut et culpa a magni dolores. Placeat qui vero accusantium possimus voluptates assumenda.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(23, 1, 'Elta Koelpin', '+201206784139', 'rebekah_macejkovic@nikolausklein.us', 'Eum dolorem ut quis porro. Repellat non quibusdam nostrum autem voluptatibus autem. Voluptas inventore corporis deserunt ad est quo porro cupiditate magni. Deserunt repellat omnis molestiae quo aut quos provident reiciendis.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(24, 1, 'Brycen Bashirian Sr.', '+201206784139', 'tristin@krajcik.ca', 'Explicabo reiciendis voluptatem velit non quasi qui. Qui eum cum quasi harum sequi omnis molestiae voluptatem. Aperiam nisi ut quisquam doloremque. Non quia eaque impedit.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(25, 1, 'Ms. Elna Lulu Braun I', '+201206784139', 'clementina@leannon.info', 'Optio earum possimus aut. Perspiciatis optio aliquam eius ut itaque nostrum perspiciatis velit.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(26, 1, 'Edyth Jacobi Sr.', '+201206784139', 'elaina.bogisich@thiellarkin.co.uk', 'Quam enim adipisci repudiandae ut rerum dolores illo. Voluptatem nemo veritatis voluptatem.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(27, 1, 'Mrs. Efrain Bartoletti', '+201206784139', 'giovani.waelchi@becker.name', 'Ut quisquam beatae modi officia. Laudantium est ipsa eos omnis nihil. Officiis tempore ullam ut consequatur quia commodi dolorem excepturi. Et repudiandae voluptatum in quae tenetur iste et dolorum. Eos consequatur rerum saepe libero incidunt.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(28, 1, 'Miss Bonnie Joany Bogisich', '+201206784139', 'mohammad@manteparisian.name', 'Illo veniam consequatur eum. Minus quia dolores dolorem esse repudiandae laudantium.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(30, 1, 'Ms. Emil Rau', '+201206784139', 'lauren@walter.co.uk', 'Dolores dolorem impedit dolorem beatae. Sed atque minima aspernatur. Dolorum a quidem molestiae totam quaerat quas porro iusto impedit. Nisi aliquam velit explicabo sint provident.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(31, 1, 'Stan Farrell', '+201206784139', 'lucy@schiller.info', 'Veritatis ut sed vero quis accusamus sint placeat. Ipsam repudiandae omnis accusamus sit fuga. Expedita voluptas enim qui est sapiente aliquam saepe nobis expedita.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(32, 1, 'Mr. Alfonso Jonas Spinka', '+201206784139', 'mya_mante@fisher.info', 'Ratione dolorem quia dicta. Inventore sequi expedita debitis veritatis molestiae autem quod ut. Sed qui rerum incidunt et.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(33, 1, 'Aniya King', '+201206784139', 'delfina_gleichner@pfannerstill.name', 'Ea tenetur enim quis eaque reiciendis ut. Qui sed qui quas consequatur ut illo sit cumque.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(34, 1, 'Tracy Adams', '+201206784139', 'sherwood_stanton@lesch.name', 'Ab at eum reiciendis id ipsa qui voluptas. Iure ut ducimus consequatur doloribus doloremque ut. Enim ea voluptas quasi est nemo molestiae in natus.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(35, 1, 'Summer Streich', '+201206784139', 'evangeline@auer.uk', 'Saepe tenetur eius modi voluptatem dolor aperiam vitae et laboriosam. Quia est et eum eius qui est iure dolores dolorem.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(36, 1, 'Mrs. Isobel Schroeder', '+201206784139', 'cordia.emmerich@kleinsporer.biz', 'Omnis eius ut laudantium qui. At facere fuga non enim magnam. Aspernatur dolorem est totam corporis laudantium et sunt incidunt sint. Et voluptas molestiae quia eaque cupiditate dolores quis. Voluptates et saepe velit.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(37, 1, 'Eliezer Purdy', '+201206784139', 'shany@kochlebsack.name', 'Ea omnis sint perferendis corporis consequatur autem sint. Unde distinctio et a nisi facere beatae sint et. Corrupti et perspiciatis enim nisi quidem nemo et dolor. Aperiam aut unde a inventore et.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(38, 1, 'Webster Blick', '+201206784139', 'benny@lind.co.uk', 'Est doloribus repellendus nobis asperiores est rerum in iusto tempore. Numquam doloremque cumque quo et itaque. Necessitatibus rerum eaque dolor.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(39, 1, 'Isabel Hills', '+201206784139', 'danielle_friesen@bahringerdare.us', 'Ut aliquam repudiandae iure. Quaerat sit eaque minima sed omnis.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(40, 1, 'Evalyn Parisian', '+201206784139', 'bridget.vonrueden@gislason.uk', 'In sed autem consequatur ad voluptatibus corrupti unde. Non nulla eos rerum sint illum itaque.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(41, 1, 'Clay Schiller', '+201206784139', 'hope_parisian@lynch.us', 'Eos ea natus similique possimus. Distinctio et ea quo veniam non explicabo. Saepe nesciunt vitae exercitationem voluptatem iusto. Amet tempore doloribus molestiae unde sit provident. Voluptates asperiores sit blanditiis.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(42, 1, 'Gina Naomie Heller DVM', '+201206784139', 'haley@bechtelarshanahan.biz', 'Alias et harum mollitia ipsum. Quo nihil non in nihil.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(43, 1, 'Sandra Bartoletti', '+201206784139', 'benedict_nienow@johnston.com', 'Cupiditate eos voluptatem sit officia et nisi natus totam in. Et et placeat ea nihil eos consequuntur. Ad tempora nam quas consectetur possimus dolor laudantium voluptate et.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(44, 1, 'Daphney Weber', '+201206784139', 'carter.tremblay@starkshields.ca', 'Sint eaque voluptatem commodi dolorum ipsa. Delectus et voluptatum iusto necessitatibus sunt iusto in laboriosam sapiente. Tempore vel possimus vero.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(45, 1, 'Tyra Neil Rogahn MD', '+201206784139', 'juwan@bauchnitzsche.co.uk', 'Velit quo ut doloremque sit possimus excepturi sapiente. Qui quam voluptatum ab assumenda. Est reiciendis aperiam corrupti quo facere nihil blanditiis. Totam corporis adipisci est magnam cupiditate possimus blanditiis a. In sint dolorum voluptatem voluptatem unde.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(46, 1, 'Pete Addison Schamberger DVM', '+201206784139', 'eulah@okon.info', 'Ea laborum ut nesciunt incidunt quis ipsam iste saepe. Eos natus sunt voluptate accusamus quia a id.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(47, 1, 'Ottis Little', '+201206784139', 'madyson@will.uk', 'Deserunt voluptas et aut veritatis soluta voluptatem minima vitae. Error ea saepe magni totam autem soluta dignissimos similique sit. Est perferendis quia doloribus.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(48, 1, 'Marcelino Nienow', '+201206784139', 'cale_bradtke@thompsonpredovic.info', 'Voluptatem fuga quidem voluptatem possimus. Praesentium quod esse totam similique sed aut.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(49, 1, 'Carlo Beer', '+201206784139', 'franz_bednar@hoeger.us', 'Voluptas sunt aspernatur vero qui ipsa. Quibusdam consequatur sed itaque eligendi. Vel error ipsam quia rem. Doloribus debitis quidem quam sit voluptas. Voluptas suscipit aliquam sunt et quas quis eos.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(50, 1, 'Ward Wiza', '+201206784139', 'sophie.friesen@streichaufderhar.name', 'Fuga iste enim et non tempore quaerat non inventore. Molestiae accusantium exercitationem sequi veniam aut adipisci impedit.', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(51, 3, 'Kirollos Hany', '+201206784139', 'kirolloshany9999@gmail.com', 'Testing validation and shit', '2021-08-25 14:16:53', '2021-08-28 09:41:23'),
(52, 1, 'Kirollos Hany', '+201206784139', 'kirolloshany9999@gmail.com', 'Testing validation and shit', '2021-08-25 14:19:09', '0001-01-01 00:00:00'),
(53, 1, 'Kirollos Hany', '+201206784139', 'kirolloshany9999@gmail.com', 'Testing validation and shit', '2021-08-25 14:20:57', '0001-01-01 00:00:00'),
(54, 1, 'Kirollos Hany', '+201206784139', 'kirolloshany9999@gmail.com', 'Message', '2021-08-26 13:00:18', '0001-01-01 00:00:00'),
(55, 1, 'Kirollos Hany', '+201206784139', 'kirolloshany9999@gmail.com', 'Message', '2021-08-26 13:10:18', '0001-01-01 00:00:00'),
(56, 1, 'Kirollos Hany', '+201206784139', 'kirolloshany9999@gmail.com', 'I want a web and desktop application..please get back to me on the price', '2021-08-27 11:22:51', '0001-01-01 00:00:00'),
(57, 1, 'Kirollos Hany', '+201206784139', 'kirolloshany9999@gmail.com', 'I want a web and desktop application..please get back to me on the price', '2021-08-27 11:23:50', '0001-01-01 00:00:00'),
(58, 1, 'Kirollos Hany', '+201206784139', 'kirolloshany9999@gmail.com', 'I want a web and desktop application..please get back to me on the price', '2021-08-27 11:29:48', '0001-01-01 00:00:00'),
(59, 1, 'Kirollos Hany', '+201206784139', 'kirolloshany9999@gmail.com', 'I want a web and desktop application..please get back to me on the price', '2021-08-27 11:31:23', '0001-01-01 00:00:00'),
(60, 1, 'Kirollos Hany', '+201206784139', 'kirolloshany9999@gmail.com', 'I want a web and desktop application..please get back to me on the price', '2021-08-27 11:33:30', '0001-01-01 00:00:00'),
(61, 2, 'Kirollos Hany', '+201206784139', 'kirolloshany9999@gmail.com', 'I want a web and desktop application..please get back to me on the price', '2021-08-27 11:37:35', '2021-09-22 09:08:14'),
(63, 1, 'kiro', '+201206784139', 'kiro@gmail.com', 'message', '2021-10-01 10:02:38', '2021-10-01 10:02:38'),
(64, 1, 'kiro', '+201206784139', 'kiro@gmail.com', 'msg', '2021-10-01 10:06:40', '2021-10-01 10:06:40'),
(65, 1, 'kiro', '+201206784139', 'kiro@gmail.com', 'msg', '2021-10-01 10:08:49', '2021-10-01 10:08:49'),
(66, 1, 'hamda', '+201206784139', 'hamada@gmail.com', 'hamada', '2021-10-02 21:56:06', '2021-10-02 21:56:06');

-- --------------------------------------------------------

--
-- Table structure for table `contactstatuses`
--

CREATE TABLE `contactstatuses` (
  `Id` int NOT NULL,
  `Status` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedAt` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `contactstatuses`
--

INSERT INTO `contactstatuses` (`Id`, `Status`, `CreatedAt`, `UpdatedAt`) VALUES
(1, 'Pending', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(2, 'InProgress', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(3, 'Completed', '2021-08-23 19:15:22', '2021-08-23 19:15:22');

-- --------------------------------------------------------

--
-- Table structure for table `linktypes`
--

CREATE TABLE `linktypes` (
  `Id` int NOT NULL,
  `LinkType` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedAt` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `linktypes`
--

INSERT INTO `linktypes` (`Id`, `LinkType`, `CreatedAt`, `UpdatedAt`) VALUES
(1, 'Url', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(2, 'Github', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(3, 'LinkedIn', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(4, 'Facebook', '2021-08-23 19:15:22', '2021-08-23 19:15:22');

-- --------------------------------------------------------

--
-- Table structure for table `projectfeedbacks`
--

CREATE TABLE `projectfeedbacks` (
  `Id` int NOT NULL,
  `ProjectId` int NOT NULL,
  `Feedback` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreatedAt` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `projectimages`
--

CREATE TABLE `projectimages` (
  `Id` int NOT NULL,
  `ProjectId` int NOT NULL,
  `ImagePath` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedAt` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `projectimages`
--

INSERT INTO `projectimages` (`Id`, `ProjectId`, `ImagePath`, `CreatedAt`, `UpdatedAt`) VALUES
(76, 68, 'images\\475c9636-1a28-49e4-b79f-62bb66b695453a698033-7fcd-4b5c-b4a4-dc8f9889ff7b.jpeg', '2021-09-20 14:37:10', '2021-09-20 14:37:10'),
(77, 68, 'images\\232a51b8-8fd7-452e-80ce-818aab2547fa9c338b0c-3023-47cd-90c4-6e7c156e2973.jpg', '2021-09-20 14:37:10', '2021-09-20 14:37:10'),
(78, 68, 'images\\8e4212e0-79de-4db5-b272-8af52f033adbaee5c8ee-36b0-4daf-a3fd-6129b9b6def1.jpg', '2021-09-20 14:37:10', '2021-09-20 14:37:10'),
(80, 68, 'images\\f0d4441d-a44b-44c6-8664-d30c981b477aimg3.jpg', '2021-09-21 12:30:13', '2021-09-21 12:30:13'),
(81, 68, 'images\\3a1570fa-ea25-43a7-9120-6fc39060e8dcf0d4441d-a44b-44c6-8664-d30c981b477aimg3.jpg', '2021-09-22 08:32:05', '2021-09-22 08:32:05');

-- --------------------------------------------------------

--
-- Table structure for table `projectlinks`
--

CREATE TABLE `projectlinks` (
  `Id` int NOT NULL,
  `ProjectId` int NOT NULL,
  `TypeId` int NOT NULL,
  `Link` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedAt` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `projectlinks`
--

INSERT INTO `projectlinks` (`Id`, `ProjectId`, `TypeId`, `Link`, `CreatedAt`, `UpdatedAt`) VALUES
(104, 68, 1, '#', '2021-09-19 20:58:50', '2021-09-22 08:32:05'),
(105, 68, 2, '#', '2021-09-19 20:58:50', '2021-09-22 08:32:05'),
(106, 68, 3, '#', '2021-09-19 20:58:50', '2021-09-22 08:32:05'),
(107, 68, 4, '#', '2021-09-19 20:58:50', '2021-09-22 08:32:05'),
(180, 87, 1, '#', '2021-09-28 18:53:38', '2021-10-03 22:37:24'),
(181, 87, 2, '#', '2021-09-28 18:53:38', '2021-10-03 22:37:24'),
(182, 87, 3, '#', '2021-09-28 18:53:38', '2021-10-03 22:37:24'),
(183, 87, 4, '#', '2021-09-28 18:53:38', '2021-10-03 22:37:24'),
(184, 88, 1, '#', '2021-09-28 18:59:32', '2021-09-29 13:18:26'),
(185, 88, 2, '#', '2021-09-28 18:59:32', '2021-09-29 13:18:26'),
(186, 88, 3, '#', '2021-09-28 18:59:32', '2021-09-29 13:18:26'),
(187, 88, 4, '#', '2021-09-28 18:59:32', '2021-09-29 13:18:26');

-- --------------------------------------------------------

--
-- Table structure for table `projectlogs`
--

CREATE TABLE `projectlogs` (
  `Id` int NOT NULL,
  `ProjectId` int DEFAULT NULL,
  `UserId` int DEFAULT NULL,
  `CreatorId` int DEFAULT NULL,
  `CreatorName` text,
  `Action` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Title` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `UserName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreatedAt` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `projectlogs`
--

INSERT INTO `projectlogs` (`Id`, `ProjectId`, `UserId`, `CreatorId`, `CreatorName`, `Action`, `Title`, `UserName`, `CreatedAt`) VALUES
(1, 88, 66, 68, 'TestUser', 'Update', 'Testss', 'Kirollos Hany', '2021-09-29 13:18:26'),
(2, 87, 66, 67, 'Test', 'Update', 'Test', 'Kirollos Hany', '2021-10-03 22:37:24'),
(3, 87, 66, 67, 'Test', 'Update', 'Test', 'Kirollos Hany', '2021-10-03 22:37:24');

-- --------------------------------------------------------

--
-- Table structure for table `projects`
--

CREATE TABLE `projects` (
  `Id` int NOT NULL,
  `CreatorId` int NOT NULL,
  `TypeId` int NOT NULL,
  `Title` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedAt` datetime NOT NULL,
  `ToolsUsed` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Thumbnail` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `projects`
--

INSERT INTO `projects` (`Id`, `CreatorId`, `TypeId`, `Title`, `Description`, `CreatedAt`, `UpdatedAt`, `ToolsUsed`, `Thumbnail`) VALUES
(68, 66, 3, 'Portofolio', 'Startup Portofolio Gallery', '2021-09-19 20:58:50', '2021-09-22 08:32:05', 'HTML-CSS-JAVASCRIPT-ASPNETCORE', 'images\\4c92845d-257f-4f1e-bf27-7776d42a8de521a0fafb-317d-4a4a-acb9-ebaf2a74ac3c.jpg'),
(87, 67, 3, 'Test', 'test test tests', '2021-09-28 18:53:37', '2021-10-03 22:37:24', 'Tool1-Tool2-Tool3', 'images\\92ff4b0e-64f0-4d99-84af-ce51e37d1fb5mm.jpg'),
(88, 68, 2, 'Testss', 'Tessssss', '2021-09-28 18:59:32', '2021-09-29 13:18:26', 'Tool1-Tool2', 'images\\392f5290-0276-4836-bf96-3d92807b49a25e7ca3fc-e758-49c6-89a9-e36b22ee89898e4212e0-79de-4db5-b272-8af52f033adbaee5c8ee-36b0-4daf-a3fd-6129b9b6def1.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `projecttypes`
--

CREATE TABLE `projecttypes` (
  `Id` int NOT NULL,
  `ProjectType` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedAt` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `projecttypes`
--

INSERT INTO `projecttypes` (`Id`, `ProjectType`, `CreatedAt`, `UpdatedAt`) VALUES
(1, 'Desktop Application', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(2, 'Mobile Application', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(3, 'Web Application', '2021-08-23 19:15:22', '2021-08-23 19:15:22');

-- --------------------------------------------------------

--
-- Table structure for table `requestedservices`
--

CREATE TABLE `requestedservices` (
  `Id` int NOT NULL,
  `ServiceId` int NOT NULL,
  `ContactId` int NOT NULL,
  `CreatedAt` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000',
  `UpdatedAt` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `requestedservices`
--

INSERT INTO `requestedservices` (`Id`, `ServiceId`, `ContactId`, `CreatedAt`, `UpdatedAt`) VALUES
(1, 1, 51, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000'),
(2, 2, 51, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000'),
(3, 1, 52, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000'),
(4, 2, 52, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000'),
(5, 1, 53, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000'),
(6, 2, 53, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000'),
(7, 1, 54, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000'),
(8, 1, 55, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000'),
(9, 1, 56, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000'),
(10, 2, 56, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000'),
(11, 1, 57, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000'),
(12, 2, 57, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000'),
(13, 1, 58, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000'),
(14, 2, 58, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000'),
(15, 1, 59, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000'),
(16, 2, 59, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000'),
(17, 1, 60, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000'),
(18, 2, 60, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000'),
(19, 1, 61, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000'),
(20, 2, 61, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000'),
(23, 1, 65, '2021-10-01 10:08:49.440209', '2021-10-01 10:08:49.440309'),
(24, 1, 66, '2021-10-02 21:56:06.440244', '2021-10-02 21:56:06.440283'),
(25, 2, 66, '2021-10-02 21:56:06.470953', '2021-10-02 21:56:06.470956'),
(26, 3, 66, '2021-10-02 21:56:06.474726', '2021-10-02 21:56:06.474727');

-- --------------------------------------------------------

--
-- Table structure for table `services`
--

CREATE TABLE `services` (
  `Id` int NOT NULL,
  `ServiceName` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ServiceDescription` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ServiceImage` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreatedAt` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000',
  `UpdatedAt` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `services`
--

INSERT INTO `services` (`Id`, `ServiceName`, `ServiceDescription`, `ServiceImage`, `CreatedAt`, `UpdatedAt`) VALUES
(1, 'Web Application Service', 'A libero quia  iure voluptas illo ut. Distinctio molestiae earum. Voluptatem fugiat ea quaerat qui illum voluptatibus natus. Labore consectetur sunt saepe. Ea distinctio est in dicta sit sequi molestiae non consequatur. Velit et repellendus a.', 'images\\7eafd4be-c144-4dce-8828-d43c3076d5d5ue1.jpg', '0001-01-01 00:00:00.000000', '2021-10-01 17:03:29.314654'),
(2, 'Desktop Application Service', 'A libero quia qui dolorum iure voluptas illo ut. Distinctio voluptas temporibus illum molestiae earum. Voluptatem fugiat ea quaerat qui illum voluptatibus natus. Labore consectetur sunt saepe. Ea distinctio est in dicta sit sequi molestiae non consequatur. Velit et repellendus a.', 'images\\8de23339-5998-4309-9ef5-ce416a6f01c3tt.jpg', '0001-01-01 00:00:00.000000', '2021-10-01 17:03:37.345186'),
(3, 'Mobile Application Service', 'Illum ea eaque est commodi. Quaerat nam voluptate sit quaerat in. Vel ut ea eum deserunt possimus et aperiam necessitatibus qui. Ducimus autem est est minima quaerat dolores modi commodi et. Vitae laudantium fugiat quibusdam dolor autem eius ut iste ducimus. Et illum corrupti ipsum qui totam.', 'images\\554bea38-7992-4947-bc36-1fcfbd30bacaue1.jpg', '0001-01-01 00:00:00.000000', '2021-10-01 17:03:21.903636'),
(12, 'Other', 'Request another service', 'images\\158509f0-f6c0-403c-888a-424c764c4a74ue1.jpg', '2021-10-01 17:03:09.326382', '2021-10-01 17:03:09.326423');

-- --------------------------------------------------------

--
-- Table structure for table `usercertificates`
--

CREATE TABLE `usercertificates` (
  `Id` int NOT NULL,
  `UserId` int NOT NULL,
  `ImagePath` text NOT NULL,
  `Description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `userlinks`
--

CREATE TABLE `userlinks` (
  `Id` int NOT NULL,
  `UserId` int NOT NULL,
  `TypeId` int NOT NULL,
  `Link` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CreatedAt` datetime NOT NULL,
  `UpdatedAt` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `userlinks`
--

INSERT INTO `userlinks` (`Id`, `UserId`, `TypeId`, `Link`, `CreatedAt`, `UpdatedAt`) VALUES
(1, 1, 4, 'http://www.langworth.ca/catalog/page.asp', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(2, 2, 3, 'http://www.oharahoeger.biz/shop/books/applet.aspx', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(4, 4, 2, 'http://www.buckridge.name/films/form.gem', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(5, 5, 4, 'http://www.stracke.us/reviews/form.aspx', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(8, 8, 4, 'http://www.langosh.ca/shop/food/index.res', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(9, 9, 4, 'http://www.schiller.name/home/form.lsp', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(10, 10, 2, 'http://www.feil.ca/reviews/root.jsp', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(11, 11, 4, 'http://www.schulistlockman.uk/home/root.html', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(65, 59, 1, '#', '0001-01-01 00:00:00', '0001-01-01 00:00:00'),
(66, 59, 2, 'https://github.com/Abanoub98', '0001-01-01 00:00:00', '0001-01-01 00:00:00'),
(67, 59, 3, '#', '0001-01-01 00:00:00', '0001-01-01 00:00:00'),
(68, 59, 4, 'https://www.facebook.com/xXlBebolXx', '0001-01-01 00:00:00', '0001-01-01 00:00:00'),
(73, 61, 1, ' #', '0001-01-01 00:00:00', '0001-01-01 00:00:00'),
(74, 61, 2, ' #', '0001-01-01 00:00:00', '0001-01-01 00:00:00'),
(75, 61, 3, ' #', '0001-01-01 00:00:00', '0001-01-01 00:00:00'),
(76, 61, 4, ' #', '0001-01-01 00:00:00', '0001-01-01 00:00:00'),
(77, 66, 4, 'https://www.facebook.com/profile.php?id=100004658298305', '2021-09-23 15:03:09', '2021-10-03 17:11:02'),
(78, 66, 2, 'https://github.com/kirollos-hany', '2021-09-23 15:03:09', '2021-10-03 17:11:02'),
(79, 66, 3, 'https://www.linkedin.com/in/kirollos-hany-92149b1b2/', '2021-09-23 15:03:09', '2021-10-03 17:11:02'),
(80, 67, 1, '#', '2021-09-28 11:09:11', '2021-09-28 12:43:12'),
(81, 67, 2, '#', '2021-09-28 11:09:12', '2021-09-28 12:43:12'),
(82, 67, 3, '#', '2021-09-28 11:09:12', '2021-09-28 12:43:12'),
(83, 67, 4, '#', '2021-09-28 11:09:12', '2021-09-28 12:43:12'),
(84, 68, 1, '#', '2021-09-28 18:58:29', '2021-09-28 18:58:29'),
(85, 68, 2, '#', '2021-09-28 18:58:29', '2021-09-28 18:58:29'),
(86, 68, 3, '#', '2021-09-28 18:58:29', '2021-09-28 18:58:29'),
(87, 68, 4, '#', '2021-09-28 18:58:29', '2021-09-28 18:58:29');

-- --------------------------------------------------------

--
-- Table structure for table `userrolesinproject`
--

CREATE TABLE `userrolesinproject` (
  `Id` int NOT NULL,
  `Role` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedAt` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `userrolesinproject`
--

INSERT INTO `userrolesinproject` (`Id`, `Role`, `CreatedAt`, `UpdatedAt`) VALUES
(1, 'BackEnd', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(2, 'FrontEnd', '2021-08-23 19:15:22', '2021-08-23 19:15:22'),
(3, 'Team Leader', '2021-08-23 19:15:22', '2021-08-23 19:15:22');

-- --------------------------------------------------------

--
-- Table structure for table `usersinprojects`
--

CREATE TABLE `usersinprojects` (
  `Id` int NOT NULL,
  `UserId` int NOT NULL,
  `ProjectId` int NOT NULL,
  `RoleId` int NOT NULL,
  `CreatedAt` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000',
  `UpdatedAt` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `usersinprojects`
--

INSERT INTO `usersinprojects` (`Id`, `UserId`, `ProjectId`, `RoleId`, `CreatedAt`, `UpdatedAt`) VALUES
(109, 59, 68, 2, '2021-09-19 20:58:49.676420', '2021-09-22 08:32:04.896429'),
(145, 66, 68, 3, '2001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000'),
(149, 66, 87, 1, '2021-09-28 18:53:37.493086', '2021-10-03 22:37:24.423830'),
(150, 59, 87, 2, '2021-09-28 18:53:37.526791', '2021-10-03 22:37:24.426113'),
(152, 66, 88, 2, '2021-09-28 18:59:32.251696', '2021-09-29 13:18:25.869378'),
(153, 67, 88, 2, '2021-09-28 18:59:32.259733', '2021-09-29 13:18:25.883308'),
(154, 68, 88, 3, '2021-09-28 18:59:32.261881', '2021-09-29 13:18:25.890052');

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20210822143603_ResettingDbAddIdentity', '5.0.9'),
('20210823171523_AddedSpecializationToUser', '5.0.9'),
('20210831071228_AddedTimeStampsForSomeModels', '5.0.9'),
('20210831102314_EditedRelationProjectTools', '5.0.9'),
('20210905125450_RemovedImageTypes', '5.0.9'),
('20210905141130_AddedIconClassForLinks', '5.0.9'),
('20210921113528_AddedProjectLogs', '5.0.9'),
('20210921124617_AddedContactLogs', '5.0.9'),
('20210921160705_AddedServicesLogs', '5.0.9');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`);

--
-- Indexes for table `aspnetroles`
--
ALTER TABLE `aspnetroles`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `RoleNameIndex` (`NormalizedName`);

--
-- Indexes for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetUserClaims_UserId` (`UserId`);

--
-- Indexes for table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  ADD KEY `IX_AspNetUserLogins_UserId` (`UserId`);

--
-- Indexes for table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD PRIMARY KEY (`UserId`,`RoleId`),
  ADD KEY `IX_AspNetUserRoles_RoleId` (`RoleId`);

--
-- Indexes for table `aspnetusers`
--
ALTER TABLE `aspnetusers`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  ADD KEY `EmailIndex` (`NormalizedEmail`);

--
-- Indexes for table `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD PRIMARY KEY (`UserId`,`LoginProvider`,`Name`);

--
-- Indexes for table `contacts`
--
ALTER TABLE `contacts`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `StatusId` (`StatusId`);

--
-- Indexes for table `contactstatuses`
--
ALTER TABLE `contactstatuses`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Status` (`Status`);

--
-- Indexes for table `linktypes`
--
ALTER TABLE `linktypes`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `LinkType` (`LinkType`);

--
-- Indexes for table `projectfeedbacks`
--
ALTER TABLE `projectfeedbacks`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `ProjectId` (`ProjectId`);

--
-- Indexes for table `projectimages`
--
ALTER TABLE `projectimages`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `ProjectId1` (`ProjectId`);

--
-- Indexes for table `projectlinks`
--
ALTER TABLE `projectlinks`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `ProjectId2` (`ProjectId`),
  ADD KEY `TypeId1` (`TypeId`);

--
-- Indexes for table `projectlogs`
--
ALTER TABLE `projectlogs`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_ProjectLogs_ProjectId` (`ProjectId`),
  ADD KEY `IX_ProjectLogs_UserId` (`UserId`);

--
-- Indexes for table `projects`
--
ALTER TABLE `projects`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `TypeId` (`TypeId`),
  ADD KEY `project_creator-fk` (`CreatorId`);

--
-- Indexes for table `projecttypes`
--
ALTER TABLE `projecttypes`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `ProjectType` (`ProjectType`);

--
-- Indexes for table `requestedservices`
--
ALTER TABLE `requestedservices`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_RequestedServices_ContactId` (`ContactId`),
  ADD KEY `IX_RequestedServices_ServiceId` (`ServiceId`);

--
-- Indexes for table `services`
--
ALTER TABLE `services`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `usercertificates`
--
ALTER TABLE `usercertificates`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `certificates_user_fk` (`UserId`);

--
-- Indexes for table `userlinks`
--
ALTER TABLE `userlinks`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `TypeId2` (`TypeId`),
  ADD KEY `UserId` (`UserId`);

--
-- Indexes for table `userrolesinproject`
--
ALTER TABLE `userrolesinproject`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `usersinprojects`
--
ALTER TABLE `usersinprojects`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `ProjectId3` (`ProjectId`),
  ADD KEY `RoleId` (`RoleId`),
  ADD KEY `UserId1` (`UserId`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `aspnetroles`
--
ALTER TABLE `aspnetroles`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `aspnetusers`
--
ALTER TABLE `aspnetusers`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=72;

--
-- AUTO_INCREMENT for table `contacts`
--
ALTER TABLE `contacts`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=67;

--
-- AUTO_INCREMENT for table `contactstatuses`
--
ALTER TABLE `contactstatuses`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `linktypes`
--
ALTER TABLE `linktypes`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `projectfeedbacks`
--
ALTER TABLE `projectfeedbacks`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=52;

--
-- AUTO_INCREMENT for table `projectimages`
--
ALTER TABLE `projectimages`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=84;

--
-- AUTO_INCREMENT for table `projectlinks`
--
ALTER TABLE `projectlinks`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=188;

--
-- AUTO_INCREMENT for table `projectlogs`
--
ALTER TABLE `projectlogs`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `projects`
--
ALTER TABLE `projects`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=89;

--
-- AUTO_INCREMENT for table `projecttypes`
--
ALTER TABLE `projecttypes`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `requestedservices`
--
ALTER TABLE `requestedservices`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- AUTO_INCREMENT for table `services`
--
ALTER TABLE `services`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `usercertificates`
--
ALTER TABLE `usercertificates`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `userlinks`
--
ALTER TABLE `userlinks`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=100;

--
-- AUTO_INCREMENT for table `userrolesinproject`
--
ALTER TABLE `userrolesinproject`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `usersinprojects`
--
ALTER TABLE `usersinprojects`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=155;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `contacts`
--
ALTER TABLE `contacts`
  ADD CONSTRAINT `contacts_ibfk_1` FOREIGN KEY (`StatusId`) REFERENCES `contactstatuses` (`Id`);

--
-- Constraints for table `projectfeedbacks`
--
ALTER TABLE `projectfeedbacks`
  ADD CONSTRAINT `projectfeedbacks_ibfk_1` FOREIGN KEY (`ProjectId`) REFERENCES `projects` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `projectimages`
--
ALTER TABLE `projectimages`
  ADD CONSTRAINT `projectimages_ibfk_1` FOREIGN KEY (`ProjectId`) REFERENCES `projects` (`Id`) ON DELETE RESTRICT;

--
-- Constraints for table `projectlinks`
--
ALTER TABLE `projectlinks`
  ADD CONSTRAINT `projectlinks_ibfk_1` FOREIGN KEY (`ProjectId`) REFERENCES `projects` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `projectlinks_ibfk_2` FOREIGN KEY (`TypeId`) REFERENCES `linktypes` (`Id`) ON DELETE RESTRICT;

--
-- Constraints for table `projects`
--
ALTER TABLE `projects`
  ADD CONSTRAINT `project_creator-fk` FOREIGN KEY (`CreatorId`) REFERENCES `aspnetusers` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  ADD CONSTRAINT `projects_ibfk_1` FOREIGN KEY (`TypeId`) REFERENCES `projecttypes` (`Id`) ON DELETE RESTRICT;

--
-- Constraints for table `requestedservices`
--
ALTER TABLE `requestedservices`
  ADD CONSTRAINT `FK_RequestedServices_contacts_ContactId` FOREIGN KEY (`ContactId`) REFERENCES `contacts` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_RequestedServices_Services_ServiceId` FOREIGN KEY (`ServiceId`) REFERENCES `services` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `usercertificates`
--
ALTER TABLE `usercertificates`
  ADD CONSTRAINT `certificates_user_fk` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT;

--
-- Constraints for table `userlinks`
--
ALTER TABLE `userlinks`
  ADD CONSTRAINT `userlinks_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `userlinks_ibfk_2` FOREIGN KEY (`TypeId`) REFERENCES `linktypes` (`Id`) ON DELETE RESTRICT;

--
-- Constraints for table `usersinprojects`
--
ALTER TABLE `usersinprojects`
  ADD CONSTRAINT `usersinprojects_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `usersinprojects_ibfk_2` FOREIGN KEY (`ProjectId`) REFERENCES `projects` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `usersinprojects_ibfk_3` FOREIGN KEY (`RoleId`) REFERENCES `userrolesinproject` (`Id`) ON DELETE RESTRICT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

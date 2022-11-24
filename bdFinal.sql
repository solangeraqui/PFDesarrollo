/*
SQLyog Community v13.1.9 (64 bit)
MySQL - 10.4.24-MariaDB : Database - sistemaventas
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`sistemaventas` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;

USE `sistemaventas`;

/*Table structure for table `admin` */

DROP TABLE IF EXISTS `admin`;

CREATE TABLE `admin` (
  `id_admin` int(11) NOT NULL,
  `nombre` varchar(255) NOT NULL,
  `password` varchar(50) NOT NULL,
  PRIMARY KEY (`id_admin`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `admin` */

insert  into `admin`(`id_admin`,`nombre`,`password`) values 
(1,'Hugo','hugo123'),
(2,'Rocio','rocio123');

/*Table structure for table `products` */

DROP TABLE IF EXISTS `products`;

CREATE TABLE `products` (
  `id_producto` int(11) NOT NULL,
  `nombre` varchar(255) NOT NULL,
  `cantidad` varchar(50) DEFAULT NULL,
  `precio_compra` decimal(25,2) NOT NULL,
  `precio_venta` decimal(25,2) NOT NULL,
  PRIMARY KEY (`id_producto`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `products` */

insert  into `products`(`id_producto`,`nombre`,`cantidad`,`precio_compra`,`precio_venta`) values 
(1,'Filtro de gasolina toyota 20/22','97',5.00,10.00),
(2,'Aceite caja 75W-90 Castrol Transmax','1',6000.00,11000.00),
(3,'Gaseosa','10',7.00,10.00),
(4,'Caramelo','20',1.00,3.00);

/*Table structure for table `users` */

DROP TABLE IF EXISTS `users`;

CREATE TABLE `users` (
  `id` int(11) unsigned NOT NULL,
  `name` varchar(60) CHARACTER SET latin1 NOT NULL,
  `username` varchar(50) CHARACTER SET latin1 NOT NULL,
  `password` varchar(255) CHARACTER SET latin1 NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `users` */

insert  into `users`(`id`,`name`,`username`,`password`) values 
(1,'Admin Users','admin','d033e22ae348aeb5660fc2140aec35850c4da997'),
(2,'Special User','special','ba36b97a41e7faf742ab09bf88405ac04f99599a'),
(3,'Solange','Admin','solange123');

/*Table structure for table `venta_detalles` */

DROP TABLE IF EXISTS `venta_detalles`;

CREATE TABLE `venta_detalles` (
  `id_ventadetalle` int(11) NOT NULL AUTO_INCREMENT,
  `venta_id` int(11) NOT NULL,
  `cantidad` int(11) NOT NULL,
  `id_producto` int(11) DEFAULT NULL,
  `precioVenta` int(11) NOT NULL,
  PRIMARY KEY (`id_ventadetalle`)
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8;

/*Data for the table `venta_detalles` */

insert  into `venta_detalles`(`id_ventadetalle`,`venta_id`,`cantidad`,`id_producto`,`precioVenta`) values 
(2,3,2,1,10),
(3,3,2,5,36000),
(4,0,0,0,0),
(5,0,0,0,0),
(6,0,0,0,0),
(7,0,20,0,0),
(8,0,10,0,0),
(9,0,97,0,0),
(10,0,20,0,0),
(11,0,10,0,0),
(12,0,10,0,0),
(13,0,5,0,0),
(14,0,4,0,0),
(15,0,4,0,0),
(16,0,5,0,0),
(17,0,5,0,0),
(18,0,20,NULL,0),
(19,0,10,NULL,0),
(20,0,10,NULL,0),
(21,0,20,NULL,0),
(22,0,20,NULL,0),
(23,0,20,NULL,0),
(24,0,20,NULL,0),
(25,0,20,NULL,0),
(26,0,3,NULL,0),
(27,0,3,NULL,0),
(28,0,3,NULL,0),
(29,0,3,NULL,0),
(30,0,3,NULL,0),
(31,0,10,NULL,0),
(32,0,2,NULL,0),
(33,0,3,NULL,0),
(34,0,4,NULL,0),
(35,0,10,NULL,0),
(36,0,20,NULL,0),
(37,0,10,NULL,0),
(38,0,10,NULL,0);

/*Table structure for table `ventas` */

DROP TABLE IF EXISTS `ventas`;

CREATE TABLE `ventas` (
  `id_venta` int(11) NOT NULL,
  `price` int(25) NOT NULL,
  `date` date DEFAULT NULL,
  PRIMARY KEY (`id_venta`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `ventas` */

insert  into `ventas`(`id_venta`,`price`,`date`) values 
(0,0,NULL),
(1,10,'2002-02-10');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

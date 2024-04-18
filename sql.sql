drop database if exists libraryMy;
create database libraryMy;
use libraryMy;
CREATE TABLE `autor` (
	`fio` VARCHAR(50) primary key
);

CREATE TABLE `users` (
	`id` INT NOT NULL AUTO_INCREMENT,
	PRIMARY KEY (`id`),
	`fio` VARCHAR(50) NOT NULL,
	`adres` VARCHAR(50) NOT NULL,
	`phone` INT NOT NULL
);

CREATE TABLE `book` (
	`id` INT NOT NULL AUTO_INCREMENT,
	PRIMARY KEY (`id`),
	`autor` VARCHAR(50) NOT NULL,
	`name` VARCHAR(50) NOT NULL,
	`year` INT NOT NULL,
	`count` INT NOT NULL,
	FOREIGN KEY (autor)  REFERENCES autor (fio)

);
CREATE TABLE `orders` (
	`id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY (`id`),
	`users` INT NOT NULL,
	`book` INT NOT NULL,
	`dates` DATE NOT NULL,
	`isBack` BOOLEAN NOT NULL,
	FOREIGN KEY (users)  REFERENCES users (id),
	FOREIGN KEY (book)  REFERENCES book (id)
);

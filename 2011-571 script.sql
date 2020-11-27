SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `mydb` ;

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`Autor`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`Autor` ;

CREATE TABLE IF NOT EXISTS `mydb`.`Autor` (
  `id` INT ,
  `FIO` VARCHAR(60) NULL,
  `dateborn` DATETIME NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Books`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`Books` ;

CREATE TABLE IF NOT EXISTS `mydb`.`Books` (
  `id` INT ,
  `name` VARCHAR(45) NULL,
  `autor` INT NULL,
  `dateget` DATETIME NULL,
  `isHas` TINYINT NULL,
  `count` INT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `autor`
    FOREIGN KEY (`autor`)
    REFERENCES `mydb`.`Autor` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Users`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`Users` ;

CREATE TABLE IF NOT EXISTS `mydb`.`Users` (
  `id` INT ,
  `fio` VARCHAR(45) NULL,
  `dateregistration` INT NULL,
  `phone` INT NULL,
  `class` VARCHAR(45) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`History`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`History` ;

CREATE TABLE IF NOT EXISTS `mydb`.`History` (
  `id` INT ,
  `user` INT NULL,
  `book` INT NULL,
  `dateget` DATETIME NULL,
  `isBack` TINYINT NULL,
  `datepost` DATETIME NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `user`
    FOREIGN KEY (`user`)
    REFERENCES `mydb`.`Users` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `book`
    FOREIGN KEY (`book`)
    REFERENCES `mydb`.`Books` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

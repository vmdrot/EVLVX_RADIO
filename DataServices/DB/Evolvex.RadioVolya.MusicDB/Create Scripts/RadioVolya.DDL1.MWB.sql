SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `zenet` ;
CREATE SCHEMA IF NOT EXISTS `radiomusiclib` DEFAULT CHARACTER SET utf8 ;
USE `zenet` ;

-- -----------------------------------------------------
-- Table `zenet`.`tbl_ref_music_genre`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `zenet`.`tbl_ref_music_genre` (
  `genre_id` INT NULL DEFAULT NULL AUTO_INCREMENT ,
  `genre_cd` VARCHAR(64) NOT NULL ,
  `genre_nm` VARCHAR(128) NOT NULL ,
  PRIMARY KEY (`genre_id`) ,
  UNIQUE INDEX (`genre_cd` ASC) ,
  UNIQUE INDEX (`genre_nm` ASC) );


-- -----------------------------------------------------
-- Table `zenet`.`tbl_ref_music_tempo`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `zenet`.`tbl_ref_music_tempo` (
  `tempo_id` INT NOT NULL AUTO_INCREMENT ,
  `tempo_nm` VARCHAR(32) NOT NULL ,
  `bpm` INT NOT NULL ,
  PRIMARY KEY (`tempo_id`) ,
  UNIQUE INDEX (`tempo_nm` ASC) );


-- -----------------------------------------------------
-- Table `zenet`.`tbl_ref_music_mood`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `zenet`.`tbl_ref_music_mood` (
  `mood_id` INT NOT NULL AUTO_INCREMENT ,
  `mood_cd` VARCHAR(16) NOT NULL ,
  `mood_nm` VARCHAR(32) NOT NULL ,
  PRIMARY KEY (`mood_id`) ,
  UNIQUE INDEX (`mood_cd` ASC) ,
  UNIQUE INDEX (`mood_nm` ASC) );


-- -----------------------------------------------------
-- Table `zenet`.`tbl_ref_lang`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `zenet`.`tbl_ref_lang` (
  `lcid` INT NOT NULL ,
  `ietf_tag` VARCHAR(15) NOT NULL ,
  `eng_nm` VARCHAR(32) NOT NULL ,
  `ukr_nm` VARCHAR(32) NOT NULL ,
  PRIMARY KEY (`lcid`) ,
  UNIQUE INDEX (`ietf_tag` ASC) ,
  UNIQUE INDEX (`eng_nm` ASC) ,
  UNIQUE INDEX (`ukr_nm` ASC) );


-- -----------------------------------------------------
-- Table `zenet`.`tbl_ref_country`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `zenet`.`tbl_ref_country` (
  `country_id` INT NOT NULL AUTO_INCREMENT ,
  `country_cd` VARCHAR(7) NOT NULL ,
  `country_nm_eng` VARCHAR(32) NOT NULL ,
  `country_nm_ukr` VARCHAR(32) NOT NULL ,
  PRIMARY KEY (`country_id`) ,
  UNIQUE INDEX (`country_cd` ASC) ,
  UNIQUE INDEX (`country_nm_eng` ASC) ,
  UNIQUE INDEX (`country_nm_ukr` ASC) );


-- -----------------------------------------------------
-- Table `zenet`.`tbl_artist`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `zenet`.`tbl_artist` (
  `artist_id` INT NULL DEFAULT NULL AUTO_INCREMENT ,
  `artist_nm` VARCHAR(128) NOT NULL ,
  `country_id` INT NULL DEFAULT NULL ,
  `birth_dttm` DATETIME NULL DEFAULT NULL ,
  `departed_dttm` DATETIME NULL DEFAULT NULL ,
  `notes` TEXT(511) NULL DEFAULT NULL ,
  PRIMARY KEY (`artist_id`) ,
  UNIQUE INDEX (`artist_nm` ASC) );


-- -----------------------------------------------------
-- Table `zenet`.`tbl_track`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `zenet`.`tbl_track` (
  `track_id` INT NULL DEFAULT NULL AUTO_INCREMENT ,
  `track_nm` VARCHAR(128) NOT NULL ,
  `album_nm` VARCHAR(128) NULL DEFAULT NULL ,
  `path` VARCHAR(255) NULL DEFAULT NULL ,
  `genre_id` INT NULL DEFAULT NULL ,
  `bitrate` INT NULL DEFAULT NULL ,
  `file_size` INT NULL DEFAULT NULL ,
  `release_dttm` DATETIME NULL DEFAULT NULL ,
  `length` INT NULL DEFAULT NULL ,
  `bpm` INT NULL DEFAULT NULL ,
  PRIMARY KEY (`track_id`) );


-- -----------------------------------------------------
-- Table `zenet`.`tbl_track_mm_artist`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `zenet`.`tbl_track_mm_artist` (
  `trck_art_id` INT NOT NULL AUTO_INCREMENT ,
  `track_id` INT NOT NULL ,
  `artist_id` INT NOT NULL ,
  PRIMARY KEY (`trck_art_id`) ,
  UNIQUE INDEX (`track_id` ASC, `artist_id` ASC) );


-- -----------------------------------------------------
-- Table `zenet`.`tbl_track_mm_lang`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `zenet`.`tbl_track_mm_lang` (
  `trck_lng_id` INT NOT NULL AUTO_INCREMENT ,
  `track_id` INT NOT NULL ,
  `lcid` INT NOT NULL ,
  PRIMARY KEY (`trck_lng_id`) ,
  UNIQUE INDEX (`track_id` ASC, `lcid` ASC) );


-- -----------------------------------------------------
-- Table `zenet`.`tbl_track_mm_mood`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `zenet`.`tbl_track_mm_mood` (
  `trck_mod_id` INT NOT NULL AUTO_INCREMENT ,
  `track_id` INT NOT NULL ,
  `mood_id` INT NOT NULL ,
  PRIMARY KEY (`trck_mod_id`) ,
  UNIQUE INDEX (`track_id` ASC, `mood_id` ASC) );


-- -----------------------------------------------------
-- Table `zenet`.`tbl_track_mm_genre`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `zenet`.`tbl_track_mm_genre` (
  `trck_gnr_id` INT NOT NULL AUTO_INCREMENT ,
  `track_id` INT NOT NULL ,
  `genre_id` INT NOT NULL ,
  UNIQUE INDEX (`track_id` ASC, `genre_id` ASC) );

USE `radiomusiclib` ;

-- -----------------------------------------------------
-- Table `radiomusiclib`.`tbl_ref_music_genre`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `radiomusiclib`.`tbl_ref_music_genre` (
  `genre_id` INT(11) NOT NULL AUTO_INCREMENT ,
  `genre_cd` VARCHAR(64) NOT NULL ,
  `genre_nm` VARCHAR(128) NOT NULL ,
  PRIMARY KEY (`genre_id`) ,
  UNIQUE INDEX `genre_cd` (`genre_cd` ASC) ,
  UNIQUE INDEX `genre_nm` (`genre_nm` ASC) )
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `radiomusiclib`.`tbl_ref_music_tempo`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `radiomusiclib`.`tbl_ref_music_tempo` (
  `tempo_id` INT(11) NOT NULL AUTO_INCREMENT ,
  `tempo_nm` VARCHAR(32) NOT NULL ,
  `bpm` INT(11) NOT NULL ,
  PRIMARY KEY (`tempo_id`) ,
  UNIQUE INDEX `tempo_nm` (`tempo_nm` ASC) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;



SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

--CREATE SCHEMA IF NOT EXISTS `radiomusiclib` DEFAULT CHARACTER SET utf8;
CREATE SCHEMA radiomusiclib;
--USE `radiomusiclib`;
--USE radiomusiclib;

CREATE TABLE IF NOT EXISTS radiomusiclib.tbl_ref_music_genre
(
	genre_id SERIAL PRIMARY KEY,
	genre_cd VARCHAR(64) NOT NULL UNIQUE,
	genre_nm VARCHAR(128) NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS radiomusiclib.tbl_tag
(
	tag_id SERIAL PRIMARY KEY,
	tag_cd VARCHAR(32) NOT NULL UNIQUE,
	tag_nm VARCHAR(128) NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS radiomusiclib.tbl_tag_mm_date
(
	tag_dttm_id SERIAL PRIMARY KEY,
	tag_id INT NOT NULL,
	start_dttm DATE NOT NULL,
	end_dttm DATE NOT NULL,
	UNIQUE(tag_id, start_dttm, end_dttm)
);
-- http://en.wikipedia.org/wiki/Tempo#Italian_tempo_markings
-- http://www.soundonsound.com/sos/sep03/articles/protoolsnotes.htm
CREATE TABLE IF NOT EXISTS radiomusiclib.tbl_ref_music_tempo
(
	tempo_id SERIAL PRIMARY KEY,
	tempo_nm VARCHAR(32) NOT NULL UNIQUE,
	bpm INT NOT NULL
);

-- http://en.wikipedia.org/wiki/Tempo#Mood_markings_with_a_tempo_conotation
CREATE TABLE IF NOT EXISTS radiomusiclib.tbl_ref_music_mood
(
	mood_id SERIAL PRIMARY KEY,
	mood_cd VARCHAR(16) NOT NULL UNIQUE,
	mood_nm VARCHAR(32) NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS radiomusiclib.tbl_ref_lang
(
	lcid INT NOT NULL PRIMARY KEY,
	ietf_tag VARCHAR(15) NOT NULL UNIQUE,
	eng_nm VARCHAR(32) NOT NULL UNIQUE,
	ukr_nm VARCHAR(32) NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS radiomusiclib.tbl_ref_country
(
	country_id SERIAL PRIMARY KEY,
	country_cd VARCHAR(7) NOT NULL UNIQUE,
	country_nm_eng VARCHAR(32) NOT NULL UNIQUE,
	country_nm_ukr VARCHAR(32) NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS radiomusiclib.tbl_artist
(
	artist_id SERIAL PRIMARY KEY,
	artist_nm VARCHAR(128) NOT NULL UNIQUE,
	country_id INT,
	birth_dttm DATE,
	departed_dttm DATE,
	notes TEXT
);

CREATE TABLE IF NOT EXISTS radiomusiclib.tbl_track
(
	track_id SERIAL PRIMARY KEY,
	track_nm VARCHAR(128) NOT NULL,
	album_nm VARCHAR(128),
	path VARCHAR(255),
	genre_id INT,
	bitrate INT,
	file_size INT,
	release_dttm DATE,
	length INT,
	bpm INT
);

CREATE TABLE IF NOT EXISTS radiomusiclib.tbl_track_mm_artist
(
	trck_art_id SERIAL PRIMARY KEY,
	track_id INT NOT NULL,
	artist_id INT NOT NULL,
	UNIQUE(track_id,artist_id)
);

CREATE TABLE IF NOT EXISTS radiomusiclib.tbl_track_mm_lang
(
	trck_lng_id SERIAL PRIMARY KEY,
	track_id INT NOT NULL,
	lcid INT NOT NULL,
	UNIQUE(track_id, lcid)
);

CREATE TABLE IF NOT EXISTS radiomusiclib.tbl_track_mm_mood
(
	trck_mod_id SERIAL PRIMARY KEY,
	track_id INT NOT NULL,
	mood_id INT NOT NULL,
	UNIQUE(track_id, mood_id)
);

CREATE TABLE IF NOT EXISTS radiomusiclib.tbl_track_mm_genre
(
	trck_gnr_id SERIAL PRIMARY KEY,
	track_id INT NOT NULL,
	genre_id INT NOT NULL,
	UNIQUE(track_id, genre_id)
);

CREATE TABLE IF NOT EXISTS radiomusiclib.tbl_track_mm_tag
(
	trck_tag_id SERIAL PRIMARY KEY,
	track_id INT NOT NULL,
	tag_id INT NOT NULL,
	UNIQUE(track_id, tag_id)
);

--CREATE SCHEMA IF NOT EXISTS `radiomusiclib` DEFAULT CHARACTER SET utf8;

CREATE TABLE IF NOT EXISTS radiomusiclib.tbl_radio_stream
(
	stream_id SERIAL PRIMARY KEY,
	stream_nm VARCHAR(32) NOT NULL UNIQUE,
	stream_descr VARCHAR(255)
);

CREATE TABLE IF NOT EXISTS radiomusiclib.tbl_track_play_history
(
	trk_pl_hist_id SERIAL PRIMARY KEY,
	track_id INT NOT NULL,
	stream_id INT NOT NULL,
	play_dttm TIMESTAMP NOT NULL
);

CREATE TABLE IF NOT EXISTS radiomusiclib.tbl_track_schedule
(
	trk_schdl_id SERIAL PRIMARY KEY,
	track_id INT NOT NULL,
	stream_id INT NOT NULL,
	scheduled_play_dttm TIMESTAMP NOT NULL
);

--CREATE SCHEMA IF NOT EXISTS `radiomusiclib` DEFAULT CHARACTER SET utf8;

CREATE TABLE IF NOT EXISTS radiomusiclib.tbl_schedule_block
(
	block_id SERIAL PRIMARY KEY,
	block_nm VARCHAR(128) NOT NULL UNIQUE,
	start_time TIME NOT NULL UNIQUE,
	end_time TIME NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS radiomusiclib.tbl_schedule_rule
(
	rule_id SERIAL PRIMARY KEY,
	stream_id INT NOT NULL, 
	block_id INT NOT NULL,
	rule_def TEXT,
	valid_since TIMESTAMP,
	valid_till TIMESTAMP,
	enabled BOOLEAN DEFAULT 'true'
);
 
 
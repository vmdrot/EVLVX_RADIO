USE RadioMusicLib;
CREATE TABLE radiomusiclib.tbl_ref_music_genre
(
	genre_id INT IDENTITY(1,1) PRIMARY KEY,
	genre_cd VARCHAR(64) NOT NULL UNIQUE,
	genre_nm NVARCHAR(128) NOT NULL UNIQUE
);

CREATE TABLE radiomusiclib.tbl_track_kind
(
	track_kind_id INT IDENTITY(1,1) PRIMARY KEY,
	track_kind_cd VARCHAR(64) NOT NULL UNIQUE,
	track_kind_nm NVARCHAR(128) NOT NULL UNIQUE
);

CREATE TABLE radiomusiclib.tbl_tag
(
	tag_id INT IDENTITY(1,1) PRIMARY KEY,
	tag_cd VARCHAR(32) NOT NULL UNIQUE,
	tag_nm NVARCHAR(128) NOT NULL UNIQUE
);

CREATE TABLE radiomusiclib.tbl_tag_mm_date
(
	tag_dttm_id INT IDENTITY(1,1) PRIMARY KEY,
	tag_id INT NOT NULL,
	start_dttm DATETIME NOT NULL,
	end_dttm DATETIME NOT NULL,
	UNIQUE(tag_id, start_dttm, end_dttm)
);
-- http://en.wikipedia.org/wiki/Tempo#Italian_tempo_markings
-- http://www.soundonsound.com/sos/sep03/articles/protoolsnotes.htm
CREATE TABLE radiomusiclib.tbl_ref_music_tempo
(
	tempo_id INT IDENTITY(1,1) PRIMARY KEY,
	tempo_nm VARCHAR(32) NOT NULL UNIQUE,
	bpm INT NOT NULL
);

-- http://en.wikipedia.org/wiki/Tempo#Mood_markings_with_a_tempo_conotation
CREATE TABLE radiomusiclib.tbl_ref_music_mood
(
	mood_id INT IDENTITY(1,1) PRIMARY KEY,
	mood_cd VARCHAR(16) NOT NULL UNIQUE,
	mood_nm NVARCHAR(32) NOT NULL UNIQUE
);

CREATE TABLE radiomusiclib.tbl_ref_lang
(
	lcid INT NOT NULL PRIMARY KEY,
	ietf_tag VARCHAR(15) NOT NULL UNIQUE,
	eng_nm VARCHAR(32) NOT NULL UNIQUE,
	ukr_nm NVARCHAR(32) NOT NULL UNIQUE
);

CREATE TABLE radiomusiclib.tbl_ref_country
(
	country_id INT IDENTITY(1,1) PRIMARY KEY,
	country_cd VARCHAR(7) NOT NULL UNIQUE,
	country_nm_eng VARCHAR(32) NOT NULL UNIQUE,
	country_nm_ukr NVARCHAR(32) NOT NULL UNIQUE
);

CREATE TABLE radiomusiclib.tbl_artist
(
	artist_id INT IDENTITY(1,1) PRIMARY KEY,
	artist_nm VARCHAR(128) NOT NULL UNIQUE,
	country_id INT,
	birth_dttm DATETIME,
	departed_dttm DATETIME,
	notes NTEXT
);

CREATE TABLE radiomusiclib.tbl_track
(
	track_id INT IDENTITY(1,1) PRIMARY KEY,
	track_kind_id INT NOT NULL,
	track_nm NVARCHAR(128) NOT NULL,
	album_nm NVARCHAR(128),
	file_path NVARCHAR(255),
	bitrate INT,
	file_size INT,
	audio_channels TINYINT, 
	audio_sample_rate INT, 
	bits_per_sample INT,
	release_year INT,
	duration DECIMAL(8,3),
	bpm INT,
	lyrics NTEXT
);

CREATE TABLE radiomusiclib.tbl_track_mm_artist
(
	trck_art_id INT IDENTITY(1,1) PRIMARY KEY,
	track_id INT NOT NULL,
	artist_id INT NOT NULL,
	UNIQUE(track_id,artist_id)
);

CREATE TABLE radiomusiclib.tbl_track_mm_lang
(
	trck_lng_id INT IDENTITY(1,1) PRIMARY KEY,
	track_id INT NOT NULL,
	lcid INT NOT NULL,
	UNIQUE(track_id, lcid)
);

CREATE TABLE radiomusiclib.tbl_track_mm_mood
(
	trck_mod_id INT IDENTITY(1,1) PRIMARY KEY,
	track_id INT NOT NULL,
	mood_id INT NOT NULL,
	UNIQUE(track_id, mood_id)
);

CREATE TABLE radiomusiclib.tbl_track_mm_genre
(
	trck_gnr_id INT IDENTITY(1,1) PRIMARY KEY,
	track_id INT NOT NULL,
	genre_id INT NOT NULL,
	UNIQUE(track_id, genre_id)
);

CREATE TABLE radiomusiclib.tbl_track_mm_tag
(
	trck_tag_id INT IDENTITY(1,1) PRIMARY KEY,
	track_id INT NOT NULL,
	tag_id INT NOT NULL,
	UNIQUE(track_id, tag_id)
);

CREATE TABLE radiomusiclib.tbl_radio_stream
(
	stream_id INT IDENTITY(1,1) PRIMARY KEY,
	stream_nm NVARCHAR(32) NOT NULL UNIQUE,
	strea_url VARCHAR(1078),
	stream_descr NVARCHAR(255)
);

CREATE TABLE radiomusiclib.tbl_track_play_history
(
	trk_pl_hist_id INT IDENTITY(1,1) PRIMARY KEY,
	track_id INT NOT NULL,
	stream_id INT NOT NULL,
	play_dttm DATETIME NOT NULL
);

CREATE TABLE radiomusiclib.tbl_track_schedule
(
	trk_schdl_id INT IDENTITY(1,1) PRIMARY KEY,
	track_id INT NOT NULL,
	stream_id INT NOT NULL,
	scheduled_play_dttm DATETIME NOT NULL
);

CREATE TABLE radiomusiclib.tbl_schedule_block
(
	block_id INT IDENTITY(1,1) PRIMARY KEY,
	block_nm NVARCHAR(128) NOT NULL UNIQUE,
	start_time DATETIME NOT NULL UNIQUE,
	end_time DATETIME NOT NULL UNIQUE
);

CREATE TABLE radiomusiclib.tbl_schedule_rule
(
	rule_id INT IDENTITY(1,1) PRIMARY KEY,
	stream_id INT NOT NULL, 
	block_id INT NOT NULL,
	rule_def NTEXT,
	valid_since DATETIME,
	valid_till DATETIME,
	is_enabled BIT DEFAULT 1
);

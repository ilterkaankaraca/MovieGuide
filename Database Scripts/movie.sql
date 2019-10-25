CREATE TABLE MOVIE(
	id auto increment
	imdb_rating
	title 
	year
	runtime
	genre mapping
	actor mapping
	director mapping
	plot
	writer mapping
	rated lookup
	released dont need
	language mappıng
	imdb votes dont need 
	imdb id
	creation_date timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
	modification_date timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
) comment = 'lookup table for movie categories';
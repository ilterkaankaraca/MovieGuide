CREATE TABLE LT_GENRE(
	id int not null auto_increment,
	code varchar(255),
	creation_date timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
	modification_date timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
	primary key(id)
) comment = 'lookup table for genre';
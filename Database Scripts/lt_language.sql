CREATE TABLE LT_LANGUAGE(
	id int not null auto_increment,
	code varchar(255),
	creation_date timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
	modifiaction_date timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
	primary key(id)
) comment = 'lookup table for actors';
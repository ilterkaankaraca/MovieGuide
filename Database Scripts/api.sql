CREATE TABLE api(
	id int not null auto_increment,
	api varchar(255),
    description varchar(255),
	creation_date timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
	modification_date timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
	primary key(id)
) 
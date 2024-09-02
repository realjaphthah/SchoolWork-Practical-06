create table reservation(
	res_id int identity(2, 2),
	email varchar(255) not null unique,
	firstname varchar(100) not null,
	lastname varchar(100) not null,
	persons int not null check(persons>=1),
	res_date date not null,
	res_time time not null,
	primary key(res_id)
);

create table menu_item(
	item_id int identity(1, 2),
	name varchar(50) not null,
	description varchar(1000) not null,
	img varchar(255) not null,
	price decimal not null,
	item_type varchar(50) not null,
	is_available boolean not null,
	primary key(item_id)
);
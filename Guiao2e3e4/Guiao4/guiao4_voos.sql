CREATE SCHEMA ReservaDeVoos;
GO
/*DROP TABLE ReservaDeVoos.fare;
DROP TABLE ReservaDeVoos.flight;
DROP TABLE ReservaDeVoos.flight_leg;
DROP TABLE ReservaDeVoos.leg_instance;
DROP TABLE ReservaDeVoos.seat;
DROP TABLE ReservaDeVoos.airplane;
DROP TABLE ReservaDeVoos.airplane_type;
DROP TABLE ReservaDeVoos.can_land;
DROP TABLE ReservaDeVoos.airport;
*/

CREATE TABLE ReservaDeVoos.flight(

	Airlane	varchar(30),
	Weekdays	varchar(30) ,
	Flight_N	int not null,

	PRIMARY KEY (Flight_N),	
);
CREATE TABLE ReservaDeVoos.fare(

	Amount	int,
	Restrictions	varchar,
	Code	int not null,
	Fflight_N	int,

	PRIMARY KEY (Code),
	FOREIGN KEY (Fflight_N) REFERENCES ReservaDeVoos.flight(Flight_N),
);

CREATE TABLE ReservaDeVoos.airport(

	A_Code	int not null,
	City	char,
	Astate	char,
	Name	varchar(15),
	
	PRIMARY KEY (A_Code),

);

CREATE TABLE ReservaDeVoos.flight_leg(

	Leg_N	int not null,
	F_flight_N	int,
	AirportCode	int,
	Sched_Dep_Time	time,
	Sched_Arr_Time	time,

	
	FOREIGN KEY (F_flight_N) REFERENCES ReservaDeVoos.flight(Flight_N),
	FOREIGN KEY (AirportCode) REFERENCES ReservaDeVoos.airport(A_Code),

	PRIMARY KEY (Leg_N,F_flight_N),
);
CREATE TABLE ReservaDeVoos.airplane_type(

	TypeName	varchar not null,
	Max_Seats	int,
	Company		varchar,

	PRIMARY KEY (TypeName),

);
CREATE TABLE ReservaDeVoos.airplane(

	Airplane_ID int not null,
	Total_Seats	int,
	TypeName	varchar,
	
	PRIMARY KEY (Airplane_ID),
	FOREIGN KEY (TypeName) REFERENCES ReservaDeVoos.airplane_type(TypeName),
);
CREATE TABLE ReservaDeVoos.leg_instance(

	Avail_Seats_N	int,
	Data	date,
	Fleg_N	int,
	Flight_N int,
	Airport_code int,
	Arr_Time time,
	Dep_time time,
	Airplane_ID int,

	PRIMARY KEY (Data,Fleg_N,Flight_N),
	FOREIGN KEY (Fleg_N) REFERENCES ReservaDeVoos.flight_leg(Leg_N),
	FOREIGN KEY (Flight_N) REFERENCES ReservaDeVoos.flight_leg(F_flight_N),
	FOREIGN KEY (Airport_code) REFERENCES ReservaDeVoos.airport(A_Code),
	FOREIGN KEY (Airplane_ID) REFERENCES ReservaDeVoos.airplane(Airplane_ID),
);
CREATE TABLE ReservaDeVoos.seat(

	Seat_N	int not null,
	Data	date,
	LegN	int,
	Flight_N	int,
	Costumer_Name varchar(15),
	Costumer_Phone int,

	PRIMARY KEY (Seat_N),
	FOREIGN KEY (LegN) REFERENCES ReservaDeVoos.leg_instance(Fleg_N),
	FOREIGN KEY (Flight_N) REFERENCES ReservaDeVoos.leg_instance(Flight_N),
	FOREIGN KEY (Data) REFERENCES ReservaDeVoos.leg_instance(Data),

);

CREATE TABLE ReservaDeVoos.can_land(

	A_Code	int,
	TypeName	varchar,
	
	FOREIGN KEY (A_Code) REFERENCES  ReservaDeVoos.airport(A_Code),
	FOREIGN KEY (TypeName) REFERENCES  ReservaDeVoos.airplane_Type(TypeName),
	
);

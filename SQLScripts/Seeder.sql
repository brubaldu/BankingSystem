insert into users values (1,'Juan Perez','juanperez@gmail.com');
insert into users values (2,'Rodrigo Gonzalez','rogonzalez@gmail.com');
insert into users values (3,'Mariano Rodriguez','marianor@gmail.com');

insert into accounts values (1,10000,1,1);
insert into accounts values (2,1000,2,2);
insert into accounts values (3,10000,1,3);
insert into accounts values (4,5000,1,2);

Delimiter //
CREATE PROCEDURE createTransactions()
BEGIN
DECLARE v1 INT DEFAULT 5;
WHILE v1 > 0 DO
    insert into transactions values (null,FLOOR(RAND()*(4)+1),FLOOR(RAND()*(4)+1),now(),'Transaction',FLOOR(RAND()*(1000)+1));
    SET v1 = v1 - 1;
END WHILE; 
END;
//
Delimiter ;
call createTransactions();

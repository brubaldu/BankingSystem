Delimiter //
CREATE PROCEDURE createTransactions()
BEGIN
DECLARE v1 INT DEFAULT 10000;
WHILE v1 > 0 DO
    insert into transactions values (null,FLOOR(RAND()*(4)+1),FLOOR(RAND()*(4)+1),now(),'Transaction',FLOOR(RAND()*(1000)+1));
    SET v1 = v1 - 1;
END WHILE; 
END;
//
Delimiter ;
call createTransactions();

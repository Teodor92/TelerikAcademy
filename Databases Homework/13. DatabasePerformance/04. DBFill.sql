DELIMITER $$

CREATE PROCEDURE Generate_random_logs ()
BEGIN
DECLARE counter INT DEFAULT 0;
START TRANSACTION;
WHILE counter < 1000000 DO
INSERT INTO Logs(LogDate, LogText)
VALUES(TIMESTAMPADD(DAY, FLOOR(1 + RAND() * 10000), '1990-01-01'),
CONCAT('Sample text ', counter));
SET counter = counter + 1;
END WHILE;
END $$

CALL Generate_random_logs ();

SELECT * FROM logs PARTITION(p2);

SELECT * FROM logs WHERE YEAR(LogDate) = 1995;
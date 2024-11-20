CREATE DATABASE gestaoFacilBD;
use gestaoFacilBD;

CREATE TABLE servidor (
id_servidor INT NOT NULL AUTO_INCREMENT,
nomeServidor VARCHAR(255) NOT NULL,
cpf VARCHAR(14) NOT NULL,
siapeServidor INT NOT NULL,
PRIMARY KEY (id_servidor)
);

INSERT INTO servidor VALUES
	(null, "João Teixeira", "123.123.123-01", 1234567),
    (null, "Fulano de tal", "097.123.634-02", 0986234),
    (null, "Lucas Guilherm", "982.960.234-90", 0759473),
    (null, "Ciclano", "045.236.234-85", 7492847);
    
SELECT * FROM servidor;
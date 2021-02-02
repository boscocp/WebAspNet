
CREATE TABLE person (
   id BIGSERIAL NOT NULL PRIMARY KEY,
   name     VARCHAR(100) NOT NULL,
   date_of_birth DATE NOT NULL,
   cpf     NUMERIC NOT NULL,
   income DOUBLE PRECISION
);

ALTER TABLE "blog" OWNER TO bosco;

INSERT INTO person (id, cpf, name, date_of_birth , income) VALUES ('1', '100000', 'Bosco', '1988-05-16T05:50:06', '4006');
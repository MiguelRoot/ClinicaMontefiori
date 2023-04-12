
/*///////////////////////////////////////////////// */
/* ///////////////// CREATE DB /////////////////// */
/*/////////////////////////////////////////////// */

USE MASTER
go
-- Evaluar si la base de datos existe
IF EXISTS(SELECT name FROM sys.databases WHERE name='clinica_montefiori')
BEGIN
    -- Eliminar la base de datos existente
    ALTER DATABASE clinica_montefiori SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE clinica_montefiori;
    PRINT 'La base de datos anterior ha sido eliminada'
END
ELSE
BEGIN
    PRINT 'La base de datos no existe'
END


-- Crear la nueva base de datos
CREATE DATABASE clinica_montefiori;
PRINT 'La nueva base de datos ha sido creada'

go

USE clinica_montefiori


go

/*///////////////////////////////////////////////// */
/* /////////////// CREATE TABLE ////////////////// */
/*/////////////////////////////////////////////// */

-- Crear tabla tb_clientes
CREATE TABLE tb_clientes (
  id INT PRIMARY KEY,
  id_recepcionista INT,
  nombre VARCHAR(50),
  apellido_paterno VARCHAR(50),
  apellido_materno VARCHAR(50),
  dni INT,
  sexo CHAR(1),
  fecha_nacimiento Date,
  telefono VARCHAR(20),
  numero_movil VARCHAR(13),
  correo VARCHAR(50)
);

-- Crear tabla tb_triaje
CREATE TABLE tb_triaje (
  id INT PRIMARY KEY,
  id_cliente INT,
  fecha DATE,
  temperatura DECIMAL(4, 1),
  peso INT,
  presion_arterial VARCHAR(10),
  frecuencia_cardiaca INT
);



-- Crear tabla tb_citas
CREATE TABLE tb_citas (
  id INT PRIMARY KEY,
  id_recepcionista INT,
  id_cliente INT,
  id_doctor INT,
  fecha DATE,
  fecha_hora DATETIME,
  duracion INT
);



-- Crear tabla tb_historial_clinico
CREATE TABLE tb_historial_clinico (
  id INT PRIMARY KEY,
  id_cliente INT,
  id_doctor INT,
  fecha_hora DATETIME,
  diagnostico VARCHAR(100),
  tratamiento VARCHAR(100)
);



-- Crear tabla tb_doctor
CREATE TABLE tb_doctor (
  id INT PRIMARY KEY,
  nombre VARCHAR(50),
  apellido_paterno VARCHAR(50),
  apellido_materno VARCHAR(50),
  dni INT,
  especialidad VARCHAR(50)
);

-- Crear tabla tb_recepcionista
CREATE TABLE tb_recepcionista (
  id INT PRIMARY KEY,
  nombre VARCHAR(50),
  apellido_paterno VARCHAR(50),
  apellido_materno VARCHAR(50),
  dni INT,
  numero_movil VARCHAR(20)
);

-- Agregar relaciones de clave foránea a tb_citas
ALTER TABLE tb_citas
ADD FOREIGN KEY (id_cliente) REFERENCES tb_clientes(id),
	FOREIGN KEY (id_doctor) REFERENCES tb_doctor(id);

-- Agregar relaciones de clave foránea a tb_triaje
ALTER TABLE tb_triaje
	ADD FOREIGN KEY (id_cliente) REFERENCES tb_clientes(id);

-- Agregar relaciones de clave foránea a tb_historial_clinico
ALTER TABLE tb_historial_clinico
ADD FOREIGN KEY (id_cliente) REFERENCES tb_clientes(id),
	FOREIGN KEY (id_doctor) REFERENCES tb_doctor(id);

 -- Agregar relaciones de clave foránea a tb_clientes
ALTER TABLE tb_clientes
	ADD FOREIGN KEY (id_recepcionista) REFERENCES tb_recepcionista(id);

 -- Agregar relaciones de clave foránea a tb_citas
ALTER TABLE tb_citas
	ADD FOREIGN KEY (id_recepcionista) REFERENCES tb_recepcionista(id);

GO


/*///////////////////////////////////////////////// */
/* ///////////////// PROCEDURES ////////////////// */
/*/////////////////////////////////////////////// */

SELECT * FROM tb_clientes;

GO

-- PROCEDURE LISTA CLIENTES (PACIENTES)
CREATE PROCEDURE clienteList
AS
SELECT * FROM tb_clientes
GO

CREATE PROCEDURE generar_id_cliente
AS
SELECT MAX(id + 1) FROM tb_clientes
GO

CREATE PROCEDURE add_cliente
  @id int,
  @id_recepcionista int,
  @nombre VARCHAR(50),
  @apellido_paterno VARCHAR(50),
  @apellido_materno VARCHAR(50),
  @dni INT,
  @sexo VARCHAR(1),
  @fecha_nacimiento DATE,
  @telefono VARCHAR(20),
  @numero_movil VARCHAR(13),
  @correo VARCHAR(50)
AS
INSERT INTO tb_clientes VALUES(@id,@id_recepcionista, @nombre, @apellido_paterno, @apellido_materno, @dni, @sexo, @fecha_nacimiento, @telefono, @numero_movil, @correo);
GO

CREATE PROCEDURE update_cliente
  @id int,
  @id_recepcionista int,
  @nombre VARCHAR(50),
  @apellido_paterno VARCHAR(50),
  @apellido_materno VARCHAR(50),
  @dni INT,
  @sexo VARCHAR(1),
  @fecha_nacimiento DATE,
  @telefono VARCHAR(20),
  @numero_movil VARCHAR(13),
  @correo VARCHAR(50)
AS
BEGIN
	UPDATE tb_clientes
		SET id_recepcionista = @id_recepcionista,
		nombre = @nombre,
		apellido_paterno = @apellido_paterno,
		apellido_materno = @apellido_materno,
		dni = @dni,
		sexo = @sexo,
		fecha_nacimiento = @fecha_nacimiento,
		telefono = @telefono,
		numero_movil = @numero_movil,
		correo = @correo
	WHERE id = @id
END

GO

CREATE PROCEDURE datele_cliente
@id varchar(3)
AS
 DELETE tb_clientes WHERE id=@id

GO


-- PROCEDURE LISTA TRIAjE
CREATE PROCEDURE triajeList
AS
SELECT * FROM tb_triaje
GO


-- PROCEDURE LISTA DE CITAS
CREATE PROCEDURE clitasList
AS
SELECT * FROM tb_citas
GO


-- PROCEDURE LISTA DE HISTORIAL CLINICO
CREATE PROCEDURE historialClinicoList
AS
SELECT * FROM tb_historial_clinico
GO


-- PROCEDURE LISTA DE DOCTOR
CREATE PROCEDURE doctorList
AS
SELECT * FROM tb_doctor
GO

CREATE PROCEDURE generar_id_doctor
AS
SELECT MAX(id + 1) FROM tb_doctor
GO

CREATE PROCEDURE add_doctor
  @id int,
  @nombre VARCHAR(50),
  @apellido_paterno VARCHAR(50),
  @apellido_materno VARCHAR(50),
  @dni INT,
  @especialidad VARCHAR(50)
AS
INSERT INTO tb_doctor VALUES(@id, @nombre, @apellido_paterno, @apellido_materno, @dni, @especialidad);
GO

CREATE PROCEDURE update_doctor
  @id int,
  @nombre VARCHAR(50),
  @apellido_paterno VARCHAR(50),
  @apellido_materno VARCHAR(50),
  @dni INT,
  @especialidad VARCHAR(50)
AS
BEGIN
	UPDATE tb_doctor
		SET nombre = @nombre,
		apellido_paterno = @apellido_paterno,
		apellido_materno = @apellido_materno,
		dni = @dni,
		especialidad = @especialidad
	WHERE id = @id
END

GO

CREATE PROCEDURE datele_doctor
@id varchar(3);
AS
 DELETE add_doctor WHERE id=@id;

GO


-- PROCEDURE LISTA DE RECEPCIONISTAS
CREATE PROCEDURE recepcionistaList
AS
SELECT * FROM tb_recepcionista
GO

CREATE PROCEDURE generar_id_recepcionista
AS
SELECT MAX(id + 1) FROM tb_recepcionista
GO

CREATE PROCEDURE add_recepcionista
  @id int,
  @nombre VARCHAR(50),
  @apellido_paterno VARCHAR(50),
  @apellido_materno VARCHAR(50),
  @dni INT,
  @numeromovil INT
AS
INSERT INTO tb_recepcionista VALUES(@id, @nombre, @apellido_paterno, @apellido_materno, @dni, @numeromovil);
GO

CREATE PROCEDURE update_recepcionista
  @id int,
  @nombre VARCHAR(50),
  @apellido_paterno VARCHAR(50),
  @apellido_materno VARCHAR(50),
  @dni INT,
  @numeromovil INT
AS
BEGIN
	UPDATE tb_recepcionista
		SET nombre = @nombre,
		apellido_paterno = @apellido_paterno,
		apellido_materno = @apellido_materno,
		dni = @dni,
		numero_movil = @numeromovil
	WHERE id = @id
END

GO

CREATE PROCEDURE datele_recepcionista
@id varchar(3)
AS
 DELETE add_recepcionista WHERE id=@id

GO

/*////////////////////////////////////////////////// */
/* /////////////////// INSER VALUE //////////////// */
/*////////////////////////////////////////////////// */

USE clinica_montefiori

INSERT INTO tb_recepcionista (id, nombre, apellido_paterno, apellido_materno, dni, numero_movil) VALUES 
(1, 'Laura', 'González', 'Pérez', 12345678, '123456789'),
(2, 'Carlos', 'Rodríguez', 'Martínez', 23456789, '234567890'),
(3, 'Ana', 'Fernández', 'García', 34567890, '345678901'),
(4, 'Sofía', 'López', 'Sánchez', 45678901, '456789012'),
(5, 'Javier', 'García', 'Pérez', 56789012, '567890123'),
(6, 'María', 'Martínez', 'Rodríguez', 67890123, '678901234'),
(7, 'Pedro', 'Sánchez', 'González', 78901234, '789012345'),
(8, 'Lucía', 'González', 'López', 89012345, '890123456'),
(9, 'Sara', 'Pérez', 'Martínez', 90123456, '901234567'),
(10, 'Alberto', 'Rodríguez', 'Fernández', 12345678, '123456789');

go

INSERT INTO tb_clientes (id, id_recepcionista, nombre, apellido_paterno, apellido_materno, dni, sexo, fecha_nacimiento, telefono, numero_movil, correo) VALUES 
(1, 1, 'María', 'García', 'Pérez', 12345678, 'F', '1990-05-10', '123456789', '1234567890123', 'maria.garcia@example.com'),
(2, 1, 'Juan', 'Rodríguez', 'Martínez', 23456789, 'M', '1985-10-15', '234567890', '2345678901234', 'juan.rodriguez@example.com'),
(3, 2, 'Laura', 'Fernández', 'González', 34567890, 'F', '1995-03-20', '345678901', '3456789012345', 'laura.fernandez@example.com'),
(4, 2, 'Pedro', 'González', 'Sánchez', 45678901, 'M', '1978-12-25', '456789012', '4567890123456', 'pedro.gonzalez@example.com'),
(5, 3, 'Sofía', 'Martínez', 'López', 56789012, 'F', '2000-01-01', '567890123', '5678901234567', 'sofia.martinez@example.com'),
(6, 3, 'Manuel', 'López', 'García', 67890123, 'M', '1992-06-30', '678901234', '6789012345678', 'manuel.lopez@example.com'),
(7, 4, 'Ana', 'Sánchez', 'Pérez', 78901234, 'F', '1980-08-08', '789012345', '7890123456789', 'ana.sanchez@example.com'),
(8, 4, 'Pablo', 'García', 'Martínez', 89012345, 'M', '1975-12-31', '890123456', '8901234567890', 'pablo.garcia@example.com'),
(9, 5, 'Lucía', 'Pérez', 'Rodríguez', 90123456, 'F', '1998-11-05', '901234567', '9012345678901', 'lucia.perez@example.com'),
(10, 5, 'Alberto', 'Rodríguez', 'Fernández', 12345678, 'M', '1983-04-25', '123456789', '1234567890123', 'alberto.rodriguez@example.com');

go


INSERT INTO tb_doctor (id, nombre, apellido_paterno, apellido_materno, dni, especialidad) VALUES 
(1, 'Juan', 'García', 'Pérez', 12345678, 'Cardiología'),
(2, 'María', 'Martínez', 'González', 23456789, 'Pediatría'),
(3, 'Carlos', 'Sánchez', 'Rodríguez', 34567890, 'Dermatología'),
(4, 'Ana', 'Fernández', 'López', 45678901, 'Oncología'),
(5, 'Javier', 'González', 'García', 56789012, 'Neurología'),
(6, 'Lucía', 'Pérez', 'Sánchez', 67890123, 'Psiquiatría'),
(7, 'Sara', 'Rodríguez', 'Martínez', 78901234, 'Oftalmología'),
(8, 'Pedro', 'López', 'Fernández', 89012345, 'Traumatología'),
(9, 'Marta', 'García', 'Pérez', 90123456, 'Ginecología'),
(10, 'Alberto', 'Martínez', 'González', 12345678, 'Urología');


go

INSERT INTO tb_historial_clinico (id, id_cliente, id_doctor, fecha_hora, diagnostico, tratamiento) VALUES 
(1, 1, 1, '2022-03-01 10:00:00', 'Dolor de cabeza', 'Paracetamol'),
(2, 2, 2, '2022-03-02 11:00:00', 'Gripe', 'Reposo'),
(3, 3, 3, '2022-03-03 12:00:00', 'Esguince de tobillo', 'Fisioterapia'),
(4, 4, 4, '2022-03-04 13:00:00', 'Fractura de brazo', 'Inmovilización'),
(5, 5, 5, '2022-03-05 14:00:00', 'Hipertensión', 'Medicación'),
(6, 6, 6, '2022-03-06 15:00:00', 'Diabetes', 'Dieta y medicación'),
(7, 7, 7, '2022-03-07 16:00:00', 'Infección de oído', 'Antibióticos'),
(8, 8, 8, '2022-03-08 17:00:00', 'Alergia', 'Antihistamínicos'),
(9, 9, 9, '2022-03-09 18:00:00', 'Bronquitis', 'Medicación y reposo'),
(10, 10, 10, '2022-03-10 19:00:00', 'Dolor de espalda', 'Ejercicios de estiramiento');

go

INSERT INTO tb_citas (id, id_recepcionista, id_cliente, id_doctor, fecha, fecha_hora, duracion) VALUES 
(1, 1, 1, 1, '2022-03-01', '2022-03-01 09:00:00', 60),
(2, 1, 2, 2, '2022-03-02', '2022-03-02 10:00:00', 60),
(3, 2, 3, 3, '2022-03-03', '2022-03-03 11:00:00', 60),
(4, 2, 4, 4, '2022-03-04', '2022-03-04 12:00:00', 60),
(5, 3, 5, 5, '2022-03-05', '2022-03-05 13:00:00', 60),
(6, 3, 6, 6, '2022-03-06', '2022-03-06 14:00:00', 60),
(7, 4, 7, 7, '2022-03-07', '2022-03-07 15:00:00', 60),
(8, 4, 8, 8, '2022-03-08', '2022-03-08 16:00:00', 60),
(9, 5, 9, 9, '2022-03-09', '2022-03-09 17:00:00', 60),
(10, 5, 10, 10, '2022-03-10', '2022-03-10 18:00:00', 60);


INSERT INTO tb_triaje (id, id_cliente, fecha, temperatura, peso, presion_arterial, frecuencia_cardiaca) VALUES 
(1, 1, '2022-02-15', 36.5, 70, '120/80', 80),
(2, 2, '2022-02-16', 37.0, 65, '115/70', 75),
(3, 3, '2022-02-17', 36.8, 80, '130/85', 82),
(4, 4, '2022-02-18', 37.2, 75, '125/80', 78),
(5, 5, '2022-02-19', 36.7, 70, '120/75', 80),
(6, 6, '2022-02-20', 37.3, 68, '115/70', 75),
(7, 7, '2022-02-21', 36.9, 82, '135/85', 82),
(8, 8, '2022-02-22', 37.1, 79, '130/80', 78),
(9, 9, '2022-02-23', 36.6, 73, '125/75', 80),
(10, 10, '2022-02-24', 37.0, 70, '120/70', 75);




USE BasePortLog

CREATE TABLE Usuario(
	Cedula VARCHAR(9) PRIMARY KEY,
	Passwrd VARCHAR(20) NOT NULL,
	Rol BIT NOT NULL
)

CREATE TABLE Cliente(
	RUT BIGINT PRIMARY KEY,
	FechaIngreso DATETIME
)
CREATE TABLE Producto(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(50),
	PesoUnidad FLOAT,
	RutCliente BIGINT REFERENCES Cliente(RUT)
)

CREATE TABLE Importacion(
	IDImportacion INT PRIMARY KEY IDENTITY(1,1),
	FechaIngreso DATETIME NOT NULL,
	FechaSalidaPrevista DATETIME NOT NULL,
	CantidadImportada INT NOT NULL CHECK(CantidadImportada >= 1),
	PrecioUnitarioProducto MONEY NOT NULL,
	ProductoImportado INT REFERENCES Producto(Id),
	IngresoImportacion VARCHAR(9) REFERENCES Usuario(Cedula)
)

--INSERT INTO table_name (column1, column2, column3, ...)
--VALUES (value1, value2, value3, ...);
SELECT * FROM Usuario WHERE Cedula='1547000-2';

INSERT INTO dbo.Usuario
(
    Cedula,
    Passwrd,
    Rol --Admin: 1, Almacen: 0
)
VALUES
(   '1',  -- Cedula - varchar(9)
	'1',  -- Passwrd - varchar(20)
    1 -- Rol - bit
),

(   '4877770-2',  -- Cedula - varchar(9)
	'Hola12345',  -- Passwrd - varchar(20)
    1 -- Rol - bit
),

(   '4877774-2',  -- Cedula - varchar(9)
	'Hola14231',  -- Passwrd - varchar(20)
    1 -- Rol - bit
),

(   '4547986-2',  -- Cedula - varchar(9)
	'Buenas45420',  -- Passwrd - varchar(20)
	0 -- Rol - bit
),


(   '3526748-2',  -- Cedula - varchar(9)
	'Jaime12345',  -- Passwrd - varchar(20)
    0 -- Rol - bit
),


(   '5147874-2',  -- Cedula - varchar(9)
	'Kakaroto45',  -- Passwrd - varchar(20)
    1 -- Rol - bit
),

(   '1235647-2',  -- Cedula - varchar(9)
	'12345T',  -- Passwrd - varchar(20)
    1 -- Rol - bit
);

INSERT INTO Cliente (RUT, FechaIngreso) 
VALUES
(	215544005500,
	'20140618 02:34:09 AM'),
(	221144775566,
	'20120418 10:55:09 PM'),
(	201346796431,
	'20110614 12:34:09 AM'),
(	231452364574,
	'20200611 10:34:09 AM'),	
(	216018252099,
	GETDATE())


INSERT INTO Producto (Nombre, PesoUnidad, RutCliente)
VALUES	('Cartas Magic', 500.0, 215544005500),
		('Pelotas de Basketball', 200.0, 221144775566),
		('Ropa para Deporte', 300.0, 201346796431),
		('Discos solidos', 450.0, 231452364574),
		('Tarjetas de Video', 335.0, 216018252099),
		('Cartas Yu Gi Oh!', 100.0, 221144775566),
		('Pelotas de Golf', 222.0, 221144775566),
		('Juegos de N64', 6511.0, 216018252099),
		('Monitores', 451.0, 231452364574),
		('Muñecas Inflables', 385.0, 231452364574)


INSERT INTO dbo.Importacion
(
    FechaIngreso,
    FechaSalidaPrevista,
    CantidadImportada,
    PrecioUnitarioProducto,
    ProductoImportado,
    IngresoImportacion
)
VALUES
(   
	'20090618 02:34:09 AM', -- FechaIngreso - datetime
    '20110416 01:34:50 AM', -- FechaSalidaPrevista - datetime
    50,         -- CantidadImportada - int
    20,      -- PrecioUnitarioProducto - money
    1,         -- ProductoImportado - int
    '4877770-2'         -- IngresoImportacion - varchar(9)
),
(   
	'20150618 10:20:04 AM', 
    '20180116 01:34:50 AM', 
    30,        
    80,     
    2,      
    '4877774-2'       
),
(   
	'20040102 10:20:04 AM', 
    '20050116 01:34:50 AM', 
    100,        
    10,     
    3,      
    '4547986-2'       
),
(   
	'20010618 10:20:04 AM', 
    '20200301 01:34:50 AM', 
    300,        
    39,     
    4,      
    '3526748-2'       
),
(   
	'20190614 10:20:04 AM', 
    '20200111 01:34:50 AM', 
    1000,        
    68,     
    5,      
    '1235647-2'       
)
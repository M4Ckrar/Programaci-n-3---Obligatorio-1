CREATE TABLE Importacion(
	IDImportacion INT PRIMARY KEY IDENTITY(1,1),
	FechaIngreso DATETIME NOT NULL,
	FechaSalidaPrevista DATETIME NOT NULL,
	CantidadImportada INT NOT NULL CHECK(CantidadImportada >= 1),
	PrecioUnitarioProducto MONEY NOT NULL,
	ProductoImportado INT REFERENCES Producto(Id),
	IngresoImportacion VARCHAR(9) REFERENCES Usuario(Cedula)
	--Precio_Prod MONEY CHECK(Precio_Prod <> 0)
)

CREATE TABLE Usuario(
	Cedula VARCHAR(9) PRIMARY KEY NOT NULL,
	Passwrd VARCHAR(20) NOT NULL,
	Rol BIT NOT NULL
)

CREATE TABLE Cliente(
	RUT INT NOT NULL PRIMARY KEY,
	FechaIngreso DATETIME

)

CREATE TABLE Producto(
	
)
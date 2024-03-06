CREATE DATABASE RestauranteDB
GO

USE RestauranteDB
GO

CREATE TABLE Pedido (
    PedidoId INT PRIMARY KEY IDENTITY,
    NomeSolicitante VARCHAR(100),
    Mesa INT
)
GO

CREATE TABLE ItensPedido (
    ItemId INT PRIMARY KEY IDENTITY,
    PedidoId INT,
    Prato VARCHAR(100),
    Bebida VARCHAR(100),
    Quantidade INT,
    FOREIGN KEY (PedidoId) REFERENCES Pedido(PedidoId)
)
GO


 SELECT * FROM Pedido
 SELECT * FROM ItensPedido

-- TRUNCATE TABLE Pedido
-- TRUNCATE TABLE ItensPedido


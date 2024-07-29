CREATE TABLE IF NOT EXISTS Products (
    Id INT GENERATED ALWAYS AS IDENTITY
    Name VARCHAR(255) NOT NULL DEFAULT ""
    Description VARCHAR(255) NOT NULL DEFAULT ""
    Price INT NOT NULL DEFAULT 0
    PRIMARY KEY(Id)
);

CREATE TABLE IF NOT EXISTS Orders (
    Id INT PRIMARY KEY
    ProductId INT NOT NULL DEFAULT ""
    IsShipped BOOLEAN NOT NULL DEFAULT
    CONSTRAINT fk_product
        FOREIGN KEY(ProductId) 
            REFERENCES Products(Id) 
);

INSERT INTO Products (Id, Name, Description, Price)
VALUES (1, "Basketball", "A ball used to play the game of baskeball", 10), 
       (2, "Football", "A ball used to play the game of football", 12),
       (3, "Tennis Ball", "A ball used to play the game of tennis", 4)
ON CONFLICT (Id) DO NOTHING;
CREATE TABLE Products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(255) NOT NULL,
    category_id INT,
    price DECIMAL(10, 2) NOT NULL,
    description TEXT,
    image_url VARCHAR(255),
    date_added VARCHAR(50),
    FOREIGN KEY (category_id) REFERENCES Categories(category_id)
);

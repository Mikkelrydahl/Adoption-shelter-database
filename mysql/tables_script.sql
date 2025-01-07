DROP DATABASE IF EXISTS animalshelter;
CREATE DATABASE animalshelter;
USE animalshelter;
CREATE TABLE employees (
    employee_id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    first_name VARCHAR(255) NOT NULL,
    last_name VARCHAR(255),
    email VARCHAR(255) NOT NULL UNIQUE
);
CREATE TABLE species (
    species_id INT PRIMARY KEY NOT NULL,
    species_name VARCHAR(255) NOT NULL
);
CREATE TABLE breeds (
    breed_id INT PRIMARY KEY NOT NULL,
    breed_name VARCHAR(255) NOT NULL
);
CREATE TABLE animal (
    id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    pet_name VARCHAR(255) NOT NULL,
    age INT,
    species INT,
    breed INT,
    CONSTRAINT fk_species FOREIGN KEY (species) REFERENCES species(species_id) ON DELETE
    SET NULL,
        CONSTRAINT fk_breed FOREIGN KEY (breed) REFERENCES breeds(breed_id) ON DELETE
    SET NULL
);
CREATE TABLE medical_appointment (
    id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    animal_id INT,
    employee_id INT,
    start_time DATETIME,
    appointment_description VARCHAR(255),
    is_completed BOOL DEFAULT FALSE,
    CONSTRAINT fk_animal FOREIGN KEY (animal_id) REFERENCES animal(id) ON DELETE CASCADE,
    CONSTRAINT fk_employee FOREIGN KEY (employee_id) REFERENCES employees(employee_id) ON DELETE CASCADE
);
CREATE TABLE medical_records (
    id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    appointment_description VARCHAR(255),
    animal_id INT,
    employee_id INT,
    CONSTRAINT fk_animal2 FOREIGN KEY (animal_id) REFERENCES animal(id) ON DELETE CASCADE,
    CONSTRAINT fk_employee2 FOREIGN KEY (employee_id) REFERENCES employees(employee_id) ON DELETE CASCADE
);
DELIMITER // CREATE TRIGGER add_medical_record
AFTER
UPDATE ON medical_appointment FOR EACH ROW BEGIN IF NEW.is_completed = TRUE THEN
INSERT INTO medical_records(appointment_description, animal_id, employee_id)
VALUES (
        NEW.appointment_description,
        NEW.animal_id,
        NEW.employee_id
    );
DELETE FROM medical_appointment
WHERE id = NEW.id;
END IF;
END // DELIMITER;
CREATE TABLE categories (
    id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    category_name VARCHAR(255) NOT NULL UNIQUE
);
CREATE TABLE products (
    id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    product_name VARCHAR(255),
    price decimal(10, 2),
    category INT,
    description VARCHAR(255),
    CONSTRAINT fk_category FOREIGN KEY (category) REFERENCES categories(id)
);
CREATE TABLE orders (
    id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    email VARCHAR(255) NOT NULL,
    is_completed BOOL DEFAULT FALSE
);
CREATE TABLE order_details (
    order_id INT NOT NULL,
    product_id INT NOT NULL,
    quantity INT NOT NULL,
    CONSTRAINT fk_order FOREIGN KEY (order_id) REFERENCES orders(id) ON DELETE CASCADE,
    CONSTRAINT fk_product FOREIGN KEY (product_id) REFERENCES products(id) ON DELETE CASCADE
);
CREATE TABLE transactions (
    id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    email VARCHAR(255),
    bankinfo INT NOT NULL,
    total_price decimal(10, 2),
    transaction_time DATETIME
);
CREATE VIEW product_view AS
SELECT p.id AS product_id,
    p.product_name AS product_name,
    p.price AS product_price,
    c.category_name AS category_name,
    p.description AS product_description
FROM products p
    JOIN categories c ON p.category = c.id;
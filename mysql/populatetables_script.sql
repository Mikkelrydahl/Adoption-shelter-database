INSERT INTO species (species_id, species_name) VALUES
(1, 'Dog'),
(2, 'Cat'),
(3, 'Rabbit');

INSERT INTO breeds (breed_id, breed_name) VALUES
(1, 'Golden Retriever'),
(2, 'Persian Cat'),
(3, 'Lop Rabbit'),
(4, 'Bulldog'),
(5, 'Siamese Cat');

INSERT INTO employees (first_name, last_name, email) VALUES
('John', 'Doe', 'john.doe@example.com'),
('Jane', 'Smith', 'jane.smith@example.com'),
('Alice', 'Brown', 'alice.brown@example.com');

INSERT INTO animal (pet_name, age, species, breed) VALUES
('Buddy', 3, 1, 1),
('Mittens', 2, 2, 2),
('Thumper', 1, 3, 3),
('Max', 5, 1, 4),
('Whiskers', 4, 2, 5),
('Snowball', 1, 3, 3),
('Bella', 3, 1, 1);

INSERT INTO medical_appointment (animal_id, employee_id, start_time, appointment_description) VALUES
(1, 1, '2025-01-07 10:00:00', 'Routine checkup for Buddy'),
(2, 2, '2025-01-08 11:00:00', 'Vaccination for Mittens'),
(3, 3, '2025-01-09 12:00:00', 'Health assessment for Thumper'),
(1, 1, '2025-01-10 15:00:00', 'Dental cleaning for Buddy'),
(5, 2, '2025-01-11 13:00:00', 'Vaccination for Whiskers'),
(4, 3, '2025-01-12 09:00:00', 'Ear infection treatment for Max');

INSERT INTO categories (category_name) VALUES
('Food'),
('Toys'),
('Accessories');

INSERT INTO products (product_name, price, category, description) VALUES
('Dog Food', 20.99, 1, 'Nutritious food for dogs'),
('Cat Toy', 10.99, 2, 'Interactive toy for cats'),
('Rabbit Hutch', 120.50, 3, 'Comfortable home for rabbits');

INSERT INTO orders (email, is_completed) VALUES
('customer1@example.com', FALSE),
('customer2@example.com', TRUE);

INSERT INTO order_details (order_id, product_id, quantity) VALUES
(1, 1, 2),
(1, 2, 1),
(2, 3, 1);
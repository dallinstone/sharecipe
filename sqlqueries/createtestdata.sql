insert into users VALUES 
("testuser", "dallin.stone@outlook.com", "dallinstone", "testpassword");

insert into recipes (title, description, user_id) VALUES 
("Test Recipe Name", "This is a recipe for testing", "testuser");

insert into ingredients (name) VALUES 
("Test Ingredient 1"),
("Test Ingredient 2"),
("Test Ingredient 3");

insert into recipe_ingredient (ordered, recipe_id, ingredient_id, measurement) VALUES 
(1, 1, 1, "Tsp"),
(2, 1, 2, "spoonfuls"),
(3, 1, 3, "some measurement");

insert into recipe_step (recipe_id, step, step_text) VALUES 
(1, 1, "Step 1 text"),
(1, 2, "Step 2 text"),
(1, 3, "Step 3 text"),
(1, 4, "Step 4 text");
CREATE TABLE users
(
  user_id varchar(100),
  email varchar(100) not null,
  username varchar(50) not null,
  password varchar(1000) not null,
  PRIMARY KEY(user_id)
);

CREATE TABLE recipes
(
  recipe_id int not null auto_increment,
  title varchar(50) not null,
  description varchar(200) not null,
  user_id varchar(100) not null,
  approved tinyint DEFAULT 1,
  PRIMARY KEY (recipe_id),
  CONSTRAINT FOREIGN KEY (user_id) REFERENCES users(user_id)
);

CREATE TABLE ingredients
(
  ingredient_id int not null auto_increment,
  name varchar(100) not null,
  approved tinyint DEFAULT 1,
  PRIMARY KEY(ingredient_id)
);

CREATE TABLE recipe_ingredient
(
  recipe_ingredient_id int auto_increment,
  ordered int not null,
	recipe_id int not null,
  ingredient_id int not null,
  measurement varchar(30) not null,
  approved boolean DEFAULT true,
  PRIMARY KEY(recipe_ingredient_id),
  CONSTRAINT FOREIGN KEY (recipe_id) REFERENCES recipes(recipe_id),
  CONSTRAINT FOREIGN KEY (ingredient_id) REFERENCES ingredients(ingredient_id)
);

CREATE TABLE recipe_step
(
  recipe_step_id int auto_increment,
  recipe_id int not null,
  step int not null,
  step_text varchar(1000) not null,
  PRIMARY KEY(recipe_step_id, recipe_id, step),
  UNIQUE KEY(recipe_id, step),
  CONSTRAINT FOREIGN KEY (recipe_id) REFERENCES recipes(recipe_id)
);
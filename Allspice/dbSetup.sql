CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';


CREATE TABLE recipes(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  title VARCHAR(255) NOT NULL,
  instructions VARCHAR(500) NOT NULL,
  img VARCHAR(500) NOT NULL,
  category VARCHAR(250) NOT NULL,
  creatorId VARCHAR(255) NOT NULL
) default charset utf8 COMMENT '';

CREATE TABLE ingredients
(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  name VARCHAR(255) NOT NULL,
  quantity VARCHAR(25) NOT NULL,
  recipeId INT NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE,
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

CREATE TABLE favorites
(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  accountId VARCHAR(255) NOT NULL,
  recipeId INT NOT NULL,
  FOREIGN KEY (accountId) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';


      INSERT INTO favorites (accountId, recipeId)
      VALUES ("64adb61337a3dfb233a73217", 23);
      SELECT LAST_INSERT_ID()

      SELECT * FROM favorites WHERE id = 1;

      DROP TABLE favorites;
      DROP TABLE ingredients;


      DROP TABLE recipes;

DROP TABLE recipes;

        UPDATE recipes
        SET
        title = "test",
        instructions = "Instructions",
        img = "Img",
        category = "Category"
        WHERE id = 2
        LIMIT 1; SELECT * FROM recipes WHERE id = 2



          UPDATE recipes
        SET
        title = @Title,
        instructions = @Instructions,
        img = @Img,
        category = @Category
        WHERE id = @Id
        LIMIT 1;
        SELECT
        r.*,
        acc.*
        FROM recipes r WHERE id = @Id
        JOIN accounts acc ON acc.id = r.creatorId
        ;
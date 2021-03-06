-- MySQL Script generated by MySQL Workbench
-- Fri Jul  3 15:02:00 2020
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema Drinks
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema Drinks
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `Drinks` ;
USE `Drinks` ;

-- -----------------------------------------------------
-- Table `Drinks`.`Drink`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Drinks`.`Drink` (
  `id` TINYINT(3) UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `glass_type` VARCHAR(45) NOT NULL,
  `prepare_time` DOUBLE NOT NULL,
  `instruction` VARCHAR(300) NULL,
  `temperature` ENUM("chilled", "room temperature", "warm") NOT NULL,
  `taste` ENUM("sweet", "sour", "bitter", "bitter-sweet", "coffee-like", "dry", "aromatic", "fruity", "citrus", "spicy", "herbal", "tangy", "savory", "rooty", "creamy") NOT NULL,
  `strength` ENUM("light", "medium", "high") NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Drinks`.`Tool`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Drinks`.`Tool` (
  `id_Tools` TINYINT(3) UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NULL,
  PRIMARY KEY (`id_Tools`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Drinks`.`Ingredient`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Drinks`.`Ingredient` (
  `id_Ingredient` TINYINT(3) UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NULL,
  `typeof` ENUM("spirit", "whisky", "liqueur", "beer&cider", "wine&champagne&vermouth", "soft-drinks", "juice", "fruit", "vegetable", "seasoning", "miscellaneous", "dairy") NULL,
  `taste` ENUM("sweet", "sour", "bitter", "bitter-sweet", "coffee-like", "dry", "crisp", "aromatic", "neutral", "fruity", "citrus", "spicy", "chocolatey", "floral", "herbal", "milky", "tangy", "alcoholic", "savory", "rooty", "creamy") NULL,
  `unit` VARCHAR(10) NULL,
  PRIMARY KEY (`id_Ingredient`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Drinks`.`Users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Drinks`.`Users` (
  `id_Users` TINYINT(3) UNSIGNED NOT NULL AUTO_INCREMENT,
  `Login` VARCHAR(45) NOT NULL,
  `Password` VARCHAR(45) NULL,
  PRIMARY KEY (`id_Users`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Drinks`.`Favorite`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Drinks`.`Favorite` (
  `id_Users` TINYINT(3) UNSIGNED NOT NULL,
  `id_Drink` TINYINT(3) UNSIGNED NOT NULL,
  INDEX `Users_idx` (`id_Users` ASC),
  INDEX `drink_idx` (`id_Drink` ASC),
  CONSTRAINT `user`
    FOREIGN KEY (`id_Users`)
    REFERENCES `Drinks`.`Users` (`id_Users`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `lubi`
    FOREIGN KEY (`id_Drink`)
    REFERENCES `Drinks`.`Drink` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Drinks`.`Recipe`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Drinks`.`Recipe` (
  `id_Drink` TINYINT(3) UNSIGNED NOT NULL,
  `id_Ingredient` TINYINT(3) UNSIGNED NOT NULL,
  `amount` VARCHAR(20) NULL,
  INDEX `id_Ingredient_idx` (`id_Ingredient` ASC),
  INDEX `id_Drink_idx` (`id_Drink` ASC),
  CONSTRAINT `contains`
    FOREIGN KEY (`id_Ingredient`)
    REFERENCES `Drinks`.`Ingredient` (`id_Ingredient`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `drink`
    FOREIGN KEY (`id_Drink`)
    REFERENCES `Drinks`.`Drink` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Drinks`.`DrinkTools`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Drinks`.`DrinkTools` (
  `id_Drink` TINYINT(3) UNSIGNED NULL,
  `id_Tool` TINYINT(3) UNSIGNED NULL,
  INDEX `drink_idx` (`id_Drink` ASC),
  INDEX `is_made_with_idx` (`id_Tool` ASC),
  CONSTRAINT `is_made_with`
    FOREIGN KEY (`id_Tool`)
    REFERENCES `Drinks`.`Tool` (`id_Tools`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `the_drink`
    FOREIGN KEY (`id_Drink`)
    REFERENCES `Drinks`.`Drink` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

-- -----------------------------------------------------
-- Data for table `Drinks`.`Drink`
-- -----------------------------------------------------
START TRANSACTION;
USE `Drinks`;
INSERT INTO `Drinks`.`Drink` (`id`, `name`, `glass_type`, `prepare_time`, `instruction`, `temperature`, `taste`, `strength`) VALUES 
(1, 'Mojito', 'tall', 10, 'Cut lime in half. Add sugar and mint to glass, Squeeze them, then add rest of ingredients.', 'chilled', 'sour', 'medium'),
(2, 'Absolut Cosmopolitan', '80 ml martini glass', 5, 'Squeeze lime. Mix ingredients with ice using shaker and strain into a glass.', 'chilled', 'sour', 'high'),
(3, 'Absolut Iceberg', '285 ml highball glass', 5, 'Pour Absolut Citron and Triple Sec onto ice, and fill with Bitter Lemon.', 'chilled', 'citrus', 'high'),
(4, 'B&B', 'brandy glass', 1, 'Pour ingredients to glass. Do not add ice.', 'room temperature', 'savory', 'high'),
(5, 'Banana Colada', '300 ml cocktail glass', 10, 'Mix ingredients with ice and pour into glass.', 'chilled', 'fruity', 'medium'),
(6, 'Banana Daiquiri', '140 ml flat champagne glass', 10, 'Mix ingredients with ice and pour into glass through strainer.', 'chilled', 'sweet', 'medium'),
(7, 'Bananarama', '140 ml cocktail glass', 10, 'Mix ingredients with ice and pour into glass.', 'chilled', 'sweet', 'high'),
(8, 'Between The Sheets', '140 ml flat champagne glass', 10, 'Mix ingredients with ice using shaker and strain into a glass', 'chilled', 'sour', 'medium'),
(9, 'Black Opal', '90 ml cocktail glass', 5, 'Pour Sambuca and Cointreau into glass, set on fire, extinguish the burning ingredients by pouring Baileys and cream.', 'room temperature', 'savory', 'medium'),
(10, 'Black Russian', '210 ml old fashioned glass', 1, 'Pour ingredients into glass filled with ice.', 'chilled', 'coffee-like', 'high'),
(11, 'Bloody Mary', '285 ml highball glass', 5, 'Mix ingredients with ice and pour into glass through strainer', 'chilled', 'tangy', 'medium'),
(12, 'Blue Bayou', '285 ml highball glass', 5, 'Mix ingredients with ice using shaker and pour into glass', 'chilled', 'bitter-sweet', 'medium'),
(13, 'Blueberry Delight', '140 ml cocktail glass', 10, 'Mix ingredients with ice using shaker and strain into a glass', 'chilled', 'fruity', 'high'),
(14, 'Blue French', '285 ml highball glass', 5, 'Pour ingredients into glass filled with ice, stirr.', 'chilled', 'bitter', 'medium'),
(15, 'Blue Hawaii', '285 ml highball glass', 5, 'Mix ingredients with ice, pour into glass.', 'chilled', 'aromatic', 'medium'),
(16, 'Bosom Caresser', '140 ml flat champagne glass', 5, 'Mix ingredients with ice using shaker and pour into glass through strainer', 'chilled', 'aromatic', 'medium'),
(17, 'Cafe Nero', '140 ml flat champagne glass', 5, 'Pour ingredients into glass, do not add ice.', 'room temperature', 'coffee-like', 'medium'),
(18, 'Cherries Jubilee', '140 ml cocktail glass', 5, 'Mix ingredients with ice using shaker and strain into a glass.', 'chilled', 'creamy', 'medium'),
(19, 'Chivas Manhattan', '90 ml cocktail glass', 10, 'Put ice cubes inside mixer cup, pour whisky and vermouth. Mix and set orange peel on fire, add into drink.', 'chilled', 'dry', 'high'),
(20, 'Chivas Royale', 'champagne flute', 2, 'Fill half glass with ice. Add rest of ingredients.', 'chilled', 'dry', 'high'),
(21, 'Daiquiri', '140 ml flat champagne glass', 5, 'Mix ingredients with ice using shaker and pour into glass through strainer.', 'chilled', 'bitter-sweet', 'high'),
(22, 'Death In The Afternoon', '140 ml wine glass', 1, 'Pour ingredients into glass, do not add ice.', 'room temperature', 'herbal', 'medium'),
(23, 'Depth Charge', '425 ml beer glass', 1, 'Pour ingredients into glass, do not add ice.', 'room temperature', 'rooty', 'medium'),
(24, 'Double Jeopardy', '285 ml highball glass', 5, 'Mix ingredients with ice, stirr and pour into glass.', 'chilled', 'creamy', 'high'),
(25, 'Evergreen', '90 ml cocktail glass', 5, 'Mix ingredients with ice using shaker and strain into a glass', 'chilled', 'tangy', 'high'),
(26, 'Fallen Angel', '285 ml highball glass', 5, 'Pour ingredients into glass filled with ice, stirr.', 'chilled', 'sour', 'high'),
(27, 'Fluffy Duck No1', '285 ml highball glass', 2, 'Pour ingredients into glass filled with ice.', 'chilled', 'creamy', 'medium'),
(28, 'Fluffy Duck No2', '140 ml flat champagne glass', 5, 'Mix ingredients with ice using shaker and pour into glass through strainer.', 'chilled', 'creamy', 'medium'),
(29, 'Frappe', 'Irish Coffee glass', 1, 'Pour ingredients into glass.', 'room temperature', 'coffee-like', 'light'),
(30, 'Freddy-Fud-Pucker', '285 ml highball glass', 1, 'Pour ingredients into glass.', 'chilled', 'spicy', 'high'),
(31, 'French Fantasy', '140 ml cocktail glass', 5, 'Mix ingredients with ice using shaker and strain into a glass.', 'chilled', 'fruity', 'high'),
(32, 'God Daughter', '140 ml flat champagne glass', 5, 'Mix ingredients with ice using shaker and strain into a glass.', 'chilled', 'bitter', 'high'),
(33, 'God Father', '185 ml old fashioned glass', 5, 'Pour ingredients into glass filled with ice.', 'chilled', 'bitter', 'high'),
(34, 'Golden Cadillac', '140 ml coctail glass', 10, 'Mix ingredients with ice using shaker and strain into a glass.','chilled', 'creamy', 'high'),
(35, 'Golden Dream', '140 ml coctail glass', 10, 'Mix ingredients with ice using shaker and strain into a glass.', 'chilled', 'citrus', 'high'),
(36, 'Gomango', '440 ml hurricane glass', 10, 'Mix ingredients with ice.', 'chilled', 'fruity', 'medium'),
(37, 'G.R.B', '90 ml coctail glass', 1, 'Pour ingredients into glass.', 'chilled', 'herbal',  'high'),
(38, 'Green With Envy', '210 ml hurricane glass', 10, 'Mix ingredients with ice using shaker and strain into a glass.', 'chilled', 'fruity', 'high'),
(39, 'Harvy Wallbanger', '285 ml highball glass', 2, 'Pour ingredients into glass filled with ice.', 'chilled', 'citrus', 'high'),
(40, 'Irish Coffee', '250 ml Irish Coffee glass', 2, 'Pour ingredients into glass.', 'warm', 'coffee-like', 'light'),
(41, 'Japanese Slipper', '90 ml cocktail glass', 10, 'Mix with ice using shaker and strain into a glass.', 'chilled', 'fruity', 'medium'),
(42, 'Jelly Bean', '285 ml highball glass', 2, 'Pour ingredients into glass.', 'chilled', 'bitter-sweet', 'high'),
(43, 'Kamikaze', '140 ml cocktail glass', 10, 'Mix with ice using shaker and strain into a glass.', 'chilled', 'citrus', 'high'),
(44, 'K.G.B', '185 ml old fashioned glass', 1, 'Pour ingredients into glass.', 'chilled','aromatic', 'medium'),
(45, 'Kick In The Balls', '140 ml flat champagne glass', 10, 'Mix with ice using shaker and strain into a glass.', 'chilled', 'fruity', 'high'),
(46, 'Kir', '140 ml wine glass', 1, 'Pour ingredients into glass. Do not add ice.', 'room temperature', 'dry', 'medium'),
(47, 'Lady M', '285 hurricane glass', 5, 'Mix ingredients, pour into glass.', 'chilled', 'sweet', 'medium'),
(48, 'Lamborghini', '90 cocktail glass', 2, 'Pour ingredients into glass without ice.', 'chilled', 'creamy', 'high'),
(49, 'Long Island Tea', '285 highball glass', 5, 'Pour ingredients into glass filled with ice.', 'chilled', 'herbal', 'high'),
(50, 'Madame Butterfly', '140 ml margarita glass', 10, 'Mix ingredients with ice using shaker and strain into a glass.', 'chilled', 'fruity', 'medium'),
(51, 'Mai-Tai', '285 ml highball glass', 5, 'Mix ingredients with ice using shaker and pour into a glass', 'chilled', 'citrus', 'medium'),
(52, 'Malibu Magic', '285 ml hurricane glass', 5, 'Mix ingredients with ice using shaker and pour into a glass', 'chilled', 'fruity', 'medium'),
(53, 'Margarita', '140 ml Margarita glass', 10, 'Mix ingredients with ice using shaker and strain into a glass', 'chilled', 'spicy', 'medium'),
(54, 'Martini', '90 ml cocktail glass', 5, 'Mix ingredients with ice and strain into a glass', 'chilled', 'dry', 'medium'),
(55, 'Melon Avalanche', '285 ml hurricane glass', 5, 'Pour Blue Curacao into glass. Mix rest of the ingredients with ice, and fillup the glass.', 'chilled', 'fruity', 'high'),
(56, 'Moscow Mule', '285 ml highball glass', 2, 'Pour ingredients into glass filled with ice.', 'chilled', 'rooty', 'high'),
(57, 'Mount Temple', '90 ml cocktail glass', 2, 'Pour ingredients into glass filled with ice.', 'chilled', 'spicy', 'high'),
(58, 'Old Fashioned - Scotch', '285 ml old fashioned glass', 2, 'Pour ingredients into glass filled with ice.', 'chilled', 'bitter', 'high'),
(59, 'Ole', '90 ml cocktail glass', 2, 'Mix with ice, strain into glass.', 'chilled', 'spicy', 'high'),
(60, 'Pimms No1 Cup', '285 ml highball glass', 2, 'Pour ingredients into glass filled with ice.', 'chilled', 'rooty', 'high'),
(61, 'Pina Colada', '285 ml highball glass', 2, 'Mix ingredients with ice using shaker and strain into a glass.', 'chilled', 'sweet', 'medium'),
(62, 'Pink Panther', '140 ml flat champagne glass', 10, 'Mix ingredients with ice using shaker and strain into a glass.', 'chilled', 'sweet', 'medium'),
(63, 'Praire Oyster', '90 ml cocktail glass', 1, 'Pour ingredients into glass. Do not add ice.', 'room temperature', 'spicy', 'medium'),
(64, 'Pretty Woman', '285 ml hurricane glass', 10, 'Mix strawberry liqueur with strawberries, mix rest of ingredients in diffrent bowl. Pour into glass.', 'chilled', 'fruity', 'high'),
(65, 'Raffles Singapore Sling', '285 ml highball glass', 10, 'Mix ingredients with ice using shaker and strain into a glass.', 'chilled', 'fruity', 'high'),
(66, 'Rocket Fuel', '210 ml old fashioned glass', 5, 'Pour ingredients into glass filled with ice.', 'chilled', 'dry', 'high'),
(67, 'Rusty Nail', '210 ml old fashioned glass', 5, 'Pour ingredients into glass filled with ice.', 'chilled', 'dry', 'high'),
(68, 'Salty Dog', '1285 ml highball glass', 10, 'Pour ingredients into glass filled with ice.', 'chilled', 'citrus', 'high'),
(69, 'Satin Pillow', '140 ml cocktail glass', 5, 'Mix ingredients with ice and pour into glass.', 'chilled', 'savory', 'high'),
(70, 'Screwdriver', '210 ml old fashioned glass', 2, 'Pour ingredients into glass filled with ice.', 'chilled', 'citrus', 'high'),
(71, 'Sex On The Beach', '210 cocktail glass', 10, 'Mix with ice using shaker and strain into a glass.', 'chilled', 'fruity', 'medium'),
(72, 'Sidecar', '90 ml cocktail glass', 10, 'Mix with ice using shaker and strain into a glass.', 'chilled', 'citrus', 'high'),
(73, 'Snowball', '285 ml highball glass', 2, 'Pour ingredients into glass filled with ice.', 'chilled', 'creamy', 'high'),
(74, 'Southern Peach', '140 ml martini glass', 10, 'Mix with ice using shaker and strain into a glass.', 'chilled', 'fruity', 'high'),
(75, 'South Pacific', '285 ml highball glass', 10, 'Pour ingredients onto ice, add Blue Curacao as last.', 'chilled', 'bitter', 'high'),
(76, 'Splice', '210 ml hurricane glass', 3, 'Mix with ice, pour into glass.', 'chilled', 'fruity', 'high'),
(77, 'Spritzer', '185  mlwine glass', 3, 'Pour into glass, do not add ice.', 'chilled', 'dry', 'medium'),
(78, 'Stars&Stripes', '300 ml cocktail glass', 10, 'Add Blue Curacao, mix rest of ingredients in another bowl and add to the drink.', 'chilled', 'fruity', 'high'),
(79, 'Stinger', '90 ml cocktail glass', 5, 'Mix ingredients with ice using mixer cup, then strain into glass.', 'chilled', 'herbal', 'high'),
(80, 'Strawberry Blonde', '285 ml highball glass', 2, 'Pour ingredients into glass filled with ice.', 'chilled', 'sweet', 'medium'),
(81, 'Summer Breeze', '300 ml cocktail glass', 5, 'Mix with ice and pour into glass.', 'chilled', 'fruity', 'medium'),
(82, 'Sunken Treasure', '90 ml cocktail glass', 10, 'Mix with ice using mixer cup, strain into glass, fillup with champagne.', 'chilled', 'dry', 'high'),
(83, 'Sweet Lady Jane', '140 ml flat champagne glass', 10, 'Mix with ice using shaker, strain into glass.', 'chilled', 'citrus', 'high'),
(84, 'Sweet Martini', '90 ml coctail glass', 2, 'Mix with ice, strain into glass.', 'chilled', 'dry', 'high'),
(85, 'Tequilla Slammer', '185 ml old fashioned glass', 2, 'Pour into glass without ice.', 'chilled', 'rooty', 'high'),
(86, 'Tequilla Sunrise', '285 ml highball glass', 2, 'Pour into glass filled with ice.', 'chilled', 'spicy', 'high'),
(87, 'The Dik Hewett', '140 ml coctail glass', 10, 'Mix with ice using shaker, strain into glass.', 'chilled', 'aromatic', 'high'),
(88, 'T.N.T', '90 ml coctail glass', 10, 'Mix with ice, strain into glass.', 'chilled', 'aromatic', 'medium'),
(89, 'Toblerone', '140 ml coctail glass', 2, 'Mix with ice, pour into glass.', 'chilled', 'creamy', 'medium'),
(90, 'Tropical Itch', '425 ml hurricane glass', 2, 'Pour into glass filled with ice.', 'chilled', 'bitter-sweet', 'high'),
(91, 'Voodoo Child', '90 ml cocktail glass', 2, 'Add Sambuca, next melon liqueur. Rest of ingredients mix with ice using shaker and strain into glass.', 'chilled', 'rooty', 'high'),
(92, 'Apple Pie', '250 ml Irish Coffee glass', 10, 'Pour brandy into glass, fill with hot apple cider, top with  whipped cream and cinnamon.', 'warm', 'spicy', 'light'),
(93, 'Buttered Whiskey', 'mug', 70, 'Mix everything except whiskey and water, wrap batter and refrigerate for 1h. Slice some, add to mug, add whiskey and hot water.', 'warm', 'creamy', 'light'),
(94, 'Milk&Honey', 'mug', 10, 'Pour Benedictine into mug, add ice cubes, top with cold milk. Stirr well.', 'chilled', 'creamy', 'light'),
(95, 'Cafe Brasileiro', '250 ml Irish Coffee glass', 15, 'Mix vanilla and heavy cream using shaker, mix rest of ingredients. Add vanilla cream on top.', 'warm', 'coffee-like', 'light'),
(96, 'Rumchata Eggnog', 'mug', 40, 'Moisten glass rim and dip it in mixed cinnamon and sugar. Whisk egg yolks and sugar add rest of ingredients. Cook for 10 min. Stirr in heavy cream and Rumchata. Refrigerate. Pour into glass. Sprinkle with nutmeg.', 'room temperature', 'creamy', 'light'),
(97, 'Mulled Wine', 'mug', 20, 'Combine all ingredients in saucepan over medium heat. Do not boil. Simmer over low heat for 10 min.', 'warm', 'rooty', 'light'),
(98, 'Hot Toddy', 'mug', 10, 'Bring water to simmer. Combine bourbon, honey , lemon to a mug. Pour over hot water and stir. Garnish with cinnamon and lemon.', 'warm', 'rooty', 'light'),
(99, 'Hot Kahlua', 'mug', 10, 'Warm whole milk and heavy cream. Add candy cane, stir until melted. Stir in chocolate and vanilla. Remove from heat, stir in Kahlua and pour into glass.', 'warm', 'aromatic', 'light'),
(100, 'Brandy Alexander', '140 ml flat champagne glass', 5, 'Mix ingredients with ice using shaker and pour into glass through strainer', 'chilled', 'rooty', 'medium'),
(101, 'Aperol Spritz', 'standard glass', 5, 'Pour Prosecco into glass with ice, then Aperol, and fill with chilled sparkling water.', 'chilled', 'sweet', 'high');

COMMIT;


-- -----------------------------------------------------
-- Data for table `Drinks`.`Tool`
-- -----------------------------------------------------
START TRANSACTION;
USE `Drinks`;
INSERT INTO `Drinks`.`Tool` (`id_Tools`, `name`) VALUES (1, 'squeezer'),
(2, 'shaker'),
(3, 'strainer'),
(4, 'mixer cup'),
(5, 'cutting board'),
(6, 'can opener'),
(7, 'corkscrew'),
(8, 'stirrer'),
(9, 'spoon'),
(10, 'mixer'),
(11, 'mixing bowl');
COMMIT;


-- -----------------------------------------------------
-- Data for table `Drinks`.`Ingredient`
-- -----------------------------------------------------
START TRANSACTION;
USE `Drinks`;
INSERT INTO `Drinks`.`Ingredient` (`id_Ingredient`, `name`, `typeof`, `taste`, `unit`) VALUES 
(1, 'pineapple', 'fruit', 'fruity', NULL), 
(2, 'pineapple pieces', 'fruit', 'fruity', NULL),
(3, 'banana', 'fruit', 'fruity', NULL),
(4, 'peach', 'fruit', 'fruity', NULL),
(5, 'cranberry', 'fruit', 'sour', NULL),
(6, 'sugar cube', 'seasoning', 'sweet', NULL),
(7, 'sugar','seasoning', 'sweet', 'teaspoon'),
(8, 'jelly beans', 'miscellaneous', 'sweet', NULL),
(9, 'cinnamon','seasoning', 'aromatic','teaspoon'),
(10, 'lemon', 'fruit', 'sour', NULL),
(11, 'maraska cherry', 'fruit', 'sour', NULL),
(12, 'mint leaves', 'seasoning', 'herbal', NULL),
(13, 'nutmeg', 'seasoning', 'aromatic', 'teaspoon'),
(14, 'apple', 'fruit', 'fruity', NULL),
(15, 'berries', 'fruit', 'fruity', NULL),
(16, 'coffee', 'miscellaneous', 'aromatic', 'ml'),
(17, 'apricot jam', 'fruit', 'fruity', 'teaspoon'),
(18, 'coconut cream', 'miscellaneous', 'milky', 'ml'),
(19, 'lime', 'fruit', 'sour', NULL),
(20, 'vanilla ice cream', 'miscellaneous', 'milky', NULL),
(21, 'mango', 'fruit', 'fruity', NULL),
(22, 'melon', 'fruit', 'fruity', NULL),
(23, 'almonds', 'miscellaneous','aromatic', NULL),
(24, 'honey', 'seasoning', 'sweet', NULL),
(25, 'cucumber', 'vegetable', 'neutral', NULL),
(26, 'olives', 'vegetable', 'bitter', NULL),
(27, 'salt', 'seasoning', 'savory', 'pinch'),
(28, 'pepper', 'seasoning', 'spicy', 'pinch'),
(29, 'orange', 'fruit', 'citrus', NULL),
(30, 'tomato', 'vegetable', 'tangy', NULL),
(31, 'tomato juice', 'juice', 'tangy', 'ml'),
(32, 'celery', 'vegetable', 'savory', NULL),
(33, 'sweet cream', 'dairy', 'milky', 'ml'),
(34, 'condensed milk', 'dairy', 'milky', 'ml'),
(35, 'pineapple juice', 'juice', 'sweet', 'ml'),
(36, 'apple juice', 'juice', 'sweet', 'ml'),
(37, 'grapefruit juice', 'juice', 'tangy', 'ml'),
(38, 'orange juice', 'juice', 'citrus', 'ml'),
(39, 'mango juice', 'juice', 'sweet', 'ml'),
(40, 'celery salt', 'seasoning', 'savory', 'pinch'),
(41, 'tabasco sauce', 'seasoning', 'spicy', 'teaspoon'),
(42, 'worcestershire sauce', 'seasoning', 'sweet', 'teaspoon'),
(43, 'egg', 'dairy', 'neutral', NULL),
(44, 'sugar syrup', 'seasoning', 'sweet', 'teaspoon'),
(45, 'strawberry', 'fruit', 'fruity', NULL),
(46, 'chocolate chips', 'miscellaneous', 'chocolatey', 'dash'),
(47, 'sparkling water', 'soft-drinks', 'neutral', 'ml'),
(48, 'lemonade', 'soft-drinks', 'bitter', 'ml'),
(49, 'Absolut Citron', 'spirit', 'citrus', 'ml'),
(50, 'Vodka', 'spirit', 'alcoholic', 'ml'),
(51, 'Bourbon Cougar', 'whisky', 'crisp', 'ml'),
(52, 'Brandy', 'spirit', 'floral', 'ml'),
(53, 'Campari', 'spirit', 'bitter', 'ml'),
(54, 'Canadian Club', 'whisky', 'spicy', 'ml'),
(55, 'Gin', 'spirit', 'alcoholic', 'ml'),
(56, 'Irish Whiskey', 'whisky', 'rooty', 'ml'),
(57, 'Cognac', 'spirit', 'savory', 'ml'),
(58, 'Malibu', 'spirit', 'sweet', 'ml'),
(59, 'Ouzo-Akropolis', 'spirit', 'spicy', 'ml'),
(60, 'Pernod', 'spirit', 'herbal', 'ml'),
(61, 'Rum Bacardi', 'spirit', 'aromatic', 'ml'),
(62, 'Rum Captain Morgan', 'spirit', 'sweet', 'ml'),
(63, 'Southern Comfort', 'whisky', 'fruity', 'ml'),
(64, 'Whisky', 'whisky', 'savory', 'ml'),
(65, 'Tequilla', 'spirit', 'spicy', 'ml'),
(66, 'White wine', 'wine&champagne&vermouth', 'dry', 'ml'),
(67, 'Ginger beer', 'beer&cider', 'rooty', 'ml'),
(68, 'Champagne', 'wine&champagne&vermouth', 'alcoholic', 'ml'),
(69, 'Advocaat', 'liqueur', 'creamy', 'ml'),
(70, 'Amaretto', 'liqueur', 'bitter', 'ml'),
(71, 'Baileys Irish Cream', 'liqueur', 'aromatic', 'ml'),
(72, 'Benedictine', 'liqueur', 'herbal', 'ml'),
(73, 'Blue Curacao', 'liqueur', 'bitter', 'ml'),
(74, 'Cassis', 'liqueur', 'sweet', 'ml'),
(75, 'Green Chartreuse', 'spirit', 'sweet', 'ml'),
(76, 'Yellow Chartreuse', 'spirit', 'sweet', 'ml'),
(77, 'Cherry Advocaat', 'liqueur', 'fruity', 'ml'),
(78, 'Cherry Brandy', 'spirit', 'sweet', 'ml'),
(79, 'Tonic', 'soft-drinks','bitter', 'ml'),
(80, 'Cointreau', 'liqueur', 'citrus', 'ml'),
(81, 'Drambuie', 'spirit', 'herbal', 'ml'),
(82, 'Frangelico', 'liqueur', 'aromatic', 'ml'),
(83, 'Galliano', 'spirit', 'herbal', 'ml'),
(84, 'Grand Marnier', 'liqueur', 'fruity', 'ml'),
(85, 'Kahlua', 'liqueur', 'coffee-like', 'ml'),
(86, 'Banana liqueur', 'liqueur', 'fruity', 'ml'),
(87, 'Peach liqueur', 'liqueur', 'fruity', 'ml'),
(88, 'Coconut liqueur', 'liqueur', 'milky', 'ml'),
(89, 'Orange liqueur', 'liqueur', 'citrus', 'ml'),
(90, 'Strawberry liqueur', 'liqueur', 'fruity', 'ml'),
(91, 'Passoa', 'liqueur', 'fruity', 'ml'),
(92, 'Pimms', 'spirit', 'sweet', 'ml'),
(93, 'Orange Curacao', 'liqueur', 'bitter-sweet', 'ml'),
(94, 'Sambuca', 'spirit', 'rooty', 'ml'),
(95, 'Tia Maria', 'liqueur', 'sweet', 'ml'),
(96, 'Triple Sec', 'liqueur', 'sweet', 'ml'),
(97, 'Cinzano Bianco', 'wine&champagne&vermouth', 'fruity', 'ml'),
(98, 'Cinzano Dry', 'wine&champagne&vermouth', 'dry', 'ml'),
(99, 'Cinzano Rosso', 'wine&champagne&vermouth', 'herbal', 'ml'),
(100, 'Martini Bianco', 'wine&champagne&vermouth', 'fruity', 'ml'),
(101, 'Martini Dry', 'wine&champagne&vermouth', 'dry', 'ml'),
(102, 'Martini Rosso', 'wine&champagne&vermouth', 'herbal', 'ml'),
(103, 'hot water', 'miscellaneous', 'neutral', 'ml'),
(104, 'brown sugar', 'seasoning', 'sweet', 'teaspoon'),
(105, 'pekan nuts', 'miscellaneous', 'aromatic', 'handful'),
(106, 'butter', 'dairy', 'creamy', 'g'),
(107, 'Apple Cider', 'beer&cider', 'crisp', 'ml'),
(108, 'Rum', 'spirit', 'spicy', 'ml'),
(109, 'whole milk', 'dairy', 'milky', 'ml'),
(110, 'sipping chocolate', 'miscellaneous', 'chocolatey', 'teaspoon'),
(111, 'whipped cream', 'dairy', 'creamy', "portion"),
(112, 'red wine', 'wine&champagne&vermouth', 'savory', 'ml'),
(113, 'cloves', 'seasoning', 'aromatic', NULL),
(114, 'cinnamon sticks', 'seasoning', 'spicy', NULL),
(115, 'star anise', 'seasoning', 'aromatic', NULL),
(116, 'cane sugar', 'seasoning', 'sweet', 'spoon'),
(117, 'Chatelle Napoleon', 'spirit', 'aromatic', 'ml'),
(118, 'sipping chocolate', 'miscellaneous', 'chocolatey', 'ml'),
(119, 'lemon juice', 'juice', 'citrus', 'ml'),
(120, 'water', 'soft-drinks', 'neutral', 'ml'),
(121, 'Bourbon', 'whisky', 'sweet', 'ml'),
(122, 'cocoa powder', 'seasoning', 'chocolatey', 'spoon'),
(123, 'caramel', 'miscellaneous', 'sweet', 'glass'),
(124, 'egg yolks', 'dairy', 'savory', NULL),
(125, 'milk', 'dairy', 'milky', 'ml'),
(126, 'vanilla', 'seasoning', 'aromatic', 'teaspoon'),
(127, 'Rumchata', 'liqueur', 'creamy', 'ml'),
(128, 'ice cubes', 'miscellaneous', 'neutral', NULL),
(129, 'crushed ice', 'miscellaneous', 'neutral', 'spoon'),
(130, 'chocolate liqueur', 'liqueur', 'chocolatey', 'ml'),
(131, 'Schnapps', 'spirit', 'alcoholic', 'ml'),
(132, 'cranberry juice', 'juice', 'sour', 'ml'),
(133, 'vanilla extract', 'seasoning', 'aromatic', 'ml'),
(134, 'Bitter Lemon', 'soft-drinks', 'bitter', 'ml'),
(135, 'coffee liqueur', 'liqueur', 'coffee-like', 'ml'),
(136, 'beer', 'beer&cider', 'aromatic', 'ml'),
(137, 'Prosecco', 'wine&champagne&vermouth', 'dry', 'ml'),
(138, 'Aperol', 'liqueur', 'bitter-sweet', 'ml'),
(139, 'Ginger Ale', 'soft-drinks', 'rooty', 'ml'),
(140, 'egg white', 'dairy', 'neutral', NULL),
(141, 'melon liqueur', 'liqueur', 'fruity', 'ml'),
(142, 'instant coffee', 'miscellaneous', 'aromatic', 'spoon'),
(143, 'chocolate syrup', 'seasoning', 'chocolatey', NULL),
(144, 'Scottish Whisky', 'whisky', 'savory', 'ml'),
(145, 'white chocolate liqueur', 'liqueur', 'chocolatey', 'ml'),
(146, 'lime liqueur', 'liqueur', 'citrus', 'ml'),
(147, 'cola', 'soft-drinks', 'sweet', 'ml'),
(148, 'Angostura', 'spirit', 'alcoholic', 'ml'),
(149, 'lime juice', 'juice', 'sour', 'ml'),
(150, 'mint liqueur', 'liqueur', 'herbal', 'ml'),
(151, 'mango liqueur', 'liqueur', 'fruity', 'ml'),
(152, 'Jack Daniels', 'whisky', 'herbal', 'ml'),
(153, 'Cachaca', 'spirit', 'aromatic', 'ml'),
(154, 'candy cane', 'miscellaneous', 'sweet', NULL);


COMMIT;


-- -----------------------------------------------------
-- Data for table `Drinks`.`Users`
-- -----------------------------------------------------
START TRANSACTION;
USE `Drinks`;
INSERT INTO `Drinks`.`Users` (`id_Users`, `Login`, `Password`) VALUES (1, 'Tester', 'testowy');

COMMIT;


-- -----------------------------------------------------
-- Data for table `Drinks`.`Favorite`
-- -----------------------------------------------------
START TRANSACTION;
USE `Drinks`;
INSERT INTO `Drinks`.`Favorite` (`id_Users`, `id_Drink`) VALUES (1, 1), (1, 5);

COMMIT;


-- -----------------------------------------------------
-- Data for table `Drinks`.`Recipe`
-- -----------------------------------------------------
START TRANSACTION;
USE `Drinks`;
INSERT INTO `Recipe` (`id_Drink`, `id_Ingredient`, `amount`) VALUES 
(1, 104, '2'), (1, 12, '2'), (1, 19, '0.5'), (1, 47, '150'), (1, 129, '3'), (1, 108, '50'),
(2, 49, '45'), (2, 96, '20'), (2, 132, '20'), (2,  19, '0.5'),
(3, 49, '30'), (3, 96, '15'), (3, 134, '150'), (3, 129, '1'), (3,  29, 'slice'),
(4, 49, '30'), (4, 72, '30'),
(5, 61, '30'), (5, 44, '30'), (5, 18, '30'),  (5, 33, '30'), (5, 35, '120'), (5, 129, '1'), (3,  3, '0.5'),
(6, 61, '30'), (6, 44, '30'), (6, 48, '30'), (6, 129, '1'), (3,  3, '3/4'),
(7, 50, '30'), (7, 85, '30'), (7, 71, '15'), (7, 3, '1'), (7, 33, '60'), (7, 129, '1'),
(8, 52, '30'), (8, 61, '30'), (8, 80, '15'), (8, 119, '15'), (8, 129, '1'),
(9, 94, '15'), (9, 80, '15'), (9, 80, '15'), (9, 71, '15'), (8, 33, '15'),
(10, 50, '30'), (10, 135, '30'), (10, 128, 'a few'),
(11, 50, '30'), (11, 31, '120'), (11, 42, '0.5'), (11, 41, '0.5'), (11, 27, "1"), (11, 28, "1"),
(12, 93, '15'), (12, 98, '15'), (12, 55, '30'), (12, 73, '15'), (12, 48, "120"),
(13, 94, '30'), (13, 88, '20'), (13, 90, '10'), (13, 33, '60'),
(14, 60, '30'), (14, 73, '5'), (14,  119, '5'), (14, 134, '120'),
(15, 61, '30'), (15, 73, '30'), (15, 35, '60'), (15, 119, '30'), (15, 44, '30'), 
(16, 52, '30'), (16, 93, '15'), (16, 124, '1'),
(17, 83, '30'), (17, 16, '70'), (17, 33, '15'), (17, 7, '0.5'),
(18, 77, '30'), (18, 130, '30'), (18, 88, '15'), (18, 33, '40'), (18, 125, '15'),
(19, 64, '15'), (19, 101, '8'), (19, 100, '8'), (19, 84, '0.15'), (19, 29, '1 smoked peel'),
(20, 64, '15'), (20, 131, '0.15'), (20, 138, '70'),
(21, 61, '45'), (21, 119, '30'), (21, 44, '15'), (21, 140, '0.5'),
(22, 60, '15'), (22, 68, '110'),
(23, 136, '400'), (23, 81, '22'), 
(24, 82, '45'), (24, 94, '45'), (24, 20, '1 scoop'), (24, 125, '150'), 
(25, 98, '15'), (25, 55, '30'), (25, 141, '15'), (25, 73, '7'),
(26, 69, '22'), (26, 78, '22'), (26, 48, '200'), 
(27, 61, '30'), (27, 69, '30'), (26, 48, '200'), (26, 33, '10'),
(28, 61, '30'), (28, 69, '30'), (28, 38, '30'), (28, 33, '30'),
(29, 85, '60'), (29, 16, '15'), (29, 111, '1'), (29, 20, '1 spoon'), (29, 143, '1 teaspoon'),
(30, 65, '30'), (30, 38, '120'), (30, 83, '15'),
(31, 84, '30'), (31, 50, '30'), (31, 95, '15'), (31, 38, '30'), (31, 35, '30'),
(32, 94, '30'), (32, 70, '30'), (32, 33, '30'),
(33, 64, '30'), (33, 70, '30'), (33, 128, 'a few'),
(34, 83, '30'), (34, 145, '30'), (34, 33, '30'),
(35, 83, '30'), (35, 80, '22'), (35, 38, '22'), (35, 33, '22'),
(36, 96, '15'), (36, 145, '15'), (36, 77, '15'), (35, 38, '15'), (35, 33, '15'), (35, 21, '1/4'),
(37, 83, '30'), (37, 61, '40'), 
(38, 59, '30'), (38, 73, '30'), (38, 35, '120'),
(39, 50, '30'), (39, 38, '120'), (39, 83, '15'),
(40, 56, '30'), (40, 104, '1'), (40, 16, '200'), (40, 111, '1'), 
(41, 141, '30'), (41, 80, '30'), (41, 119, '30'), 
(42, 59, '30'), (42, 73, '15'), (42, 48, '210'),
(43, 50, '30'), (43, 80, '30'), (43, 119, '30'),  (43, 146, '5'), 
(44, 85, '30'), (44, 84, '30'), (44, 71, '30'),
(45, 62, '30'), (45, 38, '30'), (45, 141, '30'), (45, 33, '30'), (45, 18, '15'),
(46, 74, '15'), (46, 66, '110'),
(47, 82, '45'), (47, 141, '45'), (47, 20, '2 scoops'),
(48, 135, '22'), (48, 80, '22'), (48, 94, '22'), (48, 33, '10'),
(49, 50, '30'), (49, 119, '30'), (49, 65, '30'), (49, 44, '30'), (49, 61, '30'), (49, 80, '15'), (49, 147, '0.15'), 
(50, 91, '30'), (50, 141, '15'), (50, 145, '15'), (50, 35, '30'), (50, 33, '30'), (50, 141, '15'),
(51, 61, '30'), (51, 119, '30'), (51, 70, '15'), (51, 44, '30'), (51, 62, '15'), (51, 19, '0.5'), (51, 93, '30'),
(52, 58, '30'), (52, 90, '30'), (52, 38, '30'), (52, 45, '3'), (52, 33, '60'),
(53, 62, '30'), (53, 119, '30'), (53, 80, '15'), (53, 124, '0.5'),
(54, 55, '45'), (54, 98, '20'), 
(55, 73, '30'), (55, 141, '30'), (55, 96, '15'), (55, 35, '60'),
(56, 50, '30'), (56, 146, '15'), (56, 67, '230'),
(57, 135, '30'), (57, 65, '30'), (57, 88, '30'),
(58, 144, '30'), (58, 148, '10'), (58, 6, '1'), (58, 47, '10'),
(59, 65, '30'), (59, 86, '30'), (59, 73, '10'),
(60, 92, '40'), (60, 48, '200'), 
(61, 61, '30'), (61, 18, '30'), (61, 44, '30'), (61, 35, '120'),
(62, 121, '22'), (62, 50, '30'), (62, 58, '15'), (62, 33, '40'),
(63, 52, '30'), (63, 27, '1'), (63, 28, '1'), (63, 41, '0.5'), (63, 42, '0.5'), (63, 124, '1'),
(64, 141, '30'), (64, 58, '30'), (64, 90, '30'), (64, 45, '3'),
(65, 55, '30'), (65, 38, '30'), (65, 78, '30'), (65, 149, '30'), (65, 96, '15'), (65, 35, '30'), (65, 148, '0.15'), (65, 72, '15'),
(66, 61, '15'), (66, 55, '15'), (66, 50, '15'), (66, 48, '30'), (66, 65, '15'),
(67, 144, '30'), (67, 81, '30'),
(68, 50, '45'), (68, 38, '230'), 
(69, 90, '5'), (69, 80, '10'), (69, 82, '15'), (69, 95, '15'), (69, 35, '20'), (69, 33, '20'),
(70, 50, '45'), (70, 38, '45'), (70, 128, 'a few'),
(71, 135, '15'), (71, 58, '30'), (71, 35, '60'), (72, 33, '60'),
(72, 52, '30'), (72, 80, '20'), (72, 119, '25'),
(73, 69, '30'), (73, 33, '10'), (73, 48, '240'),
(74, 80, '30'), (74, 52, '15'), (74, 78, '15'), (74, 35, '15'), (74, 119, '15'),
(75, 55, '30'), (75, 83, '15'), (75, 73, '15'), (75, 48, '200'),
(76, 141, '30'), (76, 83, '15'), (76, 88, '15'), (76, 35, '30'), (76, 33, '30'),
(77, 55, '135'), (77, 47, '45'),
(78, 73, '10'), (78, 63, '30'), (78, 82, '30'), (78, 90, '30'), (78, 45, '3'),
(79, 52, '45'), (79, 150, '10'),
(80, 130, '30'), (80, 147, '240'), (80, 33, '10'),
(81, 87, '60'), (81, 61, '15'), (81, 151, '15'), (81, 55, '15'), (81, 35, '60'), (81, 38, '60'), (81, 21, '1'), (81, 4, '1'),
(82, 55, '30'), (82, 87, '15'), (82, 68, '30'),
(83, 84, '15'), (83, 38, '15'), (83, 96, '15'), (93, 18, '15'), (83, 90, '30'), (83, 33, '30'),
(84, 55, '45'), (84, 99, '20'), 
(85, 65, '30'), (85, 139, '60'),
(86, 65, '30'), (86, 38, '230'),
(87, 152, '30'), (87, 57, '30'), (87, 72, '30'),
(88, 52, '45'), (88, 93, '30'), 
(89, 71, '5'), (89, 135, '15'), (89, 145, '15'), (89, 82, '30'), (89, 33, '60'), (89, 24, '0.5 spoon'),
(90, 61, '45'), (90, 121, '45'), (90, 19, '0.5 squezzed'), (90, 145, '0.15'), (90, 35, '200'),
(91, 141, '15'), (91, 94, '15'), (90, 71, '15'), (90, 95, '15'), (90, 33, '15'),
(92, 52, '60'), (92, 107, '100'), (92, 111, '1'), (92, 114, '2'),
(93, 106, '110'), (93, 104, '16'), (93, 9, '0.5'), (93, 27, '1'), (93, 13, '1/8'), (93, 113, '10'), (93, 64, '60'), (93, 103, '90'),
(94, 72, '40'), (94, 125, '150'), (94, 114, '1'),
(95, 33, '60'), (95, 20, '1 teaspoon'), (95, 153, '40'), (95, 135, '15'), (95, 16, '70'),
(96, 7, '10'), (96, 9, '1'), (96, 124, '5'), (96, 125, '400'), (96, 9, '0.5'), (96, 13, '0.25'), (96, 33, '150') , (96, 127, '220'), 
(97, 112, '750'), (97, 29, '1'), (97, 113, '6'), (97, 114, '3'), (97, 115, '3'), (97, 24, '4 spoons'), (97, 52, '100'),
(98, 120, '120'), (98, 121, '45'), (98, 24, '1 spoon'), (98, 119, '10'), (98, 114, '1'),
(99, 109, '100'), (99, 33, '100'), (99, 154, '1'), (99, 110, '6'), (99, 85, '45'), (99, 111, '1'),
(100, 52, '30'), (100, 130, '30'), (100, 33, '30'), (100, 13, '0.5'),
(101, 138, '100'), (101, 137, '100'), (101, 47, '20'), (101, 29, 'a few pieces');

COMMIT;
-- -----------------------------------------------------
-- Data for table `Drinks`.`DrinkTools`
-- -----------------------------------------------------
START TRANSACTION;
USE `Drinks`;
INSERT INTO `Drinks`.`DrinkTools` (`id_Drink`, `id_Tool`) VALUES 
(1, 5), (1, 9),
(2, 2),
(5, 8),(5,10),
(6, 8), (6, 3), (6,10),
(7, 10),
(8, 10), (8,3),
(10, 3),
(11, 3),
(13, 2), (13, 3),
(14, 8), 
(15, 10),
(16, 3),
(18, 2), (18, 3),
(21, 3),
(24, 8), (24, 10),
(25, 2), (25, 3),
(26, 8),
(27, 3),
(28, 2),
(31, 2), (31, 3),
(32, 2), (32, 3),
(34, 2), (34, 3),
(35, 2), (35, 3),
(36, 10),
(37, 2), (38, 3),
(41, 2), (41, 3),
(43, 2), (43, 3),
(45, 2), (45, 3),
(47, 10),
(50, 2), (50, 3),
(52, 2),
(53, 2), (53, 3),
(54, 8), (54, 3),
(59, 8), (59, 3),
(61, 2), (61, 3),
(62, 2), (62, 3),
(64, 11), (64, 11),
(65, 2), (65, 3),
(69, 10),
(71, 2), (71, 3),
(72, 2), (72, 3),
(74, 2), (74, 3),
(76, 10),
(78, 11),
(79, 4), (79, 3),
(81, 10),
(82, 4), (82, 3),
(83, 2), (83, 3),
(84, 8), (84, 3),
(87, 3),
(88, 3),
(89, 10),
(91, 2), (91, 3),
(94, 8),
(95, 2),
(96, 8),
(100, 3);


COMMIT;


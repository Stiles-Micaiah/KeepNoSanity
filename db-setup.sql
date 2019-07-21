USE somename2;
-- SET FOREIGN_KEY_CHECKS 0
-- DROP TABLE vaultkeeps;
-- DROP TABLE vaults;
-- DROP TABLE keeps;
-- DROP TABLE users;
-- DROP * FROM somename;
CREATE TABLE users (
  id VARCHAR(255) NOT NULL,
  username VARCHAR(20) NOT NULL,
  email VARCHAR(255) NOT NULL,
  hash VARCHAR(255) NOT NULL,
  created_at timestamp default current_timestamp,
  updated_at timestamp DEFAULT CURRENT_TIMESTAMP ON UPDATE current_timestamp,
  PRIMARY KEY (id),
  UNIQUE KEY email (email)
);
CREATE TABLE vaults (
  id int NOT NULL AUTO_INCREMENT,
  name VARCHAR(20) NOT NULL,
  description VARCHAR(255) NOT NULL,
  created_at timestamp default current_timestamp,
  updated_at timestamp DEFAULT CURRENT_TIMESTAMP ON UPDATE current_timestamp,
  userId VARCHAR(255),
  INDEX userId(userId),
  FOREIGN KEY(userId) REFERENCES users(id) ON DELETE CASCADE,
  PRIMARY KEY (id)
);
CREATE TABLE keeps (
  id int NOT NULL AUTO_INCREMENT,
  name VARCHAR(20) NOT NULL,
  description VARCHAR(255) NOT NULL,
  userId VARCHAR(255),
  img VARCHAR(255),
  isPrivate TINYINT,
  views INT DEFAULT 0,
  shares INT DEFAULT 0,
  keeps INT DEFAULT 0,
  created_at timestamp default current_timestamp,
  updated_at timestamp DEFAULT CURRENT_TIMESTAMP ON UPDATE current_timestamp,
  INDEX userId(userId),
  FOREIGN KEY (userId) REFERENCES users (id) ON DELETE CASCADE,
  PRIMARY KEY (id)
);
CREATE TABLE vaultkeeps (
  id int NOT NULL AUTO_INCREMENT,
  vaultId int NOT NULL,
  keepId int NOT NULL,
  created_at timestamp default current_timestamp,
  updated_at timestamp DEFAULT CURRENT_TIMESTAMP ON UPDATE current_timestamp,
  userId VARCHAR (255) NOT NULL,
  PRIMARY KEY (id),
  INDEX (vaultId, keepId),
  INDEX (userId),
  FOREIGN KEY (userId) REFERENCES users (id) ON DELETE CASCADE,
  FOREIGN KEY (vaultId) REFERENCES vaults (id) ON DELETE CASCADE,
  FOREIGN KEY (keepId) REFERENCES keeps (id) ON DELETE CASCADE
);
-- SET FOREIGN_KEY_CHECKS 1
-- -- USE THIS LINE FOR GET KEEPS BY VAULTID
-- SELECT * FROM vaultkeeps vk
-- INNER JOIN keeps k ON k.id = vk.keepId
-- WHERE (vaultId = @vaultId AND vk.userId = @userId)
-- HA
-- SELECT
-- name,
--  description,
--   userId,
--    img,
--     isPrivate,
--      views,
--       shares,
--        keeps,
--         DATE_FORMAT(created,'%e-%c-%Y %l:%i ')
--          FROM keeps
--           WHERE id = 3
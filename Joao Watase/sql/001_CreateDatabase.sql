USE db;
CREATE TABLE Users (
  id char(255) NOT NULL,
  firstName char(255) NOT NULL,
  surname char(255) DEFAULT NULL,
  creationDate datetime NOT NULL,
  age int NOT NULL
)
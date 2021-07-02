CREATE TABLE IF NOT EXISTS `books` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `book_name` varchar(80) NOT NULL,
  `writter` varchar(100) NOT NULL,
  `type_book` varchar(6) NOT NULL,
  PRIMARY KEY (`id`)
)
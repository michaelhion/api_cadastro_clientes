FROM mysql:latest
ENV MYSQL_ROOT_PASSWORD=senha
env MYSQL_DATABASE=db
ADD 001_CreateDatabase.sql /docker-entrypoint-initdb.d/
EXPOSE 3306
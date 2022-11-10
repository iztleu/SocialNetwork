#docker run --name social-network-mysql -e MYSQL_ROOT_PASSWORD=123456 -d mysql:8.0
docker run --name=social-network-mysql -p3306:3306 -e MYSQL_ROOT_PASSWORD=123456 -d mysql:8.0
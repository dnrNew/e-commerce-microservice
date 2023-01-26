CREATE DATABASE eshop_product_api;
USE eShop_product_api;
select * from Product;

INSERT INTO product VALUES (1, 'Copo Gamer com canudo', 23.99, 'Copo Gamer com canudo ideal para tomar suco e refrigerante.', 'Copos', 
'https://github.com/dnrNew/virtual-store-microservice/tree/eShop/eShopMicroservice/eShopImages/Glass_Gamer.jpg');

CREATE DATABASE eshop_identity_server;
USE eshop_identity_server;

CREATE DATABASE eshop_cart_api;
USE eshop_cart_api;

select * from product;
select * from cart_header;
select * from cart_detail;

DESCRIBE cart_header;
ALTER TABLE cart_header MODIFY coupon_code longtext;

CREATE DATABASE eshop_coupon_api;
USE eshop_coupon_api;

select * from coupon;
update coupon set discount_amount = 20.00 where id = 1;

CREATE DATABASE eshop_order_api;
USE eshop_order_api;

select * from order_detail;
select * from order_header;

# API Specification

|         Path         | RequestMethod | RequestParams |  RequestBody  |    ResponseCodes     |   ResponseBody   |
| :------------------: | :-----------: | :-----------: | :-----------: | :------------------: | :--------------: |
|      /products       |      GET      |       -       |       -       |          OK          | list of products |
|        /users        |      GET      |       -       |       -       |          OK          |  list of users   |
|    /orderHistory     |      GET      |    userId     |       -       |     OK, NotFound     |  list of order   |
|     /newProduct      |     POST      |  User(admin)  |    Product    | OK, NotAuth, BadReq  |        -         |
|       /signup        |     POST      |       -       |     User      |      OK, BadReq      |        -         |
|        /login        |     POST      |       -       |     User      |      OK, BadReq      |        -         |
|        /users        |     POST      |   userEmail   |       -       |     OK,NotFound      |       User       |
|      /products       |     POST      |   productId   |       -       |     OK, NotFound     |     Product      |
|    /updateProduct    |     PUTH      |   productId   |    Product    |      OK, BadReq      |        -         |
|     /updateUser      |     PUTH      |    userId     |     User      |      OK, BadReq      |        -         |
|    /deleteProduct    |    DELETE     |   productId   |       -       |     OK, NotFound     |        -         |
|     /deleteUser      |    DELETE     |    userId     |       -       |     OK,NotFound      |        -         |
| /changeProductStatus |     PATCH     |   productId   | productStatus | OK, BadReq, NotFound |        -         |

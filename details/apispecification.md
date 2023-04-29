# API Specification

|          Path           | RequestMethod | RequestParams | QueryParams | RequestBody |        ResponseCodes        |   ResponseBody   |
| :---------------------: | :-----------: | :-----------: | :---------: | :---------: | :-------------------------: | :--------------: |
|      /api/products      |      GET      |       -       |      -      |      -      |        OK, NoContent        | list of products |
|   /api/products/{id}    |      GET      |   productId   |      -      |      -      |        OK, NotFound         | specific product |
|       /api/orders       |      GET      |       -       |   UserId    |      -      |  OK, NoContent, BadRequest  |  list of orders  |
|    /api/orders/{id}     |      GET      |    orderId    |      -      |      -      |        OK, NotFound         |  specific order  |
|       /api/users        |      GET      |       -       |      -      |      -      | OK, NoContent, Unauthorized |  list of users   |
|     /api/users/{id}     |      GET      |    userId     |      -      |      -      | OK, NotFound, Unauthorized  |  specific user   |
|     /api/addProduct     |     POST      |       -       |      -      |   Product   |  OK, BadReq, Unauthorized   |    ProductDto    |
|      /api/addOrder      |     POST      |       -       |      -      |    Order    |     OK, BadReq, Forbid      |     OrderDto     |
| /api/updateProduct/{id} |     PUTH      |   productId   |      -      |   Product   |  OK, BadReq, Unauthorized   |    ProductDto    |
| /api/deleteProduct/{id} |    DELETE     |   productId   |      -      |      -      | OK, NotFound, Unauthorized  |    ProductDto    |
|  /api/deleteUser/{id}   |    DELETE     |    userId     |      -      |      -      | OK, NotFound, Unauthorized  |     UserDto      |

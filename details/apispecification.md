# API Specification

|        Path         | RequestMethod | RequestParams | RequestBody |        ResponseCodes        |   ResponseBody   |
| :-----------------: | :-----------: | :-----------: | :---------: | :-------------------------: | :--------------: |
|      /products      |      GET      |       -       |      -      |        OK, NoContent        | list of products |
|   /products/{id}    |      GET      |   productId   |      -      |        OK, NotFound         | specific product |
|       /orders       |      GET      |       -       |      -      |  OK, NoContent, BadRequest  |  list of orders  |
|    /orders/{id}     |      GET      |    orderId    |      -      |        OK, NotFound         |  specific order  |
|       /users        |      GET      |       -       |      -      | OK, NoContent, Unauthorized |  list of users   |
|     /users/{id}     |      GET      |    userId     |      -      | OK, NotFound, Unauthorized  |  specific user   |
|     /addProduct     |     POST      |       -       |   Product   |  OK, BadReq, Unauthorized   |    ProductDto    |
|      /addOrder      |     POST      |       -       |    Order    |     OK, BadReq, Forbid      |     OrderDto     |
| /updateProduct/{id} |     PUTH      |   productId   |   Product   |  OK, BadReq, Unauthorized   |    ProductDto    |
| /deleteProduct/{id} |    DELETE     |   productId   |      -      | OK, NotFound, Unauthorized  |    ProductDto    |
|  /deleteUser/{id}   |    DELETE     |    userId     |      -      | OK, NotFound, Unauthorized  |     UserDto      |

## Data for testing endpoints without UI

### Produt

```js
{
    "name":"Test2",
    "category":"Test2 Category",
    "description": "Test2 description",
    "image":"",
    "price":211,
    "isInStock": true
}
```

### Order

```js
{
    "shipAddress": "test address",
    "orderDetails" : [
        {
            "productId": "ProductId",
            "quantity": 26
        }
    ]
}
```

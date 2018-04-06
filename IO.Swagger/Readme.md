### Instructions for regenerating swagger classes

Download swagger-codegen (I used the current 2.4.0 snapshot because of fixes to the csharp generator)

Use `https://esi.tech.ccp.is/_latest/swagger.json` so that we get the exact versioned urls not latest/dev routes. https://developers.eveonline.com/blog/article/esi-best-practices-using-underscore-routes

```
java -jar .\swagger-codegen-cli-2.4.0-20180405.154650-206.jar generate -i https://esi.tech.ccp.is/_latest/swagger.json -l csharp -o esi-swagger
```

Copy `esi-swagger/src/IO.Swagger` to `evemon/IO.Swagger`
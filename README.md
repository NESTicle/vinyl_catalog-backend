# Vinyl Catalog App (Backend)

Proyecto mantenido por una única persona (en el momento), donde aplicaré mis conocimientos.

![Vinyl Catalog](https://user-images.githubusercontent.com/1715022/89719450-feff9400-d98d-11ea-850b-d121d914dc73.png)

## appSettings.json

Este es el appSettings.json que estoy usando por el momento, cualquier cambio que realice lo registraré aquí para tenerlo actualizado

```json
{
"Logging": {
  "LogLevel": {
    "Default": "Information",
    "Microsoft": "Warning",
    "Microsoft.Hosting.Lifetime": "Information"
  }
},
"ConnectionStrings": {
  "Db": "User ID=POSTGRE_USERNAME;Password=YOUR_POSTGRE_PASSWORD;Host=localhost;Port=5432;Database=Vinyl_Collection;Pooling=true"
},
"Keys": {
  "JWT": "YOU_NEED_TO_GENERATE_AN_ALPHANUMERIC_STRING_AND_PUT_IT_HERE"
},
  "AllowedHosts": "*"
}
```

## Tecnologías

**Backend:** Asp.net, PostgreSQL

## Autores

- [@nesticle](https://www.github.com/NESTicle)

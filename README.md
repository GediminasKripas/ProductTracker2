# ProductsAPI
Clone the repository
```bash
git clone https://github.com/GediminasKripas/ProductsAPI.git
```
Change directory:
```bash
cd ProductsAPI
```

Launch docker container:
```bash
docker build -t productapi .
docker run -it -dp 80:80 productapi
```
## Swagger
Url to swagger:
```bash
http://localhost:80/swagger/index.html
```
HttpPatch example:
```bash
[
  {
    "path": "itemName",
    "op": "replace",
    "value": "test"
  }
]
```
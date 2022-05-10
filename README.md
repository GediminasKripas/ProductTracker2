# ProductsAPI
Clone the repository
```bash
git clone https://github.com/GediminasKripas/ProductTracker2.git
```
Change directory:
```bash
cd ProductTracker2
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
# Target Products API

TODO: Description

## How to Build

Before building, ensure that you have Docker installed on your machine.

After you have verified that Docker is installed, run the following command from the root of the solution directory:

```
docker build -t target_products_api .
```

## How to Run

After you have built the Docker image, you can run it with the following:

```
docker run -d -p 8080:80 --name target_products_api target_products_api
```
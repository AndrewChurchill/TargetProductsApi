# Target Products API

## Overview

Hello, and welcome to my simple products API!
You can find details about how to run the application locally below, or you can head over to my hosted instance at https://target-products-api.herokuapp.com/swagger/index.html.

I have implemented the GET and PUT operations for the `/products/{id}` endpoint, details of which can be found at the [Swagger UI page linked to above](https://target-products-api.herokuapp.com/swagger/index.html).

You can also use CuRL to check out the responses:

```
curl -X 'GET' \
  'https://target-products-api.herokuapp.com/products/54456119' \
  -H 'accept: */*'
```

```
curl -X 'PUT' \
  'https://target-products-api.herokuapp.com/products/54456119' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "currentPrice": {
    "value": 5.44,
    "currencyCode": "USD"
  }
}'
```

## What's next?

Since this application is meant to be a proof of concept, there are things that would need to be added before this reached production.
Most notably:
* Implement some sort of authorization/authentication before allowing requests (especially for writing).
* Add more logging (i.e., any logging) and connect it to a service like Splunk for easy viewing.
* Add better HTTP response codes and exception handling.
* Add better input validation (i.e. validating currency codes).
* Update the Open API Specification to reflect all of the status codes that can be returned and which values can be modified in a PUT request.
* Add more data to the Products object (if needed).
* Introduce better networking between the API and MongoDB (right now they use the default bridge when running locally).
* Add unit, unit integration, system integration, and end to end tests.

## Running Locally

Quick aside, if you don't want to build the images locally, feel free to check out the API hosted on [Heroku](https://target-products-api.herokuapp.com/swagger/index.html)! 

Before running locally inside or outside of Docker, make sure you have a running MongoDB Docker container:

```
docker run --name mongodb -d -p 27017:27017 mongo
```

### Building the Docker image locally

To build the API image, run the following command from the root of the solution directory in your favorite shell:

```
docker build -t target_products_api .
```

### Running the Docker image locally

After you have built the API image and verified that MongoDB is up and running, you can start an API container with the following:

```
docker run -d -p 8080:80 -e TARGET_PRODUCT_API_MONGO_CONNECTION=mongodb://172.17.0.2:27017/targetProductPriceDb --name target_products_api target_products_api
```

### Running the API outside of Docker

You can also run the API outside of Docker if you would like. To do so, verify that you have .NET 6 installed locally on your machine:

```
dotnet --list-sdks
```

Then, you can start the API by running the following from the root of the solution directory (make sure you have started MongoDB first!):

```
dotnet build
dotnet run --project ./TargetProductsApi/TargetProductsApi.csproj
```

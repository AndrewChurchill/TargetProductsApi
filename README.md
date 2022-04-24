# Target Products API

TODO: Description

## Running Locally

### Building the Docker image locally

Before building, ensure that you have Docker installed on your machine.

After you have verified that Docker is installed, run the following command from the root of the solution directory:

```
docker build -t target_products_api .
```

### Running the Docker image locally

After you have built the Docker image, you can run it with the following:

```
docker run -d -p 8080:80 --name target_products_api target_products_api
```

## Running on Heroku

### Setting up Heroku

Log into your Heroku account and create an SSH key.

```
heroku login
```

Log into the Heroku container registry.

```
heroku container:login
```

### Running on Heroku

Build the Dockerfile locally.

```
docker build -t target_products_api .
```

Build the Dockerfile and push to Heroku.

```
heroku container:push web --app <your-app-name>
```

Release the newly published changes on Heroku.

```
heroku container:release web --app <your-app-name>
```
# Environment Variables

The service requires some mandatory environment settings and supports some
customizations via optional environment variables.

Depending on the OS and how the microservice is run, environment variables
can be defined in multiple ways. See below how to set environment variables
in the different contexts.

## Mandatory Settings

* `PCS_TELEMETRY_DOCUMENTDB_CONNSTRING` [mandatory]: contains the full connection
string required to connect the telemetry to the Document DB in the Azure cloud, 
where the Rules, Messages and the Alarms are stored.

* `PCS_STORAGEADAPTER_WEBSERVICE_URL` [mandatory]: the URL where the storage 
adapter service is available, e.g. `http://127.0.0.1:9022`

* `PCS_TELEMETRY_EVENTHUB_CONNSTRING`: [mandatory]:contains the full connection 
string required to connect the service to the EventHub.

* `PCS_TELEMETRY_EVENTHUB_NAME`: [mandatory]: the name of the eventhub used 
for notification system in the telemetry service.

* `PCS_TELEMETRY_DATA_AZUREBLOB_ACCOUNT`: [mandatory]: blob storage account 
used for storing checkpointing data for the eventhub used in the notification system.

* `PCS_TELEMETRY_DATA_AZUREBLOB_KEY`: [mandatory]: blob storage key used 
for storing checkpointing data for the eventhub used in the notification system.

* `PCS_TELEMETRY_LOGICAPP_ENDPOINT_URL`: [mandatory]: logic app end point
URL used to send email actions for Notification system.

* `PCS_SOLUTION_NAME`: [mandatory]: Solution name used to generate URL
for email notifications.

## Optional Settings

* `PCS_AUTH_REQUIRED` [optional, default `True`]: whether the web service requires client authentication, e.g. via the Authorization headers.

* `PCS_CORS_WHITELIST` [optional, default empty]: the web service cross-origin request settings. By default, cross origin requests are not allowed.
  Use `{ 'origins': ['*'], 'methods': ['*'], 'headers': ['*'] }` to allow any request during development.  In Production CORS is not required, and should be used very carefully if enabled.

* `PCS_AUTH_ISSUER` [optional, default empty]: the OAuth2 JWT tokens issuer, e.g. `https://sts.windows.net/fa01ade2-2365-4dd1-a084-a6ef027090fc/`.

* `PCS_AUTH_AUDIENCE` [optional, default empty]: the OAuth2 JWT tokens audience, e.g. `2814e709-6a0e-4861-9594-d3b6e2b81331`.

# How to define Environment Variables

### Environment variables in Windows

Environment variables can be set globally via the Control Panel. From the
Start menu search "environment variables" and open the first result
("Edit the system environment variables"). In the Advanced tab, click the
"Environment Variables" button to open the window where you can add/edit
variables.

### Environment variables in Linux and MacOS

In Unix-like systems environment variables are usually inherited from the
parent process. To set variables *globally* (i.e. for all processes) you
can use Bash settings (e.g. customize `.bash_profile` or `.bashrc` file).
In MacOS you can also use `launchctl setenv`.

### Environment variables when using Visual Studio

Global variables still apply, however it's possible to store environment
variables in the the startup project settings.

Right click on the WebService project, select Properties. Environment
variables can be set in `Debug` section.

These can be found also in the `WebService/Properties/launchSettings.json` file.

### Environment variables when using IntelliJ Rider

If you are using IntelliJ Rider or other IDEs, environment variables
are usually defined in the *run* configurations, and can be optionally
be inherited (or not) from the system.

Some IDEs store these in the `WebService.csproj` file.

### Environment variable when using Docker command line

Global variables values can be referenced, specifying only the name,
or passed explicitly inline.

Example 1, use global values:

```
docker run -e PCS_IOTHUB_CONNSTRING -e PCS_STORAGEADAPTER_WEBSERVICE_URL azureiotpcs/device-simulation-dotnet
```

Example 2, pass values explicitly:

```
docker run -e PCS_IOTHUB_CONNSTRING="...value here..." -e PCS_STORAGEADAPTER_WEBSERVICE_URL="...value here..." azureiotpcs/device-simulation-dotnet
```

For information see also https://docs.docker.com/engine/reference/run

### Environment variable when using Docker Compose

Global variables values can be referenced, specifying only the name,
or set explicitly, inlining the values in the configuration file,
typically `docker-compose.yml`.

For information see also https://docs.docker.com/compose/compose-file
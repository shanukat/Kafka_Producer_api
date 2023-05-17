# Building real time transaction applications using .NET Core and KAFKA

Producer API - This is created for publish messages to kafka topic using .Net core 6.0 web API


User Scenario:
Returning the paginated list of money account transactions for arbitrary calendar month for a given customer. The transactions retrieving process is real time as this is monitoring by logged customer through an e-banking portal.
To successfully create the above scenario, the below component has been built.
•	A Transaction API(RESTful) that takes transactions and responds back immediately.

Architecture diagram:
 
     https://github.com/shanukat/Producer_api/blob/master/architecture.JPG


Prerequisites

•	Visual Studio 2022

•	.NET core 6.0

•	Docker Desktop
. Kubernetes

How to install KAFKA in local?

It's easy to setup KAFKA in local using docker containers.create a new file called docker-compose.yml file and creating a new topic inside the yml file as below. KAFKA_CREATE_TOPICS: "MyTransactionTopic:1:1"

Navigate via the command line to the folder where you saved the docker-compose.yml file. Then, run the following command to start the images:
docker-compose up

This code will start the download of all the dependencies and start the images. During the process, you may see a lot of logs

To check if the Docker images are up, run the following command in another cmd window:
docker ps

Above instructions should start a KAFKA server, and you can use the broker localhost:9092 to produce/consumer messages. and already build Docker images.
. attached screenshot here

Implementation

1) Implemented a dotnetcore 6.0-WebApi post methods to capture customer Transactions requests.( into "MyTransactionTopic" kafka topic)
2) Need to import Confluent.kafka(2.1.1) library using Nuget Package manager or below command line which helps to make C# code understand how to produce and consume messages.
PM> Install-Package Confluent.Kafka
3)Implemented Log4net for write log messages- install Microsoft.Extensions.Logging.Log4net.AspNetCore(6.1.0)








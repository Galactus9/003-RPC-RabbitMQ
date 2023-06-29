# RPC-RabbitMQ
RPC-RabbitMQ is a repository that demonstrates the implementation of Remote Procedure Call (RPC) using RabbitMQ in C#. RPC allows a client to invoke methods or functions on a remote server and receive the results. RabbitMQ, a widely-used message broker, is used as the messaging middleware to facilitate RPC communication between the client and the server.

## Requirements
To run the RPC-RabbitMQ code, ensure you have the following dependencies:

- RabbitMQ: Make sure you have RabbitMQ installed and running on your local machine or have access to a RabbitMQ server.
- .NET SDK: You must have .NET SDK installed on your system.


## Configuration
By default, the code is set up to use a local RabbitMQ server running on localhost. If you have RabbitMQ running on a different host or port, you can modify the connection settings 

## Usage
The repository provides a basic client-server setup for RPC using RabbitMQ. Follow the steps below to run the code:

Just run the solution through cli or IDE, go to the swagger window, and use the only endpoint that exists.

The logic of this example is pretty simple, give the controller 2 integers and a Task 

available tasks : 

- 0 - Addition
- 1 - Subtraction
- 2 - Multiplication
- 3 - Division

Then the controller will send a message to RabbitMQ through RpcClient
The RpcServer will hear about the massage, will consume it, and will generate the result.
When the result is ready will respond to the RpcClient and then the result will be displayed in swagger.

## Acknowledgements

- RabbitMQ: https://www.rabbitmq.com/

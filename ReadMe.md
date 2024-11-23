# AlgoTrader

This is the core system for a basic algorithmic trading platform.

## Things to do (TODO):

- Storage

  - Create a database for storage of trading operations
  - Create a database to store market Data

- Implement multi-threading

  - Wrap the Trader class in a service to handle multiple threads with each thread containing a Trader object

- Market data connections

  - Add an HTTP market data service
  - Create a market data replay service to be used for backtesting
  - Connect to a mock data server
  - Look into CSV upload of market data to be able to backtest with

- Trading strategies
  - Investigate various tradung strategies
  - Abstract the implementation of tradin strategies so that future strategies can be created/stored

## Folder Structure

The project is structured as follows:

### **src** - AlgoTrader.api

The main source code of the project.

- #### Models

  This folder contains all the models and enums needed to build out the application.

- #### Data

  This folder will contain all data related classes needed e.g. Database contexts etc...

- #### Repositories

  This folder will contain all database repositories needed to abstract the database contexts and connections

- #### Services

  This folder contains all service required for the trading system to function. This forms a laayer between data/external resources and the controllers.

- #### TradingTools

  This folder contains service which are directly involved in trade operations. This is mainly strategies and automated traders.

- #### Controllers
  This folder will contain the various controllers which will have the endpoints which will be exposed to

### test

This is where the testing projects are stored for both unit and integration testing of the system.

- #### AlgoTrader.api.tests.unit

  The project containing all of the unit tests for the

- #### AlgoTrader.api.tests.integration

  TODO: Create the integration test project

## Setup

TODO: Write the setup instructiojns for the project

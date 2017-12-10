# BrainItUp

Intellectual Game 

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

What things you need to install the software and how to install them

```
Microsoft Visual Studio 2017
Microsoft SQL Server 2016
```

### Installing

A step by step series of examples that tell you have to get a development env running

```
Open Database project, locate and double click Database.publish.xml, push Publish button. 
```

If it is sucessfully published

```
Open BrainItUp project, set it as Startup Project and Start application.
```

That's all.

## Running the tests

Open Test Explorer, click Run All and make sure all the tests are green.

### Break down into end to end tests

All tests should be green to make sure the app works as intended.

```
        [Fact]
        public void Database_Should_Exists()
        {
            Assert.True(_fixture.BrainItUp.Database.Exists());
        }
```

## Authors

* **Kuzmina Lyubov** 
* **Romanova Darya** 
* **Shamazova Leysan** 

## Acknowledgments

* HSE

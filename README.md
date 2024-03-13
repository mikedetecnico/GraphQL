# GraphQLProject

This is a GraphQL API built with .NET 7.0. that allows for querying data relating patients to patient imaging studies.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

- .NET 7.0
- Docker (optional)

### Installing

1. Clone the repository
2. Navigate to the project directory
3. Run `dotnet restore`

### Running the application

1. Run `dotnet run` to start the application
2. Navigate to `http://localhost:5109/graphiql` to access the GraphiQL interface

### Running with Docker

1. Build the Docker image: `docker build -t graphqlproject .`
2. Run the Docker container: `docker run -p 80:80 graphqlproject`

## Built With

- [.NET 7.0](https://dotnet.microsoft.com/download/dotnet/7.0)
- [GraphQL](https://graphql.org/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)

## Contributing

Please read [CONTRIBUTING.md](CONTRIBUTING.md) for details on our code of conduct, and the process for submitting pull requests to us.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Sample Queries

```graphql
query PatientsQuery {
  patientQuery {
    patients {
      patientId,
      firstName
      lastName
      studies {
        studyId
      }
    }
  }
}
```

```graphql
query PatientQuery {
  patientQuery {
    patient(patientId: "4f0481f2-5d8e-4ecf-9953-6d56442bc4d6") {
      firstName,
      lastName,
      studies {
        studyId,
        modality,
        patientId
      }
    }
  }
}
```

```graphql
query StudiesQuery {
  studyQuery {
    studies {
      studyId,
      modality,
      patientId,
    }
  }
}
```
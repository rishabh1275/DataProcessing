# Data Processing ETL Pipeline

## Overview

The Data Processing ETL Pipeline is an automated pipeline designed to extract data from Salesforce Excel sheets, transform the data into programming objects, and load it into MongoDB. This project focuses on efficient data processing and storage, utilizing object-oriented design and data modeling.

## Features

- Automated extraction of data from Salesforce Excel sheets
- Data transformation and mapping to programming objects
- Data storage in MongoDB
- Robust error handling and logging

## Tech Stack

- **Programming Language:** C#
- **Framework:** .NET Core
- **Design Principles:** Object-Oriented Design (OOD), Data Modeling
- **Database:** MongoDB
- **Version Control:** Git
- **Testing:** Unit Testing with xUnit

## Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/yourusername/data-processing-etl-pipeline.git
    ```
2. Navigate to the project directory:
    ```sh
    cd data-processing-etl-pipeline
    ```
3. Restore the dependencies:
    ```sh
    dotnet restore
    ```
4. Build the project:
    ```sh
    dotnet build
    ```

## Usage

1. Configure the connection string for MongoDB in the `appsettings.json` file.
2. Run the pipeline:
    ```sh
    dotnet run
    ```

## Testing

To run the unit tests, use the following command:
    ```sh
    dotnet test
    ```

## Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/your-feature`)
3. Commit your changes (`git commit -am 'Add some feature'`)
4. Push to the branch (`git push origin feature/your-feature`)
5. Create a new Pull Request

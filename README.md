# AI-Powered Clinical Notes Summarization & Insights

## Overview
This project is an AI-powered system that processes clinical notes, extracts key medical insights, and provides structured summaries. It leverages **Azure OpenAI**, **Azure Speech-to-Text**, and an **event-driven architecture** to enhance efficiency in Electronic Health Records (EHR) systems.

## Features
<!-- - **Speech-to-Text Conversion**: Converts dictated clinical notes into structured text using Azure Speech-to-Text.
- **AI-Powered Summarization**: Uses Azure OpenAI (GPT-4) to generate concise, structured summaries.
- **Medical Insights Extraction**: Identifies diagnoses, medications, and risk factors.
- **Decision Support Module**: Provides AI-driven recommendations (e.g., ICD-10 codes, risk alerts).
- **Event-Driven Processing**: Utilizes MassTransit and RabbitMQ for scalable messaging.
- **Secure Data Storage**: Stores structured summaries in an Azure SQL-backed EHR system.
- **User Interface**: A web-based UI built with Blazor for clinicians. -->

## Architecture
- **API Layer**: ASP.NET Core (Controllers, MediatR Handlers)
- **Application Layer**: Business logic and CQRS (Commands/Queries)
- **Domain Layer**: Entities, Aggregates, Domain Events
- **Infrastructure Layer**: Azure OpenAI, Speech-to-Text, MassTransit, RabbitMQ
- **Database**: Postgres for structured EHR data
- **Frontend**: ASP.NET Core Blazor

## Technology Stack
- **Backend**: ASP.NET Core, MediatR, MassTransit
- **AI Services**: Azure OpenAI (GPT-4), Azure Speech-to-Text
- **Messaging**: RabbitMQ
- **Database**: Postgres, Entity Framework Core
- **Frontend**: ASP.NET Core Blazor
- **Containerization**: Docker, Kubernetes (Optional)

## Getting Started
### Prerequisites
- .NET 9 SDK
- Azure Account (for OpenAI and Speech-to-Text services)
- RabbitMQ (for messaging)
- SQL Server / Azure SQL
- Docker (if running in a containerized environment)

### Setup Instructions
1. Clone the repository:
   ```sh
   git clone https://github.com/yourrepo/ClinicalNotesSummarization.git
   cd ClinicalNotesSummarization
   ```
2. Install dependencies:
   ```sh
   dotnet restore
   ```
3. Set up environment variables:
   ```sh
   cp .env.example .env
   ```
   - Add Azure OpenAI API key
   - Configure database connection string
4. Run database migrations:
   ```sh
   dotnet ef database update
   ```
5. Start the application:
   ```sh
   dotnet run --project src/ClinicalNotesSummarization.Api
   ```
6. Access the UI:
   - If using Blazor: `http://localhost:5000`

## Roadmap
- ✅ Implement AI-powered summarization
- ✅ Integrate Azure Speech-to-Text
- ⏳ Enhance Decision Support with AI insights
- ⏳ Deploy on Kubernetes

## Contributing
Contributions are welcome! Please submit a pull request or open an issue.

## License
This project is licensed under the MIT License.

# dotnet ef database update --project ClinicalNotesSummarization.Infrastructure --startup-project ClinicalNotesSummarization.Api
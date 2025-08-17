ClinicalNotesSummarization.Orchestration

This project contains orchestration logic for Semantic Kernel-based LLM tasks, skills, and retrieval.

- KernelFactory.cs - builds an IKernel instance using configuration
- RegistrationExtensions.cs - registers orchestration services with DI
- Services/SemanticSummarizationService.cs - sample summarization implementation
- ISummarizationService.cs - interface and DTO used by this project

Notes:
- Application interfaces should ideally be moved to ClinicalNotesSummarization.Application. For quick scaffolding, ISummarizationService is placed here.
- Update configuration for OpenAI / Azure OpenAI keys under OpenAI:ApiKey and OpenAI:Endpoint
- For Ollama or non-OpenAI providers, implement a custom connector or point to an OpenAI-compatible local endpoint.

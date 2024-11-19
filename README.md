# Modulith_EShop
EShop Modulith on .NET used Asp.Net Web API, PostgreSQL, Redis, RabbitMQ, Keycloak, Seq, Docker, MassTransit


Modular Monoliths (Modulith) Architecture

Vertical Slice Architecture (VSA) 

Domain-Driven Design (DDD)

Command Query Responsibility Segregation (CQRS)

Outbox Pattern for Reliable Messaging

CQRS (Command Query Responsibility Segregation) and Vertical Slice architectures for module development

Communicate over In-process method calls-public APIs and use RabbitMQ for event-driven communication

Secure APIs with Keycloak, using OpenID Connect and Bearer Tokens

ASPNET Core Minimal APIs and latest features of .Net8 and C# 12

Vertical Slice Architecture implementation with Feature folders

DDD, CQRS Patterns using MediatR library w/ following Best Practices

Use Domain Events & Integration Events when UpdatePriceChanged event

Use Entity Framework Core Code-First Approach and Migrations on PostgreSQL Database

Cross-cutting Concerns including Logging with Serilog, Validation with MediatR Pipeline Behaviors, Exceptions, Pagination

Using Redis as a Distributed Cache over PostgreSQL database

Develop Proxy, Decorator and Cache-aside patterns

Sync Communications between Catalog and Basket Modules w/ In-process Method Calls (Public APIs)

Async Communications between Modules w/ RabbitMQ & MassTransit

Develop User Identity Module with Keycloak Authentication

OAuth2 + OpenID Connect Flows with Keycloak

Outbox Pattern For Reliable Messaging w/ BasketCheckout Use Case

Publish BasketCheckoutEvent to RabbitMQ via MassTransit library, Consume from Ordering Module

Migrating to Microservices: EShop Modules to Microservices w/ Stranger Fig Pattern


# Persona Blog

Persona Blog is a Blog Platform, which helps me write my stories and publish them conveniently. It is being designed in DDD (Domain-Driven Design) for helping me to practice a lot so as to improve  architecture design skills.

## Architecture
As for this Blog platform, I'm using **the Clean Architecture** (aka **the Onion Architecture**):

<image src="https://miro.medium.com/max/1544/1*B7LkQDyDqLN3rRSrNYkETA.jpeg"/>
<figcaption>Clean Architecture, Courtesy: Uncle Bob</figcaption>

1. Shared Kernel

    This is the most important component for platform. It contains all shared interfaces, classes, functions... for every components can use it. I helps reduce code duplication.

2. Domain

    It contains entities which define business rules, events of application.

3. Persistence

    It supports platform to register entity to EF core and contains migration meta.

4. Infrastructure

    We use infrastrucure to implement repository pattern, requesting API services, send email, etc. It helps our app to integrate with outside services.

5. API

    It is our main API for Presentaters. It does not only use Entities in Domain, but also uses it own ViewModel to validate requesting data befor call Queries or Commands.

7. Presenters

    There are 2 main presenters, one for Administrator to CRUD data, another for Front Page to show for viewers.

## Design Patterns
    ✅ Repository
    ✅ CQRS - Command Query Resource Segregation
    ✅ Dependency Injection
    TBD...

# BillerTestDigitalWare
Prueba Tecnica DigitalWare

## El dominio del problema
Se requiere que se puedan realizar facturas (Facturación) y administrar el stock de los articulos, por ejemplo cuanto entra de tal articulo y cuando sale.

## Casos de uso
* Generar una factura.
* Consultar facturas
* Eliminar una factura.
* Editar productos
* Crear productos
* Eliminar productos
* Consultar productos

## Observaciones
* Este proyecto usa secretos de usuario.
* Usa como motor de base de datos Microsoft SQLServer.
* Las pruebas unitarias solo dan cobertura a los casos de uso, 23 pruebas en total.

## Estructura de Carpetas y Arquitectura
El diseño del modelo esta basado en Domain-Driven Design (DDD).
Se usan tres capas 
1. Application: Casos de uso.
2. Domain: Modelo Dominio
3. Infrastructure: Capa de configuration de infraestructura como, implementaciones a acceso a datos y etc. Solo se agregan implementaciones de los repositorios para EFCore

Cada entidad raiz tiene una implementacion de estas 3 capas, visualice la entidad "Invoices" de "Billing".

El proyecto RESTFull esta basado en .NET Core Web API mvc , sin embargo se respeta el principio de responsabilidad unica agregando un controlador para cada operacion HTTP.

<pre>
├───apps
│   └───Biller
│       └───Server
│           ├───Controllers
│           │   ├───Customers
│           │   │   └───Request
│           │   ├───Invoices
│           │   │   └───Request
│           │   └───Products
│           │       └───Request
│           ├───Infrastructure
│           │   ├───DependencyInjection
│           │   │   ├───Customers
│           │   │   ├───Invoices
│           │   │   └───Products
│           │   └───Mvc
│           │       └───JsonConverts
│           └───Properties
├───src
│   ├───Billing
│   │   ├───Customers
│   │   │   ├───Application
│   │   │   │   ├───Create
│   │   │   │   ├───SearchAll
│   │   │   │   └───SearchById
│   │   │   ├───Domain
│   │   │   │   └───Exceptions
│   │   │   └───Infrastructure
│   │   │       ├───Mappings
│   │   │       └───Persistence
│   │   │           └───Configurations
│   │   ├───Invoices
│   │   │   ├───Application
│   │   │   │   ├───Create
│   │   │   │   ├───Delete
│   │   │   │   ├───SearchAll
│   │   │   │   └───SearchById
│   │   │   ├───Domain
│   │   │   │   ├───Exceptions
│   │   │   │   └───ValueObjects
│   │   │   └───Infrastructure
│   │   │       ├───Mappings
│   │   │       └───Persistence
│   │   │           └───Configurations
│   │   ├───Products
│   │   │   ├───Application
│   │   │   │   ├───AdjustStock
│   │   │   │   ├───Create
│   │   │   │   ├───Delete
│   │   │   │   ├───SearchAll
│   │   │   │   ├───SearchById
│   │   │   │   └───Update
│   │   │   ├───Domain
│   │   │   │   └───Exceptions
│   │   │   └───Infrastructure
│   │   │       ├───Mappings
│   │   │       └───Persistence
│   │   │           └───Configurations
│   │   └───Shared
│   │       └───Infrastructure
│   │           └───Persistence
│   │               └───EfCore
│   │                   └───Migrations
│   └───Shared
│       ├───Domain
│       │   ├───Enums
│       │   └───ValueObjects
│       ├───Infrastructure
│       │   └───Persistence
│       │       └───EfCore
└───test
    └───src
        └───BillingTest
            ├───Customers
            │   └───Domain
            ├───Invoices
            │   ├───Application
            │   │   ├───Create
            │   │   ├───Delete
            │   │   └───Search
            │   └───Domain
            └───Products
                ├───Application
                │   ├───Create
                │   ├───Delete
                │   ├───Search
                │   └───Update
                └───Domain
<pre/>

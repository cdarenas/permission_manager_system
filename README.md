# permission_manager_system
Permission Manager Application Demo (.NET and NextJS)


Esta solución de demostración basada en una arquitectura de microservicios implementando CQRS como patrón de arquitectura y el patrón de comportamiento Mediator para la gestión de la comunicación entre objetos de manera desacoplada. A fines de simplificar esta demo, se utilizaron MongoDB como base de datos documental, PostgreSQL como base de datos relacional y Kafka para la gestión de eventos, corriendo en Docker.

La solución Permission Manager contempla un proyecto Core para la implementación de CQRS que permite la separación del modelo de lectura y de escritura, la solución SM-PermissionManager que implementa la API de Commands y la API de Queries, así como también un proyecto con clases de uso compartido.

Arquitectura de la solución de backend con CQRS y Event Sourcing:


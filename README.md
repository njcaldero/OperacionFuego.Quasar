# OperacionFuego.Quasar
Desafío MELI

# Solución:

El Proyecto se abordo bajo los lineamientos de clean arquitecture para la distribución de las diferentes capas o componentes de la solución, teniendo en cuenta la dependencia de adentro hacia afuera.

![image](https://user-images.githubusercontent.com/2071253/162592502-72428983-95f9-47fc-b93f-fc436094796f.png)

----------------------------------------------------------
-
  - IDE: Visual Studio 2022
  - Lenguaje: C#
  - Tipo Proyecto: Asp.net core web api
  - Version: .net core 5.0

Durante la construcción se tuvieron en cuenta los siguientes puntos:
* Principios SOLID como:
  * División de responsabiidad unica
  * Segregación de interfaces
  * Inversión de control
  * Inyeccion de dependencias
  * Open/Close

* Para tener en cuenta:
  * En la capa repository se hace una simulación de persistencia la cual esta inMemory.
  * Se utiliza Library automapper para el mapeo entre entidades de modelo del dominio  y modelo de presentación
  * La app es desplegable en contenedores linux y windows para lo cual se registro una imagen en dockerHub

----------------------------------------------------------
# Despliegue

La app fue desplegada por medio del servicio de AWS en Elastic Beanstalk:
* endponit: http://operacionfuegoquasarapi-test.us-east-1.elasticbeanstalk.com/
 * Resources api:
  -   api/Communication/topsecret
  -   api/Satellite/topsecret_split/{satelite_name}
  -   api/Satellite/topsecret_split

La documentación en formato open api puede ser encontrada en el siguiente link:
* https://app.swaggerhub.com/apis/nescalro/operacion-fuego_quasar_api/v1

Adjunto tambien se encontraran la collection de postman para la realización de pruebas.

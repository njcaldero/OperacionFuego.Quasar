# OperacionFuego.Quasar
Desafío MELI

# Solución:

El Proyecto se abordo bajo los lineamientos de clean arquitecture para la distribución de las diferentes capas o componentes de la solución, teniendo en cuenta la dependencia de adentro hacia afuera.

En lo posible tener alta cohesión y bajo acoplamiento.

![image](https://user-images.githubusercontent.com/2071253/162592502-72428983-95f9-47fc-b93f-fc436094796f.png)

----------------------------------------------------------
-
  - IDE: Visual Studio 2022
  - Lenguaje: C#
  - Tipo Proyecto: Asp.net core web api
  - Version: .net core 5.0
  - ![image](https://user-images.githubusercontent.com/2071253/162593703-3787fb0d-274f-4d06-bde5-a60826929c61.png)



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

El Despliegue se realizo en un ambiente de pruebas, pero en el desarrollo se tiene en cuenta las diferentes ambientes de dev, sqa ,pro

* endponit: http://operacionfuegoquasarapi-test.us-east-1.elasticbeanstalk.com/
  * Resources api:
     -   api/Communication/topsecret
     -   api/Satellite/topsecret_split/{satelite_name}
     -   api/Satellite/topsecret_split


![image](https://user-images.githubusercontent.com/2071253/162593062-824e0519-5cca-439b-8493-9ed91996e2f8.png)

![image](https://user-images.githubusercontent.com/2071253/162593066-af4b2b22-840b-4da7-9614-9d7d490ff012.png)

La documentación en formato open api puede ser encontrada en el siguiente link:
* https://app.swaggerhub.com/apis/nescalro/operacion-fuego_quasar_api/v1

![image](https://user-images.githubusercontent.com/2071253/162593112-b6f44b59-1330-4ba4-95c5-02ce77d4b214.png)

* Adjunto tambien el json de la collection de postman para la realización de pruebas:
  * https://www.getpostman.com/collections/9ca56e9f1cb8580e8a08
  * ![image](https://user-images.githubusercontent.com/2071253/162593298-d87bb381-fafe-494b-b195-1a4657a75b88.png)


* By Nestor Calderon.

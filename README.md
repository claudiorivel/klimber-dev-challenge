# klimber-dev-challenge
Development challenge for Klimber

## Descripción del ejercicio
Tenemos un método que genera un reporte en base a una colección de formas geométricas, procesando algunos datos para presentar como reporte información extra. La firma del método es: public static string Imprimir(List<FormaGeometrica> formas, int idioma) y se encuentra ubicado en la clase FormaGeometrica.cs

En consecuencia a como fue codificado este módulo, al equipo de desarrollo se le hace muy difícil el poder agregar una nueva forma geométrica o implementar la impresión del reporte en otro idioma. Nos gustaría poder dar soporte para que en el futuro los desarrolladores puedan agregar otros tipos de formas y obtener el reporte en otros idiomas con más agilidad. ¿Nos podrías ayudar a refactorizar la clase FormaGeometrica?

Acompañando al proyecto encontrarás una serie de tests unitarios (librería NUnit) que describen el comportamiento actual del método Imprimir. Se puede modificar absolutamente cualquier cosa del código y de los tests, con la única condición que los tests deben pasar correctamente al entregar la solución.
Dentro del código hay un TODO con los requerimientos técnicos y del usuario a satisfacer.

## Solución propuesta
Se refactorizó la clase `FormaGeometrica` (se dejo la clase original en el proyecto solo a modo ejemplo). Se separó dicha clase en varias clases de acuerdo a cada forma geométrica y se creó la interfaz `I2DShape` la cual debe implementar cada forma geométrica que se desee agregar en el proyecto. Para la internacionalización se implementó un archivo de recurso (.resx) por cada idioma el cual contiene todos los textos que deben ser mostrados.

## Cómo implementar una nueva forma geométrica
Para implementar una nueva forma geométrica es necesario 
  * Crear una nueva clase que implemente la interfaz `I2DShape`.
  * Modificar la clase `Shapes` y agregar una constante con el nombre de la forma geométrica.
  * Modicar los archivos `.resx` para incluir el nombre de la forma geométrica en los diferentes idiomas soportados.

## Cómo agregar un nuevo idioma
Para agregar un nuevo idioma es necesario
  * Crear un nuevo archivo `.resx` con formato `Text.[idioma].resx`
  * Copiar y traducir los strings
  * Modificar la clase `Languages` y agregar una constante con el nombre del idioma agregado. 

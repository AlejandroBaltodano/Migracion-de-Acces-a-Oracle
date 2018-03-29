# Migracion-de-Acces-a-Oracle

Aplicacion creada mediante el entorno de desarrollo Visual studio 2015 community, utilizando el lenguaje de programacion C# y las bases de datos 
Oracle y Acces.

Esta aplicacion se realizo con el objetivo de poder migrar los datos de las tablas que se encuentran en Access y pasarlas a la base de datos
Oracle.

El proceso se realiza mediante consutas y procedimientos sql. Esto es porque para extraer todos los datos de las tablas en Acces se realiza
una consulta Select de las tablas a las que se quieren migrar y de la base de datos luego al obtener esos datos los guardo en un dataset
en C# y luego lo pase a una datatable para crear un unico prodecimiento almacenado de insertar los datos a las tablas en Oracle, pero para 
esto primero tenia que eliminar los datos en las tablas en Oracle y luego insertar los nuevos registros.

Para armar el procedimiento con la transaccion insert, se creo un metodo ConstructuraSQL donde recorria las filas y columnas de la datatable
e hiba insertando los datos en el String que hiba creando la cadena del procedimiento almacenado.

Por ejemplo:

string cadena = "Begin ";
cadena += "Datos extraidos de la datatable, aqui utilizo el metodo ConstructuraSQL";
cadena += "end;"
 
 Pero el proceso de obtener los datos de una query de Acces y la tabla en esta base de datos, lo realiza el metodo MigracionAO, que es el
 encargado de recibir como parametro las query y nombre de la tabla para extraer los datos en Acces y meterlos en el dataset, luego este metodo me invoca el metodo ConsturcturaSQL para poder armar el procedimiento insert para oracle y asi migrar los datos de acces a oracle.

Ya teniendo el procedimiento nada mas lo ejecuto desde la aplicacion con los metodos creados en la clase ConexionOracle, donde realizo los
diferentes procesos dml.

Ver el siguiente link para entrar a la pagina del proyecto 

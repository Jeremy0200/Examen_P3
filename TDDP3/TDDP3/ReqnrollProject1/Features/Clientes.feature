Feature: Clientes

A short summary of the feature

@tag1
Scenario: Insertar Clientes
	Given El usuario esta en la pagina
	When Llenar los campos dentro del Formulario
		| Cedula     | Apellidos   | Nombres        | FechaNacimiento | Mail          | Telefono   | Direccion    | Estado |
		| 1726203936 | Garcia Jara | Luis Sebastian | 2003-04-10      | luis@test.com | 0987654321 | Guayllabamba | 1      |
	And Dar click en el boton de guardar
		| Cedula     | Apellidos   | Nombres        | FechaNacimiento | Mail          | Telefono   | Direccion    | Estado |
		| 1726203936 | Garcia Jara | Luis Sebastian | 2003-04-10      | luis@test.com | 0987654321 | Guayllabamba | 1      |
	Then El resultado se ve reflejado en la tabla
		| Cedula     | Apellidos   | Nombres        | FechaNacimiento | Mail          | Telefono   | Direccion    | Estado |
		| 1726203936 | Garcia Jara | Luis Sebastian | 2003-04-10      | luis@test.com | 0987654321 | Guayllabamba | 1      |


@tag2
Scenario: Se edita un usuario
	Given El usuario esta en la pagina para hacer el crud-editar
	When Llenar los campos dentro del Formulario editar
		| Cedula     | Apellidos   | Nombres     | FechaNacimiento | Mail           | Telefono   | Direccion | Estado |
		| 1726203936 | Reyes Ceron | Ariel Reyes | 2003-04-10      | ariel@test.com | 0987654321 | Lloa      | 1      |
	And Dar click en el boton de guardar del formulario editar
	Then Verificar la url de la pagina


@tag3
Scenario: Se verifica el delete de un usuario
	Given El usuario esta en la pagina para hacer el crud-delete
	When Se da click en el boton de eliminar
	Then Verificar la url de la pagina final


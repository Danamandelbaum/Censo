List<persona> listaPersonas = new List<persona>();
int opcion = 0;
int cantPersonas = 0;

do
{
    
    Console.WriteLine("1 - Cargar Persona");
    Console.WriteLine("2 - Obtener estadisticas del censo");
    Console.WriteLine("3 - Buscar Persona");
    Console.WriteLine("4 - Modificar email de una Persona");
    Console.WriteLine("5 - Salir");
    opcion = int.Parse(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            ingresarPersona();
        break;

        case 2:
            verEstadisticas();
        break;

        case 3:
            buscarPersona();
        break;

        case 4:
            modificarMail();
        break;
    }

} while(opcion != 5);



void modificarMail()
{
    int dniIngresado;
    string dniActualizado;
    Console.WriteLine("Ingrese el DNI de la persona para modificar su mail: ");
    dniIngresado = int.Parse(Console.ReadLine());
    foreach (persona personas in listaPersonas)
    {
        if (dniIngresado == personas.DNI)
        {
            Console.WriteLine("Cambie el email: ");
            dniActualizado = Console.ReadLine();
            personas.email = dniActualizado;
        }
        
    }
    
}


void buscarPersona()
{
    int dniIngresado;
    Console.WriteLine("Ingrese el DNI de la persona que busca: ");
    dniIngresado = int.Parse(Console.ReadLine());
    foreach (persona personas in listaPersonas)
    {
        if (dniIngresado == personas.DNI)
        {
            Console.WriteLine(personas.nombre);
            Console.WriteLine(personas.apellido);
            Console.WriteLine(personas.fechaNacimiento);
            Console.WriteLine(personas.email);
        }
    }
    
}


void verEstadisticas()
{
    bool votar;
    int promedio, edadPersona, edades;
    edades = 0;
    if ( cantPersonas > 0)
    {
        Console.WriteLine("Cantidad de personas en la lista: " + cantPersonas);
    }
    else{
        Console.WriteLine("No hay personas en la lista");
    }
    foreach (persona personas in listaPersonas)
    {
        votar = personas.comprobarSiPuedeVotar();
        if (votar == true)
        {
            Console.WriteLine("La persona puede votar");
        }
        else {
            Console.WriteLine("La persona no puede votar");
        }
        edadPersona = personas.edadPersona();
        edades = edades + edadPersona;
    }
    promedio = calcularPromedio(edades, cantPersonas);
    Console.WriteLine("El promedio es: " + promedio);
}


int calcularPromedio(int edades, int cantPersonas)
{
    int promedio = 0;
    promedio = edades/cantPersonas;
    return promedio;
}


void ingresarPersona()
{
    int dni = ingresarDNI("Ingresar DNI: ");
    string apellido = ingresarApellido("Ingresar apellido: ");
    string nombre = ingresarNombre("Ingresar nombre: ");
    DateTime fn = ingresarFecha("Ingresar fecha de nacimiento: ");
    string mail = ingresarMail("Ingresar mail: ");

    persona unaPersona = new persona(dni, apellido, nombre, fn, mail);
    listaPersonas.Add(unaPersona);
    cantPersonas = cantPersonas + 1;
    Console.WriteLine("Se creó la persona: " + nombre + apellido +" y se agrego a la lista.");
}

string ingresarMail(string msj)
{
    string mail;
    Console.WriteLine(msj);
    mail = Console.ReadLine();
    return mail;
}

DateTime ingresarFecha(string msj)
{
    DateTime fn;
    Console.WriteLine(msj);
    fn = DateTime.Parse(Console.ReadLine());
    return fn;
}

string ingresarNombre(string msj)
{
    string nombre;
    Console.WriteLine(msj);
    nombre = Console.ReadLine();
    return nombre;
}

string ingresarApellido(string msj)
{
    string apellido;
    Console.WriteLine(msj);
    apellido = Console.ReadLine();
    return apellido;

}

int ingresarDNI(string msj)
{
    int dni;
    Console.WriteLine(msj);
    dni = int.Parse(Console.ReadLine());
    return dni;
}
class persona
{
    public int DNI{get; private set;}
    public string apellido{get; set;}
    public string nombre{get; set;}
    public DateTime fechaNacimiento{get; set;}
    public string email{get; set;}
    private int edad{get;set;}
    
    public persona(){
    }

    public persona(int dni = 0, string apell = "", string nom = "", DateTime fn = new DateTime(), string mail = "")
    {
        DNI = dni;
        apellido = apell;
        nombre = nom;
        fechaNacimiento = fn;
        email = mail;
        edad = 0;
    }

    public int edadPersona()
    {
        DateTime fechaNacimientoHoy = new DateTime(DateTime.Today.Year, fechaNacimiento.Month, fechaNacimiento.Day);
        edad = 0;
        if (fechaNacimientoHoy < DateTime.Today)
        {
            edad = DateTime.Today.Year - fechaNacimiento.Year;
        }
        else{
            edad = DateTime.Today.Year - fechaNacimiento.Year - 1;
        }
        return edad;

    }

    public bool comprobarSiPuedeVotar()
    {
        bool votar = false;
        if (edad >= 16)
        {
            votar = true;
        }
        return votar;
    }
}
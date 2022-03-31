using Ejercicios2y3Unidad8.Models.Entities;

namespace Ejercicios2y3Unidad8.Models.ViewModels
{
    public class PersonasViewModel
    {
        public List<clsPersona> personas;

        public PersonasViewModel()
        {
            personas = listaCompletaPersonas();
        }

        private List<clsPersona> listaCompletaPersonas()
        {
            List<clsPersona> ps = new List<clsPersona>()
            {
                new clsPersona()
                {
                    Id = 1,
                    Nombre = "Pepe",
                    Apellidos = "Jarilla",
                    FechaNac = DateTime.Parse("1997-05-09")
                },
 new clsPersona()
            {
                Id = 2,
                Nombre = "Juan",
                Apellidos = "Matasue",
                FechaNac = DateTime.Parse("1995-04-09")
            }
            };
            return ps;
        }

        public clsPersona SeleccionarPersona(int id)
        {
            clsPersona persona = new clsPersona();
            bool salir = false;
            for (int i = 0; i < personas.Count && !salir; i++)
            {
                if (personas[i].Id == id)
                {
                    persona = personas[i];
                    salir = true;
                }
            }
            return persona;
        }
    }
}

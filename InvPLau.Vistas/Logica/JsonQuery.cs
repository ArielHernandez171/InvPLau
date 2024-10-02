using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InvPLau.Vistas.Logica
{
    public class JsonQuery<T>
    {
        public string Rute;//la ruta de los archivos a guardar y obtener la lista de productos/clientes/servicios
        public List<T>? Prod;//aca se guarda los datos
        public JsonQuery(){//construtor vacio
            Rute = "";
            Prod = new List<T>();
        }
        public void Guardar()
        {
            string text = JsonSerializer.Serialize(Prod);//Serealiza los datos de la lista prod
            File.WriteAllText(Rute,text);//Guarda los datos de la lista prod ya serealizados
        }
        public void Cargar()
        {
            string text = File.ReadAllText(Rute);//se pasa del archvo al texto
            Prod = JsonSerializer.Deserialize<List<T>>(text);//se deserealiza los datos y se lo guarda en una lista

        }
    }
}

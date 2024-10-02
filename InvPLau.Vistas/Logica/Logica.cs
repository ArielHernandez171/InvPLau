using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvPLau.Vistas.Clases;
namespace InvPLau.Vistas.Logica
{
    public class Logica
    {
        public List<Legajo>? ObtenerLegajos()//se obtiene los legajos de los clientes
        {
            JsonQuery<Legajo> query = new JsonQuery<Legajo>();
            query.Rute = "Legajo.json";
            query.Cargar();
            return query.Prod;
        }
        public void ActualizarLegajos(Legajo legajo)
        {
            JsonQuery<Legajo> query = new JsonQuery<Legajo>();
            query.Rute = "Legajo.json";
            query.Cargar();//se cargan los legajos de los clientes
            query.Prod.Where(l => l.Id == legajo.Id).First().Name = legajo.Name;
            query.Prod.Where(l => l.Id == legajo.Id).First().SurName = legajo.SurName;
            query.Prod.Where(l => l.Id == legajo.Id).First().Images = legajo.Images;
            query.Prod.Where(l => l.Id == legajo.Id).First().Historial = legajo.Historial;//se hace los cambios
            query.Guardar();//se guarda los cambios

        }
        public void NuevoLegajo(Legajo legajo)
        {
            JsonQuery<Legajo> query = new JsonQuery<Legajo>();
            query.Rute = "Legajo.json";
            query.Cargar();
            query.Prod.Add(legajo);//se agrega un legajo de un cliente
            query.Guardar();//se guarda los cambios
        }
        public Legajo? BuscarLegajo(string Id)
        {
            if (ObtenerLegajos().Where(l => l.Id == Id).First() != null)
                return ObtenerLegajos().Where(l => l.Id == Id).First();//retorna el legajo de el cliente en base al id
            else
                return null;//si no existe el id buscado, retorna null
        }
        public void GuardarServicio(RegistroServs servs)
        {
            JsonQuery<RegistroServs> query = new JsonQuery<RegistroServs>();
            query.Rute = "registros.json";
            query.Cargar();
            List<RegistroServs> registros = query.Prod;//se agrega un nuevo servicio
            query.Prod.Add(servs);
            query.Guardar();//se guarda los cambios
        }
        public List<RegistroServs>? ObtenerServiDate(DateTime inicio, DateTime fin)
        {
            JsonQuery<RegistroServs> query = new JsonQuery<RegistroServs>();
            query.Rute = "registros.json";
            query.Cargar();
            List<RegistroServs> registros = query.Prod;
            return (from p in registros
                    where p.Fecha > inicio && p.Fecha < fin
                    select p).ToList();//se retorna una lista de servicios dados en de entre dos fechas
        }
        public void GuardarProd(Producto servs)
        {
            JsonQuery<Producto> query = new JsonQuery<Producto>();
            query.Rute = "Productos.json";
            query.Cargar();
            query.Prod.Add(servs);// se agrega un nuevo producto
            query.Guardar();//se guarda los datos
        }
        public void AddProd(ProdStock servs, string Nombre)
        {
            JsonQuery<Producto> query = new JsonQuery<Producto>();
            query.Rute = "Productos.json";
            query.Cargar();
            var p = query.Prod.Where(q => q.Productos == Nombre).First();
            if (p.Tipo == Tipo.Fifo)
                p.AddFifo(servs);
            else
                p.AddProm(servs);
            query.Guardar();
        }
        public void EliminarProd(Producto p)
        {
            JsonQuery<Producto> query = new JsonQuery<Producto>();
            query.Rute = "Productos.json";
            query.Cargar();
            query.Prod.Remove(p);//se elimina el producto
            query.Guardar();//se guarda los cambios
        }
        public List<Producto> ObtenerProductos()
        {
            JsonQuery<Producto> query = new JsonQuery<Producto>();
            query.Rute = "Productos.json";
            query.Cargar();
            return query.Prod;//retorna todos los productos
        }
    }
}

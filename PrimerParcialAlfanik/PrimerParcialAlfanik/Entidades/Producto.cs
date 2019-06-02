using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PrimerParcialAlfanik.Entidades
{
    public class Producto
    {
        [Key]

     public   int  ProductoId { get; set; } 
     public   string Descripcion { get; set; }
     public   int Existencia { get; set; }
     public   decimal Costo { get; set; }
     public   decimal ValorInventario { get; set; }

        public Producto()
        {
            ProductoId = 0;
            Descripcion = " ";
            Costo = 0;
            ValorInventario = 0;
        }

    }
}

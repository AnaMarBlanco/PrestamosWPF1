using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PrestamosWPF.Entidades
{
    class Moras
    {
        public int MoraId { get; set; }
        public DateTime Fecha{ get; set; }
        public decimal Total { get; set; }

        [ForeignKey("MoraId")]
        public virtual List<MorasDetalle> MoraDetalle { get; set; }

        public Moras()
        {
            MoraId = 0;
            Fecha = DateTime.Now;
            Total = 0;
            MoraDetalle = new List<MorasDetalle>();
        }
    }

}

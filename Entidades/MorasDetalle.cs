using System;
using System.Collections.Generic;
using System.Text;

namespace PrestamosWPF.Entidades
{
    class MorasDetalle
    {
        public int Id { get; set; }
        public int MoraId { get; set; }
        public int PrestamoId { get; set; }
        public decimal Valor { get; set; }

        public MorasDetalle()
        {
            Id = 0;
            MoraId = 0;
            PrestamoId = 0;
            Valor = 0;
        }

        public MorasDetalle(int id, int moraId, int prestamoId, decimal valor)
        {
            Id = id;
            MoraId = moraId;
            PrestamoId = prestamoId;
            Valor = valor;
        }
    }
}

using System;
using System.Collections.Generic;

namespace ProjetoLucas.Models
{
    public class Reserva
    {
        public int IdReserva { get; set; }
        public int IdHospede { get; set; }
        public int IdFilial { get; set; }
        public int NumeroQuarto { get; set; }
        public string TipoQuarto { get; set; }
        public DateTime DataCheckin { get; set; }
        public DateTime DataCheckout { get; set; }
        public decimal ValorDiaria { get; set; }
        public string Observacoes { get; set; }
        public string Status { get; set; }
    }

    public class ReservaCollection : List<Reserva> { }
}

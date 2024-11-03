﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace BackCine.Data.Entities;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public int IdTipoDoc { get; set; }

    public string NroDoc { get; set; }

    public DateTime FechaNac { get; set; }

    public int IdBarrio { get; set; }

    public string Calle { get; set; }

    public long Altura { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Practica04.Data.Models;

public partial class TPresupuesto
{
    public int Id { get; set; }

    public string Cliente { get; set; }

    public DateTime Fecha { get; set; }

    public int Vigencia { get; set; }

    public virtual ICollection<TDetallesPresupuesto> TDetallesPresupuestos { get; set; } = new List<TDetallesPresupuesto>();
}
﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace BackCine.Data;

public partial class Butaca
{
    public int IdButaca { get; set; }

    public int NroButaca { get; set; }

    public int Fila { get; set; }

    public int IdSala { get; set; }

    public virtual ICollection<ButacasReservada> ButacasReservada { get; set; } = new List<ButacasReservada>();

    public virtual ICollection<DetalleButaca> DetalleButacas { get; set; } = new List<DetalleButaca>();
}
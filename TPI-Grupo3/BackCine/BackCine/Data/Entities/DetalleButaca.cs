﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace BackCine.Data.Entities;

public partial class DetalleButaca
{
    public int IdButaca { get; set; }

    public int IdFuncion { get; set; }

    public int IdSala { get; set; }

    public virtual Butaca Butaca { get; set; }

    public virtual ICollection<DetallesCompra> DetallesCompras { get; set; } = new List<DetallesCompra>();

    public virtual Funcione IdFuncionNavigation { get; set; }
}
﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BackCine.Data.Entities;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Email { get; set; }

    public string Contrasenha { get; set; }

    public string Rol { get; set; }

    public int IdCliente { get; set; }

    public bool? Estado { get; set; }
    [JsonIgnore]
    public virtual Cliente IdClienteNavigation { get; set; }
}
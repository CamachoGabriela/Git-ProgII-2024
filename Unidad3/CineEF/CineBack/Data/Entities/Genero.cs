﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CineBack.Data.Entities;

public partial class Genero
{
    public int Id { get; set; }

    public string Nombre { get; set; }
    [JsonIgnore]
    public virtual ICollection<Pelicula> Peliculas { get; set; } = new List<Pelicula>();
}
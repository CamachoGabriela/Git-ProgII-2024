﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace BackCine.Data;

public partial class Pelicula
{
    public int IdPelicula { get; set; }

    public string Titulo { get; set; }

    public TimeOnly Duracion { get; set; }

    public string ApellidoDirector { get; set; }

    public string NombreDirector { get; set; }

    public string ApellidoActor { get; set; }

    public string NombreActor { get; set; }

    public int IdTipoPelicula { get; set; }

    public int IdCalificacion { get; set; }

    public int IdDistribuidor { get; set; }

    public bool EstaActivo { get; set; }

    public int IdPais { get; set; }

    public virtual ICollection<Funcione> Funciones { get; set; } = new List<Funcione>();

    public virtual TiposPelicula IdTipoPeliculaNavigation { get; set; }
}
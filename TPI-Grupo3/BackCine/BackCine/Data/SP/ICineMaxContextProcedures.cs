﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using BackCine.Data.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace BackCine.Data.Entities
{
    public partial interface ICineMaxContextProcedures
    {
        Task<List<pa_analisis_ocupacionResult>> pa_analisis_ocupacionAsync(DateTime? fecha1, DateTime? fecha2, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<PA_CONSULTA_CLIENTEResult>> PA_CONSULTA_CLIENTEAsync(string nombre, string apellido, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> pa_verificar_disponibilidadAsync(string pelicula, DateTime? fecha, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}
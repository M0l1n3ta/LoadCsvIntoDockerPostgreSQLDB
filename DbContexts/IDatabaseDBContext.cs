// <copyright file="IRutileDbContext.cs" company="M0l1n3ta">
// Copyright (c) Molinetai All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using loadCsvIntoDockerPostgreSQLDB.Entities;

namespace loadCsvIntoDockerPostgreSQLDB.DbContexts;

public interface IDatabaseDBContext 
{
    /// <summary>
    /// Gets or sets set of entities of type Alarm.
    /// </summary>
    DbSet<Vendor> Vendors { get; set; }

}
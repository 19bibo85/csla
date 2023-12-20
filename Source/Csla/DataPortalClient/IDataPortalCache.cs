﻿//-----------------------------------------------------------------------
// <copyright file="IDataPortalCache.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: https://cslanet.com
// </copyright>
// <summary>Defines interface for a client-side cache service</summary>
//-----------------------------------------------------------------------
using System;
using System.Threading.Tasks;

namespace Csla.DataPortalClient
{
  /// <summary>
  /// Defines interface for a client-side cache service
  /// used by the create and fetch operations in the
  /// client-side data portal.
  /// </summary>
  public interface IDataPortalCache
  {
    /// <summary>
    /// Try to get object from cache.
    /// </summary>
    /// <param name="objectType">Type of domain object to retrieve</param>
    /// <param name="criteria">Criteria for domain type being retrieved</param>
    /// <param name="operation">Data portal operation</param>
    /// <param name="result">Cached data portal result</param>
    /// <returns>true if success, false if object isn't returned</returns>
    Task<bool> TryGetObject(Type objectType, object criteria, DataPortalOperations operation, out Server.DataPortalResult result);
    /// <summary>
    /// Add object to cache.
    /// </summary>
    /// <param name="objectType">Type of domain object to add</param>
    /// <param name="criteria">Criteria for domain type being added</param>
    /// <param name="operation">Data portal operation</param>
    /// <param name="result">Data portal result to cache</param>
    /// <returns></returns>
    Task AddObject(Type objectType, object criteria, DataPortalOperations operation, Server.DataPortalResult result);
  }
}

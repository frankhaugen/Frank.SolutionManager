﻿// Copyright (c) Microsoft Corporation.
//
// Licensed under the MIT license.

namespace Frank.SolutionManager.Internals;

/// <summary>
/// Represents a generic equality comparer.
/// </summary>
/// <typeparam name="T">The type of the objects that will be compared.</typeparam>
internal sealed class EqualityComparer<T> : IEqualityComparer<T>
{
    private readonly Func<T, T, bool> _equals;
    private readonly Func<T, int> _getHashCode;

    /// <summary>
    /// Initializes a new instance of the <see cref="EqualityComparer{T}"/> class.
    /// </summary>
    /// <param name="equals">A <see cref="Func{T1,T2,TResult}" /> to use for comparing objects.</param>
    internal EqualityComparer(Func<T, T, bool> equals)
        : this(equals, arg => arg.GetHashCode())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EqualityComparer{T}"/> class.
    /// </summary>
    /// <param name="equals">A <see cref="Func{T1,T2,TResult}" /> to use for comparing objects.</param>
    /// <param name="getHashCode">A <see cref="Func{T1,TResult}" /> to use when getting the hashcode of an object.</param>
    internal EqualityComparer(Func<T, T, bool> equals, Func<T, int> getHashCode)
    {
        _equals = equals;
        _getHashCode = getHashCode;
    }

    /// <inheritdoc/>
    public bool Equals(T x, T y)
    {
        return _equals(x, y);
    }

    /// <inheritdoc/>
    public int GetHashCode(T obj)
    {
        return _getHashCode(obj);
    }
}
﻿// Copyright (c) Ullrich Praetz - https://github.com/friflo. All rights reserved.
// See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.InteropServices;
using static System.Diagnostics.DebuggerBrowsableState;
using Browse = System.Diagnostics.DebuggerBrowsableAttribute;

// ReSharper disable once CheckNamespace
namespace Friflo.Engine.ECS;

[ComponentKey("scl3")]
[StructLayout(LayoutKind.Explicit)]
public struct Scale3Cmp : IComponent, IEquatable<Scale3Cmp>
{
    [Browse(Never)]
    [FieldOffset(0)] public     Vector3 value;  // 12
    //
    [FieldOffset(0)] public     float   x;      // (4)
    [FieldOffset(4)] public     float   y;      // (4)
    [FieldOffset(8)] public     float   z;      // (4)

    public readonly override string ToString() => $"{x}, {y}, {z}";

    public Scale3Cmp (float x, float y, float z) {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    
    public          bool    Equals      (Scale3Cmp other)                  => value == other.value;
    public static   bool    operator == (in Scale3Cmp p1, in Scale3Cmp p2)    => p1.value == p2.value;
    public static   bool    operator != (in Scale3Cmp p1, in Scale3Cmp p2)    => p1.value != p2.value;

    [ExcludeFromCodeCoverage] public override   int     GetHashCode()       => throw new NotImplementedException("to avoid boxing");
    [ExcludeFromCodeCoverage] public override   bool    Equals(object obj)  => throw new NotImplementedException("to avoid boxing");
}
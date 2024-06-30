﻿// Copyright (c) Ullrich Praetz - https://github.com/friflo. All rights reserved.
// See LICENSE file in the project root for full license information.


using System.Collections;
using System.Collections.Generic;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Friflo.Engine.ECS;

/// <summary>
/// Contains the relation components of a specific entity returned by <see cref="RelationExtensions.GetRelations{TComponent}"/>.
/// </summary>
internal readonly struct RelationComponents<TComponent> : IEnumerable<TComponent>
    where TComponent : struct, IComponent
{
    public   override   string          ToString()  => $"Relations<{typeof(TComponent).Name}>[{Length}]";
    /// <summary>
    /// Return the number of relation components.<br/>
    /// Executes in O(1).
    /// </summary>
    public   readonly   int             Length;     //  4
    internal readonly   int             start;      //  4
    internal readonly   int[]           positions;  //  8
    internal readonly   TComponent[]    components; //  8
    internal readonly   int             position;   //  4
    
    internal RelationComponents(TComponent[] components, int[] positions, int start, int length)
    {
        this.components = components;
        this.positions  = positions;
        this.start      = start;
        Length          = length;
    }
   
    internal RelationComponents(TComponent[] components, int position) {
        this.components = components;
        this.position   = position;
        Length          = 1;
    }
    
    /// <summary>
    /// Return the relation component at the given <paramref name="index"/>.<br/>
    /// Executes in O(1).
    /// </summary>
    public TComponent this[int index] => components[positions != null ? positions[index] : position];
       
    // --- IEnumerable<>
    IEnumerator<TComponent>   IEnumerable<TComponent>.GetEnumerator() => new RelationsEnumerator<TComponent>(this);
    
    // --- IEnumerable
    IEnumerator                           IEnumerable.GetEnumerator() => new RelationsEnumerator<TComponent>(this);
    
    // --- new
    public RelationsEnumerator<TComponent>          GetEnumerator() => new RelationsEnumerator<TComponent>(this);
}


internal struct RelationsEnumerator<TComponent> : IEnumerator<TComponent>
    where TComponent : struct, IComponent
{
    private  readonly   int[]           positions;
    private  readonly   int             position;
    private  readonly   TComponent[]    components;
    private  readonly   int             start;
    private  readonly   int             last;
    private             int             index;
    
    
    internal RelationsEnumerator(in RelationComponents<TComponent> relations) {
        positions   = relations.positions;
        position    = relations.position;
        components  = relations.components;
        start       = relations.start - 1;
        last        = start + relations.Length;
        index       = start;
    }
    
    // --- IEnumerator<>
    public readonly TComponent Current   => components[positions != null ? positions[index] : position];
    
    // --- IEnumerator
    public bool MoveNext() {
        if (index < last) {
            index++;
            return true;
        }
        return false;
    }

    public void Reset() {
        index = start;
    }
    
    object IEnumerator.Current => components[positions != null ? positions[index] : position];

    // --- IDisposable
    public void Dispose() { }
}
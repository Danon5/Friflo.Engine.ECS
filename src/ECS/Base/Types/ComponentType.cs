﻿// Copyright (c) Ullrich Praetz - https://github.com/friflo. All rights reserved.
// See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics.CodeAnalysis;
using static Friflo.Engine.ECS.SchemaTypeKind;

// ReSharper disable ConvertToPrimaryConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Friflo.Engine.ECS;

/// <summary>
/// Provide meta data for an <see cref="IComponent"/> struct.
/// </summary>
public abstract class ComponentType : SchemaType, IComparable<ComponentType>
{
#region fields
    /// <summary> The index in <see cref="EntitySchema"/>.<see cref="EntitySchema.Components"/>. </summary>
    public   readonly   int         StructIndex;    //  4
    /// <summary> Return true if <see cref="IComponent"/>'s of this type can be copied. </summary>
    public   readonly   bool        IsBlittable;    //  4
    /// <summary> The size in bytes of the <see cref="IComponent"/> struct. </summary>
    public   readonly   int         StructSize;     //  4
    
    public   readonly   Type        IndexType;      //  8
    
    internal readonly   Type        IndexValueType; //  8
    
    internal readonly   Type        RelationType;   //  8
    
    internal readonly   Type        RelationKeyType;//  8
    
    internal            int         nameSortOrder;  //  4
    #endregion

#region methods
    internal abstract   StructHeap              CreateHeap();
    [ExcludeFromCodeCoverage] internal virtual  bool RemoveEntityComponent  (Entity entity)                 => throw new InvalidOperationException();
    [ExcludeFromCodeCoverage] internal virtual  bool AddEntityComponent     (Entity entity)                 => throw new InvalidOperationException();
    [ExcludeFromCodeCoverage] internal virtual  bool AddEntityComponentValue(Entity entity, object value)   => throw new InvalidOperationException();
    
    
    [ExcludeFromCodeCoverage] internal virtual  BatchComponent      CreateBatchComponent()                  => throw new InvalidOperationException();
    [ExcludeFromCodeCoverage] internal virtual  ComponentCommands   CreateComponentCommands()               => throw new InvalidOperationException();
    
    internal ComponentType(string componentKey, int structIndex, Type type, Type indexType, Type indexValueType, int byteSize, Type relationType, Type keyType)
        : base (componentKey, type, Component)
    {
        StructIndex     = structIndex;
        IsBlittable     = GetBlittableType(type, true) == BlittableType.Blittable;
        StructSize      = byteSize;
        IndexType       = indexType;
        IndexValueType  = indexValueType;
        RelationType    = relationType;
        RelationKeyType = keyType;
    }
    #endregion

    public int CompareTo(ComponentType other) {
        return nameSortOrder - other.nameSortOrder;
    }
}

internal static class StructInfo<T>
    where T : struct
{
    // --- static internal
    // Check initialization by directly calling unit test method: Test_SchemaType.Test_SchemaType_StructIndex()
    // readonly improves performance significant
    internal static readonly    int     Index       = SchemaTypeUtils.GetStructIndex(typeof(T));
    
    internal static readonly    bool    HasIndex    = SchemaTypeUtils.HasIndex(typeof(T));
    
    // internal static readonly    bool    IsRelation  = SchemaTypeUtils.IsRelation(typeof(T)); obsolete property
}

internal sealed class ComponentType<T> : ComponentType
    where T : struct, IComponent
{
#region properties
    public   override   string          ToString()  => $"Component: [{typeof(T).Name}]";
    #endregion

    internal ComponentType(string componentKey, int structIndex, Type indexType, Type indexValueType)
        : base(componentKey, structIndex, typeof(T), indexType, indexValueType, StructPadding<T>.ByteSize, null, null)
    {
    }
    
    internal override bool RemoveEntityComponent(Entity entity) {
        return entity.RemoveComponent<T>();
    }
    
    internal override bool AddEntityComponent(Entity entity) {
        return entity.AddComponent<T>(default);
    }
    
    internal override bool AddEntityComponentValue(Entity entity, object value) {
        var componentValue = (T)value;
        return entity.AddComponent(componentValue);
    }
    
    internal override StructHeap CreateHeap() {
        return new StructHeap<T>(StructIndex);
    }
    
    internal override ComponentCommands CreateComponentCommands()
    {
        return new ComponentCommands<T>(StructIndex, IndexType) {
            componentCommands = new ComponentCommand<T>[8]
        };
    }
    
    internal override BatchComponent CreateBatchComponent() => new BatchComponent<T>();
}

internal sealed class RelationType<T> : ComponentType
    where T : struct, IRelation
{
    #region properties
    public   override   string          ToString()  => $"Relation: [{typeof(T).Name}]";
    #endregion
    

    
    internal RelationType(string componentKey, int structIndex, Type relationType, Type keyType)
        : base(componentKey, structIndex, typeof(T), null, null, StructPadding<T>.ByteSize, relationType, keyType)
    {
    }
    
    internal override StructHeap CreateHeap() {
        return new StructHeap<T>(StructIndex);
    }
}

﻿// Copyright (c) Ullrich Praetz - https://github.com/friflo. All rights reserved.
// See LICENSE file in the project root for full license information.

using System;

// ReSharper disable once CheckNamespace
namespace Friflo.Engine.ECS;

public partial class EntityStoreBase
{
    /// <summary>
    /// Return the entity with a <see cref="UniqueEntityCmp"/> component and its <see cref="UniqueEntityCmp.uid"/> == <paramref name="uid"/>.<br/>
    /// See <a href="https://friflo.gitbook.io/friflo.engine.ecs/documentation/entity#unique-entity">Example.</a>
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// In case none or more than one <see cref="UniqueEntityCmp"/> with the given <paramref name="uid"/> found.
    /// </exception>
    /// <remarks>
    /// To Get all <see cref="UniqueEntityCmp"/>'s of the store use <see cref="UniqueEntities"/>.
    /// </remarks>
    public Entity GetUniqueEntity(string uid)
    {
        // var index    = internBase.uniqueEntityIndex ??= CreateUniqueEntityIndex();
        // var entities = index.GetHasValueEntities(uid);
        var index = ((EntityStore)this).ComponentIndex<UniqueEntityCmp, string>();
        var entities = index[uid];
        switch (entities.Count) {
            case 1:
                return entities[0];
            case 0:
                throw FoundNoUniqueEntity(uid);
            default:
                throw MultipleEntitiesWithSameName(uid);
        }
    }
    
    private QueryEntities GetUniqueEntities()
    {
        var query = internBase.uniqueEntityQuery ??= CreateUniqueEntityQuery();
        return query.Entities;
    }
    
    private ArchetypeQuery<UniqueEntityCmp> CreateUniqueEntityQuery() => Query<UniqueEntityCmp>().WithDisabled();
    
    private static InvalidOperationException FoundNoUniqueEntity(string name) {
        return new InvalidOperationException($"found no {nameof(UniqueEntityCmp)} with uid: \"{name}\"");
    }

    private static InvalidOperationException MultipleEntitiesWithSameName(string uid) {
        return new InvalidOperationException($"found multiple {nameof(UniqueEntityCmp)}'s with uid: \"{uid}\"");
    }
}

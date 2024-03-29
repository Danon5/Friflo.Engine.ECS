﻿// ﻿// Copyright (c) Ullrich Praetz - https://github.com/friflo. All rights reserved.
// See LICENSE file in the project root for full license information.


// ReSharper disable UseNullPropagation
// ReSharper disable ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable once CheckNamespace
namespace Friflo.Engine.ECS;

public partial struct  Entity
{
    public void Add<T1>(
        in T1   component1,
        in Tags tags = default)
            where T1 : struct, IComponent
    {
        var oldType         = archetype;
        var oldCompIndex    = compIndex;
        var bitSet          = oldType.componentTypes.bitSet;
        bitSet.SetBit(StructHeap<T1>.StructIndex);
        var newType         = store.GetArchetypeWithTagsAdd(bitSet, oldType, tags);
        StashComponents(store, newType, oldType, oldCompIndex);

        var newCompIndex    = refCompIndex = Archetype.MoveEntityTo(oldType, Id, oldCompIndex, newType);
        refArchetype        = newType;
        var heapMap         = newType.heapMap;
        ((StructHeap<T1>)heapMap[StructHeap<T1>.StructIndex]).components[newCompIndex] = component1;
        
        // Send event. See: SEND_EVENT notes
        SendAddEvents(store, Id, newType, oldType);
    }
    
    public void Add<T1, T2>(
        in T1   component1,
        in T2   component2,
        in Tags tags = default)
            where T1 : struct, IComponent
            where T2 : struct, IComponent
    {
        var oldType         = archetype;
        var oldCompIndex    = compIndex;
        var bitSet          = oldType.componentTypes.bitSet;
        bitSet.SetBit(StructHeap<T1>.StructIndex);
        bitSet.SetBit(StructHeap<T2>.StructIndex);
        var newType         = store.GetArchetypeWithTagsAdd(bitSet, oldType, tags);
        StashComponents(store, newType, oldType, oldCompIndex);

        var newCompIndex    = refCompIndex = Archetype.MoveEntityTo(oldType, Id, oldCompIndex, newType);
        refArchetype        = newType;
        var heapMap         = newType.heapMap;
        ((StructHeap<T1>)heapMap[StructHeap<T1>.StructIndex]).components[newCompIndex] = component1;
        ((StructHeap<T2>)heapMap[StructHeap<T2>.StructIndex]).components[newCompIndex] = component2;
        
        // Send event. See: SEND_EVENT notes
        SendAddEvents(store, Id, newType, oldType);
    }
    
    public void Add<T1, T2, T3>(
        in T1   component1,
        in T2   component2,
        in T3   component3,
        in Tags tags = default)
            where T1 : struct, IComponent
            where T2 : struct, IComponent
            where T3 : struct, IComponent
    {
        var oldType         = archetype;
        var oldCompIndex    = compIndex;
        var bitSet          = oldType.componentTypes.bitSet;
        bitSet.SetBit(StructHeap<T1>.StructIndex);
        bitSet.SetBit(StructHeap<T2>.StructIndex);
        bitSet.SetBit(StructHeap<T3>.StructIndex);
        var newType         = store.GetArchetypeWithTagsAdd(bitSet, oldType, tags);
        StashComponents(store, newType, oldType, oldCompIndex);

        var newCompIndex    = refCompIndex = Archetype.MoveEntityTo(oldType, Id, oldCompIndex, newType);
        refArchetype        = newType;
        var heapMap         = newType.heapMap;
        ((StructHeap<T1>)heapMap[StructHeap<T1>.StructIndex]).components[newCompIndex] = component1;
        ((StructHeap<T2>)heapMap[StructHeap<T2>.StructIndex]).components[newCompIndex] = component2;
        ((StructHeap<T3>)heapMap[StructHeap<T3>.StructIndex]).components[newCompIndex] = component3;
        
        // Send event. See: SEND_EVENT notes
        SendAddEvents(store, Id, newType, oldType);
    }
    
    public void Add<T1, T2, T3, T4>(
        in T1   component1,
        in T2   component2,
        in T3   component3,
        in T4   component4,
        in Tags tags = default)
            where T1 : struct, IComponent
            where T2 : struct, IComponent
            where T3 : struct, IComponent
            where T4 : struct, IComponent
    {
        var oldType         = archetype;
        var oldCompIndex    = compIndex;
        var bitSet          = oldType.componentTypes.bitSet;
        bitSet.SetBit(StructHeap<T1>.StructIndex);
        bitSet.SetBit(StructHeap<T2>.StructIndex);
        bitSet.SetBit(StructHeap<T3>.StructIndex);
        bitSet.SetBit(StructHeap<T4>.StructIndex);
        var newType         = store.GetArchetypeWithTagsAdd(bitSet, oldType, tags);
        StashComponents(store, newType, oldType, oldCompIndex);

        var newCompIndex    = refCompIndex = Archetype.MoveEntityTo(oldType, Id, oldCompIndex, newType);
        refArchetype        = newType;
        var heapMap         = newType.heapMap;
        ((StructHeap<T1>)heapMap[StructHeap<T1>.StructIndex]).components[newCompIndex] = component1;
        ((StructHeap<T2>)heapMap[StructHeap<T2>.StructIndex]).components[newCompIndex] = component2;
        ((StructHeap<T3>)heapMap[StructHeap<T3>.StructIndex]).components[newCompIndex] = component3;
        ((StructHeap<T4>)heapMap[StructHeap<T4>.StructIndex]).components[newCompIndex] = component4;
        
        // Send event. See: SEND_EVENT notes
        SendAddEvents(store, Id, newType, oldType);
    }
    
    public void Add<T1, T2, T3, T4, T5>(
        in T1   component1,
        in T2   component2,
        in T3   component3,
        in T4   component4,
        in T5   component5,
        in Tags tags = default)
            where T1 : struct, IComponent
            where T2 : struct, IComponent
            where T3 : struct, IComponent
            where T4 : struct, IComponent
            where T5 : struct, IComponent
    {
        var oldType         = archetype;
        var oldCompIndex    = compIndex;
        var bitSet          = oldType.componentTypes.bitSet;
        bitSet.SetBit(StructHeap<T1>.StructIndex);
        bitSet.SetBit(StructHeap<T2>.StructIndex);
        bitSet.SetBit(StructHeap<T3>.StructIndex);
        bitSet.SetBit(StructHeap<T4>.StructIndex);
        bitSet.SetBit(StructHeap<T5>.StructIndex);
        var newType         = store.GetArchetypeWithTagsAdd(bitSet, oldType, tags);
        StashComponents(store, newType, oldType, oldCompIndex);

        var newCompIndex    = refCompIndex = Archetype.MoveEntityTo(oldType, Id, oldCompIndex, newType);
        refArchetype        = newType;
        var heapMap         = newType.heapMap;
        ((StructHeap<T1>)heapMap[StructHeap<T1>.StructIndex]).components[newCompIndex] = component1;
        ((StructHeap<T2>)heapMap[StructHeap<T2>.StructIndex]).components[newCompIndex] = component2;
        ((StructHeap<T3>)heapMap[StructHeap<T3>.StructIndex]).components[newCompIndex] = component3;
        ((StructHeap<T4>)heapMap[StructHeap<T4>.StructIndex]).components[newCompIndex] = component4;
        ((StructHeap<T5>)heapMap[StructHeap<T5>.StructIndex]).components[newCompIndex] = component5;
        
        // Send event. See: SEND_EVENT notes
        SendAddEvents(store, Id, newType, oldType);
    }
    
    private static void StashComponents(EntityStoreBase store, Archetype newType, Archetype oldType, int oldCompIndex)
    {
        if (store.ComponentAdded == null) {
            return;
        }
        var oldHeapMap = oldType.heapMap;
        foreach (var newHeap in newType.structHeaps) {
            var oldHeap = oldHeapMap[newHeap.structIndex];
            if (oldHeap == null) {
                continue;
            }
            oldHeap.StashComponent(oldCompIndex);
        }
    }
    
    private static void SendAddEvents(EntityStoreBase store, int id, Archetype newType, Archetype oldType)
    {
        // --- tag event
        var tagsChanged = store.TagsChanged;
        if (tagsChanged != null && !newType.tags.bitSet.Equals(oldType.Tags.bitSet)) {
            tagsChanged(new TagsChanged(store, id, newType.tags, oldType.Tags));
        }
        // --- component events 
        var componentAdded = store.ComponentAdded;
        if (componentAdded == null) {
            return;
        }
        var heaps = newType.structHeaps;
        for (int n = 0; n < heaps.Length; n++)
        {
            var structIndex = heaps[n].structIndex;
            ComponentChangedAction action;
            StructHeap oldHeap;
            if (oldType.componentTypes.bitSet.Has(structIndex)) {
                action = ComponentChangedAction.Update;
                oldHeap = oldType.heapMap[structIndex];
            } else {
                action  = ComponentChangedAction.Add;
                oldHeap = null;
            }
            componentAdded(new ComponentChanged (store, id, action, structIndex, oldHeap));    
        }
    }
} 
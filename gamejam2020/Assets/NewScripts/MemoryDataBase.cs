using System.Collections.Generic;
using UnityEngine;

public class MemoryDataBase : MonoBehaviour
{
    public List<Memory> memories = new List<Memory>();

    private void Awake()
    {
       // BuildDataBase();
    }

    public Memory GetMemory(int id)
    {
        return memories.Find(memory => memory.order == id);
    }

    void addToDataBase(Memory memory)
    {
        memories.Add(memory);
    }

    //void BuildDataBase()
    //{
    //    memories = new List<Memory>() {
    //        new Memory(1, "Memory 1"),
    //        new Memory(2, "Memory 2"),
    //        new Memory(3, "Memory 3"),
    //        new Memory(1, "Memory 4"),
    //        new Memory(2, "Memory 5")
    //    };
    //}
}

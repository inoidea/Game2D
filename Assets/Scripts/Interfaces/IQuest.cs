using System;
using UnityEngine;

namespace PlatformerMVC
{
    public interface IQuest : IDisposable
    {
        event EventHandler<IQuest> QuestCompleted;

        bool IsCompleted { get; }

        void Reset();
    }
}
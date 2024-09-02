// Decompiled with JetBrains decompiler
// Type: NGProfiler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;
using UnityEngine.Profiling;

public class NGProfiler : Singleton<NGProfiler>
{
  protected override void Initialize()
  {
  }

  private string AddComma(uint value)
  {
    char[] array = value.ToString().Reverse<char>().ToArray<char>();
    List<string> self = new List<string>();
    for (; array.Length != 0; array = ((IEnumerable<char>) array).Skip<char>(3).ToArray<char>())
      self.Add(((IEnumerable<char>) array).Take<char>(3).Reverse<char>().ToStringForChars());
    self.Reverse();
    return self.Join(",");
  }

  private void OnGUI()
  {
    GUILayout.Space(5f);
    GUIStyle styleLeft = new GUIStyle();
    styleLeft.alignment = TextAnchor.UpperLeft;
    styleLeft.fixedWidth = 150f;
    styleLeft.normal.textColor = Color.white;
    GUIStyle styleRight = new GUIStyle();
    styleRight.alignment = TextAnchor.UpperRight;
    styleRight.fixedWidth = 120f;
    styleRight.normal.textColor = Color.white;
    System.Action<string, uint> action = (System.Action<string, uint>) ((text, value) =>
    {
      GUILayout.BeginHorizontal((GUIStyle) "box");
      GUILayout.Label(text, styleLeft);
      GUILayout.Label(this.AddComma(value), styleRight);
      GUILayout.EndHorizontal();
    });
    action("Used Heap Size:", Profiler.usedHeapSize);
    action("Mono Used Size:", Profiler.GetMonoUsedSize());
    action("Mono Heap Size:", Profiler.GetMonoHeapSize());
    action("Total Allocated Memory:", Profiler.GetTotalAllocatedMemory());
    action("Total Reserved Memory:", Profiler.GetTotalReservedMemory());
    action("Total Unused Reserved Memory:", Profiler.GetTotalUnusedReservedMemory());
    action("System.GC.GetTotalMemory():", (uint) GC.GetTotalMemory(false));
    action("SystemInfo.systemMemorySize:", (uint) (SystemInfo.systemMemorySize * 1024 * 1024));
  }
}

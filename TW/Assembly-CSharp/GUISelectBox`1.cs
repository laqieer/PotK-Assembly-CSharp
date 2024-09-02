// Decompiled with JetBrains decompiler
// Type: GUISelectBox`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
public class GUISelectBox<T>
{
  private readonly string title;
  private readonly T[] options;
  private readonly string[] labels;
  private Vector2 scrollPosition;
  private bool toggle;
  private int selectedIndex;

  public GUISelectBox(string title_, T[] options_, Func<T, string> toLabel)
  {
    this.title = title_;
    this.toggle = false;
    this.selectedIndex = 0;
    this.options = options_;
    this.labels = ((IEnumerable<T>) this.options).Select<T, string>((Func<T, string>) (x => toLabel(x))).ToArray<string>();
    if (((IEnumerable<T>) this.options).Count<T>() != 0)
      return;
    Debug.LogError((object) "option is empty");
  }

  public T Render(Action<T> changeCallback = null)
  {
    return changeCallback == null ? this.RenderWithIndex() : this.RenderWithIndex((Action<int, T>) ((_, val) => changeCallback(val)));
  }

  public T RenderWithIndex(Action<int, T> changeCallback = null)
  {
    if (this.toggle)
    {
      if (GUILayout.Button("back", new GUILayoutOption[1]
      {
        GUILayout.Width(120f)
      }))
        this.toggle = false;
      this.scrollPosition = GUILayout.BeginScrollView(this.scrollPosition, false, false, new GUILayoutOption[2]
      {
        GUILayout.Width(600f),
        GUILayout.Height(800f)
      });
      int num = GUILayout.SelectionGrid(this.selectedIndex, this.labels, 1, new GUILayoutOption[1]
      {
        GUILayout.Width(500f)
      });
      GUILayout.EndScrollView();
      if (num != this.selectedIndex)
      {
        this.selectedIndex = num;
        this.toggle = false;
        if (changeCallback != null)
          changeCallback(this.selectedIndex, this.Value());
      }
    }
    else
      this.toggle = GUILayout.Toggle(this.toggle, this.title + " " + this.labels[this.selectedIndex], new GUILayoutOption[0]);
    return this.Value();
  }

  public T Value() => this.options[this.selectedIndex];

  public void setSelected(int i) => this.selectedIndex = i;
}

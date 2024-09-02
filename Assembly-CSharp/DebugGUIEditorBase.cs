// Decompiled with JetBrains decompiler
// Type: DebugGUIEditorBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public abstract class DebugGUIEditorBase : MonoBehaviour
{
  protected bool isWaitEnd_;

  [Conditional("_ENABLE_DEBUG_WINDOW")]
  protected void setActionOnClosed(System.Action act)
  {
  }

  protected virtual DebugGUIEditorBase.WindowParam[] windowSettings { get; }

  protected void exitDebug()
  {
  }

  protected string stringParam(string str) => (string) null;

  protected int convNullableToInt(int? v) => 0;

  protected int? convIntToNullable(int i) => new int?();

  protected void beginBlock(string title)
  {
  }

  protected void drawLabel(string label)
  {
  }

  protected void drawValueLine<T>(T value, string label = null)
  {
  }

  protected void drawValueLine(int? n, string label = null)
  {
  }

  protected void drawTextLine(string text, string label = null)
  {
  }

  protected void endBlock()
  {
  }

  protected T editValue<T>(T value, string name, params T[] ts) => (T) null;

  protected T selectValue<T>(
    T value,
    T[] values,
    string name,
    string[] options = null,
    System.Action<T> onChanged = null)
  {
    return (T) null;
  }

  protected void drawLineSpace()
  {
  }

  protected static T deepClone<T>(T src) => (T) null;

  protected static void copyFieldValueTypes<T>(T des, T src, HashSet<string> ignores = null)
  {
  }

  protected struct WindowParam
  {
    public string name_;
    public System.Action<int> edit_;
    public System.Action<int> onStart_;
    public System.Action<int> onEnd_;

    public WindowParam(
      System.Action<int> funcStart,
      System.Action<int> funcEdit,
      System.Action<int> funcEnd,
      string name)
      : this()
    {
      this.name_ = name;
      this.edit_ = funcEdit;
      this.onStart_ = funcStart;
      this.onEnd_ = funcEnd;
    }
  }
}

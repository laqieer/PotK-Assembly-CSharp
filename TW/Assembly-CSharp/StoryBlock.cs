﻿// Decompiled with JetBrains decompiler
// Type: StoryBlock
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore.LispCore;

#nullable disable
public class StoryBlock
{
  public string label;
  public ScriptBlock script = new ScriptBlock();
  public TextBlock text = new TextBlock();
  public SelectBlock select;
  public bool next_enable = true;

  public void addScript(string func, Cons args) => this.script.add(func, args);

  public void addScriptBody(Cons body) => this.script.add(body);

  public void setText(string t) => this.text.setText(t);

  public void addText(string t) => this.text.addText(t);

  public string getText() => this.text.text;

  public void setSelect(SelectBlock sb) => this.select = sb;

  public void setSelectIndex(int index)
  {
    if (this.select == null)
      return;
    this.select.selected = index;
  }

  public void eval(Lisp engine) => this.script.eval(engine);
}

// Decompiled with JetBrains decompiler
// Type: StoryBlock
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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

  public void setText(string t) => this.text.text = t;

  public void addText(string t) => this.text.text += t;

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

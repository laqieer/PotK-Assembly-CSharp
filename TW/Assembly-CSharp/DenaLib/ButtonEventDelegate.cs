// Decompiled with JetBrains decompiler
// Type: DenaLib.ButtonEventDelegate
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine.Events;
using UnityEngine.UI;

#nullable disable
namespace DenaLib
{
  public class ButtonEventDelegate
  {
    private LuaManager m_LuaManager;
    public string m_UIName = string.Empty;
    public Button m_Button;
    public UnityAction m_Action;

    public ButtonEventDelegate(
      LuaManager luaManager,
      string UIName,
      Button button,
      UnityAction action)
    {
      this.m_LuaManager = luaManager;
      this.m_UIName = UIName;
      this.m_Button = button;
      this.m_Action = action;
      // ISSUE: method pointer
      ((UnityEvent) this.m_Button.onClick).AddListener(new UnityAction((object) this, __methodptr(ButtonClick)));
    }

    private void ButtonClick()
    {
    }
  }
}

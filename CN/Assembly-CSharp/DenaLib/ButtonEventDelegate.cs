// Decompiled with JetBrains decompiler
// Type: DenaLib.ButtonEventDelegate
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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

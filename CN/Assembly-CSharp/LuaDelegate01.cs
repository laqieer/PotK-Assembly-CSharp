// Decompiled with JetBrains decompiler
// Type: LuaDelegate01
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using UnityEngine;

#nullable disable
public class LuaDelegate01 : MonoBehaviour
{
  private string script = "                  \r\n            function DoClick1(go)\r\n                print('click1 on ', go.name)\r\n            end\r\n\r\n            function DoClick2(go)\r\n                print('click2 on ', go.name)\r\n            end\r\n            \r\n            local click2 = nil\r\n\r\n            function AddDelegate(listener)                     \r\n                listener.OnClick = DoClick1\r\n                click2 = DelegateFactory.Action_GameObject(DoClick2)                \r\n                listener.OnClick = listener.OnClick + click2                                    \r\n            end\r\n\r\n            function RemoveDelegate(listener)                \r\n                listener.OnClick = listener.OnClick - click2       \r\n                return delegate         \r\n            end\r\n    ";

  private void Start()
  {
    LuaScriptMgr luaScriptMgr = new LuaScriptMgr();
    luaScriptMgr.Start();
    TestEventListenerWrap.Register(luaScriptMgr.GetL());
    luaScriptMgr.DoString(this.script);
    GameObject gameObject = new GameObject("TestGo");
    TestEventListener testEventListener = (TestEventListener) gameObject.AddComponent(typeof (TestEventListener));
    LuaFunction luaFunction1 = luaScriptMgr.GetLuaFunction("AddDelegate");
    luaFunction1.Call((object) testEventListener);
    testEventListener.OnClick(gameObject);
    luaFunction1.Release();
    Debug.Log((object) "---------------------------------------------------------------------");
    LuaFunction luaFunction2 = luaScriptMgr.GetLuaFunction("RemoveDelegate");
    luaFunction2.Call((object) testEventListener);
    testEventListener.OnClick(gameObject);
    luaFunction2.Release();
  }
}

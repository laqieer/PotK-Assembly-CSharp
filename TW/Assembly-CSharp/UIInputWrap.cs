// Decompiled with JetBrains decompiler
// Type: UIInputWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class UIInputWrap
{
  private static System.Type classType = typeof (UIInput);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[6]
    {
      new LuaMethod("Validate", new LuaCSFunction(UIInputWrap.Validate)),
      new LuaMethod("Submit", new LuaCSFunction(UIInputWrap.Submit)),
      new LuaMethod("UpdateLabel", new LuaCSFunction(UIInputWrap.UpdateLabel)),
      new LuaMethod("New", new LuaCSFunction(UIInputWrap._CreateUIInput)),
      new LuaMethod("GetClassType", new LuaCSFunction(UIInputWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(UIInputWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[21]
    {
      new LuaField("current", new LuaCSFunction(UIInputWrap.get_current), new LuaCSFunction(UIInputWrap.set_current)),
      new LuaField("selection", new LuaCSFunction(UIInputWrap.get_selection), new LuaCSFunction(UIInputWrap.set_selection)),
      new LuaField("label", new LuaCSFunction(UIInputWrap.get_label), new LuaCSFunction(UIInputWrap.set_label)),
      new LuaField("inputType", new LuaCSFunction(UIInputWrap.get_inputType), new LuaCSFunction(UIInputWrap.set_inputType)),
      new LuaField("keyboardType", new LuaCSFunction(UIInputWrap.get_keyboardType), new LuaCSFunction(UIInputWrap.set_keyboardType)),
      new LuaField("validation", new LuaCSFunction(UIInputWrap.get_validation), new LuaCSFunction(UIInputWrap.set_validation)),
      new LuaField("characterLimit", new LuaCSFunction(UIInputWrap.get_characterLimit), new LuaCSFunction(UIInputWrap.set_characterLimit)),
      new LuaField("savedAs", new LuaCSFunction(UIInputWrap.get_savedAs), new LuaCSFunction(UIInputWrap.set_savedAs)),
      new LuaField("selectOnTab", new LuaCSFunction(UIInputWrap.get_selectOnTab), new LuaCSFunction(UIInputWrap.set_selectOnTab)),
      new LuaField("activeTextColor", new LuaCSFunction(UIInputWrap.get_activeTextColor), new LuaCSFunction(UIInputWrap.set_activeTextColor)),
      new LuaField("caretColor", new LuaCSFunction(UIInputWrap.get_caretColor), new LuaCSFunction(UIInputWrap.set_caretColor)),
      new LuaField("selectionColor", new LuaCSFunction(UIInputWrap.get_selectionColor), new LuaCSFunction(UIInputWrap.set_selectionColor)),
      new LuaField("onSubmit", new LuaCSFunction(UIInputWrap.get_onSubmit), new LuaCSFunction(UIInputWrap.set_onSubmit)),
      new LuaField("onChange", new LuaCSFunction(UIInputWrap.get_onChange), new LuaCSFunction(UIInputWrap.set_onChange)),
      new LuaField("onValidate", new LuaCSFunction(UIInputWrap.get_onValidate), new LuaCSFunction(UIInputWrap.set_onValidate)),
      new LuaField("defaultText", new LuaCSFunction(UIInputWrap.get_defaultText), new LuaCSFunction(UIInputWrap.set_defaultText)),
      new LuaField("value", new LuaCSFunction(UIInputWrap.get_value), new LuaCSFunction(UIInputWrap.set_value)),
      new LuaField("isSelected", new LuaCSFunction(UIInputWrap.get_isSelected), new LuaCSFunction(UIInputWrap.set_isSelected)),
      new LuaField("cursorPosition", new LuaCSFunction(UIInputWrap.get_cursorPosition), new LuaCSFunction(UIInputWrap.set_cursorPosition)),
      new LuaField("selectionStart", new LuaCSFunction(UIInputWrap.get_selectionStart), new LuaCSFunction(UIInputWrap.set_selectionStart)),
      new LuaField("selectionEnd", new LuaCSFunction(UIInputWrap.get_selectionEnd), new LuaCSFunction(UIInputWrap.set_selectionEnd))
    };
    LuaScriptMgr.RegisterLib(L, "UIInput", typeof (UIInput), regs, fields, typeof (MonoBehaviour));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateUIInput(IntPtr L)
  {
    LuaDLL.luaL_error(L, "UIInput class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, UIInputWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_current(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Object) UIInput.current);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_selection(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Object) UIInput.selection);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_label(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name label");
      else
        LuaDLL.luaL_error(L, "attempt to index label on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.label);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_inputType(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name inputType");
      else
        LuaDLL.luaL_error(L, "attempt to index inputType on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) luaObject.inputType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_keyboardType(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name keyboardType");
      else
        LuaDLL.luaL_error(L, "attempt to index keyboardType on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) luaObject.keyboardType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_validation(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name validation");
      else
        LuaDLL.luaL_error(L, "attempt to index validation on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) luaObject.validation);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_characterLimit(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name characterLimit");
      else
        LuaDLL.luaL_error(L, "attempt to index characterLimit on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.characterLimit);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_savedAs(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name savedAs");
      else
        LuaDLL.luaL_error(L, "attempt to index savedAs on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.savedAs);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_selectOnTab(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name selectOnTab");
      else
        LuaDLL.luaL_error(L, "attempt to index selectOnTab on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.selectOnTab);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_activeTextColor(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name activeTextColor");
      else
        LuaDLL.luaL_error(L, "attempt to index activeTextColor on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.activeTextColor);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_caretColor(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name caretColor");
      else
        LuaDLL.luaL_error(L, "attempt to index caretColor on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.caretColor);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_selectionColor(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name selectionColor");
      else
        LuaDLL.luaL_error(L, "attempt to index selectionColor on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.selectionColor);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_onSubmit(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name onSubmit");
      else
        LuaDLL.luaL_error(L, "attempt to index onSubmit on a nil value");
    }
    LuaScriptMgr.PushObject(L, (object) luaObject.onSubmit);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_onChange(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name onChange");
      else
        LuaDLL.luaL_error(L, "attempt to index onChange on a nil value");
    }
    LuaScriptMgr.PushObject(L, (object) luaObject.onChange);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_onValidate(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name onValidate");
      else
        LuaDLL.luaL_error(L, "attempt to index onValidate on a nil value");
    }
    LuaScriptMgr.Push(L, (Delegate) luaObject.onValidate);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_defaultText(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name defaultText");
      else
        LuaDLL.luaL_error(L, "attempt to index defaultText on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.defaultText);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_value(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name value");
      else
        LuaDLL.luaL_error(L, "attempt to index value on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.value);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isSelected(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name isSelected");
      else
        LuaDLL.luaL_error(L, "attempt to index isSelected on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.isSelected);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_cursorPosition(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name cursorPosition");
      else
        LuaDLL.luaL_error(L, "attempt to index cursorPosition on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.cursorPosition);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_selectionStart(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name selectionStart");
      else
        LuaDLL.luaL_error(L, "attempt to index selectionStart on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.selectionStart);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_selectionEnd(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name selectionEnd");
      else
        LuaDLL.luaL_error(L, "attempt to index selectionEnd on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.selectionEnd);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_current(IntPtr L)
  {
    UIInput.current = (UIInput) LuaScriptMgr.GetUnityObject(L, 3, typeof (UIInput));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_selection(IntPtr L)
  {
    UIInput.selection = (UIInput) LuaScriptMgr.GetUnityObject(L, 3, typeof (UIInput));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_label(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name label");
      else
        LuaDLL.luaL_error(L, "attempt to index label on a nil value");
    }
    luaObject.label = (UILabel) LuaScriptMgr.GetUnityObject(L, 3, typeof (UILabel));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_inputType(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name inputType");
      else
        LuaDLL.luaL_error(L, "attempt to index inputType on a nil value");
    }
    luaObject.inputType = (UIInput.InputType) LuaScriptMgr.GetNetObject(L, 3, typeof (UIInput.InputType));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_keyboardType(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name keyboardType");
      else
        LuaDLL.luaL_error(L, "attempt to index keyboardType on a nil value");
    }
    luaObject.keyboardType = (UIInput.KeyboardType) LuaScriptMgr.GetNetObject(L, 3, typeof (UIInput.KeyboardType));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_validation(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name validation");
      else
        LuaDLL.luaL_error(L, "attempt to index validation on a nil value");
    }
    luaObject.validation = (UIInput.Validation) LuaScriptMgr.GetNetObject(L, 3, typeof (UIInput.Validation));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_characterLimit(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name characterLimit");
      else
        LuaDLL.luaL_error(L, "attempt to index characterLimit on a nil value");
    }
    luaObject.characterLimit = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_savedAs(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name savedAs");
      else
        LuaDLL.luaL_error(L, "attempt to index savedAs on a nil value");
    }
    luaObject.savedAs = LuaScriptMgr.GetString(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_selectOnTab(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name selectOnTab");
      else
        LuaDLL.luaL_error(L, "attempt to index selectOnTab on a nil value");
    }
    luaObject.selectOnTab = (GameObject) LuaScriptMgr.GetUnityObject(L, 3, typeof (GameObject));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_activeTextColor(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name activeTextColor");
      else
        LuaDLL.luaL_error(L, "attempt to index activeTextColor on a nil value");
    }
    luaObject.activeTextColor = LuaScriptMgr.GetColor(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_caretColor(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name caretColor");
      else
        LuaDLL.luaL_error(L, "attempt to index caretColor on a nil value");
    }
    luaObject.caretColor = LuaScriptMgr.GetColor(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_selectionColor(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name selectionColor");
      else
        LuaDLL.luaL_error(L, "attempt to index selectionColor on a nil value");
    }
    luaObject.selectionColor = LuaScriptMgr.GetColor(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_onSubmit(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name onSubmit");
      else
        LuaDLL.luaL_error(L, "attempt to index onSubmit on a nil value");
    }
    luaObject.onSubmit = (List<EventDelegate>) LuaScriptMgr.GetNetObject(L, 3, typeof (List<EventDelegate>));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_onChange(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name onChange");
      else
        LuaDLL.luaL_error(L, "attempt to index onChange on a nil value");
    }
    luaObject.onChange = (List<EventDelegate>) LuaScriptMgr.GetNetObject(L, 3, typeof (List<EventDelegate>));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_onValidate(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name onValidate");
      else
        LuaDLL.luaL_error(L, "attempt to index onValidate on a nil value");
    }
    if (LuaDLL.lua_type(L, 3) != LuaTypes.LUA_TFUNCTION)
    {
      luaObject.onValidate = (UIInput.OnValidate) LuaScriptMgr.GetNetObject(L, 3, typeof (UIInput.OnValidate));
    }
    else
    {
      LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
      luaObject.onValidate = (UIInput.OnValidate) ((param0, param1, param2) =>
      {
        int oldTop = func.BeginPCall();
        LuaScriptMgr.Push(L, param0);
        LuaScriptMgr.Push(L, param1);
        LuaScriptMgr.Push(L, param2);
        func.PCall(oldTop, 3);
        object[] objArray = func.PopValues(oldTop);
        func.EndPCall(oldTop);
        return (char) objArray[0];
      });
    }
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_defaultText(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name defaultText");
      else
        LuaDLL.luaL_error(L, "attempt to index defaultText on a nil value");
    }
    luaObject.defaultText = LuaScriptMgr.GetString(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_value(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name value");
      else
        LuaDLL.luaL_error(L, "attempt to index value on a nil value");
    }
    luaObject.value = LuaScriptMgr.GetString(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_isSelected(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name isSelected");
      else
        LuaDLL.luaL_error(L, "attempt to index isSelected on a nil value");
    }
    luaObject.isSelected = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_cursorPosition(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name cursorPosition");
      else
        LuaDLL.luaL_error(L, "attempt to index cursorPosition on a nil value");
    }
    luaObject.cursorPosition = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_selectionStart(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name selectionStart");
      else
        LuaDLL.luaL_error(L, "attempt to index selectionStart on a nil value");
    }
    luaObject.selectionStart = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_selectionEnd(IntPtr L)
  {
    UIInput luaObject = (UIInput) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name selectionEnd");
      else
        LuaDLL.luaL_error(L, "attempt to index selectionEnd on a nil value");
    }
    luaObject.selectionEnd = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Validate(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    string str = ((UIInput) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIInput")).Validate(LuaScriptMgr.GetLuaString(L, 2));
    LuaScriptMgr.Push(L, str);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Submit(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((UIInput) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIInput")).Submit();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int UpdateLabel(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((UIInput) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIInput")).UpdateLabel();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Lua_Eq(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool b = Object.op_Equality(LuaScriptMgr.GetLuaObject(L, 1) as Object, LuaScriptMgr.GetLuaObject(L, 2) as Object);
    LuaScriptMgr.Push(L, b);
    return 1;
  }
}

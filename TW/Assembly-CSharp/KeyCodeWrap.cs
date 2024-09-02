// Decompiled with JetBrains decompiler
// Type: KeyCodeWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class KeyCodeWrap
{
  private static LuaMethod[] enums = new LuaMethod[322]
  {
    new LuaMethod("None", new LuaCSFunction(KeyCodeWrap.GetNone)),
    new LuaMethod("Backspace", new LuaCSFunction(KeyCodeWrap.GetBackspace)),
    new LuaMethod("Delete", new LuaCSFunction(KeyCodeWrap.GetDelete)),
    new LuaMethod("Tab", new LuaCSFunction(KeyCodeWrap.GetTab)),
    new LuaMethod("Clear", new LuaCSFunction(KeyCodeWrap.GetClear)),
    new LuaMethod("Return", new LuaCSFunction(KeyCodeWrap.GetReturn)),
    new LuaMethod("Pause", new LuaCSFunction(KeyCodeWrap.GetPause)),
    new LuaMethod("Escape", new LuaCSFunction(KeyCodeWrap.GetEscape)),
    new LuaMethod("Space", new LuaCSFunction(KeyCodeWrap.GetSpace)),
    new LuaMethod("Keypad0", new LuaCSFunction(KeyCodeWrap.GetKeypad0)),
    new LuaMethod("Keypad1", new LuaCSFunction(KeyCodeWrap.GetKeypad1)),
    new LuaMethod("Keypad2", new LuaCSFunction(KeyCodeWrap.GetKeypad2)),
    new LuaMethod("Keypad3", new LuaCSFunction(KeyCodeWrap.GetKeypad3)),
    new LuaMethod("Keypad4", new LuaCSFunction(KeyCodeWrap.GetKeypad4)),
    new LuaMethod("Keypad5", new LuaCSFunction(KeyCodeWrap.GetKeypad5)),
    new LuaMethod("Keypad6", new LuaCSFunction(KeyCodeWrap.GetKeypad6)),
    new LuaMethod("Keypad7", new LuaCSFunction(KeyCodeWrap.GetKeypad7)),
    new LuaMethod("Keypad8", new LuaCSFunction(KeyCodeWrap.GetKeypad8)),
    new LuaMethod("Keypad9", new LuaCSFunction(KeyCodeWrap.GetKeypad9)),
    new LuaMethod("KeypadPeriod", new LuaCSFunction(KeyCodeWrap.GetKeypadPeriod)),
    new LuaMethod("KeypadDivide", new LuaCSFunction(KeyCodeWrap.GetKeypadDivide)),
    new LuaMethod("KeypadMultiply", new LuaCSFunction(KeyCodeWrap.GetKeypadMultiply)),
    new LuaMethod("KeypadMinus", new LuaCSFunction(KeyCodeWrap.GetKeypadMinus)),
    new LuaMethod("KeypadPlus", new LuaCSFunction(KeyCodeWrap.GetKeypadPlus)),
    new LuaMethod("KeypadEnter", new LuaCSFunction(KeyCodeWrap.GetKeypadEnter)),
    new LuaMethod("KeypadEquals", new LuaCSFunction(KeyCodeWrap.GetKeypadEquals)),
    new LuaMethod("UpArrow", new LuaCSFunction(KeyCodeWrap.GetUpArrow)),
    new LuaMethod("DownArrow", new LuaCSFunction(KeyCodeWrap.GetDownArrow)),
    new LuaMethod("RightArrow", new LuaCSFunction(KeyCodeWrap.GetRightArrow)),
    new LuaMethod("LeftArrow", new LuaCSFunction(KeyCodeWrap.GetLeftArrow)),
    new LuaMethod("Insert", new LuaCSFunction(KeyCodeWrap.GetInsert)),
    new LuaMethod("Home", new LuaCSFunction(KeyCodeWrap.GetHome)),
    new LuaMethod("End", new LuaCSFunction(KeyCodeWrap.GetEnd)),
    new LuaMethod("PageUp", new LuaCSFunction(KeyCodeWrap.GetPageUp)),
    new LuaMethod("PageDown", new LuaCSFunction(KeyCodeWrap.GetPageDown)),
    new LuaMethod("F1", new LuaCSFunction(KeyCodeWrap.GetF1)),
    new LuaMethod("F2", new LuaCSFunction(KeyCodeWrap.GetF2)),
    new LuaMethod("F3", new LuaCSFunction(KeyCodeWrap.GetF3)),
    new LuaMethod("F4", new LuaCSFunction(KeyCodeWrap.GetF4)),
    new LuaMethod("F5", new LuaCSFunction(KeyCodeWrap.GetF5)),
    new LuaMethod("F6", new LuaCSFunction(KeyCodeWrap.GetF6)),
    new LuaMethod("F7", new LuaCSFunction(KeyCodeWrap.GetF7)),
    new LuaMethod("F8", new LuaCSFunction(KeyCodeWrap.GetF8)),
    new LuaMethod("F9", new LuaCSFunction(KeyCodeWrap.GetF9)),
    new LuaMethod("F10", new LuaCSFunction(KeyCodeWrap.GetF10)),
    new LuaMethod("F11", new LuaCSFunction(KeyCodeWrap.GetF11)),
    new LuaMethod("F12", new LuaCSFunction(KeyCodeWrap.GetF12)),
    new LuaMethod("F13", new LuaCSFunction(KeyCodeWrap.GetF13)),
    new LuaMethod("F14", new LuaCSFunction(KeyCodeWrap.GetF14)),
    new LuaMethod("F15", new LuaCSFunction(KeyCodeWrap.GetF15)),
    new LuaMethod("Alpha0", new LuaCSFunction(KeyCodeWrap.GetAlpha0)),
    new LuaMethod("Alpha1", new LuaCSFunction(KeyCodeWrap.GetAlpha1)),
    new LuaMethod("Alpha2", new LuaCSFunction(KeyCodeWrap.GetAlpha2)),
    new LuaMethod("Alpha3", new LuaCSFunction(KeyCodeWrap.GetAlpha3)),
    new LuaMethod("Alpha4", new LuaCSFunction(KeyCodeWrap.GetAlpha4)),
    new LuaMethod("Alpha5", new LuaCSFunction(KeyCodeWrap.GetAlpha5)),
    new LuaMethod("Alpha6", new LuaCSFunction(KeyCodeWrap.GetAlpha6)),
    new LuaMethod("Alpha7", new LuaCSFunction(KeyCodeWrap.GetAlpha7)),
    new LuaMethod("Alpha8", new LuaCSFunction(KeyCodeWrap.GetAlpha8)),
    new LuaMethod("Alpha9", new LuaCSFunction(KeyCodeWrap.GetAlpha9)),
    new LuaMethod("Exclaim", new LuaCSFunction(KeyCodeWrap.GetExclaim)),
    new LuaMethod("DoubleQuote", new LuaCSFunction(KeyCodeWrap.GetDoubleQuote)),
    new LuaMethod("Hash", new LuaCSFunction(KeyCodeWrap.GetHash)),
    new LuaMethod("Dollar", new LuaCSFunction(KeyCodeWrap.GetDollar)),
    new LuaMethod("Ampersand", new LuaCSFunction(KeyCodeWrap.GetAmpersand)),
    new LuaMethod("Quote", new LuaCSFunction(KeyCodeWrap.GetQuote)),
    new LuaMethod("LeftParen", new LuaCSFunction(KeyCodeWrap.GetLeftParen)),
    new LuaMethod("RightParen", new LuaCSFunction(KeyCodeWrap.GetRightParen)),
    new LuaMethod("Asterisk", new LuaCSFunction(KeyCodeWrap.GetAsterisk)),
    new LuaMethod("Plus", new LuaCSFunction(KeyCodeWrap.GetPlus)),
    new LuaMethod("Comma", new LuaCSFunction(KeyCodeWrap.GetComma)),
    new LuaMethod("Minus", new LuaCSFunction(KeyCodeWrap.GetMinus)),
    new LuaMethod("Period", new LuaCSFunction(KeyCodeWrap.GetPeriod)),
    new LuaMethod("Slash", new LuaCSFunction(KeyCodeWrap.GetSlash)),
    new LuaMethod("Colon", new LuaCSFunction(KeyCodeWrap.GetColon)),
    new LuaMethod("Semicolon", new LuaCSFunction(KeyCodeWrap.GetSemicolon)),
    new LuaMethod("Less", new LuaCSFunction(KeyCodeWrap.GetLess)),
    new LuaMethod("Equals", new LuaCSFunction(KeyCodeWrap.GetEquals)),
    new LuaMethod("Greater", new LuaCSFunction(KeyCodeWrap.GetGreater)),
    new LuaMethod("Question", new LuaCSFunction(KeyCodeWrap.GetQuestion)),
    new LuaMethod("At", new LuaCSFunction(KeyCodeWrap.GetAt)),
    new LuaMethod("LeftBracket", new LuaCSFunction(KeyCodeWrap.GetLeftBracket)),
    new LuaMethod("Backslash", new LuaCSFunction(KeyCodeWrap.GetBackslash)),
    new LuaMethod("RightBracket", new LuaCSFunction(KeyCodeWrap.GetRightBracket)),
    new LuaMethod("Caret", new LuaCSFunction(KeyCodeWrap.GetCaret)),
    new LuaMethod("Underscore", new LuaCSFunction(KeyCodeWrap.GetUnderscore)),
    new LuaMethod("BackQuote", new LuaCSFunction(KeyCodeWrap.GetBackQuote)),
    new LuaMethod("A", new LuaCSFunction(KeyCodeWrap.GetA)),
    new LuaMethod("B", new LuaCSFunction(KeyCodeWrap.GetB)),
    new LuaMethod("C", new LuaCSFunction(KeyCodeWrap.GetC)),
    new LuaMethod("D", new LuaCSFunction(KeyCodeWrap.GetD)),
    new LuaMethod("E", new LuaCSFunction(KeyCodeWrap.GetE)),
    new LuaMethod("F", new LuaCSFunction(KeyCodeWrap.GetF)),
    new LuaMethod("G", new LuaCSFunction(KeyCodeWrap.GetG)),
    new LuaMethod("H", new LuaCSFunction(KeyCodeWrap.GetH)),
    new LuaMethod("I", new LuaCSFunction(KeyCodeWrap.GetI)),
    new LuaMethod("J", new LuaCSFunction(KeyCodeWrap.GetJ)),
    new LuaMethod("K", new LuaCSFunction(KeyCodeWrap.GetK)),
    new LuaMethod("L", new LuaCSFunction(KeyCodeWrap.GetL)),
    new LuaMethod("M", new LuaCSFunction(KeyCodeWrap.GetM)),
    new LuaMethod("N", new LuaCSFunction(KeyCodeWrap.GetN)),
    new LuaMethod("O", new LuaCSFunction(KeyCodeWrap.GetO)),
    new LuaMethod("P", new LuaCSFunction(KeyCodeWrap.GetP)),
    new LuaMethod("Q", new LuaCSFunction(KeyCodeWrap.GetQ)),
    new LuaMethod("R", new LuaCSFunction(KeyCodeWrap.GetR)),
    new LuaMethod("S", new LuaCSFunction(KeyCodeWrap.GetS)),
    new LuaMethod("T", new LuaCSFunction(KeyCodeWrap.GetT)),
    new LuaMethod("U", new LuaCSFunction(KeyCodeWrap.GetU)),
    new LuaMethod("V", new LuaCSFunction(KeyCodeWrap.GetV)),
    new LuaMethod("W", new LuaCSFunction(KeyCodeWrap.GetW)),
    new LuaMethod("X", new LuaCSFunction(KeyCodeWrap.GetX)),
    new LuaMethod("Y", new LuaCSFunction(KeyCodeWrap.GetY)),
    new LuaMethod("Z", new LuaCSFunction(KeyCodeWrap.GetZ)),
    new LuaMethod("Numlock", new LuaCSFunction(KeyCodeWrap.GetNumlock)),
    new LuaMethod("CapsLock", new LuaCSFunction(KeyCodeWrap.GetCapsLock)),
    new LuaMethod("ScrollLock", new LuaCSFunction(KeyCodeWrap.GetScrollLock)),
    new LuaMethod("RightShift", new LuaCSFunction(KeyCodeWrap.GetRightShift)),
    new LuaMethod("LeftShift", new LuaCSFunction(KeyCodeWrap.GetLeftShift)),
    new LuaMethod("RightControl", new LuaCSFunction(KeyCodeWrap.GetRightControl)),
    new LuaMethod("LeftControl", new LuaCSFunction(KeyCodeWrap.GetLeftControl)),
    new LuaMethod("RightAlt", new LuaCSFunction(KeyCodeWrap.GetRightAlt)),
    new LuaMethod("LeftAlt", new LuaCSFunction(KeyCodeWrap.GetLeftAlt)),
    new LuaMethod("LeftCommand", new LuaCSFunction(KeyCodeWrap.GetLeftCommand)),
    new LuaMethod("LeftApple", new LuaCSFunction(KeyCodeWrap.GetLeftApple)),
    new LuaMethod("LeftWindows", new LuaCSFunction(KeyCodeWrap.GetLeftWindows)),
    new LuaMethod("RightCommand", new LuaCSFunction(KeyCodeWrap.GetRightCommand)),
    new LuaMethod("RightApple", new LuaCSFunction(KeyCodeWrap.GetRightApple)),
    new LuaMethod("RightWindows", new LuaCSFunction(KeyCodeWrap.GetRightWindows)),
    new LuaMethod("AltGr", new LuaCSFunction(KeyCodeWrap.GetAltGr)),
    new LuaMethod("Help", new LuaCSFunction(KeyCodeWrap.GetHelp)),
    new LuaMethod("Print", new LuaCSFunction(KeyCodeWrap.GetPrint)),
    new LuaMethod("SysReq", new LuaCSFunction(KeyCodeWrap.GetSysReq)),
    new LuaMethod("Break", new LuaCSFunction(KeyCodeWrap.GetBreak)),
    new LuaMethod("Menu", new LuaCSFunction(KeyCodeWrap.GetMenu)),
    new LuaMethod("Mouse0", new LuaCSFunction(KeyCodeWrap.GetMouse0)),
    new LuaMethod("Mouse1", new LuaCSFunction(KeyCodeWrap.GetMouse1)),
    new LuaMethod("Mouse2", new LuaCSFunction(KeyCodeWrap.GetMouse2)),
    new LuaMethod("Mouse3", new LuaCSFunction(KeyCodeWrap.GetMouse3)),
    new LuaMethod("Mouse4", new LuaCSFunction(KeyCodeWrap.GetMouse4)),
    new LuaMethod("Mouse5", new LuaCSFunction(KeyCodeWrap.GetMouse5)),
    new LuaMethod("Mouse6", new LuaCSFunction(KeyCodeWrap.GetMouse6)),
    new LuaMethod("JoystickButton0", new LuaCSFunction(KeyCodeWrap.GetJoystickButton0)),
    new LuaMethod("JoystickButton1", new LuaCSFunction(KeyCodeWrap.GetJoystickButton1)),
    new LuaMethod("JoystickButton2", new LuaCSFunction(KeyCodeWrap.GetJoystickButton2)),
    new LuaMethod("JoystickButton3", new LuaCSFunction(KeyCodeWrap.GetJoystickButton3)),
    new LuaMethod("JoystickButton4", new LuaCSFunction(KeyCodeWrap.GetJoystickButton4)),
    new LuaMethod("JoystickButton5", new LuaCSFunction(KeyCodeWrap.GetJoystickButton5)),
    new LuaMethod("JoystickButton6", new LuaCSFunction(KeyCodeWrap.GetJoystickButton6)),
    new LuaMethod("JoystickButton7", new LuaCSFunction(KeyCodeWrap.GetJoystickButton7)),
    new LuaMethod("JoystickButton8", new LuaCSFunction(KeyCodeWrap.GetJoystickButton8)),
    new LuaMethod("JoystickButton9", new LuaCSFunction(KeyCodeWrap.GetJoystickButton9)),
    new LuaMethod("JoystickButton10", new LuaCSFunction(KeyCodeWrap.GetJoystickButton10)),
    new LuaMethod("JoystickButton11", new LuaCSFunction(KeyCodeWrap.GetJoystickButton11)),
    new LuaMethod("JoystickButton12", new LuaCSFunction(KeyCodeWrap.GetJoystickButton12)),
    new LuaMethod("JoystickButton13", new LuaCSFunction(KeyCodeWrap.GetJoystickButton13)),
    new LuaMethod("JoystickButton14", new LuaCSFunction(KeyCodeWrap.GetJoystickButton14)),
    new LuaMethod("JoystickButton15", new LuaCSFunction(KeyCodeWrap.GetJoystickButton15)),
    new LuaMethod("JoystickButton16", new LuaCSFunction(KeyCodeWrap.GetJoystickButton16)),
    new LuaMethod("JoystickButton17", new LuaCSFunction(KeyCodeWrap.GetJoystickButton17)),
    new LuaMethod("JoystickButton18", new LuaCSFunction(KeyCodeWrap.GetJoystickButton18)),
    new LuaMethod("JoystickButton19", new LuaCSFunction(KeyCodeWrap.GetJoystickButton19)),
    new LuaMethod("Joystick1Button0", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button0)),
    new LuaMethod("Joystick1Button1", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button1)),
    new LuaMethod("Joystick1Button2", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button2)),
    new LuaMethod("Joystick1Button3", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button3)),
    new LuaMethod("Joystick1Button4", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button4)),
    new LuaMethod("Joystick1Button5", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button5)),
    new LuaMethod("Joystick1Button6", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button6)),
    new LuaMethod("Joystick1Button7", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button7)),
    new LuaMethod("Joystick1Button8", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button8)),
    new LuaMethod("Joystick1Button9", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button9)),
    new LuaMethod("Joystick1Button10", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button10)),
    new LuaMethod("Joystick1Button11", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button11)),
    new LuaMethod("Joystick1Button12", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button12)),
    new LuaMethod("Joystick1Button13", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button13)),
    new LuaMethod("Joystick1Button14", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button14)),
    new LuaMethod("Joystick1Button15", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button15)),
    new LuaMethod("Joystick1Button16", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button16)),
    new LuaMethod("Joystick1Button17", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button17)),
    new LuaMethod("Joystick1Button18", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button18)),
    new LuaMethod("Joystick1Button19", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button19)),
    new LuaMethod("Joystick2Button0", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button0)),
    new LuaMethod("Joystick2Button1", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button1)),
    new LuaMethod("Joystick2Button2", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button2)),
    new LuaMethod("Joystick2Button3", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button3)),
    new LuaMethod("Joystick2Button4", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button4)),
    new LuaMethod("Joystick2Button5", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button5)),
    new LuaMethod("Joystick2Button6", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button6)),
    new LuaMethod("Joystick2Button7", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button7)),
    new LuaMethod("Joystick2Button8", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button8)),
    new LuaMethod("Joystick2Button9", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button9)),
    new LuaMethod("Joystick2Button10", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button10)),
    new LuaMethod("Joystick2Button11", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button11)),
    new LuaMethod("Joystick2Button12", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button12)),
    new LuaMethod("Joystick2Button13", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button13)),
    new LuaMethod("Joystick2Button14", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button14)),
    new LuaMethod("Joystick2Button15", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button15)),
    new LuaMethod("Joystick2Button16", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button16)),
    new LuaMethod("Joystick2Button17", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button17)),
    new LuaMethod("Joystick2Button18", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button18)),
    new LuaMethod("Joystick2Button19", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button19)),
    new LuaMethod("Joystick3Button0", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button0)),
    new LuaMethod("Joystick3Button1", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button1)),
    new LuaMethod("Joystick3Button2", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button2)),
    new LuaMethod("Joystick3Button3", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button3)),
    new LuaMethod("Joystick3Button4", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button4)),
    new LuaMethod("Joystick3Button5", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button5)),
    new LuaMethod("Joystick3Button6", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button6)),
    new LuaMethod("Joystick3Button7", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button7)),
    new LuaMethod("Joystick3Button8", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button8)),
    new LuaMethod("Joystick3Button9", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button9)),
    new LuaMethod("Joystick3Button10", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button10)),
    new LuaMethod("Joystick3Button11", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button11)),
    new LuaMethod("Joystick3Button12", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button12)),
    new LuaMethod("Joystick3Button13", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button13)),
    new LuaMethod("Joystick3Button14", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button14)),
    new LuaMethod("Joystick3Button15", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button15)),
    new LuaMethod("Joystick3Button16", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button16)),
    new LuaMethod("Joystick3Button17", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button17)),
    new LuaMethod("Joystick3Button18", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button18)),
    new LuaMethod("Joystick3Button19", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button19)),
    new LuaMethod("Joystick4Button0", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button0)),
    new LuaMethod("Joystick4Button1", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button1)),
    new LuaMethod("Joystick4Button2", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button2)),
    new LuaMethod("Joystick4Button3", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button3)),
    new LuaMethod("Joystick4Button4", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button4)),
    new LuaMethod("Joystick4Button5", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button5)),
    new LuaMethod("Joystick4Button6", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button6)),
    new LuaMethod("Joystick4Button7", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button7)),
    new LuaMethod("Joystick4Button8", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button8)),
    new LuaMethod("Joystick4Button9", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button9)),
    new LuaMethod("Joystick4Button10", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button10)),
    new LuaMethod("Joystick4Button11", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button11)),
    new LuaMethod("Joystick4Button12", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button12)),
    new LuaMethod("Joystick4Button13", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button13)),
    new LuaMethod("Joystick4Button14", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button14)),
    new LuaMethod("Joystick4Button15", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button15)),
    new LuaMethod("Joystick4Button16", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button16)),
    new LuaMethod("Joystick4Button17", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button17)),
    new LuaMethod("Joystick4Button18", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button18)),
    new LuaMethod("Joystick4Button19", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button19)),
    new LuaMethod("Joystick5Button0", new LuaCSFunction(KeyCodeWrap.GetJoystick5Button0)),
    new LuaMethod("Joystick5Button1", new LuaCSFunction(KeyCodeWrap.GetJoystick5Button1)),
    new LuaMethod("Joystick5Button2", new LuaCSFunction(KeyCodeWrap.GetJoystick5Button2)),
    new LuaMethod("Joystick5Button3", new LuaCSFunction(KeyCodeWrap.GetJoystick5Button3)),
    new LuaMethod("Joystick5Button4", new LuaCSFunction(KeyCodeWrap.GetJoystick5Button4)),
    new LuaMethod("Joystick5Button5", new LuaCSFunction(KeyCodeWrap.GetJoystick5Button5)),
    new LuaMethod("Joystick5Button6", new LuaCSFunction(KeyCodeWrap.GetJoystick5Button6)),
    new LuaMethod("Joystick5Button7", new LuaCSFunction(KeyCodeWrap.GetJoystick5Button7)),
    new LuaMethod("Joystick5Button8", new LuaCSFunction(KeyCodeWrap.GetJoystick5Button8)),
    new LuaMethod("Joystick5Button9", new LuaCSFunction(KeyCodeWrap.GetJoystick5Button9)),
    new LuaMethod("Joystick5Button10", new LuaCSFunction(KeyCodeWrap.GetJoystick5Button10)),
    new LuaMethod("Joystick5Button11", new LuaCSFunction(KeyCodeWrap.GetJoystick5Button11)),
    new LuaMethod("Joystick5Button12", new LuaCSFunction(KeyCodeWrap.GetJoystick5Button12)),
    new LuaMethod("Joystick5Button13", new LuaCSFunction(KeyCodeWrap.GetJoystick5Button13)),
    new LuaMethod("Joystick5Button14", new LuaCSFunction(KeyCodeWrap.GetJoystick5Button14)),
    new LuaMethod("Joystick5Button15", new LuaCSFunction(KeyCodeWrap.GetJoystick5Button15)),
    new LuaMethod("Joystick5Button16", new LuaCSFunction(KeyCodeWrap.GetJoystick5Button16)),
    new LuaMethod("Joystick5Button17", new LuaCSFunction(KeyCodeWrap.GetJoystick5Button17)),
    new LuaMethod("Joystick5Button18", new LuaCSFunction(KeyCodeWrap.GetJoystick5Button18)),
    new LuaMethod("Joystick5Button19", new LuaCSFunction(KeyCodeWrap.GetJoystick5Button19)),
    new LuaMethod("Joystick6Button0", new LuaCSFunction(KeyCodeWrap.GetJoystick6Button0)),
    new LuaMethod("Joystick6Button1", new LuaCSFunction(KeyCodeWrap.GetJoystick6Button1)),
    new LuaMethod("Joystick6Button2", new LuaCSFunction(KeyCodeWrap.GetJoystick6Button2)),
    new LuaMethod("Joystick6Button3", new LuaCSFunction(KeyCodeWrap.GetJoystick6Button3)),
    new LuaMethod("Joystick6Button4", new LuaCSFunction(KeyCodeWrap.GetJoystick6Button4)),
    new LuaMethod("Joystick6Button5", new LuaCSFunction(KeyCodeWrap.GetJoystick6Button5)),
    new LuaMethod("Joystick6Button6", new LuaCSFunction(KeyCodeWrap.GetJoystick6Button6)),
    new LuaMethod("Joystick6Button7", new LuaCSFunction(KeyCodeWrap.GetJoystick6Button7)),
    new LuaMethod("Joystick6Button8", new LuaCSFunction(KeyCodeWrap.GetJoystick6Button8)),
    new LuaMethod("Joystick6Button9", new LuaCSFunction(KeyCodeWrap.GetJoystick6Button9)),
    new LuaMethod("Joystick6Button10", new LuaCSFunction(KeyCodeWrap.GetJoystick6Button10)),
    new LuaMethod("Joystick6Button11", new LuaCSFunction(KeyCodeWrap.GetJoystick6Button11)),
    new LuaMethod("Joystick6Button12", new LuaCSFunction(KeyCodeWrap.GetJoystick6Button12)),
    new LuaMethod("Joystick6Button13", new LuaCSFunction(KeyCodeWrap.GetJoystick6Button13)),
    new LuaMethod("Joystick6Button14", new LuaCSFunction(KeyCodeWrap.GetJoystick6Button14)),
    new LuaMethod("Joystick6Button15", new LuaCSFunction(KeyCodeWrap.GetJoystick6Button15)),
    new LuaMethod("Joystick6Button16", new LuaCSFunction(KeyCodeWrap.GetJoystick6Button16)),
    new LuaMethod("Joystick6Button17", new LuaCSFunction(KeyCodeWrap.GetJoystick6Button17)),
    new LuaMethod("Joystick6Button18", new LuaCSFunction(KeyCodeWrap.GetJoystick6Button18)),
    new LuaMethod("Joystick6Button19", new LuaCSFunction(KeyCodeWrap.GetJoystick6Button19)),
    new LuaMethod("Joystick7Button0", new LuaCSFunction(KeyCodeWrap.GetJoystick7Button0)),
    new LuaMethod("Joystick7Button1", new LuaCSFunction(KeyCodeWrap.GetJoystick7Button1)),
    new LuaMethod("Joystick7Button2", new LuaCSFunction(KeyCodeWrap.GetJoystick7Button2)),
    new LuaMethod("Joystick7Button3", new LuaCSFunction(KeyCodeWrap.GetJoystick7Button3)),
    new LuaMethod("Joystick7Button4", new LuaCSFunction(KeyCodeWrap.GetJoystick7Button4)),
    new LuaMethod("Joystick7Button5", new LuaCSFunction(KeyCodeWrap.GetJoystick7Button5)),
    new LuaMethod("Joystick7Button6", new LuaCSFunction(KeyCodeWrap.GetJoystick7Button6)),
    new LuaMethod("Joystick7Button7", new LuaCSFunction(KeyCodeWrap.GetJoystick7Button7)),
    new LuaMethod("Joystick7Button8", new LuaCSFunction(KeyCodeWrap.GetJoystick7Button8)),
    new LuaMethod("Joystick7Button9", new LuaCSFunction(KeyCodeWrap.GetJoystick7Button9)),
    new LuaMethod("Joystick7Button10", new LuaCSFunction(KeyCodeWrap.GetJoystick7Button10)),
    new LuaMethod("Joystick7Button11", new LuaCSFunction(KeyCodeWrap.GetJoystick7Button11)),
    new LuaMethod("Joystick7Button12", new LuaCSFunction(KeyCodeWrap.GetJoystick7Button12)),
    new LuaMethod("Joystick7Button13", new LuaCSFunction(KeyCodeWrap.GetJoystick7Button13)),
    new LuaMethod("Joystick7Button14", new LuaCSFunction(KeyCodeWrap.GetJoystick7Button14)),
    new LuaMethod("Joystick7Button15", new LuaCSFunction(KeyCodeWrap.GetJoystick7Button15)),
    new LuaMethod("Joystick7Button16", new LuaCSFunction(KeyCodeWrap.GetJoystick7Button16)),
    new LuaMethod("Joystick7Button17", new LuaCSFunction(KeyCodeWrap.GetJoystick7Button17)),
    new LuaMethod("Joystick7Button18", new LuaCSFunction(KeyCodeWrap.GetJoystick7Button18)),
    new LuaMethod("Joystick7Button19", new LuaCSFunction(KeyCodeWrap.GetJoystick7Button19)),
    new LuaMethod("Joystick8Button0", new LuaCSFunction(KeyCodeWrap.GetJoystick8Button0)),
    new LuaMethod("Joystick8Button1", new LuaCSFunction(KeyCodeWrap.GetJoystick8Button1)),
    new LuaMethod("Joystick8Button2", new LuaCSFunction(KeyCodeWrap.GetJoystick8Button2)),
    new LuaMethod("Joystick8Button3", new LuaCSFunction(KeyCodeWrap.GetJoystick8Button3)),
    new LuaMethod("Joystick8Button4", new LuaCSFunction(KeyCodeWrap.GetJoystick8Button4)),
    new LuaMethod("Joystick8Button5", new LuaCSFunction(KeyCodeWrap.GetJoystick8Button5)),
    new LuaMethod("Joystick8Button6", new LuaCSFunction(KeyCodeWrap.GetJoystick8Button6)),
    new LuaMethod("Joystick8Button7", new LuaCSFunction(KeyCodeWrap.GetJoystick8Button7)),
    new LuaMethod("Joystick8Button8", new LuaCSFunction(KeyCodeWrap.GetJoystick8Button8)),
    new LuaMethod("Joystick8Button9", new LuaCSFunction(KeyCodeWrap.GetJoystick8Button9)),
    new LuaMethod("Joystick8Button10", new LuaCSFunction(KeyCodeWrap.GetJoystick8Button10)),
    new LuaMethod("Joystick8Button11", new LuaCSFunction(KeyCodeWrap.GetJoystick8Button11)),
    new LuaMethod("Joystick8Button12", new LuaCSFunction(KeyCodeWrap.GetJoystick8Button12)),
    new LuaMethod("Joystick8Button13", new LuaCSFunction(KeyCodeWrap.GetJoystick8Button13)),
    new LuaMethod("Joystick8Button14", new LuaCSFunction(KeyCodeWrap.GetJoystick8Button14)),
    new LuaMethod("Joystick8Button15", new LuaCSFunction(KeyCodeWrap.GetJoystick8Button15)),
    new LuaMethod("Joystick8Button16", new LuaCSFunction(KeyCodeWrap.GetJoystick8Button16)),
    new LuaMethod("Joystick8Button17", new LuaCSFunction(KeyCodeWrap.GetJoystick8Button17)),
    new LuaMethod("Joystick8Button18", new LuaCSFunction(KeyCodeWrap.GetJoystick8Button18)),
    new LuaMethod("Joystick8Button19", new LuaCSFunction(KeyCodeWrap.GetJoystick8Button19)),
    new LuaMethod("IntToEnum", new LuaCSFunction(KeyCodeWrap.IntToEnum))
  };

  public static void Register(IntPtr L)
  {
    LuaScriptMgr.RegisterLib(L, "UnityEngine.KeyCode", typeof (KeyCode), KeyCodeWrap.enums);
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetNone(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 0);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetBackspace(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 8);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetDelete(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) (int) sbyte.MaxValue);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetTab(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 9);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClear(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 12);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetReturn(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 13);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetPause(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 19);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetEscape(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 27);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetSpace(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 32);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetKeypad0(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 256);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetKeypad1(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 257);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetKeypad2(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 258);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetKeypad3(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 259);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetKeypad4(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 260);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetKeypad5(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 261);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetKeypad6(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 262);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetKeypad7(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 263);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetKeypad8(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 264);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetKeypad9(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 265);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetKeypadPeriod(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 266);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetKeypadDivide(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 267);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetKeypadMultiply(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 268);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetKeypadMinus(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 269);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetKeypadPlus(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 270);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetKeypadEnter(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 271);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetKeypadEquals(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 272);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetUpArrow(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 273);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetDownArrow(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 274);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetRightArrow(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 275);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetLeftArrow(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 276);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetInsert(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 277);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetHome(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 278);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetEnd(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 279);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetPageUp(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 280);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetPageDown(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 281);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetF1(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 282);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetF2(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 283);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetF3(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 284);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetF4(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 285);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetF5(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 286);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetF6(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 287);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetF7(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 288);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetF8(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 289);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetF9(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 290);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetF10(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 291);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetF11(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 292);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetF12(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 293);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetF13(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 294);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetF14(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 295);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetF15(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 296);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetAlpha0(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 48);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetAlpha1(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 49);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetAlpha2(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 50);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetAlpha3(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 51);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetAlpha4(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 52);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetAlpha5(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 53);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetAlpha6(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 54);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetAlpha7(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 55);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetAlpha8(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 56);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetAlpha9(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 57);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetExclaim(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 33);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetDoubleQuote(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 34);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetHash(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 35);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetDollar(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 36);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetAmpersand(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 38);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetQuote(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 39);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetLeftParen(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 40);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetRightParen(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 41);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetAsterisk(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 42);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetPlus(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 43);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetComma(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 44);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetMinus(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 45);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetPeriod(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 46);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetSlash(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 47);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetColon(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 58);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetSemicolon(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 59);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetLess(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 60);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetEquals(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 61);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetGreater(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 62);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetQuestion(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 63);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetAt(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 64);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetLeftBracket(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 91);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetBackslash(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 92);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetRightBracket(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 93);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetCaret(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 94);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetUnderscore(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 95);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetBackQuote(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 96);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetA(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 97);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetB(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 98);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetC(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 99);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetD(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 100);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetE(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 101);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetF(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 102);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetG(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 103);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetH(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 104);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetI(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 105);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJ(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 106);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetK(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 107);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetL(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 108);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetM(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 109);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetN(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 110);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetO(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 111);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetP(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 112);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetQ(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 113);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetR(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 114);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetS(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 115);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetT(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 116);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetU(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 117);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetV(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 118);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetW(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 119);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetX(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 120);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetY(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 121);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetZ(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 122);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetNumlock(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 300);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetCapsLock(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 301);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetScrollLock(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 302);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetRightShift(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 303);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetLeftShift(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 304);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetRightControl(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 305);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetLeftControl(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 306);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetRightAlt(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 307);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetLeftAlt(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 308);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetLeftCommand(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 310);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetLeftApple(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 310);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetLeftWindows(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 311);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetRightCommand(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 309);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetRightApple(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 309);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetRightWindows(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 312);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetAltGr(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 313);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetHelp(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 315);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetPrint(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 316);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetSysReq(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 317);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetBreak(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 318);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetMenu(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 319);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetMouse0(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 323);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetMouse1(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 324);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetMouse2(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 325);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetMouse3(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 326);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetMouse4(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 327);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetMouse5(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 328);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetMouse6(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 329);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystickButton0(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 330);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystickButton1(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 331);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystickButton2(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 332);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystickButton3(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 333);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystickButton4(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 334);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystickButton5(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 335);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystickButton6(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 336);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystickButton7(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 337);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystickButton8(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 338);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystickButton9(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 339);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystickButton10(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 340);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystickButton11(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 341);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystickButton12(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 342);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystickButton13(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 343);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystickButton14(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 344);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystickButton15(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 345);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystickButton16(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 346);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystickButton17(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 347);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystickButton18(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 348);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystickButton19(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 349);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick1Button0(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 350);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick1Button1(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 351);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick1Button2(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 352);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick1Button3(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 353);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick1Button4(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 354);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick1Button5(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 355);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick1Button6(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 356);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick1Button7(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 357);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick1Button8(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 358);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick1Button9(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 359);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick1Button10(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 360);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick1Button11(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 361);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick1Button12(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 362);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick1Button13(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 363);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick1Button14(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 364);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick1Button15(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 365);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick1Button16(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 366);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick1Button17(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 367);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick1Button18(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 368);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick1Button19(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 369);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick2Button0(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 370);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick2Button1(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 371);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick2Button2(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 372);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick2Button3(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 373);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick2Button4(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 374);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick2Button5(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 375);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick2Button6(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 376);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick2Button7(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 377);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick2Button8(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 378);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick2Button9(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 379);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick2Button10(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 380);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick2Button11(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 381);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick2Button12(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 382);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick2Button13(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 383);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick2Button14(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 384);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick2Button15(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 385);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick2Button16(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 386);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick2Button17(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 387);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick2Button18(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 388);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick2Button19(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 389);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick3Button0(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 390);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick3Button1(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 391);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick3Button2(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 392);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick3Button3(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 393);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick3Button4(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 394);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick3Button5(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 395);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick3Button6(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 396);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick3Button7(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 397);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick3Button8(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 398);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick3Button9(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 399);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick3Button10(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 400);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick3Button11(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 401);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick3Button12(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 402);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick3Button13(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 403);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick3Button14(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 404);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick3Button15(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 405);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick3Button16(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 406);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick3Button17(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 407);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick3Button18(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 408);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick3Button19(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 409);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick4Button0(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 410);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick4Button1(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 411);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick4Button2(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 412);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick4Button3(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 413);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick4Button4(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 414);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick4Button5(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 415);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick4Button6(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 416);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick4Button7(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 417);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick4Button8(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 418);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick4Button9(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 419);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick4Button10(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 420);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick4Button11(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 421);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick4Button12(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 422);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick4Button13(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 423);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick4Button14(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 424);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick4Button15(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 425);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick4Button16(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 426);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick4Button17(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 427);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick4Button18(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 428);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick4Button19(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 429);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick5Button0(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 430);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick5Button1(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 431);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick5Button2(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 432);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick5Button3(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 433);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick5Button4(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 434);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick5Button5(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 435);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick5Button6(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 436);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick5Button7(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 437);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick5Button8(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 438);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick5Button9(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 439);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick5Button10(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 440);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick5Button11(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 441);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick5Button12(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 442);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick5Button13(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 443);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick5Button14(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 444);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick5Button15(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 445);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick5Button16(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 446);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick5Button17(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 447);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick5Button18(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 448);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick5Button19(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 449);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick6Button0(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 450);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick6Button1(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 451);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick6Button2(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 452);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick6Button3(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 453);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick6Button4(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 454);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick6Button5(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 455);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick6Button6(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 456);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick6Button7(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 457);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick6Button8(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 458);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick6Button9(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 459);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick6Button10(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 460);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick6Button11(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 461);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick6Button12(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 462);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick6Button13(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 463);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick6Button14(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 464);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick6Button15(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 465);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick6Button16(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 466);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick6Button17(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 467);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick6Button18(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 468);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick6Button19(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 469);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick7Button0(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 470);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick7Button1(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 471);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick7Button2(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 472);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick7Button3(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 473);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick7Button4(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 474);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick7Button5(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 475);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick7Button6(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 476);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick7Button7(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 477);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick7Button8(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 478);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick7Button9(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 479);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick7Button10(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 480);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick7Button11(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 481);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick7Button12(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 482);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick7Button13(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 483);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick7Button14(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 484);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick7Button15(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 485);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick7Button16(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 486);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick7Button17(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 487);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick7Button18(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 488);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick7Button19(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 489);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick8Button0(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 490);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick8Button1(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 491);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick8Button2(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 492);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick8Button3(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 493);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick8Button4(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 494);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick8Button5(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 495);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick8Button6(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 496);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick8Button7(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 497);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick8Button8(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 498);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick8Button9(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 499);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick8Button10(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 500);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick8Button11(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 501);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick8Button12(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 502);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick8Button13(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 503);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick8Button14(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 504);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick8Button15(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 505);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick8Button16(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 506);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick8Button17(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 507);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick8Button18(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 508);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetJoystick8Button19(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (KeyCode) 509);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int IntToEnum(IntPtr L)
  {
    KeyCode e = (KeyCode) (int) LuaDLL.lua_tonumber(L, 1);
    LuaScriptMgr.Push(L, (Enum) (object) e);
    return 1;
  }
}

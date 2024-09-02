// Decompiled with JetBrains decompiler
// Type: StoryEnvironment
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore.LispCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UniLinq;
using UnityEngine;

public class StoryEnvironment
{
  private float r;
  private float g;
  private float b;
  private float fromAlpha;
  private float toAlpha;
  private float standPos;
  private GameObject obj;
  public static bool IsNoWaitOnChoise;
  private Dictionary<string, object> scriptEnv = new Dictionary<string, object>();
  private Lisp engine;
  private List<StoryBlock> storyBlocks;
  private StoryExecuter executer;
  private int currentIdx;
  private string nextLabel;

  private int? lispNumberToInt(object a)
  {
    Decimal? nullable = a as Decimal?;
    return !nullable.HasValue ? new int?() : new int?((int) nullable.Value);
  }

  private float? lispNumberToFloat(object a)
  {
    Decimal? nullable = a as Decimal?;
    return !nullable.HasValue ? new float?() : new float?((float) nullable.Value);
  }

  private string lispStringToString(object a) => !(a is SExpString sexpString) ? (string) null : sexpString.strValue;

  private void defineVariables()
  {
    this.engine.setq("on", (object) true);
    this.engine.setq("off", (object) false);
  }

  private static void colorFromName(string name, out float r, out float g, out float b)
  {
    if (!(name == "black"))
    {
      if (!(name == "white"))
      {
        if (!(name == "red"))
        {
          if (!(name == "green"))
          {
            if (!(name == "blue"))
            {
              if (name == "pink")
              {
                r = 1f;
                g = 0.75f;
                b = 0.8f;
              }
              else
              {
                r = 0.2f;
                g = 0.0f;
                b = 0.0f;
              }
            }
            else
            {
              r = 0.0f;
              g = 0.0f;
              b = 1f;
            }
          }
          else
          {
            r = 0.0f;
            g = 1f;
            b = 0.0f;
          }
        }
        else
        {
          r = 1f;
          g = 0.0f;
          b = 0.0f;
        }
      }
      else
      {
        r = 1f;
        g = 1f;
        b = 1f;
      }
    }
    else
    {
      r = 0.0f;
      g = 0.0f;
      b = 0.0f;
    }
  }

  private void defunCommands()
  {
    this.engine.defun("serif", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      if (nullable.Value == 0)
      {
        this.current.text.pos = TextBlock.Position.BOTTOM;
      }
      else
      {
        this.current.text.pos = TextBlock.Position.TOP;
        this.executer.openTopLabelObject();
      }
      return args[0];
    }));
    this.engine.defun("setname", (Func<List<object>, object>) (args =>
    {
      this.engine.setq("name", args[0]);
      string text = this.lispStringToString(args[0]);
      if (text == null)
        return (object) null;
      int? nullable = new int?();
      if (args.Count >= 2)
        nullable = this.lispNumberToInt(args[1]);
      string s = TextBlock.decorateText(text);
      if (this.current.text.pos == TextBlock.Position.BOTTOM)
        this.executer.setBottomName(s, nullable.HasValue ? nullable.Value : -1);
      else
        this.executer.setTopName(s, nullable.HasValue ? nullable.Value : -1);
      return args[0];
    }));
    this.engine.defun("gotolabel", (Func<List<object>, object>) (args =>
    {
      this.setNextLabel(this.lispStringToString(args[0]));
      return args[0];
    }));
    this.engine.defun("debug-addtext", (Func<List<object>, object>) (args =>
    {
      this.current.addText(this.lispStringToString(args[0]) ?? args[0].ToString());
      return args[0];
    }));
    this.engine.defun("unity-debug-log", (Func<List<object>, object>) (args =>
    {
      Debug.Log((object) (this.lispStringToString(args[0]) ?? args[0].ToString()));
      return args[0];
    }));
    this.engine.defun("body", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      int? job_id = args.Count > 1 ? this.lispNumberToInt(args[1]) : new int?();
      this.executer.setPerson(nullable.Value, nullable.Value, job_id);
      return args[0];
    }));
    this.engine.defun("entry", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      int? nullable2 = this.lispNumberToInt(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      int? job_id = args.Count > 2 ? this.lispNumberToInt(args[2]) : new int?();
      this.executer.setPerson(nullable1.Value, nullable2.Value, job_id);
      return args[0];
    }));
    this.engine.defun("pos", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      int? nullable2 = this.lispNumberToInt(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      this.executer.setCharaPosition(nullable1.Value, nullable2.Value);
      return args[0];
    }));
    this.engine.defun("chara", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      int? jobid = args.Count > 1 ? this.lispNumberToInt(args[1]) : new int?();
      this.executer.getCharaPosition(nullable.Value, jobid);
      return args[0];
    }));
    this.engine.defun("face", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      string s = this.lispStringToString(args[1]);
      if (s == null)
        return (object) null;
      this.executer.setFace(nullable.Value, s);
      return args[0];
    }));
    this.engine.defun("eye", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      string s = this.lispStringToString(args[1]);
      if (s == null)
        return (object) null;
      this.executer.setEye(nullable.Value, s);
      return args[0];
    }));
    this.engine.defun("leftin", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      float? nullable2 = this.lispNumberToFloat(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      this.executer.setCharaMoveIn(nullable1.Value, nullable2.Value, -1000f);
      return args[0];
    }));
    this.engine.defun("rightin", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      float? nullable2 = this.lispNumberToFloat(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      this.executer.setCharaMoveIn(nullable1.Value, nullable2.Value, 1000f);
      return args[0];
    }));
    this.engine.defun("leftout", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      float? nullable2 = this.lispNumberToFloat(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      this.executer.setCharaMoveOut(nullable1.Value, nullable2.Value, -1000f);
      return args[0];
    }));
    this.engine.defun("rightout", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      float? nullable2 = this.lispNumberToFloat(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      this.executer.setCharaMoveOut(nullable1.Value, nullable2.Value, 1000f);
      return args[0];
    }));
    this.engine.defun("scale", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      float? nullable2 = this.lispNumberToFloat(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      float? nullable3 = this.lispNumberToFloat(args[2]);
      if (!nullable3.HasValue)
        return (object) null;
      this.executer.setCharaScale(nullable1.Value, nullable2.Value, nullable3.Value);
      return args[0];
    }));
    this.engine.defun("henshinbody", (Func<List<object>, object>) (args =>
    {
      int count = args.Count;
      switch (count)
      {
        case 3:
        case 4:
          int? nullable1 = this.lispNumberToInt(args[0]);
          if (!nullable1.HasValue)
            return (object) null;
          int num1 = count == 3 ? 0 : 1;
          List<object> objectList1 = args;
          int index1 = num1;
          int num2 = index1 + 1;
          int? nullable2 = this.lispNumberToInt(objectList1[index1]);
          if (!nullable2.HasValue)
            return (object) null;
          List<object> objectList2 = args;
          int index2 = num2;
          int index3 = index2 + 1;
          int? nullable3 = this.lispNumberToInt(objectList2[index2]);
          if (!nullable3.HasValue)
            return (object) null;
          int? nullable4 = this.lispNumberToInt(args[index3]);
          if (!nullable4.HasValue)
            return (object) null;
          this.executer.setHenshin(nullable1.Value, nullable2.Value, nullable3.Value, nullable4.Value);
          return args[0];
        default:
          return (object) null;
      }
    }));
    this.engine.defun("henshin", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      this.executer.startHenshin(nullable.Value);
      return args[0];
    }));
    this.engine.defun("henshinskip", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      this.executer.skipHenshin(nullable.Value);
      return args[0];
    }));
    this.engine.defun("emotionbody", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      int? nullable2 = this.lispNumberToInt(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      int? nullable3 = this.lispNumberToInt(args[2]);
      if (!nullable3.HasValue)
        return (object) null;
      int? nullable4 = this.lispNumberToInt(args[3]);
      if (!nullable4.HasValue)
        return (object) null;
      int? nullable5 = this.lispNumberToInt(args[4]);
      if (!nullable5.HasValue)
        return (object) null;
      int? nullable6 = args.Count == 6 ? this.lispNumberToInt(args[5]) : new int?(0);
      if (!nullable6.HasValue)
        return (object) null;
      this.executer.setEmotion(nullable1.Value, nullable2.Value, nullable6.Value, nullable3.Value, nullable4.Value, nullable5.Value);
      return args[0];
    }));
    this.engine.defun("envbody", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      int? nullable2 = this.lispNumberToInt(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      int? nullable3 = args.Count == 3 ? this.lispNumberToInt(args[2]) : new int?(0);
      if (!nullable3.HasValue)
        return (object) null;
      this.executer.setEnvEffect(nullable1.Value, nullable2.Value, nullable3.Value);
      return args[0];
    }));
    this.engine.defun("effectbody", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      int? nullable2 = this.lispNumberToInt(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      int? nullable3 = this.lispNumberToInt(args[2]);
      if (!nullable3.HasValue)
        return (object) null;
      int? nullable4 = this.lispNumberToInt(args[3]);
      if (!nullable4.HasValue)
        return (object) null;
      int? nullable5 = args.Count == 5 ? this.lispNumberToInt(args[4]) : new int?(0);
      if (!nullable5.HasValue)
        return (object) null;
      this.executer.setEffect(nullable1.Value, nullable2.Value, nullable5.Value, nullable3.Value, nullable4.Value);
      return args[0];
    }));
    this.engine.defun("effectpattern", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      int? nullable2 = this.lispNumberToInt(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      int? nullable3 = args.Count == 3 ? this.lispNumberToInt(args[2]) : new int?(0);
      if (!nullable3.HasValue)
        return (object) null;
      this.executer.changeEffect(nullable1.Value, nullable2.Value, nullable3.Value);
      return args[0];
    }));
    this.engine.defun("effectstart", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      this.executer.startEffect(nullable.Value);
      return args[0];
    }));
    this.engine.defun("effectskip", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      this.executer.skipEffect(nullable.Value);
      return args[0];
    }));
    this.engine.defun("jump", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      this.executer.setJump(nullable.Value);
      return args[0];
    }));
    this.engine.defun("clash", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      this.executer.setClash(nullable.Value);
      return args[0];
    }));
    this.engine.defun("move", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      int? nullable2 = this.lispNumberToInt(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      float? nullable3 = this.lispNumberToFloat(args[2]);
      if (!nullable3.HasValue)
        return (object) null;
      this.executer.setMoveChara(nullable1.Value, nullable2.Value, nullable3.Value);
      return args[0];
    }));
    this.engine.defun("brightness", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      float? nullable2 = this.lispNumberToFloat(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      float? nullable3 = this.lispNumberToFloat(args[2]);
      if (!nullable3.HasValue)
        return (object) null;
      this.executer.setCharaBrightness(nullable1.Value, nullable2.Value, nullable3.Value);
      return args[0];
    }));
    this.engine.defun("alpha", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      float? nullable2 = this.lispNumberToFloat(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      float? nullable3 = this.lispNumberToFloat(args[2]);
      if (!nullable3.HasValue)
        return (object) null;
      this.executer.setCharaAlpha(nullable1.Value, nullable2.Value, nullable3.Value);
      return args[0];
    }));
    this.engine.defun("reversal", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      int? nullable2 = this.lispNumberToInt(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      StoryExecuter executer = this.executer;
      int id = nullable1.Value;
      int? nullable3 = nullable2;
      int num1 = 0;
      int num2 = nullable3.GetValueOrDefault() == num1 & nullable3.HasValue ? 1 : 0;
      executer.setCharaReversal(id, num2 != 0);
      return args[0];
    }));
    this.engine.defun("distinction", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      int? nullable2 = this.lispNumberToInt(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      this.executer.setUnitDistinction(nullable1.Value, nullable2.Value);
      return args[0];
    }));
    this.engine.defun("distinctionstop", (Func<List<object>, object>) (args =>
    {
      this.executer.stopDistinction();
      return args[0];
    }));
    this.engine.defun("clone", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      int? nullable2 = this.lispNumberToInt(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      this.executer.setPerson(nullable1.Value, nullable2.Value);
      return args[0];
    }));
    this.engine.defun("cutinname", (Func<List<object>, object>) (args =>
    {
      float? nullable1 = this.lispNumberToFloat(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      int? nullable2 = this.lispNumberToInt(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      this.executer.setCutinName(nullable1.Value, nullable2.Value);
      return args[0];
    }));
    this.engine.defun("textflame", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      if (nullable1.Value == 0)
      {
        int? nullable2 = this.lispNumberToInt(args[1]);
        if (!nullable2.HasValue)
          return (object) null;
        this.executer.setTextFlame(nullable1.Value, nullable2.Value);
      }
      else
        this.executer.setTextFlame(nullable1.Value);
      return args[0];
    }));
    this.engine.defun("textboxarrow", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      int? nullable2 = this.lispNumberToInt(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      if (nullable1.Value == 0)
        this.executer.setBottomTextArrow(nullable2.Value);
      else
        this.executer.setTopTextArrow(nullable2.Value);
      return (object) null;
    }));
    this.engine.defun("layer", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      int? nullable2 = this.lispNumberToInt(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      this.executer.setCharaLayer(nullable1.Value, nullable2.Value);
      return args[0];
    }));
    this.engine.defun("delete", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      this.executer.deleteUnit(nullable.Value);
      return args[0];
    }));
    this.engine.defun("mask", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      bool enable = (bool) args[1];
      this.executer.SetMaskEnable(nullable.Value, enable);
      return args[0];
    }));
    this.engine.defun("background", (Func<List<object>, object>) (args =>
    {
      string s = this.lispStringToString(args[0]);
      if (s == null)
        return (object) null;
      this.executer.setBackGround(s);
      return args[0];
    }));
    this.engine.defun("wait", (Func<List<object>, object>) (args =>
    {
      float? nullable = this.lispNumberToFloat(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      this.executer.setWait(nullable.Value);
      return args[0];
    }));
    this.engine.defun("waitandnext", (Func<List<object>, object>) (args =>
    {
      float? nullable = this.lispNumberToFloat(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      this.executer.setWait(nullable.Value, true);
      return args[0];
    }));
    this.engine.defun("fillrect", (Func<List<object>, object>) (args =>
    {
      string name = this.lispStringToString(args[0]);
      if (name == null)
        return (object) null;
      float? nullable1 = this.lispNumberToFloat(args[1]);
      if (!nullable1.HasValue)
        return (object) null;
      float? nullable2 = this.lispNumberToFloat(args[2]);
      if (!nullable2.HasValue)
        return (object) null;
      float? nullable3 = this.lispNumberToFloat(args[3]);
      if (!nullable3.HasValue)
        return (object) null;
      StoryEnvironment.colorFromName(name, out this.r, out this.g, out this.b);
      this.executer.setColorAndTime(this.r, this.g, this.b, nullable2.Value, nullable3.Value, nullable1.Value);
      this.executer.startFillrect();
      return args[0];
    }));
    this.engine.defun("subfillrect", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      string name = this.lispStringToString(args[1]);
      if (name == null)
        return (object) null;
      float? nullable2 = this.lispNumberToFloat(args[2]);
      if (!nullable2.HasValue)
        return (object) null;
      float? nullable3 = this.lispNumberToFloat(args[3]);
      if (!nullable3.HasValue)
        return (object) null;
      float? nullable4 = this.lispNumberToFloat(args[4]);
      if (!nullable4.HasValue)
        return (object) null;
      StoryEnvironment.colorFromName(name, out this.r, out this.g, out this.b);
      this.executer.setSubDepth(nullable1.Value);
      this.executer.setSubColorAndTime(this.r, this.g, this.b, nullable3.Value, nullable4.Value, nullable2.Value);
      this.executer.startSubFillrect();
      return args[0];
    }));
    this.engine.defun("framein", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      float? nullable2 = this.lispNumberToFloat(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      this.executer.startMoveFrame(nullable1.Value, false, nullable2.Value);
      return args[0];
    }));
    this.engine.defun("frameout", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      float? nullable2 = this.lispNumberToFloat(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      this.executer.startMoveFrame(nullable1.Value, true, nullable2.Value);
      return args[0];
    }));
    this.engine.defun("buttonsin", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      float? nullable2 = this.lispNumberToFloat(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      this.executer.startMoveButtons(nullable1.Value, false, nullable2.Value);
      return args[0];
    }));
    this.engine.defun("buttonsout", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      float? nullable2 = this.lispNumberToFloat(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      this.executer.startMoveButtons(nullable1.Value, true, nullable2.Value);
      return args[0];
    }));
    this.engine.defun("fadein", (Func<List<object>, object>) (args =>
    {
      string name = this.lispStringToString(args[0]);
      if (name == null)
        return (object) null;
      float? nullable = this.lispNumberToFloat(args[1]);
      if (!nullable.HasValue)
        return (object) null;
      StoryEnvironment.colorFromName(name, out this.r, out this.g, out this.b);
      this.fromAlpha = 1f;
      this.toAlpha = 0.0f;
      this.executer.setColorAndTime(this.r, this.g, this.b, this.fromAlpha, this.toAlpha, nullable.Value);
      this.executer.startFade();
      return args[0];
    }));
    this.engine.defun("fadeout", (Func<List<object>, object>) (args =>
    {
      string name = this.lispStringToString(args[0]);
      if (name == null)
        return (object) null;
      float? nullable = this.lispNumberToFloat(args[1]);
      if (!nullable.HasValue)
        return (object) null;
      StoryEnvironment.colorFromName(name, out this.r, out this.g, out this.b);
      this.fromAlpha = 0.0f;
      this.toAlpha = 1f;
      this.executer.setColorAndTime(this.r, this.g, this.b, this.fromAlpha, this.toAlpha, nullable.Value);
      this.executer.startFade();
      return args[0];
    }));
    this.engine.defun("flush", (Func<List<object>, object>) (args =>
    {
      string name = this.lispStringToString(args[0]);
      if (name == null)
        return (object) null;
      float? nullable1 = this.lispNumberToFloat(args[1]);
      if (!nullable1.HasValue)
        return (object) null;
      int? nullable2 = this.lispNumberToInt(args[2]);
      if (!nullable2.HasValue)
        return (object) null;
      StoryEnvironment.colorFromName(name, out this.r, out this.g, out this.b);
      return this.executer.startFlush(new Color(this.r, this.g, this.b), nullable1.Value, nullable2.Value);
    }));
    this.engine.defun("textwindow", (Func<List<object>, object>) (args =>
    {
      string s = this.lispStringToString(args[0]);
      if (s == null)
        return (object) null;
      if (s == "close" || s == "")
        this.executer.setTextClose(this.current.text.pos);
      else if (s == "top_close")
        this.executer.setTextClose(TextBlock.Position.TOP);
      else if (s == "bottom_close")
        this.executer.setTextClose(TextBlock.Position.BOTTOM);
      else if (this.current.text.pos == TextBlock.Position.TOP)
        this.executer.setTextTopWindow(s);
      else
        this.executer.setTextBottomWindow(s);
      return args[0];
    }));
    this.engine.defun("textsize", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      if (this.current.text.pos == TextBlock.Position.TOP)
        this.executer.setTextSize(nullable.Value, true);
      else
        this.executer.setTextSize(nullable.Value, false);
      return args[0];
    }));
    this.engine.defun("textshake", (Func<List<object>, object>) (args =>
    {
      float? nullable = this.lispNumberToFloat(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      if (this.current.text.pos == TextBlock.Position.TOP)
        this.executer.setTextShake(nullable.Value, true);
      else
        this.executer.setTextShake(nullable.Value, false);
      return args[0];
    }));
    this.engine.defun("textcolor", (Func<List<object>, object>) (args =>
    {
      string color = this.lispStringToString(args[0]);
      if (color == null)
        return (object) null;
      this.executer.SetColorText(this.current.text.pos, color);
      return args[0];
    }));
    this.engine.defun("textalign", (Func<List<object>, object>) (args =>
    {
      string align = this.lispStringToString(args[0]);
      if (align == null)
        return (object) null;
      this.executer.SetTextAlgin(this.current.text.pos, align);
      return args[0];
    }));
    this.engine.defun("textstop", (Func<List<object>, object>) (args =>
    {
      this.executer.SetColorText(this.current.text.pos, "normal");
      if (this.current.text.pos == TextBlock.Position.TOP)
      {
        this.executer.setTextSize(24, true);
        this.executer.setTextTopWindow("normal");
      }
      else
      {
        this.executer.setTextSize(24, false);
        this.executer.setTextBottomWindow("normal");
      }
      if (this.current.text.pos == TextBlock.Position.TOP)
        this.executer.stopTextShake(true);
      else
        this.executer.stopTextShake(false);
      return args[0];
    }));
    this.engine.defun("shake", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      float w = 3f;
      if (nullable1.Value != 0)
        w = 7f;
      float? nullable2 = this.lispNumberToFloat(args[1]);
      this.executer.setShake(w, nullable2.Value);
      return args[0];
    }));
    this.engine.defun("shakeloop", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      float w = 3f;
      if (nullable.Value != 0)
        w = 7f;
      this.executer.setShake(w, 0.0f);
      return (object) null;
    }));
    this.engine.defun("shakestop", (Func<List<object>, object>) (args =>
    {
      this.executer.stopShake();
      return (object) null;
    }));
    this.engine.defun("imageset", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) false;
      string name = this.lispStringToString(args[1]);
      if (name == null)
        return (object) null;
      this.executer.setImageName(nullable.Value, name);
      return args[0];
    }));
    this.engine.defun("imagelayer", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) false;
      int? nullable2 = this.lispNumberToInt(args[1]);
      if (!nullable2.HasValue)
        return (object) false;
      this.executer.setImagePriority(nullable1.Value, nullable2.Value);
      return args[0];
    }));
    this.engine.defun("imagepos", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      float? nullable2 = this.lispNumberToFloat(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      float? nullable3 = this.lispNumberToFloat(args[2]);
      if (!nullable3.HasValue)
        return (object) null;
      this.executer.setImagePosition(nullable1.Value, nullable2.Value, nullable3.Value);
      return args[0];
    }));
    this.engine.defun("imagealpha", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      float? nullable2 = this.lispNumberToFloat(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      float? nullable3 = this.lispNumberToFloat(args[2]);
      if (!nullable3.HasValue)
        return (object) null;
      this.executer.setImageAlpha(nullable1.Value, nullable2.Value, nullable3.Value);
      return args[0];
    }));
    this.engine.defun("imagescale", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      float? nullable2 = this.lispNumberToFloat(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      float? nullable3 = this.lispNumberToFloat(args[2]);
      if (!nullable3.HasValue)
        return (object) null;
      this.executer.setImageScale(nullable1.Value, nullable2.Value, nullable3.Value);
      return args[0];
    }));
    this.engine.defun("imageleftin", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      float? nullable2 = this.lispNumberToFloat(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      this.executer.setImageMoveIn(nullable1.Value, nullable2.Value, -2500f, 0.0f);
      return args[0];
    }));
    this.engine.defun("imagerightin", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      float? nullable2 = this.lispNumberToFloat(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      this.executer.setImageMoveIn(nullable1.Value, nullable2.Value, 2500f, 0.0f);
      return args[0];
    }));
    this.engine.defun("imageleftout", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      float? nullable2 = this.lispNumberToFloat(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      this.executer.setImageMoveOut(nullable1.Value, nullable2.Value, -2500f, 0.0f);
      return args[0];
    }));
    this.engine.defun("imagerightout", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      float? nullable2 = this.lispNumberToFloat(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      this.executer.setImageMoveOut(nullable1.Value, nullable2.Value, 2500f, 0.0f);
      return args[0];
    }));
    this.engine.defun("imagemoveto", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) null;
      float? nullable2 = this.lispNumberToFloat(args[1]);
      if (!nullable2.HasValue)
        return (object) null;
      float? nullable3 = this.lispNumberToFloat(args[2]);
      if (!nullable3.HasValue)
        return (object) null;
      float? nullable4 = this.lispNumberToFloat(args[3]);
      if (!nullable4.HasValue)
        return (object) null;
      this.executer.setImageMoveOut(nullable1.Value, nullable4.Value, nullable2.Value, nullable3.Value);
      return args[0];
    }));
    this.engine.defun("emotion", (Func<List<object>, object>) (args =>
    {
      if (!this.lispNumberToInt(args[0]).HasValue)
        return (object) false;
      string str = this.lispStringToString(args[1]);
      if (str == null)
        return (object) null;
      if (!this.lispNumberToFloat(args[2]).HasValue)
        return (object) null;
      if (!this.lispNumberToFloat(args[3]).HasValue)
        return (object) null;
      if (str == "del")
        this.executer.deleteEmotion();
      else if (str == "brightness")
        this.executer.setEmotionBright();
      else
        this.executer.setEmotion();
      return args[0];
    }));
    this.engine.defun("voice", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) false;
      string name = this.lispStringToString(args[1]);
      if (name == null)
        return (object) null;
      this.executer.setVoice(nullable.Value.ToString(), name);
      return args[0];
    }));
    this.engine.defun("voicedelay", (Func<List<object>, object>) (args =>
    {
      int? nullable1 = this.lispNumberToInt(args[0]);
      if (!nullable1.HasValue)
        return (object) false;
      string name = this.lispStringToString(args[1]);
      if (name == null)
        return (object) null;
      float? nullable2 = this.lispNumberToFloat(args[2]);
      if (!nullable2.HasValue)
        return (object) false;
      this.executer.setVoice(nullable1.Value.ToString(), name, nullable2.Value);
      return args[0];
    }));
    this.engine.defun("se", (Func<List<object>, object>) (args =>
    {
      string clip = this.lispStringToString(args[0]);
      if (clip == null)
        return (object) null;
      this.executer.setSe(clip);
      return args[0];
    }));
    this.engine.defun("sedelay", (Func<List<object>, object>) (args =>
    {
      string clip = this.lispStringToString(args[0]);
      if (clip == null)
        return (object) null;
      float? nullable = this.lispNumberToFloat(args[1]);
      if (!nullable.HasValue)
        return (object) false;
      this.executer.setSe(clip, nullable.Value);
      return args[0];
    }));
    this.engine.defun("sestop", (Func<List<object>, object>) (args =>
    {
      string clip = this.lispStringToString(args[0]);
      if (clip == null)
        return (object) null;
      this.executer.stopSe(clip);
      return args[0];
    }));
    this.engine.defun("sestopdelay", (Func<List<object>, object>) (args =>
    {
      string clip = this.lispStringToString(args[0]);
      if (clip == null)
        return (object) null;
      float? nullable = this.lispNumberToFloat(args[1]);
      if (!nullable.HasValue)
        return (object) false;
      this.executer.stopSe(clip, nullable.Value);
      return args[0];
    }));
    this.engine.defun("bgm", (Func<List<object>, object>) (args =>
    {
      string s = this.lispStringToString(args[0]);
      if (s == null)
        return (object) null;
      if (s == "stop")
      {
        this.executer.stopBgm();
      }
      else
      {
        float? nullable = this.lispNumberToFloat(args[1]);
        if ((double) nullable.Value < 0.699999988079071)
          this.executer.setBgm(s);
        else
          this.executer.setBgm(s, nullable.Value);
      }
      return args[0];
    }));
    this.engine.defun("bgmfile", (Func<List<object>, object>) (args =>
    {
      string s = this.lispStringToString(args[0]);
      if (s == null)
        return (object) null;
      if (s == "stop")
      {
        this.executer.stopBgm();
      }
      else
      {
        string file = this.lispStringToString(args[1]);
        float? nullable = this.lispNumberToFloat(args[2]);
        if ((double) nullable.Value < 0.699999988079071)
          this.executer.setBgmFile(file, s);
        else
          this.executer.setBgmFile(file, s, nullable.Value);
      }
      return args[0];
    }));
    this.engine.defun("setnextbgmblock", (Func<List<object>, object>) (args =>
    {
      int? nullable = this.lispNumberToInt(args[0]);
      if (!nullable.HasValue)
        return (object) null;
      this.executer.setNextBgmBlock(nullable.Value);
      return args[0];
    }));
    this.engine.defun("movieplay", (Func<List<object>, object>) (args =>
    {
      string fileName = this.lispStringToString(args[0]);
      if (fileName == null)
        return (object) null;
      bool enabledSkip = (args.Count<object>() < 2 ? "skip" : this.lispStringToString(args[1])) == "skip";
      this.executer.PlayMovie(fileName, enabledSkip);
      return args[0];
    }));
    this.engine.defun("flag", (Func<List<object>, object>) (args =>
    {
      if (args.Count < 2)
        return (object) null;
      return this.lispStringToString(args[0]) == null ? (object) null : args[0];
    }));
    this.engine.defun("flagjump", (Func<List<object>, object>) (args =>
    {
      if (args.Count < 2)
        return (object) null;
      string v = this.lispStringToString(args[0]);
      if (v == null)
        return (object) null;
      bool? nullable = (bool?) this.getVariable(v);
      if (!nullable.HasValue)
      {
        this.setVariable(v, (object) false);
        nullable = new bool?(false);
      }
      this.setNextLabel(this.lispStringToString(args[1]));
      return args[0];
    }));
    this.engine.defun("labeljump", (Func<List<object>, object>) (args =>
    {
      if (args.Count < 1)
        return (object) null;
      this.setNextLabel(this.lispStringToString(args[0]));
      return args[0];
    }));
    this.engine.defun("select", (Func<List<object>, object>) (args =>
    {
      if (args.Count < 2 || args.Count % 2 != 0)
        return (object) null;
      SelectBlock sb = new SelectBlock();
      int num = args.Count / 2;
      for (int index = 0; index < num; ++index)
      {
        SelectBlock.Data data = new SelectBlock.Data();
        data.msg = this.lispStringToString(args[index * 2]);
        data.label = this.lispStringToString(args[index * 2 + 1]);
        if (data.msg == null || data.label == null)
          return (object) null;
        sb.data.Add(data);
      }
      this.current.setSelect(sb);
      this.executer.StartSelect(sb);
      this.current.next_enable = false;
      return args[0];
    }));
    this.engine.defun("popupstoryeffect", (Func<List<object>, object>) (args =>
    {
      if (args.Count < 1)
        return (object) null;
      this.executer.PopupStoryEffect(this.lispStringToString(args[0]));
      return args[0];
    }));
  }

  public bool SkipReady()
  {
    if (StoryEnvironment.IsNoWaitOnChoise)
      return true;
    return this.storyBlocks != null && this.storyBlocks.Count > 0 && this.current.select == null;
  }

  public StoryBlock current => this.storyBlocks[this.currentIdx];

  public ReadOnlyCollection<StoryBlock> all() => new ReadOnlyCollection<StoryBlock>((IList<StoryBlock>) this.storyBlocks);

  public void initialize(string program, StoryExecuter exec)
  {
    this.engine = new Lisp(this.scriptEnv);
    this.executer = exec;
    this.defineVariables();
    this.defunCommands();
    this.storyBlocks = new StoryParser().parse(program, this.scriptEnv);
    this.currentIdx = 0;
  }

  public void setVariable(string v, object o) => this.scriptEnv[v] = o;

  public object getVariable(string v)
  {
    try
    {
      return this.scriptEnv[v];
    }
    catch (Exception ex)
    {
      UnityEngine.Debug.LogError((object) ("getVariable not found name=" + v));
      return (object) null;
    }
  }

  public object nextBlock()
  {
    if (this.nextBlockp())
    {
      if (this.nextLabel == null)
      {
        ++this.currentIdx;
      }
      else
      {
        this.setCurrent(this.nextLabel);
        this.nextLabel = (string) null;
      }
    }
    return (object) this.storyBlocks[this.currentIdx];
  }

  public object resetBlock()
  {
    this.currentIdx = 0;
    return (object) this.storyBlocks[this.currentIdx];
  }

  public object backBlock() => (object) this.storyBlocks[this.currentIdx - 1];

  public bool nextBlockp() => this.nextLabel != null || this.currentIdx < this.storyBlocks.Count - 1;

  public object setCurrent(string label)
  {
    int num = 0;
    foreach (StoryBlock storyBlock in this.storyBlocks)
    {
      if (storyBlock.label == label)
      {
        this.currentIdx = num;
        return (object) label;
      }
      ++num;
    }
    return (object) null;
  }

  public void evalCurrent() => this.current.eval(this.engine);

  public void setNextLabel(string label) => this.nextLabel = label;
}

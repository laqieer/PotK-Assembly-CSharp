﻿// Decompiled with JetBrains decompiler
// Type: MypagePopupInformation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class MypagePopupInformation : MonoBehaviour
{
  [SerializeField]
  private TweenAlpha outTweenAlpha;
  [SerializeField]
  private TweenPosition outTweenPosition;
  [SerializeField]
  private MypagePopupInformation.Node[] nodes_;
  [SerializeField]
  private MypagePopupInformation.TypeData[] baseSheets_ = new MypagePopupInformation.TypeData[1];
  private bool pause_ = true;
  private bool initialized_;
  private bool clearAnime_;
  private int idCount_;
  private Queue<MypagePopupInformation.Sheet> que_ = new Queue<MypagePopupInformation.Sheet>();
  private MypagePopupInformation.Popup[] popups_ = new MypagePopupInformation.Popup[0];

  private int generatId
  {
    get
    {
      do
        ;
      while (++this.idCount_ == 0);
      return this.idCount_;
    }
  }

  [DebuggerHidden]
  public IEnumerator init()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MypagePopupInformation.\u003Cinit\u003Ec__Iterator9DF()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator loadData()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MypagePopupInformation.\u003CloadData\u003Ec__Iterator9E0()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void Update()
  {
    float time = Time.time;
    int num = 0;
    for (int index = 0; index < this.popups_.Length; ++index)
    {
      MypagePopupInformation.Popup popup = this.popups_[index];
      if (popup != null)
      {
        if (popup.popup_.activeSelf)
        {
          if (!popup.ending_ && (this.clearAnime_ || (double) popup.out_ <= (double) time))
          {
            popup.sheet_.sendChangeState(MypagePopupInformation.SheetState.FadeOut);
            this.attachAnimationOut(popup.popup_);
            popup.ending_ = true;
          }
          ++num;
        }
        else if (this.clearAnime_ || popup.ending_)
        {
          popup.sheet_.sendChangeState(MypagePopupInformation.SheetState.Finished);
          Object.Destroy((Object) popup.popup_);
          popup.sheet_ = (MypagePopupInformation.Sheet) null;
          popup.popup_ = (GameObject) null;
          this.popups_[index] = (MypagePopupInformation.Popup) null;
        }
        else
        {
          if ((double) popup.in_ <= (double) time)
          {
            popup.sheet_.sendChangeState(MypagePopupInformation.SheetState.FadeIn);
            popup.popup_.SetActive(true);
          }
          ++num;
        }
      }
    }
    if (!this.pause_ && this.initialized_ && num == 0 && this.que_.Count > 0)
    {
      int length = this.popups_.Length;
      List<MypagePopupInformation.Sheet> slst = new List<MypagePopupInformation.Sheet>();
      for (; length > 0 && this.que_.Count > 0; --length)
        slst.Add(this.que_.Dequeue());
      this.createSheets(slst);
    }
    this.clearAnime_ = false;
  }

  private void attachAnimationOut(GameObject go)
  {
    GameObject go1 = go.GetComponent<MypageInformationSheet>().node_;
    if (Object.op_Equality((Object) go1, (Object) null))
      go1 = go;
    TweenAlpha tweenAlpha = TweenAlpha.Begin(go1, this.outTweenAlpha.duration, this.outTweenAlpha.to);
    tweenAlpha.style = this.outTweenAlpha.style;
    tweenAlpha.animationCurve = this.outTweenAlpha.animationCurve;
    tweenAlpha.tweenGroup = this.outTweenAlpha.tweenGroup;
    tweenAlpha.ignoreTimeScale = this.outTweenAlpha.ignoreTimeScale;
    tweenAlpha.AddOnFinished(new EventDelegate.Callback(go.GetComponent<MypageInformationSheet>().onOutFinished));
    Vector3 pos = Vector3.op_Subtraction(this.outTweenPosition.to, ((Component) this).gameObject.transform.localPosition);
    TweenPosition tweenPosition = TweenPosition.Begin(go1, this.outTweenPosition.duration, pos);
    tweenPosition.style = this.outTweenPosition.style;
    tweenPosition.animationCurve = this.outTweenPosition.animationCurve;
    tweenPosition.tweenGroup = this.outTweenPosition.tweenGroup;
    tweenPosition.ignoreTimeScale = this.outTweenPosition.ignoreTimeScale;
    tweenPosition.AddOnFinished(new EventDelegate.Callback(go.GetComponent<MypageInformationSheet>().onOutFinished));
  }

  private void createSheets(List<MypagePopupInformation.Sheet> slst)
  {
    int index = 0;
    float time = Time.time;
    foreach (MypagePopupInformation.Sheet sheet in slst)
    {
      MypagePopupInformation.Popup popup = new MypagePopupInformation.Popup();
      popup.sheet_ = sheet;
      popup.ending_ = false;
      MypagePopupInformation.Node node = this.nodes_[index];
      popup.popup_ = this.createSheet(node.node_, popup.sheet_);
      if (Object.op_Inequality((Object) popup.popup_, (Object) null))
      {
        this.popups_[index] = popup;
        if ((double) node.timeIn_ > 0.0)
        {
          popup.in_ = node.timeIn_ + time;
        }
        else
        {
          sheet.sendChangeState(MypagePopupInformation.SheetState.FadeIn);
          popup.popup_.SetActive(true);
        }
        popup.out_ = node.timeOut_ + time;
        if ((double) sheet.life_ > 0.0)
          popup.out_ += sheet.life_;
      }
      ++index;
    }
  }

  private GameObject createSheet(GameObject parent, MypagePopupInformation.Sheet s)
  {
    int type = (int) s.type_;
    if (type < 0 || type >= 1)
    {
      s.sendChangeState(MypagePopupInformation.SheetState.Error);
      return (GameObject) null;
    }
    MypagePopupInformation.TypeData baseSheet = this.baseSheets_[type];
    GameObject sheet = NGUITools.AddChild(parent, baseSheet.prefab_);
    MypageInformationSheet component = sheet.GetComponent<MypageInformationSheet>();
    if (Object.op_Inequality((Object) component, (Object) null))
    {
      if (Object.op_Inequality((Object) component.txtTitle_, (Object) null))
        component.txtTitle_.SetTextLocalize(!string.IsNullOrEmpty(s.title_) ? s.title_ : baseSheet.title_);
      if (Object.op_Inequality((Object) component.txtMessage_, (Object) null) && !string.IsNullOrEmpty(s.message_))
        component.txtMessage_.SetTextLocalize(s.message_);
      s.sendChangeState(MypagePopupInformation.SheetState.Entry);
      sheet.SetActive(false);
    }
    else
    {
      Object.Destroy((Object) sheet);
      s.sendChangeState(MypagePopupInformation.SheetState.Error);
      sheet = (GameObject) null;
    }
    return sheet;
  }

  public int setMessage(
    string message,
    MypagePopupInformation.CallbackChangeState onChangeState = null,
    float life = 0.0f,
    string title = null,
    MypagePopupInformation.Type type = MypagePopupInformation.Type.MissionClear)
  {
    if (this.que_ == null)
      this.que_ = new Queue<MypagePopupInformation.Sheet>();
    int generatId = this.generatId;
    this.que_.Enqueue(new MypagePopupInformation.Sheet(generatId, title, message, life, type, onChangeState));
    return generatId;
  }

  public bool cancelMessage(int id)
  {
    int count = this.que_.Count;
    if (count == 0)
      return false;
    Queue<MypagePopupInformation.Sheet> sheetQueue = new Queue<MypagePopupInformation.Sheet>();
    for (int index = 0; index < count; ++index)
    {
      MypagePopupInformation.Sheet sheet = this.que_.Dequeue();
      if (sheet.id_ != id)
        sheetQueue.Enqueue(sheet);
    }
    this.que_ = sheetQueue;
    return this.que_.Count != count;
  }

  public void pause() => this.pause_ = true;

  public void resume() => this.pause_ = false;

  public void clearAll(bool clearAnimation = true)
  {
    if (this.que_ != null)
      this.que_.Clear();
    if (clearAnimation)
    {
      this.clearAnime_ = true;
    }
    else
    {
      for (int index = 0; index < this.popups_.Length; ++index)
      {
        MypagePopupInformation.Popup popup = this.popups_[index];
        if (popup != null)
        {
          popup.sheet_ = (MypagePopupInformation.Sheet) null;
          if (Object.op_Inequality((Object) popup.popup_, (Object) null))
          {
            Object.Destroy((Object) popup.popup_);
            popup.popup_ = (GameObject) null;
          }
          this.popups_[index] = (MypagePopupInformation.Popup) null;
        }
      }
    }
  }

  public enum Type
  {
    None = -1, // 0xFFFFFFFF
    MissionClear = 0,
    Num = 1,
  }

  [Serializable]
  private class TypeData
  {
    public GameObject prefab_;
    public string title_ = string.Empty;
  }

  [Serializable]
  private class Node
  {
    public GameObject node_;
    public float timeIn_;
    public float timeOut_;
  }

  public enum SheetState
  {
    Entry,
    FadeIn,
    FadeOut,
    Finished,
    Error,
  }

  private class Sheet
  {
    public int id_;
    public MypagePopupInformation.Type type_;
    public float life_;
    public string title_;
    public string message_;
    public MypagePopupInformation.CallbackChangeState onChangeState_;

    public Sheet()
    {
      this.id_ = 0;
      this.type_ = MypagePopupInformation.Type.None;
      this.life_ = 1f;
      this.title_ = string.Empty;
      this.message_ = string.Empty;
      this.onChangeState_ = (MypagePopupInformation.CallbackChangeState) null;
    }

    public Sheet(
      int id,
      string title,
      string message,
      float life,
      MypagePopupInformation.Type type,
      MypagePopupInformation.CallbackChangeState func)
    {
      this.id_ = id;
      this.type_ = type;
      this.life_ = life;
      this.title_ = title;
      this.message_ = message;
      this.onChangeState_ = func;
    }

    public Sheet(MypagePopupInformation.Sheet s)
    {
      this.id_ = s.id_;
      this.type_ = s.type_;
      this.life_ = s.life_;
      this.title_ = s.title_;
      this.message_ = s.message_;
      this.onChangeState_ = s.onChangeState_;
    }

    ~Sheet() => this.onChangeState_ = (MypagePopupInformation.CallbackChangeState) null;

    public void sendChangeState(MypagePopupInformation.SheetState state)
    {
      if (this.onChangeState_ == null)
        return;
      if (!this.onChangeState_(this.id_, state))
        this.onChangeState_ = (MypagePopupInformation.CallbackChangeState) null;
      switch (state)
      {
        case MypagePopupInformation.SheetState.Finished:
        case MypagePopupInformation.SheetState.Error:
          this.onChangeState_ = (MypagePopupInformation.CallbackChangeState) null;
          break;
      }
    }
  }

  private class Popup
  {
    public MypagePopupInformation.Sheet sheet_;
    public GameObject popup_;
    public float in_;
    public float out_;
    public bool ending_;

    ~Popup()
    {
      this.sheet_ = (MypagePopupInformation.Sheet) null;
      if (!Object.op_Inequality((Object) this.popup_, (Object) null))
        return;
      Object.Destroy((Object) this.popup_);
      this.popup_ = (GameObject) null;
    }
  }

  public delegate bool CallbackChangeState(int id, MypagePopupInformation.SheetState state);
}

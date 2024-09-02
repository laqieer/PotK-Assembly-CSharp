// Decompiled with JetBrains decompiler
// Type: SimpleInput
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public sealed class SimpleInput
{
  private const float DRAG_MIN_RADIUS = 5f;
  public static int JoystickOffset = 111;
  private static Dictionary<int, Touch> m_touchs = new Dictionary<int, Touch>();
  private static bool m_isClicked = false;
  private static Vector2 m_clickedPos = Vector2.zero;
  private static bool m_isDoubleClicked = false;
  private static Vector2 m_doubleClickedPos = Vector2.zero;
  private static bool m_isZoomed = false;
  private static float m_zoomFactor;
  private static bool m_isDraged = false;
  private static float m_eulerAngle = -1000f;
  private static Vector2 m_startPoint = Vector2.zero;
  private static Vector2 m_endPoint = Vector2.zero;
  private static bool m_dragMeet = false;
  private static float m_fingerDistance = 0.0f;
  private static bool m_dragMouseDown = false;
  private static bool m_isNGUIClick = false;
  private static float m_clickTime = Time.unscaledTime;
  private static bool m_enable = true;
  public static float ValidAreaX = 0.5f;
  public static float ValidAreaY = 0.5f;

  public static bool Enable
  {
    set
    {
      SimpleInput.m_enable = value;
      SimpleInput.Reset();
    }
  }

  public static void Reset()
  {
    SimpleInput.m_touchs.Clear();
    SimpleInput.m_isClicked = false;
    SimpleInput.m_isDoubleClicked = false;
    SimpleInput.m_isDraged = false;
    SimpleInput.m_isZoomed = false;
    SimpleInput.m_dragMeet = false;
    SimpleInput.m_fingerDistance = 0.0f;
    SimpleInput.m_dragMouseDown = false;
    SimpleInput.m_isNGUIClick = false;
  }

  public static void Update()
  {
    if (!SimpleInput.m_enable)
      return;
    SimpleInput.m_isClicked = false;
    SimpleInput.m_isDoubleClicked = false;
    SimpleInput.m_isDraged = false;
    SimpleInput.m_isZoomed = false;
    if (Application.platform == 11 || Application.platform == 8)
    {
      for (int index = 0; index < Input.touchCount; ++index)
      {
        Touch touch1 = Input.GetTouch(index);
        if (((Touch) ref touch1).phase == null)
        {
          if (!SimpleInput.HasClickGUI(((Touch) ref touch1).position.x, ((Touch) ref touch1).position.y) && !SimpleInput.m_touchs.ContainsKey(((Touch) ref touch1).fingerId))
            SimpleInput.m_touchs.Add(((Touch) ref touch1).fingerId, touch1);
        }
        else if (((Touch) ref touch1).phase == 3 || ((Touch) ref touch1).phase == 4)
        {
          if (SimpleInput.m_touchs.ContainsKey(((Touch) ref touch1).fingerId))
          {
            if (!SimpleInput.m_isDoubleClicked && ((Touch) ref touch1).tapCount == 2)
            {
              SimpleInput.m_isDoubleClicked = true;
              SimpleInput.m_doubleClickedPos = ((Touch) ref touch1).position;
            }
            if (!SimpleInput.m_isDoubleClicked && !SimpleInput.m_isClicked && ((Touch) ref touch1).tapCount == 1)
            {
              SimpleInput.m_isClicked = true;
              SimpleInput.m_clickedPos = ((Touch) ref touch1).position;
            }
            SimpleInput.m_touchs.Remove(((Touch) ref touch1).fingerId);
          }
        }
        else if (SimpleInput.m_touchs.ContainsKey(((Touch) ref touch1).fingerId))
        {
          if (!SimpleInput.m_isDraged)
          {
            bool flag = true;
            if (!SimpleInput.m_dragMeet)
            {
              Touch touch2 = SimpleInput.m_touchs[((Touch) ref touch1).fingerId];
              SimpleInput.m_startPoint = ((Touch) ref touch2).position;
              flag = SimpleInput.IsInDragValidArea(SimpleInput.m_startPoint);
            }
            SimpleInput.m_endPoint = ((Touch) ref touch1).position;
            Vector2 vector2 = Vector2.op_Subtraction(SimpleInput.m_endPoint, SimpleInput.m_startPoint);
            if (flag && ((double) ((Vector2) ref vector2).magnitude > 5.0 || SimpleInput.m_dragMeet))
            {
              SimpleInput.m_eulerAngle = (double) SimpleInput.m_startPoint.x <= (double) SimpleInput.m_endPoint.x ? Vector2.Angle(new Vector2(0.0f, 1f), vector2) : -Vector2.Angle(new Vector2(0.0f, 1f), vector2);
              float num1 = (double) ((float) Screen.width / (float) Screen.height) < 1.7777777910232544 ? 2048f / (float) Screen.width : 1152f / (float) Screen.height;
              float num2 = (float) (SimpleInput.JoystickOffset * 2) / num1;
              float num3 = ((Vector2) ref vector2).magnitude - num2;
              if ((double) num3 > 0.0)
                SimpleInput.m_startPoint = Vector2.op_Addition(SimpleInput.m_startPoint, Vector2.op_Multiply(((Vector2) ref vector2).normalized, num3));
              SimpleInput.m_dragMeet = true;
              SimpleInput.m_isDraged = true;
            }
          }
          SimpleInput.m_touchs[((Touch) ref touch1).fingerId] = touch1;
        }
      }
      if (SimpleInput.m_touchs.Count > 1)
      {
        int num4 = 0;
        Touch[] touchArray = new Touch[2];
        foreach (Touch touch in SimpleInput.m_touchs.Values)
        {
          touchArray[num4++] = touch;
          if (num4 == 2)
            break;
        }
        if ((double) SimpleInput.m_fingerDistance == 0.0)
          SimpleInput.m_fingerDistance = Vector2.Distance(((Touch) ref touchArray[0]).position, ((Touch) ref touchArray[1]).position);
        float num5 = Vector2.Distance(((Touch) ref touchArray[0]).position, ((Touch) ref touchArray[1]).position);
        SimpleInput.m_zoomFactor = (float) (-((double) num5 - (double) SimpleInput.m_fingerDistance) * 0.10000000149011612);
        SimpleInput.m_isZoomed = true;
        SimpleInput.m_fingerDistance = num5;
        SimpleInput.m_isClicked = false;
        SimpleInput.m_isDoubleClicked = false;
        SimpleInput.m_isDraged = false;
      }
      else if ((double) SimpleInput.m_fingerDistance > 0.0)
        SimpleInput.Reset();
      else
        SimpleInput.m_fingerDistance = 0.0f;
    }
    else
    {
      Vector3 mousePosition = Input.mousePosition;
      bool flag = SimpleInput.HasClickGUI(mousePosition.x, mousePosition.y);
      if (Input.GetMouseButtonUp(0))
      {
        if (!SimpleInput.m_isNGUIClick)
        {
          float unscaledTime = Time.unscaledTime;
          if ((double) SimpleInput.m_clickTime + 0.30000001192092896 > (double) unscaledTime)
          {
            SimpleInput.m_isDoubleClicked = true;
            SimpleInput.m_doubleClickedPos = Vector2.op_Implicit(Input.mousePosition);
          }
          else
          {
            SimpleInput.m_isClicked = true;
            SimpleInput.m_clickedPos = Vector2.op_Implicit(Input.mousePosition);
          }
          SimpleInput.m_clickTime = unscaledTime;
        }
        SimpleInput.m_dragMouseDown = false;
      }
      if (Input.GetMouseButtonDown(0))
      {
        SimpleInput.m_isNGUIClick = flag;
        if (!flag)
        {
          SimpleInput.m_startPoint = Vector2.op_Implicit(Input.mousePosition);
          SimpleInput.m_dragMouseDown = SimpleInput.IsInDragValidArea(SimpleInput.m_startPoint);
        }
      }
      if (SimpleInput.m_dragMouseDown)
      {
        SimpleInput.m_endPoint = Vector2.op_Implicit(Input.mousePosition);
        Vector2 vector2 = Vector2.op_Subtraction(SimpleInput.m_endPoint, SimpleInput.m_startPoint);
        if ((double) ((Vector2) ref vector2).magnitude > 5.0 || SimpleInput.m_dragMeet)
        {
          SimpleInput.m_eulerAngle = (double) SimpleInput.m_startPoint.x <= (double) SimpleInput.m_endPoint.x ? Vector2.Angle(new Vector2(0.0f, 1f), vector2) : -Vector2.Angle(new Vector2(0.0f, 1f), vector2);
          float num6 = (double) ((float) Screen.width / (float) Screen.height) < 1.7777777910232544 ? 2048f / (float) Screen.width : 1152f / (float) Screen.height;
          float num7 = (float) (SimpleInput.JoystickOffset * 2) / num6;
          float num8 = ((Vector2) ref vector2).magnitude - num7;
          if ((double) num8 > 0.0)
            SimpleInput.m_startPoint = Vector2.op_Addition(SimpleInput.m_startPoint, Vector2.op_Multiply(((Vector2) ref vector2).normalized, num8));
          SimpleInput.m_dragMeet = true;
          SimpleInput.m_isDraged = true;
        }
      }
      SimpleInput.m_zoomFactor = Input.GetAxis("Mouse ScrollWheel");
      if ((double) SimpleInput.m_zoomFactor > 0.0)
      {
        SimpleInput.m_zoomFactor = -1f;
        SimpleInput.m_isZoomed = true;
      }
      else if ((double) SimpleInput.m_zoomFactor < 0.0)
      {
        SimpleInput.m_zoomFactor = 1f;
        SimpleInput.m_isZoomed = true;
      }
    }
    if (!SimpleInput.m_dragMeet || SimpleInput.m_isDraged)
      return;
    SimpleInput.m_dragMeet = false;
  }

  public static bool GetTouchEnd(out float x, out float y)
  {
    x = SimpleInput.m_clickedPos.x;
    y = SimpleInput.m_clickedPos.y;
    return SimpleInput.m_isClicked;
  }

  public static bool GetTouchDouble(out float x, out float y)
  {
    x = SimpleInput.m_doubleClickedPos.x;
    y = SimpleInput.m_doubleClickedPos.y;
    return SimpleInput.m_isDoubleClicked;
  }

  public static bool GetJoystick(
    out float eulerAngle,
    out Vector2 startPoint,
    out Vector2 endPoint)
  {
    eulerAngle = SimpleInput.m_eulerAngle;
    startPoint = SimpleInput.m_startPoint;
    endPoint = SimpleInput.m_endPoint;
    return SimpleInput.m_isDraged;
  }

  public static bool GetZoom(out float zoomFactor)
  {
    zoomFactor = SimpleInput.m_zoomFactor;
    return SimpleInput.m_isZoomed;
  }

  public static bool GetMouseRight(out float x, out float y)
  {
    bool mouseRight = false;
    Vector3 vector3 = Vector3.zero;
    x = 0.0f;
    y = 0.0f;
    if (Application.platform == 7 || Application.platform == 2)
    {
      if (Input.GetMouseButton(1))
      {
        vector3 = Input.mousePosition;
        mouseRight = true;
      }
      if (mouseRight)
      {
        x = vector3.x;
        y = vector3.y;
      }
    }
    return mouseRight;
  }

  public static bool HasClickGUI(Vector3 pos) => false;

  public static bool HasClickGUI(float x, float y)
  {
    return SimpleInput.HasClickGUI(new Vector3(x, y, 0.0f));
  }

  public static bool IsInDragValidArea(Vector2 pos)
  {
    return (double) pos.x > 0.0 && (double) pos.x < (double) Screen.width * (double) SimpleInput.ValidAreaX && (double) pos.y > 0.0 && (double) pos.y < (double) Screen.height * (double) SimpleInput.ValidAreaY;
  }
}

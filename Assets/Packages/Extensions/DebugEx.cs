using System;
using System.Reflection;
using UnityEngine;

/// <summary>
/// Debug に関する拡張機能を実装します。
/// </summary>
public static class DebugEx
{
    /// <summary>
    /// 複数のメッセージを messages[length - 1] で区切ってデバッグ出力します.
    /// </summary>
    /// <param name="message">
    /// 出力するメッセージ.
    /// </param>
    /// <param name="messages">
    /// 出力するメッセージ.
    /// [messages.length - 1] 番目のメッセージで各メッセージを区切ります.
    /// </param>
    public static void Log(object message, params object[] messages)
    {
        DebugEx.Log(Debug.Log, message, messages);
    }

    /// <summary>
    /// 複数のメッセージを messages[length - 1] で区切ってデバッグ出力します.
    /// </summary>
    /// <param name="message">
    /// 出力するメッセージ.
    /// </param>
    /// <param name="messages">
    /// 出力するメッセージ.
    /// [messages.length - 1] 番目のメッセージで各メッセージを区切ります.
    /// </param>
    public static void LogWarning(object message, params object[] messages)
    {
        DebugEx.Log(Debug.LogWarning, message, messages);
    }

    /// <summary>
    /// 複数のメッセージを messages[length - 1] で区切ってデバッグ出力します.
    /// </summary>
    /// <param name="message">
    /// 出力するメッセージ.
    /// </param>
    /// <param name="messages">
    /// 出力するメッセージ.
    /// [messages.length - 1] 番目のメッセージで各メッセージを区切ります.
    /// </param>
    public static void LogError(object message, params object[] messages)
    {
        DebugEx.Log(Debug.LogError, message, messages);
    }

    /// <summary>
    /// 複数のメッセージを messages[length - 1] で区切ってデバッグ出力します.
    /// </summary>
    /// <param name="logAction">
    /// Debug.Log~ アクション.
    /// </param>
    /// <param name="message">
    /// 出力するメッセージ.
    /// </param>
    /// <param name="messages">
    /// 出力するメッセージ.
    /// [messages.length - 1] 番目のメッセージで各メッセージを区切ります.
    /// </param>
    private static void Log(Action<object> logAction, object message, params object[] messages)
    {
        int messagesLength = messages.Length;

        if (messagesLength == 0)
        {
            logAction(message);
            return;
        }

        string split = messages[messagesLength - 1].ToString();

        for (int i = 0; i < messagesLength - 1; i++)
        {
            message += split + messages[i];
        }

        logAction(message);
    }

    /// <summary>
    /// 条件を満たすとき, 複数のメッセージを messages[length - 1] で区切ってデバッグ出力します.
    /// </summary>
    /// <param name="condition">
    /// 条件.
    /// </param>
    /// <param name="message">
    /// 出力するメッセージ.
    /// </param>
    /// <param name="messages">
    /// 出力するメッセージ.
    /// [messages.length - 1] 番目のメッセージで各メッセージを区切ります.
    /// </param>
    public static void LogIf(bool condition, object message, params object[] messages)
    {
        if (condition)
        {
            DebugEx.Log(Debug.Log, message, messages);
        }
    }

    /// <summary>
    /// 条件を満たすとき, 複数のメッセージを messages[length - 1] で区切ってデバッグ出力します.
    /// </summary>
    /// <param name="condition">
    /// 条件.
    /// </param>
    /// <param name="message">
    /// 出力するメッセージ.
    /// </param>
    /// <param name="messages">
    /// 出力するメッセージ.
    /// [messages.length - 1] 番目のメッセージで各メッセージを区切ります.
    /// </param>
    public static void LogWarningIf(bool condition, object message, params object[] messages)
    {
        if (condition)
        {
            DebugEx.Log(Debug.LogWarning, message, messages);
        }
    }

    /// <summary>
    /// 条件を満たすとき, 複数のメッセージを messages[length - 1] で区切ってデバッグ出力します.
    /// </summary>
    /// <param name="condition">
    /// 条件.
    /// </param>
    /// <param name="message">
    /// 出力するメッセージ.
    /// </param>
    /// <param name="messages">
    /// 出力するメッセージ.
    /// [messages.length - 1] 番目のメッセージで各メッセージを区切ります.
    /// </param>
    public static void LogErrorIf(bool condition, object message, params object[] messages)
    {
        if (condition)
        {
            DebugEx.Log(Debug.LogError, message, messages);
        }
    }

    /// <summary>
    /// 条件を満たすとき, 複数のメッセージを messages[length - 1] で区切ってデバッグ出力します.
    /// </summary>
    /// <param name="logAction">
    /// Debug.Log~ アクション.
    /// </param>
    /// <param name="condition">
    /// 条件.
    /// </param>
    /// <param name="message">
    /// 出力するメッセージ.
    /// </param>
    /// <param name="messages">
    /// 出力するメッセージ.
    /// [messages.length - 1] 番目のメッセージで各メッセージを区切ります.
    /// </param>
    private static void LogIf(Action<object> logAction, bool condition, object message, params object[] messages)
    {
        if (condition)
        {
            DebugEx.Log(logAction, message, messages);
        }
    }

    /// <summary>
    /// オブジェクトに定義されたすべてのフィールドの値を出力します。
    /// </summary>
    /// <param name="data">
    /// フィールドの値を出力するオブジェクトのインスタンス。
    /// </param>
    public static void LogField(object data)
    {
        FieldInfo fieldInfo;
        FieldInfo[] fieldInfos = data.GetType().GetFields(BindingFlags.NonPublic
                                                        | BindingFlags.Public
                                                        | BindingFlags.Instance);

        if (fieldInfos.Length == 0)
        {
            return;
        }

        const string BR = "\n";

        string result = "Log Field : " + data.ToString() + "\nSelect & See below window.\n";

        for (var i = 0; i < fieldInfos.Length; i++)
        {
            fieldInfo = fieldInfos[i];
            result += BR + fieldInfo.Name + " : " + fieldInfo.GetValue(data);
        }

        result += BR;

        Debug.Log(result);
    }
}
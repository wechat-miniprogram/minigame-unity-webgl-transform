// The MIT License (MIT)

// Copyright 2015 Siney/Pangweiwei siney@yeah.net / jiangzhhhh  jiangzhhhh@gmail.com
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Text;
using System;

namespace SLua
{
    public class LuaConsole : EditorWindow
    {
        #region COMMON_DEFINE
        const string COMMON_DEFINE = @"
local function prettyTabToStr(tab, level, path, visited)
    local result = ''
    if level == nil then
        visited = {}
        level = 0
        path = '(self)'
    end

    if visited[tab] then
        return string.format( '%s%s\n', string.rep('\t', level), visited[tab] )
    end
    visited[tab] = path

    result = result .. string.format('%s{\n', string.rep('\t', level))
    local ignore = {}
    for i,v in ipairs(tab)do
        ignore[i] = true
        if type(v) == 'table' then
            local newPath = path .. '.' .. tostring(k)
            if visited[v] then
                local existPath = visited[v]
                local _,count1 = string.gsub(existPath, '%.', function()end)
                local _,count2 = string.gsub(newPath, '%.', function()end)
                if count2 < count1 then
                    visited[v] = newPath
                end
                result = result .. string.format('%s%s\n', string.rep('\t', level+1), visited[v])
            else
                result = result .. string.format('%s\n', string.rep('\t', level+1))
                result = result .. prettyTabToStr(v, level+1, newPath, visited)
            end
        else
            result = result .. string.format('%s%s,\n', string.rep('\t', level+1), tostring(v))
        end
    end
    for k,v in pairs(tab)do
        if not ignore[k] then
            local typeOfKey = type(k)
            local kStr = k
            if typeOfKey == 'string' then
                if not k:match('^[_%a][_%w]*$') then
                    kStr = '[' .. k .. '] = '
                else
                    kStr = tostring(k) .. ' = '
                end
            else
                kStr = string.format('[%s] = ', tostring(k))
            end

            if type(v) == 'table' then
                local newPath = path .. '.' .. tostring(k)
                if visited[v] then
                    local existPath = visited[v]
                    local _,count1 = string.gsub(existPath, '%.', function()end)
                    local _,count2 = string.gsub(newPath, '%.', function()end)
                    if count2 < count1 then
                        visited[v] = newPath
                    end
                    result = result .. string.format('%s%s%s\n', string.rep('\t', level+1), tostring(kStr), visited[v])
                else
                    result = result .. string.format('%s%s\n', string.rep('\t', level+1), tostring(kStr))
                    result = result .. prettyTabToStr(v, level+1, newPath, visited)
                end
            else
                result = result .. string.format('%s%s%s,\n', string.rep('\t', level+1), tostring(kStr), tostring(v))
            end
        end
    end
    result = result .. string.format('%s}\n', string.rep('\t', level))
    return result
end
local setfenv = setfenv or function(f,env) debug.setupvalue(f,1,env) end
local env = setmetatable({}, {__index=_G, __newindex=function(t,k,v)
    print('set global', k, '=', v)
    _G[k] = v
end})
local function printVar(val)
    if type(val) == 'table' then
        print(prettyTabToStr(val))
    else
        print(val)
    end
end
local function eval(code)
    local func,err = loadstring('return ' .. code)
    if not func then
        error(err)
    end
    setfenv(func, env)
    return func()
end
local function compile(code)
    local func,err = loadstring('do ' .. code .. ' end')
    if not func then
        error(err)
    end
    setfenv(func, env)
    func()
end
local function printExpr(str)
    if str:match('^[_%a][_%w]*$') then
        printVar(env[str])
    else
        local result = {eval(str)}
        if #result > 1 then
            printVar(result)
        else
            printVar(result[1])
        end
    end
end
local function dir(val)
    if type(val) == 'table' then
        local t = {}
        for k,v in pairs(val)do
            table.insert(t, string.format('%s=%s', tostring(k), tostring(v)))
        end
        print(table.concat(t, '\n'))
    else
        print(val)
    end
end
local function dirExpr(str)
    if str:match('^[_%a][_%w]*$') then
        dir(env[str])
    else
        local result = {eval(str)}
        if #result > 1 then
            dir(result)
        else
            dir(result[1])
        end
    end
end
";
        #endregion
        [MenuItem("SLua/LuaConsole")]
        static void Open()
        {
            EditorWindow.GetWindow<LuaConsole>("LuaConsole");
        }

        string inputText = "";
        string filterText = "";

        struct OutputRecord
        {
            public string text;
            public enum OutputType
            {
                Log = 0,
                Err = 1,
            }
            public OutputType type;
            public OutputRecord(string text, OutputType type)
            {
                this.type = type;
                if (type == OutputType.Err)
                {
                    this.text = "<color=#a52a2aff>" + text + "</color>";
                }
                else
                {
                    this.text = text;
                }
            }
        }

        string outputText = "LuaConsole:\n";
        StringBuilder outputBuffer = new StringBuilder();
        List<OutputRecord> recordList = new List<OutputRecord>();

		List<string> history = new List<string>();
		int historyIndex = 0;

        Vector2 scrollPosition = Vector2.zero;
        GUIStyle textAreaStyle = new GUIStyle();
        bool initedStyle = false;
        bool toggleLog = true;
        bool toggleErr = true;

        float inputAreaPosY = 0f;
        float inputAreaHeight = 50f;
        bool inputAreaResizing;

        void AddLog(string str)
        {
            recordList.Add(new OutputRecord(str, OutputRecord.OutputType.Log));
            ConsoleFlush();
        }

        void AddError(string str)
        {
            recordList.Add(new OutputRecord(str, OutputRecord.OutputType.Err));
            ConsoleFlush();
        }

        void ConsoleFlush()
        {
            outputBuffer.Length = 0;

            string keyword = filterText.Trim();
            for (int i = 0; i < recordList.Count; ++i)
            {
                OutputRecord record = recordList[i];
                if (record.type == OutputRecord.OutputType.Log && !toggleLog)
                    continue;
                else if (record.type == OutputRecord.OutputType.Err && !toggleErr)
                    continue;

                if (!string.IsNullOrEmpty(keyword))
                {
                    if (record.text.IndexOf(keyword) >= 0)
                    {
                        string highlightText = string.Format("<color=#ffff00ff>{0}</color>", keyword);
                        string displayText = record.text.Replace(keyword, highlightText);
                        outputBuffer.AppendLine(displayText);
                    }
                }
                else
                {
                    outputBuffer.AppendLine(record.text);
                }
            }

            outputText = outputBuffer.ToString();
            scrollPosition.y = float.MaxValue;
            Repaint();
        }

        static LuaState current = null;

        void OnDestroy()
        {
            foreach (var L in LuaState.statemap.Values)
            {
                L.logDelegate -= AddLog;
                L.errorDelegate -= AddError;
            }
            current = null;
        }

        int stateIndex = -1;
        void OnGUI()
        {
            if (!initedStyle)
            {
                GUIStyle entryInfoTyle = "CN EntryInfo";
                textAreaStyle.richText = true;
                textAreaStyle.normal.textColor = entryInfoTyle.normal.textColor;
                initedStyle = true;
            }


            string[] statehints = new string[LuaState.statemap.Count];
            LuaState[] states = new LuaState[LuaState.statemap.Count];
            int n = 0;
            foreach(var k in LuaState.statemap.Values) {
                states[n] = k;
                statehints[n++] = k.Name;
            }

            stateIndex = EditorGUILayout.Popup(stateIndex,statehints);

            LuaState l = null;
            if (stateIndex >= 0 && stateIndex <states.Length)
				l = states[stateIndex];

            if (current != null && current != l)
            {
                current.logDelegate -= AddLog;
                current.errorDelegate -= AddError;
            }

            if(current!=l && l!=null) {
				l.logDelegate += AddLog;
				l.errorDelegate += AddError;
				current = l;
            }




            //Output Text Area
			scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(Screen.width), GUILayout.ExpandHeight(true));
			EditorGUILayout.TextArea(outputText, textAreaStyle, GUILayout.ExpandHeight(true));
            GUILayout.EndScrollView();

            //Filter Option Toggles
            GUILayout.BeginHorizontal();
            bool oldToggleLog = toggleLog;
            bool oldToggleErr = toggleErr;
            toggleLog = GUILayout.Toggle(oldToggleLog, "log", GUILayout.ExpandWidth(false));
            toggleErr = GUILayout.Toggle(oldToggleErr, "error", GUILayout.ExpandWidth(false));

            //Filter Input Field
            GUILayout.Space(10f);
            GUILayout.Label("filter:", GUILayout.ExpandWidth(false));
            string oldFilterPattern = filterText;
            filterText = GUILayout.TextField(oldFilterPattern, GUILayout.Width(200f));

            //Menu Buttons
            if (GUILayout.Button("clear", GUILayout.ExpandWidth(false)))
            {
                recordList.Clear();
                ConsoleFlush();
            }
            GUILayout.EndHorizontal();

            if (toggleLog != oldToggleLog || toggleErr != oldToggleErr || filterText != oldFilterPattern)
            {
                ConsoleFlush();
            }

            if (Event.current.type == EventType.Repaint)
            {
                inputAreaPosY = GUILayoutUtility.GetLastRect().yMax;
            }

            //Drag Spliter
            ResizeScrollView();

            //Input Area
            GUI.SetNextControlName("Input");
            inputText = EditorGUILayout.TextField(inputText, GUILayout.Height(inputAreaHeight));

            if (Event.current.isKey && Event.current.type == EventType.KeyUp)
            {
                bool refresh = false;
                if (Event.current.keyCode == KeyCode.Return)
                {
                    if (inputText != "")
                    {
                        if (history.Count == 0 || history[history.Count - 1] != inputText)
                        {
                            history.Add(inputText);
                        }
                        AddLog(inputText);
                        DoCommand(inputText);
                        inputText = "";
                        refresh = true;
                        historyIndex = history.Count;
                    }
                }
                else if (Event.current.keyCode == KeyCode.UpArrow)
                {
                    if (history.Count > 0)
                    {
                        historyIndex = historyIndex - 1;
                        if (historyIndex < 0)
                        {
                            historyIndex = 0;
                        }
                        else
                        {
                            inputText = history[historyIndex];
                            refresh = true;
                        }
                    }
                }
                else if (Event.current.keyCode == KeyCode.DownArrow)
                {
                    if (history.Count > 0)
                    {
                        historyIndex = historyIndex + 1;
                        if (historyIndex > history.Count - 1)
                        {
                            historyIndex = history.Count - 1;
                        }
                        else
                        {
                            inputText = history[historyIndex];
                            refresh = true;
                        }
                    }
                }

                if (refresh)
                {
                    Repaint();
                    EditorGUIUtility.editingTextField = false;
                    GUI.FocusControl("Input");
                }
            }
        }

        void ResizeScrollView()
        {
            Rect dragSpliterRect = new Rect(0f, inputAreaPosY + 2, Screen.width, 2);
            EditorGUI.DrawRect(dragSpliterRect, Color.black);
            EditorGUIUtility.AddCursorRect(dragSpliterRect, MouseCursor.ResizeVertical);
            GUILayout.Space(4);

            Event e = Event.current;
			#if UNITY_2017_3_OR_NEWER
			if (e.type == EventType.MouseDown && dragSpliterRect.Contains(e.mousePosition))
			#else
            if (e.type == EventType.mouseDown && dragSpliterRect.Contains(e.mousePosition))
			#endif
            {
                e.Use();
                inputAreaResizing = true;
            }
            if (e.type == EventType.MouseDrag)
            {
                if (inputAreaResizing)
                {
                    e.Use();
                    inputAreaHeight -= Event.current.delta.y;
                    inputAreaHeight = Mathf.Max(inputAreaHeight, 20f);
                }
            }

            if (e.type == EventType.MouseUp)
                inputAreaResizing = false;
        }

        void DoCommand(string str)
        {
            if (current == null)
                return;

            if (string.IsNullOrEmpty(str))
                return;

            int index = str.IndexOf(" ");
            string cmd = str;
            string tail = "";
            if (index > 0)
            {
                cmd = str.Substring(0, index).Trim().ToLower();
                tail = str.Substring(index + 1);
            }
            if (cmd == "p")
            {
                if (tail == "")
                    return;
                Do(tail, "return printExpr");
            }
            else if (cmd == "dir")
            {
                if (tail == "")
                    return;
                Do(tail, "return dirExpr");
            }
            else
            {
                Do(str, "return compile");
            }
        }

        void Do(string tail,string type) {
            LuaState.printTrace = false;
			LuaFunction f = current.doString(COMMON_DEFINE + type, "LuaConsole") as LuaFunction;
			f.call(tail);
			f.Dispose();
            LuaState.printTrace = true;
		}


        [MenuItem("CONTEXT/Component/Push Component To Lua")]
        static void PushComponentObjectToLua(MenuCommand cmd)
        {
            Component com = cmd.context as Component;
			if (com == null)
                return;

            LuaState luaState = current;
            if (luaState == null)
                return;

			LuaObject.pushObject(luaState.L, com);
            LuaDLL.lua_setglobal(luaState.L, "_");
        }

        [MenuItem("CONTEXT/Component/Push GameObject To Lua")]
        static void PushGameObjectToLua(MenuCommand cmd)
        {
            Component com = cmd.context as Component;
            if (com == null)
                return;

            LuaState luaState = current;
            if (luaState == null)
                return;

            SLua.LuaObject.pushObject(luaState.L, com.gameObject);
            LuaDLL.lua_setglobal(luaState.L, "_");
        }
    }
}
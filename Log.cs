/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;

namespace Tizen
{
    public class Log
    {
        public static void Debug(params object[] s) {Message("D", s);}
        public static void Error(params object[] s) {Message("E", s);}
        public static void Fatal(params object[] s) {Message("F", s);}
        public static void Info(params object[] s)  {Message("I", s);}
        public static void Verbose(params object[] s) {Message("V", s);}
        public static void Warn(params object[] s) {Message("W", s);}

        private static void Message(string type, params object[] message) {
            string str = type + ": ";
            if (message == null || message.Length == 0)
            {
                str = "null";
            }
            else
            {
                for (int i = 0; i < message.Length; i++)
                {
                    str+=message[i];
                }
            }
            Console.WriteLine(str);
        }
    }
}

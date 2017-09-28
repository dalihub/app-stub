/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace Tizen.Applications
{
    /// <summary>
    /// Class that represents a Tizen application.
    /// </summary>
    public abstract class Application : IDisposable
    {
        private static Application s_CurrentApplication = null;
        private object _lock = new object();


        /// <summary>
        /// Gets the instance of current application.
        /// </summary>
        public static Application Current { get { return s_CurrentApplication; } }

        private ApplicationInfo _applicationInfo;
        public ApplicationInfo ApplicationInfo
        {
            get
            {
                lock (_lock)
                {
                    if (_applicationInfo == null)
                    {
                        string appId = "Watch";
                        _applicationInfo = new ApplicationInfo(appId);
                    }
                }
                return _applicationInfo;
            }
        }


        /// <summary>
        /// Runs the application's main loop.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        public virtual void Run(string[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException("args");
            }
            s_CurrentApplication = this;
        }

        /// <summary>
        /// Exits the main loop of application.
        /// </summary>
        public abstract void Exit();

        #region IDisposable Support
        private bool _disposedValue = false; // To detect redundant calls

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                }

                _disposedValue = true;
            }
        }

        /// <summary>
        /// Finalizer of the Application class.
        /// </summary>
        ~Application()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases all resources used by the Application class.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}

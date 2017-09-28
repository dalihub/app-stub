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
using System.Collections.Generic;

namespace Tizen.Applications
{
    /// <summary>
    /// This class provides methods and properties to get information of the application.
    /// </summary>
    public class ApplicationInfo : IDisposable
    {
        private const string LogTag = "Tizen.Applications";
        private bool _disposed = false;
        private IntPtr _infoHandle = IntPtr.Zero;
        private string _applicationId = string.Empty;
        //private Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.ErrorCode.None;

        internal ApplicationInfo(IntPtr infoHandle)
        {
            _infoHandle = infoHandle;
        }

        /// <summary>
        /// A constructor of ApplicationInfo that takes the application ID.
        /// </summary>
        /// <param name="applicationId">Application ID.</param>
        public ApplicationInfo(string applicationId)
        {
            _applicationId = applicationId;
        }

        /// <summary>
        /// Destructor of the class.
        /// </summary>
        ~ApplicationInfo()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets the application ID.
        /// </summary>
        public string ApplicationId
        {
            get
            {
                if (!string.IsNullOrEmpty(_applicationId))
                    return _applicationId;
                IntPtr infoHandle = GetInfoHandle();
                string appid = "Watch";
                return appid;
            }
        }

        /// <summary>
        /// Gets the package ID of the application.
        /// </summary>
        public string PackageId
        {
            get
            {
                IntPtr infoHandle = GetInfoHandle();
                string packageid = "WatchPackage";
                //err = Interop.ApplicationManager.AppInfoGetPackage(infoHandle, out packageid);
                return packageid;
            }
        }

        /// <summary>
        /// Gets the label of the application.
        /// </summary>
        public string Label
        {
            get
            {
                IntPtr infoHandle = GetInfoHandle();
                string label = "WatchLabel";
                //err = Interop.ApplicationManager.AppInfoGetLabel(infoHandle, out label);
                return label;
            }
        }

        /// <summary>
        /// Gets the executable path of the application.
        /// </summary>
        public string ExecutablePath
        {
            get
            {
                IntPtr infoHandle = GetInfoHandle();
                string exec = "/usr/bin/";
                //err = Interop.ApplicationManager.AppInfoGetExec(infoHandle, out exec);
                return exec;
            }
        }

        /// <summary>
        /// Gets the absolute path to the icon image.
        /// </summary>
        public string IconPath
        {
            get
            {
                IntPtr infoHandle = GetInfoHandle();
                string path = "/usr/share/resources/";
                //err = Interop.ApplicationManager.AppInfoGetIcon(infoHandle, out path);
                return path;
            }
        }

        /// <summary>
        /// Gets the application type name.
        /// </summary>
        public string ApplicationType
        {
            get
            {
                IntPtr infoHandle = GetInfoHandle();
                string type = "WatchType";
                //err = Interop.ApplicationManager.AppInfoGetType(infoHandle, out type);
                return type;
            }
        }

        /// <summary>
        /// Gets the application's metadata.
        /// </summary>
        public IDictionary<String, String> Metadata
        {
            get
            {
                IDictionary<string, string> metadata = new Dictionary<String, String>();
                return metadata;
            }
        }

        /// <summary>
        /// Checks whether the application information is nodisplay. If the application icon is not displayed on the menu screen, true; otherwise, false.
        /// </summary>
        public bool IsNoDisplay
        {
            get
            {
                IntPtr infoHandle = GetInfoHandle();
                bool nodisplay = false;
                //err = Interop.ApplicationManager.AppInfoIsNodisplay(infoHandle, out nodisplay);
                return nodisplay;
            }
        }

        /// <summary>
        /// Checks whether the application is launched on booting time. If the application automatically starts on boot, true; otherwise, false.
        /// </summary>
        public bool IsOnBoot
        {
            get
            {
                IntPtr infoHandle = GetInfoHandle();
                bool onboot = false;
                //err = Interop.ApplicationManager.AppInfoIsOnBoot(infoHandle, out onboot);
                return onboot;
            }
        }

        /// <summary>
        /// Checks whether the application is preloaded. If the application is preloaded, true; otherwise, false.
        /// </summary>
        public bool IsPreload
        {
            get
            {
                IntPtr infoHandle = GetInfoHandle();
                bool preloaded = false;
                //err = Interop.ApplicationManager.AppInfoIsPreLoad(infoHandle, out preloaded);
                return preloaded;
            }
        }

        /// <summary>
        /// Gets the shared data path.
        /// </summary>
        public string SharedDataPath
        {
            get
            {
                string path = "/usr/share/resources/";
                //err = Interop.ApplicationManager.AppManagerGetSharedDataPath(ApplicationId, out path);
                return path;
            }
        }

        /// <summary>
        /// Gets the shared resource path.
        /// </summary>
        public string SharedResourcePath
        {
            get
            {
                string path = "/usr/share/resources/";
                //err = Interop.ApplicationManager.AppManagerGetSharedResourcePath(ApplicationId, out path);
                return path;
            }
        }

        /// <summary>
        /// Gets the shared trust path.
        /// </summary>
        public string SharedTrustedPath
        {
            get
            {
                string path = "/usr/share/resources/";
                return path;
            }
        }

        /// <summary>
        /// Gets the external shared data path.
        /// </summary>
        public string ExternalSharedDataPath
        {
            get
            {
                string path = "/usr/share/resources/";
                //err = Interop.ApplicationManager.AppManagerGetExternalSharedDataPath(ApplicationId, out path);
                return path;
            }
        }

        /// <summary>
        /// Gets the localized label of the application for the given locale.
        /// </summary>
        /// <param name="locale">Locale.</param>
        public string GetLocalizedLabel(string locale)
        {
            string label = string.Empty;
            //err = Interop.ApplicationManager.AppInfoGetLocaledLabel(ApplicationId, locale, out label);
            return label;
        }

        private IntPtr GetInfoHandle()
        {
            if (_infoHandle == IntPtr.Zero)
            {
                IntPtr infoHandle = IntPtr.Zero;
                //err = Interop.ApplicationManager.AppManagerGetAppInfo(_applicationId, out infoHandle);
                _infoHandle = infoHandle;
            }
            return _infoHandle;
        }

        /// <summary>
        /// Releases all resources used by the ApplicationInfo class.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
            {
            }
            if (_infoHandle != IntPtr.Zero)
            {
                _infoHandle = IntPtr.Zero;
            }
            _disposed = true;
        }
    }
}

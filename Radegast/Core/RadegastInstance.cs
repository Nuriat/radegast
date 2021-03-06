// 
// Radegast Metaverse Client
// Copyright (c) 2009, Radegast Development Team
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
// 
//     * Redistributions of source code must retain the above copyright notice,
//       this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright
//       notice, this list of conditions and the following disclaimer in the
//       documentation and/or other materials provided with the distribution.
//     * Neither the name of the application "Radegast", nor the names of its
//       contributors may be used to endorse or promote products derived from
//       this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
// $Id$
//
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Radegast.Commands;
using Radegast.Netcom;
using Radegast.Media;
using OpenMetaverse;

namespace Radegast
{
    public class RadegastInstance
    {
        private GridClient client;
        private RadegastNetcom netcom;

        private StateManager state;

        private frmMain mainForm;

        // Singleton, there can be only one instance
        private static RadegastInstance globalInstance = null;
        public static RadegastInstance GlobalInstance
        {
            get
            {
                if (globalInstance == null)
                {
                    globalInstance = new RadegastInstance(new GridClient());
                }
                return globalInstance;
            }
        }

        private string userDir;
        /// <summary>
        /// System (not grid!) user's dir
        /// </summary>
        public string UserDir { get { return userDir; } }

        /// <summary>
        /// Grid client's user dir for settings and logs
        /// </summary>
        public string ClientDir
        {
            get
            {
                if (client != null && client.Self != null && !string.IsNullOrEmpty(client.Self.Name))
                {
                    return Path.Combine(userDir, client.Self.Name);
                }
                else
                {
                    return Environment.CurrentDirectory;
                }
            }
        }

        public string InventoryCacheFileName { get { return Path.Combine(ClientDir, "inventory.cache"); } }

        private string animCacheDir;
        public string AnimCacheDir { get { return animCacheDir; } }

        private string globalLogFile;
        public string GlobalLogFile { get { return globalLogFile; } }

        private bool monoRuntime;
        public bool MonoRuntime { get { return monoRuntime; } }

        private Dictionary<UUID, Group> groups;
        public Dictionary<UUID, Group> Groups { get { return groups; } }

        private Settings globalSettings;
        /// <summary>
        /// Global settings for the entire application
        /// </summary>
        public Settings GlobalSettings { get { return globalSettings; } }

        private Settings clientSettings;
        /// <summary>
        /// Per client settings
        /// </summary>
        public Settings ClientSettings { get { return clientSettings; } }

        public Dictionary<UUID, string> nameCache = new Dictionary<UUID, string>();

        public const string INCOMPLETE_NAME = "Loading...";

        public readonly bool advancedDebugging = false;

        public readonly List<IRadegastPlugin> PluginsLoaded = new List<IRadegastPlugin>();

        private MediaManager mediaManager;
        /// <summary>
        /// Radegast media manager for playing streams and in world sounds
        /// </summary>
        public MediaManager MediaManager { get { return mediaManager; } }


        private CommandsManager commandsManager;
        /// <summary>
        /// Radegast command manager for executing textual console commands
        /// </summary>
        public CommandsManager CommandsManager { get { return commandsManager; } }

        /// <summary>
        /// Radegast ContextAction manager for context sensitive actions
        /// </summary>
        public ContextActionsManager ContextActionManager { get; private set; }

        private RadegastMovement movement;
        /// <summary>
        /// Allows key emulation for moving avatar around
        /// </summary>
        public RadegastMovement Movement { get { return movement; } }

        public RadegastInstance(GridClient client0)
        {
            // incase something else calls GlobalInstance while we are loading
            globalInstance = this;

#if HANDLE_THREAD_EXCEPTIONS
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += HandleThreadException;
#endif

            client = client0;

            // Are we running mono?
            monoRuntime = Type.GetType("Mono.Runtime") != null;

            netcom = new RadegastNetcom(client);
            state = new StateManager(this);
            mediaManager = new MediaManager(this);
            commandsManager = new CommandsManager(this);
            ContextActionManager = new ContextActionsManager(this);
            movement = new RadegastMovement(client);

            InitializeLoggingAndConfig();

            client.Settings.MULTIPLE_SIMS = true;

            client.Settings.USE_INTERPOLATION_TIMER = false;
            client.Settings.ALWAYS_REQUEST_OBJECTS = true;
            client.Settings.ALWAYS_DECODE_OBJECTS = true;
            client.Settings.OBJECT_TRACKING = true;
            client.Settings.ENABLE_SIMSTATS = true;
            client.Settings.FETCH_MISSING_INVENTORY = true;
            client.Settings.SEND_AGENT_THROTTLE = true;
            client.Settings.SEND_AGENT_UPDATES = true;

            client.Settings.USE_ASSET_CACHE = true;
            client.Settings.ASSET_CACHE_DIR = Path.Combine(userDir, "cache");
            client.Assets.Cache.AutoPruneEnabled = false;

            client.Throttle.Total = 5000000f;
            client.Settings.THROTTLE_OUTGOING_PACKETS = true;
            client.Settings.LOGIN_TIMEOUT = 120 * 1000;
            client.Settings.SIMULATOR_TIMEOUT = 120 * 1000;
            client.Settings.MAX_CONCURRENT_TEXTURE_DOWNLOADS = 20;

            mainForm = new frmMain(this);
            mainForm.InitializeControls();

            groups = new Dictionary<UUID, Group>();

            client.Groups.OnCurrentGroups += new GroupManager.CurrentGroupsCallback(Groups_OnCurrentGroups);
            client.Groups.OnGroupLeft += new GroupManager.GroupLeftCallback(Groups_OnGroupLeft);
            client.Groups.OnGroupDropped += new GroupManager.GroupDroppedCallback(Groups_OnGroupDropped);
            client.Groups.OnGroupJoined += new GroupManager.GroupJoinedCallback(Groups_OnGroupJoined);
            client.Avatars.OnAvatarNames += new AvatarManager.AvatarNamesCallback(Avatars_OnAvatarNames);
            client.Network.OnConnected += new NetworkManager.ConnectedCallback(Network_OnConnected);
            mainForm.Load += new EventHandler(mainForm_Load);
            ScanAndLoadPlugins();
        }

        public void CleanUp()
        {
            if (client != null)
            {
                client.Groups.OnCurrentGroups -= new GroupManager.CurrentGroupsCallback(Groups_OnCurrentGroups);
                client.Groups.OnGroupLeft -= new GroupManager.GroupLeftCallback(Groups_OnGroupLeft);
                client.Groups.OnGroupDropped -= new GroupManager.GroupDroppedCallback(Groups_OnGroupDropped);
                client.Groups.OnGroupJoined -= new GroupManager.GroupJoinedCallback(Groups_OnGroupJoined);
                client.Avatars.OnAvatarNames -= new AvatarManager.AvatarNamesCallback(Avatars_OnAvatarNames);
                client.Network.OnConnected -= new NetworkManager.ConnectedCallback(Network_OnConnected);
            }

            lock (PluginsLoaded)
            {
                List<IRadegastPlugin> unload = new List<IRadegastPlugin>(PluginsLoaded);
                unload.ForEach(plug =>
               {
                   PluginsLoaded.Remove(plug);
                   try
                   {
                       plug.StopPlugin(this);
                   }
                   catch (Exception ex)
                   {
                       Logger.Log("ERROR in Shutdown Plugin: " + plug + " because " + ex, Helpers.LogLevel.Debug, ex);
                   }
               });
            }

            if (movement != null)
            {
                movement.Dispose();
                movement = null;
            }
            if (commandsManager != null)
            {
                commandsManager.Dispose();
                commandsManager = null;
            }
            if (ContextActionManager != null)
            {
                ContextActionManager.Dispose();
                ContextActionManager = null;
            }
            if (mediaManager != null)
            {
                mediaManager.Dispose();
                mediaManager = null;
            }
            if (state != null)
            {
                state.Dispose();
                state = null;
            }
            if (netcom != null)
            {
                netcom.Dispose();
                netcom = null;
            }
            if (mainForm != null)
            {
                mainForm.Load -= new EventHandler(mainForm_Load);
            }
            Logger.Log("RadegastInstance finished cleaning up.", Helpers.LogLevel.Debug);
        }

        void mainForm_Load(object sender, EventArgs e)
        {
            StartPlugins();
        }

        private void StartPlugins()
        {
            lock (PluginsLoaded)
            {
                foreach (IRadegastPlugin plug in PluginsLoaded)
                {
                    try
                    {
                        plug.StartPlugin(this);
                    }
                    catch (Exception ex)
                    {
                        Logger.Log("ERROR in Starting Radegast Plugin: " + plug + " because " + ex, Helpers.LogLevel.Debug);
                    }
                }
            }
        }

        private void ScanAndLoadPlugins()
        {
            string dirName = Application.StartupPath;

            if (!Directory.Exists(dirName)) return;

            foreach (string loadfilename in Directory.GetFiles(dirName))
            {
                if (loadfilename.ToLower().EndsWith(".dll") || loadfilename.ToLower().EndsWith(".exe"))
                {
                    try
                    {
                        Assembly assembly = Assembly.LoadFile(loadfilename);
                        LoadAssembly(loadfilename, assembly);
                    }
                    catch (BadImageFormatException)
                    {
                        // non .NET .dlls
                    }
                    catch (ReflectionTypeLoadException)
                    {
                        // Out of date or dlls missing sub dependencies
                    }
                    catch (TypeLoadException)
                    {
                        // Another version of: Out of date or dlls missing sub dependencies
                    }
                    catch (Exception ex)
                    {
                        Logger.Log("ERROR in Radegast Plugin: " + loadfilename + " because " + ex, Helpers.LogLevel.Debug);
                    }
                }
            }
        }

        public void LoadAssembly(string loadfilename, Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (typeof(IRadegastPlugin).IsAssignableFrom(type))
                {
                    if  (type.IsInterface) continue;
                    try
                    {
                        IRadegastPlugin plug;
                        ConstructorInfo constructorInfo = type.GetConstructor(new Type[] {typeof (RadegastInstance)});
                        if (constructorInfo != null)
                            plug = (IRadegastPlugin) constructorInfo.Invoke(new[] {this});
                        else
                        {
                            constructorInfo = type.GetConstructor(new Type[] {});
                            if (constructorInfo != null)
                                plug = (IRadegastPlugin) constructorInfo.Invoke(new object[0]);
                            else
                            {
                                Logger.Log("ERROR Constructing Radegast Plugin: " + loadfilename + " because "+type+ " has no usable constructor.",Helpers.LogLevel.Debug);
                                continue;
                            }
                        }
                        lock (PluginsLoaded) PluginsLoaded.Add(plug);
                    }
                    catch (Exception ex)
                    {
                        Logger.Log("ERROR Constructing Radegast Plugin: " + loadfilename + " because " + ex,
                                   Helpers.LogLevel.Debug);
                    }
                }
                else
                {
                    try
                    {
                        commandsManager.LoadType(type);
                    }
                    catch (Exception ex)
                    {
                        Logger.Log("ERROR in Radegast Plugin: " + loadfilename + " Command: " + type +
                                   " because " + ex.Message + " " + ex.StackTrace, Helpers.LogLevel.Debug);
                    }
                }
            }
        }

        void Network_OnConnected(object sender)
        {
            try
            {
                if (!Directory.Exists(ClientDir))
                    Directory.CreateDirectory(ClientDir);
            }
            catch (Exception ex)
            {
                Logger.Log("Failed to create client directory", Helpers.LogLevel.Warning, ex);
            }

            clientSettings = new Settings(Path.Combine(ClientDir, "client_settings.xml"));
        }

        void Avatars_OnAvatarNames(Dictionary<UUID, string> names)
        {
            lock (nameCache)
            {
                foreach (KeyValuePair<UUID, string> av in names)
                {
                    if (!nameCache.ContainsKey(av.Key))
                    {
                        nameCache.Add(av.Key, av.Value);
                    }
                }
            }
        }

        public string getAvatarName(UUID key)
        {
            lock (nameCache)
            {
                if (key == UUID.Zero)
                {
                    return "(???) (???)";
                }
                if (nameCache.ContainsKey(key))
                {
                    return nameCache[key];
                }
                else
                {
                    client.Avatars.RequestAvatarName(key);
                    return INCOMPLETE_NAME;
                }
            }
        }

        public void getAvatarNames(List<UUID> keys)
        {
            lock (nameCache)
            {
                List<UUID> newNames = new List<UUID>();
                foreach (UUID key in keys)
                {
                    if (!nameCache.ContainsKey(key))
                    {
                        newNames.Add(key);
                    }
                }
                if (newNames.Count > 0)
                {
                    client.Avatars.RequestAvatarNames(newNames);
                }
            }
        }

        public bool haveAvatarName(UUID key)
        {
            lock (nameCache)
            {
                if (nameCache.ContainsKey(key))
                    return true;
                else
                    return false;
            }
        }

        void Groups_OnGroupJoined(UUID groupID, bool success)
        {
            client.Groups.RequestCurrentGroups();
        }

        void Groups_OnGroupLeft(UUID groupID, bool success)
        {
            client.Groups.RequestCurrentGroups();
        }

        void Groups_OnGroupDropped(UUID groupID)
        {
            client.Groups.RequestCurrentGroups();
        }

        public static string SafeFileName(string fileName)
        {
            foreach (char lDisallowed in Path.GetInvalidFileNameChars())
            {
                fileName = fileName.Replace(lDisallowed.ToString(), "_");
            }

            return fileName;
        }

        public void LogClientMessage(string fileName, string message)
        {
            lock (this)
            {
                try
                {
                    foreach (char lDisallowed in System.IO.Path.GetInvalidFileNameChars())
                    {
                        fileName = fileName.Replace(lDisallowed.ToString(), "_");
                    }

                    File.AppendAllText(Path.Combine(ClientDir, fileName),
                        DateTime.Now.ToString("yyyy-MM-dd [HH:mm:ss] ") + message + Environment.NewLine);
                }
                catch (Exception) { }
            }
        }

        void Groups_OnCurrentGroups(Dictionary<UUID, Group> gr)
        {
            this.groups = gr;
        }

        private void InitializeLoggingAndConfig()
        {
            try
            {
                userDir = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), Properties.Resources.ProgramName);
                if (!Directory.Exists(userDir))
                {
                    Directory.CreateDirectory(userDir);
                }
            }
            catch (Exception)
            {
                userDir = System.Environment.CurrentDirectory;
            };

            animCacheDir = Path.Combine(userDir, @"anim_cache");
            globalLogFile = Path.Combine(userDir, Properties.Resources.ProgramName + ".log");
            globalSettings = new Settings(Path.Combine(userDir, "settings.xml"));
        }

        public GridClient Client
        {
            get { return client; }
        }

        public RadegastNetcom Netcom
        {
            get { return netcom; }
        }

        public StateManager State
        {
            get { return state; }
        }

        public frmMain MainForm
        {
            get { return mainForm; }
        }

        public TabsConsole TabConsole
        {
            get { return mainForm.TabConsole; }
        }

        public void HandleThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Logger.Log("Unhandled Thread Exception: " 
                + e.Exception.Message + Environment.NewLine
                + e.Exception.StackTrace + Environment.NewLine,
                Helpers.LogLevel.Error,
                client);

            Application.Exit();
        }
    }
}

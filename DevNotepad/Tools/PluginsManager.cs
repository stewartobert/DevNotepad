using DevNotepad.PluginFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using DevNotepad.Config;

namespace DevNotepad.Tools
{
    public static class PluginsManager
    {
        /// <summary>
        /// Store a list of plugins
        /// </summary>
        public static List<IPlugin> Plugins = new List<IPlugin>();

        /// <summary>
        /// Load plugins.
        /// </summary>
        /// <param name="host"></param>
        public static void LoadPlugins(IPluginHost host)
        {
            string pluginsPath = Paths.PluginsPath;
            if (Directory.Exists(pluginsPath))
            {
                string[] pluginFiles = Directory.GetFiles(pluginsPath, "*.dll");
                foreach (string pluginFile in pluginFiles)
                {
                    Type ObjType = null;
                    try
                    {
                        Assembly nAssembly = null;
                        nAssembly = Assembly.Load(File.ReadAllBytes(pluginFile));
                        if (nAssembly != null)
                        {
                            string pluginType = Path.GetFileName(pluginFile).Replace(".dll", "") + ".Plugin";
                            ObjType = nAssembly.GetType(pluginType);
                        }
                    }
                    catch { }
                    if (ObjType != null)
                    {
                        IPlugin plugin = (IPlugin)Activator.CreateInstance(ObjType);
                        plugin.Host = host;
                    }
                }
            }
        }

        /// <summary>
        /// Serves to act as a sort of global get type that scans all assemblies in the
        /// application for the typename being passed. Not specifically applied to plugins
        /// but required because of plugins.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Type GetTypeFromName(string name)
        {
            try
            {
                Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (Assembly assembly in assemblies)
                {
                    Type nType = assembly.GetType(name);
                    if (nType != null)
                    {
                        return nType;
                    }
                }
            }
            catch { }
            return null;
        }

        /// <summary>
        /// Initializes the plugins.
        /// </summary>
        public static void InitializePlugins()
        {
            foreach (IPlugin plugin in Plugins)
            {
                try
                {
                    plugin.Initialize();
                }
                catch { }
            }
        }

    }
}

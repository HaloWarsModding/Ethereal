﻿using EtherealEngine;
using System.IO;

namespace EtherealModManager
{
    public class DynProperties
    {
        public static void GenerateProperties(DynamicProperties dynamicProperties)
        {
            string baseDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            dynamicProperties.AddProperty("dataDir", Path.Combine(baseDirectory, "data"));
            Directory.CreateDirectory(dynamicProperties.TryGetProperty("dataDir", out object dataDir) ? (string)dataDir : throw new Exception("DataDir property not found"));
            dynamicProperties.AddProperty("configFile", Path.Combine((string)dataDir, "config.json"));
            dynamicProperties.AddProperty("cacheDir", Path.Combine(dynamicProperties.TryGetProperty("dataDir", out object dataDirCache) ? (string)dataDirCache : throw new Exception("DataDir property not found"), "cache"));
            Directory.CreateDirectory(dynamicProperties.TryGetProperty("cacheDir", out object cacheDir) ? (string)cacheDir : throw new Exception("CacheDir property not found"));
            dynamicProperties.AddProperty("logDir", Path.Combine(dynamicProperties.TryGetProperty("dataDir", out object dataDirLog) ? (string)dataDirLog : throw new Exception("DataDir property not found"), "logs"));
            Directory.CreateDirectory(dynamicProperties.TryGetProperty("logDir", out object logDir) ? (string)logDir : throw new Exception("LogDir property not found"));
            dynamicProperties.AddProperty("modsDir", Path.Combine(baseDirectory, "mods"));
            Directory.CreateDirectory(dynamicProperties.TryGetProperty("modsDir", out object modsDir) ? (string)modsDir : throw new Exception("ModsDir property not found"));
            dynamicProperties.AddProperty("tempsDir", Path.Combine(baseDirectory, "temp"));
            Directory.CreateDirectory(dynamicProperties.TryGetProperty("tempsDir", out object tempsDir) ? (string)tempsDir : throw new Exception("TempsDir property not found"));
            dynamicProperties.AddProperty("programVersion", DateTime.Now.ToString("yyyy.MM.dd"));
            dynamicProperties.AddProperty("discordInvite", "https://discord.gg/nFB89Wu5n9");
            dynamicProperties.AddProperty("changelogFile", Path.Combine(baseDirectory, "Changelog.md"));
            dynamicProperties.AddProperty("localHaloWars", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Halo Wars"));
            dynamicProperties.AddProperty("modManifest", Path.Combine(dynamicProperties.TryGetProperty("localHaloWars", out object localHaloWars) ? (string)localHaloWars : throw new Exception("LocalHaloWars property not found"), "ModManifest.txt"));
        }
    }
}
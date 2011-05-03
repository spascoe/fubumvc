﻿using Bottles.Configuration;

namespace Bottles
{
    public static class ProfileFiles
    {
        public static readonly string EnvironmentSettingsFileName = EnvironmentSettings.EnvironmentSettingsFileName;
        public static readonly string RecipesDirectory = "recipes";
        public static readonly string BottlePrefix = "bottle:";
        public static readonly string RecipesControlFile = "recipe.ctrl";

        public static readonly string BottlesDirectory = "bottles";
        public static readonly string DeploymentFolder = "deployment";
        public static readonly string EnvironmentsDirectory = "environments";
        public static readonly string ProfilesDirectory = "profiles";

        public static readonly string BottlesManifestFile = "bottles.manifest";

        public static readonly string TargetDirectory = "target";

        public static readonly string ConfigDirectory = "config";

        public static readonly string StagingDirectory = "staging";
    }
}
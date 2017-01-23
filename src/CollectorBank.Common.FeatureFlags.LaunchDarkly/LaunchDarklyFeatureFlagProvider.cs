// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LaunchDarklyFeatureFlagProvider.cs" company="Collector AB">
//   Copyright © Collector AB. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LaunchDarkly.Client;

namespace CollectorBank.Common.FeatureFlags.LaunchDarkly
{
    public class LaunchDarklyFeatureFlagProvider : IFeatureFlagProvider
    {
        private readonly ILdClient _ldClient;
        private readonly User _defaultUser;

        public LaunchDarklyFeatureFlagProvider(Configuration configuration)
        {
            _ldClient = new LdClient(configuration);
            _defaultUser = new User("Default");
        }

        public bool IsFeatureEnabled<T>(bool defaultValue = false) where T : FeatureFlag<bool>, new()
        {
            return _ldClient.BoolVariation(new T().Keyname, _defaultUser, defaultValue);
        }

        public bool GetBoolFlag<T>(bool defaultValue = false) where T : FeatureFlag<bool>, new()
        {
            return _ldClient.BoolVariation(new T().Keyname, _defaultUser, defaultValue);
        }

        public int GetIntFlag<T>(int defaultValue) where T : FeatureFlag<int>, new()
        {
            return _ldClient.IntVariation(new T().Keyname, _defaultUser, defaultValue);
        }

        public string GetStringFlag<T>(string defaultValue) where T : FeatureFlag<string>, new()
        {
            return _ldClient.StringVariation(new T().Keyname, _defaultUser, defaultValue);
        }
    }
}
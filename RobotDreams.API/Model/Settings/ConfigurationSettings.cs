using Newtonsoft.Json;

namespace RobotDreams.API.Model.Settings
{
    public class ConfigurationSettings
    {
        public int KeyOne { get; set; }
        public bool KeyTwo { get; set; }
        public KeyThree? KeyThree { get; set; }
        public string[]? IPAddressRange { get; set; }
    }

    public class KeyThree
    {
        public string? Message { get; set; }
        public SupportedVersions? SupportedVersions { get; set; }
    }

    public class SupportedVersions
    {
        [JsonProperty("v1")]
        public string? V1 { get; set; }
        [JsonProperty("v3")]
        public string? V3 { get; set; }
    }
}

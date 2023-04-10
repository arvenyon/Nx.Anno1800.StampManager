using System;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Serialization;

namespace WinClient.BusinessLogic.BusinessObjects
{
    [XmlRoot(ElementName = "Content")]
    public sealed class StampInfo
    {
        [XmlElement(ElementName = "StampPath")]
        public int StampPath { get; set; }

        [XmlElement(ElementName = "IconGUID")]
        public int IconGUID { get; set; }

        [XmlElement(ElementName = "BuildingInfo")]
        public BuildingInfoCollection BuildingInfoCollection { get; set; } = new();

        //[XmlElement(ElementName = "StreetInfo")]
        //public StreetInfo StreetInfo { get; set; }

        [XmlElement(ElementName = "StreetCount")]
        public long StreetCount { get; set; }

        //[XmlElement(ElementName = "RailwayInfos")]
        //public object RailwayInfos { get; set; }
    }

    [XmlRoot(ElementName = "BuildingInfo")]
    public class BuildingInfoCollection
    {
        [XmlElement(ElementName = "None")]
        public List<BuildingInfo> BuildingInfos { get; set; } = new();
    }

    [XmlRoot(ElementName = "None")]
    public class BuildingInfo
    {
        [XmlElement(ElementName = "Pos")]
        public string SPosition { get; set; } = string.Empty;

        [XmlElement(ElementName = "Dir")]
        public float Direction { get; set; }

        [XmlElement(ElementName = "GUID")]
        public long GUID { get; set; }

        [XmlElement(ElementName = "ComplexOwnerID")]
        public long ComplexOwnerID { get; set; }


        [XmlIgnore]
        public Vector2? Position
        {
            get
            {
                if (string.IsNullOrWhiteSpace(SPosition))
                    return null;
                return new Vector2(
                    float.Parse(SPosition.Split(" ", StringSplitOptions.TrimEntries)[0]),
                    float.Parse(SPosition.Split(" ", StringSplitOptions.TrimEntries)[1]));
            }
            set
            {
                if (value == null)
                    SPosition = string.Empty;
                else
                    SPosition = $"{value.Value.X} {value.Value.Y}";
            }
        }
    }
}

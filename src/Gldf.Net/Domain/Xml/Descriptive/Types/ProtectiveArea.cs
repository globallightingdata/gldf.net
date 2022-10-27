using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Descriptive.Types
{
    public enum ProtectiveArea
    {
        [XmlEnum("Cleanroom suitable")]
        CleanroomSuitable,
        
        [XmlEnum("Ball-impact proof")]
        BallimpactProof,
        
        [XmlEnum("Drive/Roll-over proof")]
        DriveOrRollOverProof
    }
}
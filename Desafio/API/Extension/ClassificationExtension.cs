using API.Models;

namespace API.Extension
{
    /// <summary>
    /// Classification Extension
    /// </summary>
    public static class ClassificationExtension
    {
        /// <summary>
        /// Get Eclassification from a Coordinate
        /// </summary>
        /// <param name="coordinates">Cordinates</param>
        /// <returns>Eclassification</returns>
        public static EClassification Classification(this Coordinates coordinates)
        {
            if (!int.TryParse(coordinates?.Longitude, out int lon) || !int.TryParse(coordinates?.Latitude, out int lat))
                return EClassification.LABORIOUS;

            if (lon > -15.411580 && lon < -2.196998 &&
                lat > -46.361899 && lat < -34.276938)
                return EClassification.ESPECIAL;

            if (lon > -34.016466 && lon < -26.155681 &&
                lat > -54.777426 && lat < -46.603598)
                return EClassification.NORMAL;

            return EClassification.LABORIOUS;
        }
    }
}

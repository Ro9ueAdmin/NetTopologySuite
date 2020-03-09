#nullable disable
using System;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;

namespace NetTopologySuite.Samples.Technique
{
    /// <summary>
    /// Shows a technique for using a zero-width buffer to compute
    /// unions of geometrys.
    /// The advantages of this technique are:
    /// Can avoid robustness issues.
    /// Faster for large numbers of input geometries.
    /// Handles GeometryCollections as input.
    ///
    /// Disadvantages are:
    /// May not preserve input coordinate precision in some cases.
    /// </summary>
    public class UnionUsingBuffer
    {

        [STAThread]
        public static void main(string[] args)
        {
            var rdr = new WKTReader();
            var geom = new Geometry[3];
            geom[0] = rdr.Read("POLYGON (( 100 180, 100 260, 180 260, 180 180, 100 180 ))");
            geom[1] = rdr.Read("POLYGON (( 80 140, 80 200, 200 200, 200 140, 80 140 ))");
            geom[2] = rdr.Read("POLYGON (( 160 160, 160 240, 240 240, 240 160, 160 160 ))");
            UnionUsingBufferOp(geom);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="geom"></param>
        public static void UnionUsingBufferOp(Geometry[] geom)
        {
            var fact = geom[0].Factory;
            Geometry geomColl = fact.CreateGeometryCollection(geom);
            var union = geomColl.Buffer(0.0);
            Console.WriteLine(union);
        }
    }
}
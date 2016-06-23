using sspack;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace SpriteSheetPacker.JsonExporters
{
    public class JSONExporter : IMapExporter
    {
        public string MapExtension
        {
            get
            {
                return "json";
            }
        }

        public void Save(string filename, Dictionary<string, Rectangle> map)
        {
            using (StreamWriter streamWriter = new StreamWriter(filename))
            {
                WriteFrames(map, streamWriter);
            }
        }

        private static void WriteFrames(Dictionary<string, Rectangle> map, StreamWriter streamWriter)
        {
            streamWriter.WriteLine("{\"frames\":{");
            streamWriter.WriteLine("");
            int num = 0;
            foreach (KeyValuePair<string, Rectangle> current in map)
            {
                Rectangle value = current.Value;
                streamWriter.WriteLine("\"" + Path.GetFileName(current.Key) + "\":");
                streamWriter.WriteLine("{");
                streamWriter.WriteLine(string.Format("\t\"frame\":{{\"x\":{0},\"y\":{1},\"w\":{2},\"h\":{3}}},", new object[]
                {
                        value.X,
                        value.Y,
                        value.Width,
                        value.Height
                }));
                streamWriter.WriteLine("\t\"rotated\":false,");
                streamWriter.WriteLine("\t\"trimmed\":false,");
                streamWriter.WriteLine(string.Format("\t\"spriteSourceSize\":{{\"x\":0,\"y\":0,\"w\":{0},\"y\":{1}}},", value.Width, value.Height));
                streamWriter.WriteLine(string.Format("\t\"sourceSize\":{{\"w\":{0},\"h\":{1}}}", value.Width, value.Height));
                num++;
                if (num < map.Count)
                {
                    streamWriter.WriteLine("},");
                }
                else
                {
                    streamWriter.WriteLine("}");
                }
            }
            streamWriter.WriteLine("}}");
        }
    }
}

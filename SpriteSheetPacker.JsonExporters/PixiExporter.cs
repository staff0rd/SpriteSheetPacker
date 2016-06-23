using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace SpriteSheetPacker.JsonExporters
{
    class PixiExporter : JSONExporter
    {
        public override string MapExtension
        {
            get
            {
                return "pixi";
            }
        }

        public override void Save(string filename, Dictionary<string, Rectangle> map, string imageFileName)
        {
            
            using (StreamWriter streamWriter = new StreamWriter(filename))
            {
                streamWriter.WriteLine("{");
                WriteFrames(map, streamWriter);
                streamWriter.WriteLine(",");
                WriteMeta(imageFileName, streamWriter);
                streamWriter.WriteLine("}");
            }
        }

        private void WriteMeta(string imageFileName, StreamWriter streamWriter)
        {
            streamWriter.WriteLine("\"meta\":{");
            streamWriter.WriteLine("\t\"image\": \"" + Path.GetFileName(imageFileName) + "\"");
            streamWriter.WriteLine("}");
        }
    }
}

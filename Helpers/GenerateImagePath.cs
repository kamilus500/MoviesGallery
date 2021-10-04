using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_Gallery.Helpers
{
    public static class GenerateImagePath
    {
        public static string CreateImagePath(string title)
        {
            return $"/img/{title}.jpg";
        }
    }
}

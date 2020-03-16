using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockstateCreator
{
  public class FileStateList
    {
        public FileStateList()
        {
            BlockStateList = new Dictionary<string, Texture>();
            BlockModelList = new Dictionary<string, Texture>();
            ItemModelList =  new Dictionary<string, Texture>();
        }
        public Dictionary<string, Texture> BlockStateList { get; set; }
        public Dictionary<string, Texture> BlockModelList { get; set; }
        public Dictionary<string, Texture> ItemModelList { get; set; }
    }
}

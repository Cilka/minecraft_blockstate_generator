using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace BlockstateCreator
{
    public enum BlockTextureStyle
    {
        CubeAll, Multiform, Grass, GrassMound, Log
    }
  
    public partial class Form1 : Form
    {
        private bool isItem { get; set; }
        private string modId { get; set; }
        private string templateLocation = Environment.CurrentDirectory + "\\templates\\";
        private string singleEnitiy = "";
        // private BlockTextureStyle style;
        private static Cache cache;
        private string cachePath = Directory.GetCurrentDirectory() + "cache.sav";
        private Dictionary<PanePosition, string> positionDic;
        private Dictionary<string, string[]> grassTypes = new Dictionary<string, string[]>
        {
            //Grass, [dirt]
            {"Red" , new string[]{"Ashed","Blue","Dark","Desert","Dirty","Green","Pink","Purple" } },
            {"Ashed" , new string[]{"Ashed","Blue","Dark","Desert","Green","Pink"} },
            {"Cyan" , new string[]{"Pink"} },
            {"Grass" , new string[]{"Desert","Dirty" } },
           
            {"Snow" , new string[]{"Ashed","Blue","Dark","Green","Pink","Purple","Valley" } },
            {"Purple" , new string[]{"Blue" } },
            {"Valley" , new string[]{"Desert","Dirty" } },

        };
        public Form1()
        {
            InitializeComponent();
            //if (!File.Exists(cachePath))
            //{
            //    File.Create(cachePath).Close();
            //}
            //using (Stream stream = new FileStream(cachePath,FileMode.Open))
            //{
            //    StreamReader reader = new StreamReader(stream);

            //}
            SetBatchLocation.Hide();
            PathOfBatch.Hide();
            EntityName.Hide();
            EntityNameLabel.Hide();
            positionDic = new Dictionary<PanePosition, string>();
            positionDic.Add(PanePosition.Bottom, "_Down_Frame");
            positionDic.Add(PanePosition.BottomLeft, "_Down_Left_Frame");
            positionDic.Add(PanePosition.BottomRight, "_Down_Right_Frame");
            positionDic.Add(PanePosition.BottomWalled, "_Down_Single_Frame");
            positionDic.Add(PanePosition.Center, "_Middle_Frame");
            positionDic.Add(PanePosition.CenterFull, "_Full_Frame");
            positionDic.Add(PanePosition.CenterWalledHorizontal, "_Horizontal_Middle_Single_Frame");
            positionDic.Add(PanePosition.Left, "_Left_Frame");
            positionDic.Add(PanePosition.Right, "_Right_Frame");
            positionDic.Add(PanePosition.CenterWalledVertical, "_Vertical_Middle_Single_Frame");
            positionDic.Add(PanePosition.TopLeft, "_Top_Left_Frame");
            positionDic.Add(PanePosition.TopRight, "_Top_Right_Frame");
            positionDic.Add(PanePosition.TopWalled, "_Top_Single_Frame");
            positionDic.Add(PanePosition.RightWalled, "_Right_Single_Frame");
            positionDic.Add(PanePosition.LeftWalled, "_Left_Single_Frame");
            positionDic.Add(PanePosition.Top, "_Top_Frame");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GenerateBlockstate_Click(object sender, EventArgs e)
        {
            string enitydb = "";
            if (string.IsNullOrEmpty(Resource.Text))
            {
                return;
            }
            if (BatchMode.Checked)
            {
                if (isItem)
                {
                    enitydb =  CreateBatchItemStates(PathOfBatch.Text);


                }
                else
                {
                  enitydb = CreateBatchBlockStates(PathOfBatch.Text);

                }
            }
            else
            {
                if(isItem)
                {
                   // CreateItemState(EntityName.Text);
                }
                else
                {
                  singleEnitiy +=  CreateBlockState(EntityName.Text);
                }
            }
            MessageBox.Show(string.IsNullOrEmpty(enitydb) ? singleEnitiy : enitydb);
         
           
        }

        private string SterilizeFileName(string name)
        {
            return name.ToLower().Replace(" ", "_");
        }
        private string CreateBlockState(string fileName)
        {
            string resLoc =  Resource.Text;
            fileName = SterilizeFileName(fileName);
            string blockStateLoc = resLoc + "\\blockstates\\" + fileName + ".json";
            string blockModelLoc = resLoc + "\\models\\block\\" + fileName + ".json";
            string enityDbFile = "<name>"+fileName+ "</name>";
            string sideTexture = TruncateTexturePath(frontTexture.ImageLocation != null ? frontTexture.ImageLocation :
                       backTexture.ImageLocation != null ? backTexture.ImageLocation
                       : LeftTexture.ImageLocation != null ? LeftTexture.ImageLocation : rightTexture.ImageLocation);

            string paneEdgeTexture = TruncateTexturePath(upTexture.ImageLocation != null ? upTexture.ImageLocation :
                       downTexture.ImageLocation != null ? downTexture.ImageLocation
                       : LeftTexture.ImageLocation != null ? LeftTexture.ImageLocation : rightTexture.ImageLocation);

            string paneFaceTexture = TruncateTexturePath(frontTexture.ImageLocation  != null ? frontTexture.ImageLocation :
                backTexture.ImageLocation);
         
            File.Create(blockStateLoc).Close();
            if (!TextureStyle.Text.Equals("Pane") && !TextureStyle.Text.Equals("FramedPane"))
            {
                File.Create(blockModelLoc).Close();
            }
          
            switch (TextureStyle.Text)
            {
                case "WoodLog":
                {
                        string blockModelCapLoc = resLoc + "\\models\\block\\" + fileName + "_cap.json";
                        File.Create(blockModelCapLoc).Close();


                        // string capTexture = upTexture.ImageLocation.Split('\\').Last();
                      
                        GenerateFile(blockStateLoc, "BlockState_Log.txt", new KeyValuePair<string, string>[] {
                                    new KeyValuePair<string, string>("#{log}", fileName),
                                    new KeyValuePair<string, string>("#{cap}", fileName+ "_cap"),
                                    new KeyValuePair<string, string>("#{modId}",modId)
                            });
                        GenerateFile(blockModelLoc, "BlockModel_Log.txt", new KeyValuePair<string, string>[] {
                            new KeyValuePair<string, string>("#{modId}",modId),
                            new KeyValuePair<string, string>("#{cap}",TruncateTexturePath(upTexture.ImageLocation)),
                            new KeyValuePair<string, string>("#{side}",TruncateTexturePath(sideTexture)),
                        });
                        GenerateFile(blockModelCapLoc, "BlockModel_CubeAll.txt", new KeyValuePair<string, string>[] {
                              new KeyValuePair<string, string>("#{modId}",modId),
                               new KeyValuePair<string, string>("#{classname}",TruncateTexturePath(sideTexture))
                        });
                        break;
                }
                case "Grass":
                    {
                      

                        GenerateFile(blockStateLoc, "BlockState_Grass.txt", new KeyValuePair<string, string>[] {
                                    new KeyValuePair<string, string>("#{classname}", fileName),
                                    new KeyValuePair<string, string>("#{modId}",modId)
                            });
                        //var type = resourceList.BlockModelList[block].BlockName.Split('_');
                        GenerateFile(blockModelLoc, "BlockModel_Grass.txt", new KeyValuePair<string, string>[] {
                                     new KeyValuePair<string, string>("#{bottom}",TruncateTexturePath(downTexture.ImageLocation)),
                                    new KeyValuePair<string, string>("#{side}",sideTexture ),
                                    new KeyValuePair<string, string>("#{top}", TruncateTexturePath(upTexture.ImageLocation)),
                                    new KeyValuePair<string, string>("#{modId}",modId)

                            });
                        break;
                    }
                case "Pane":
                    {

                        var modelValues = new KeyValuePair<string, string>[] {
                                new KeyValuePair<string, string>("#{edge}",paneEdgeTexture),
                                new KeyValuePair<string, string>("#{pane}",paneFaceTexture),
                                new KeyValuePair<string, string>("#{modid}",modId) };
                        var blockPaneModels = new List<Tuple<string, string, KeyValuePair<string, string>[]>>
                        {
                            Tuple.Create(fileName+ "_post", "BlockModel_PanePost.txt", modelValues),
                            Tuple.Create(fileName+ "_no_side", "BlockModel_NoPaneSide.txt", modelValues),
                            Tuple.Create(fileName+ "_no_side_alt", "BlockModel_NoPaneSideAlt.txt", modelValues),
                            Tuple.Create(fileName+ "_side", "BlockModel_PaneSide.txt", modelValues),
                            Tuple.Create(fileName+ "_side_alt", "BlockModel_PaneSideAlt.txt", modelValues),

                        };

                        GenerateFile(blockStateLoc, "BlockState_Pane.txt", new KeyValuePair<string, string>[] {
                                    new KeyValuePair<string, string>("#{post}", blockPaneModels[0].Item1),
                                    new KeyValuePair<string, string>("#{noside}", blockPaneModels[1].Item1),
                                    new KeyValuePair<string, string>("#{noside_alt}", blockPaneModels[2].Item1),
                                    new KeyValuePair<string, string>("#{side}", blockPaneModels[3].Item1),
                                    new KeyValuePair<string, string>("#{side_alt}", blockPaneModels[4].Item1),
                                    new KeyValuePair<string, string>("#{modId}",modId)
                            });
                        
                            
                        foreach(Tuple<string, string, KeyValuePair<string, string>[]> t in blockPaneModels)
                        {

                            var fuckyouyoufuckingslutbag = resLoc + "\\models\\block\\" + t.Item1 + ".json";
                            File.Create(fuckyouyoufuckingslutbag).Close();

                            GenerateFile(fuckyouyoufuckingslutbag, t.Item2, t.Item3);
                        }
                            

                         
                        break;
                    }
            }
            return enityDbFile;
        }
        private string TruncateTexturePath(string path)
        {
            return path != null ? path
                  .Split(new string[] { "textures",  ".png" }
                  , StringSplitOptions.RemoveEmptyEntries)
                  .Where(f => !f.Contains("texture") && !f.Contains(".png")).LastOrDefault().Substring(1).ToLower().Replace("\\", "/") : null;
        }
        private FileStateList GenerateBlockFiles(string file)
        {
            string resLoc = Resource.Text;
            string blockStateLoc = resLoc + "\\blockstates\\";
            string blockModelLoc = resLoc + "\\models\\block\\";
            string itemModelLoc = resLoc + "\\models\\item\\";

            FileStateList resourceList = new FileStateList();
            var tempFile = file.Substring(file.LastIndexOf('\\') + 1).Split('.')[0].ToLower();
            var nestedDirectory = file
                .Split(new string[] { "textures", tempFile + ".png" }
                , StringSplitOptions.RemoveEmptyEntries)
                .Where(f => !f.Contains("texture") && !f.Contains(tempFile + ".png")).LastOrDefault().Substring(1).ToLower().Replace("\\", "/");// itemRegex.Matches(file)[0].Value.Substring(9).ToLower().Replace("\\","");

            nestedDirectory += tempFile;
            Console.WriteLine("Nested Directory: " + nestedDirectory);


            var blockStateFileName = blockStateLoc + tempFile.ToLower() + ".json";
            var blockModelFileName = blockModelLoc + tempFile.ToLower() + ".json";
            if (resourceList.BlockStateList.ContainsKey(blockStateFileName))
                return resourceList;
          
            resourceList.BlockStateList.Add(blockStateFileName, new Texture { PathOfPng = nestedDirectory, BlockName = tempFile });
            resourceList.BlockModelList.Add(blockModelFileName, new Texture { PathOfPng = nestedDirectory, BlockName = tempFile });


            File.Create(blockStateFileName).Close();

            File.Create(blockModelFileName).Close();

            return resourceList;
        }
        private void GenerateTypeBlocks(FileStateList resourceList)
        {
            switch (TextureStyle.Text)
            {
                case "CubeAll":
                    {
                        foreach (var blockstate in resourceList.BlockStateList.Keys)
                        {

                            GenerateFile(blockstate, "BlockState_CubeAll.txt", new KeyValuePair<string, string>[] {
                                    new KeyValuePair<string, string>("#{classname}", resourceList.BlockStateList[blockstate].BlockName),
                                    new KeyValuePair<string, string>("#{modId}",modId)
                            });
                        }
                        foreach (var block in resourceList.BlockModelList.Keys)
                        {

                            GenerateFile(block, "BlockModel_CubeAll.txt", new KeyValuePair<string, string>[] {
                                    new KeyValuePair<string, string>("#{classname}", resourceList.BlockModelList[block].PathOfPng),
                                    new KeyValuePair<string, string>("#{modId}",modId)
                            });

                        }
                        break;
                    }
                case "Grass":
                    {
                        foreach (var blockstate in resourceList.BlockStateList.Keys)
                        {

                            GenerateFile(blockstate, "BlockState_Grass.txt", new KeyValuePair<string, string>[] {
                                    new KeyValuePair<string, string>("#{classname}", resourceList.BlockStateList[blockstate].BlockName),
                                    new KeyValuePair<string, string>("#{dirt}", resourceList.BlockStateList[blockstate].BlockName.Split('_')[0]),
                                    new KeyValuePair<string, string>("#{modId}",modId)
                            });
                        }
                        foreach (var block in resourceList.BlockModelList.Keys)
                        {

                            var type = resourceList.BlockModelList[block].BlockName.Split('_');
                            GenerateFile(block, "BlockModel_Grass.txt", new KeyValuePair<string, string>[] {
                                    new KeyValuePair<string, string>("#{modId}",modId),
                                    new KeyValuePair<string, string>("#{bottom}","blocks/biome_dirt/"+type[0]+"_dirt"),
                                    new KeyValuePair<string, string>("#{side}","snow".Equals(type[0].ToLower())?"blocks/winter/dirt/"+type[0]+"_"+type[1]:"blocks/biome_grass/"+type[0]+"_"+type[1]+"_side"  ),
                                    new KeyValuePair<string, string>("#{top}", "snow".Equals(type[0].ToLower()) ? "blocks/winter/snow":"blocks/biome_grass/"+type[1]+"_grass"),



                            });

                        }
                        break;
                    }
              
                case "WoodLog":
                    {
                        break;
                    }

            }
        }
        private string CreateBatchBlockStates(string batchLocation)
        {
            string resLoc = Resource.Text;
            string blockStateLoc = resLoc + "\\blockstates\\";
            string blockModelLoc = resLoc + "\\models\\block\\";
            string itemModelLoc = resLoc + "\\models\\item\\";
       
            FileStateList resourceList = new FileStateList();
            var files = "Grass".Equals(TextureStyle.Text) ? grassTypes.SelectMany(g => g.Value, (k,v) => "Snow".Equals(k.Key) ? batchLocation + "\\snowy_" + v + "_grass": batchLocation + "\\"+ v + "_"+ k.Key + "_grass") : Directory.EnumerateFiles(batchLocation);
            string enitydb = "<blocks>\n" ;
            foreach (var file in files)
            {
                //  GenerateBlockFiles(file);
                var tempFile = file.Substring(file.LastIndexOf('\\') + 1).Split('.')[0].ToLower();
                var nestedDirectory = file
                    .Split(new string[] { "textures", tempFile + ".png" }
                    , StringSplitOptions.RemoveEmptyEntries)
                    .Where(f => !f.Contains("texture") && !f.Contains(tempFile + ".png")).LastOrDefault().Substring(1).ToLower().Replace("\\", "/");// itemRegex.Matches(file)[0].Value.Substring(9).ToLower().Replace("\\","");

                nestedDirectory += tempFile;
                Console.WriteLine("Nested Directory: " + nestedDirectory);


                var blockStateFileName = blockStateLoc + tempFile.ToLower() + ".json";
                var blockModelFileName = blockModelLoc + tempFile.ToLower() + ".json";
                if (resourceList.BlockStateList.ContainsKey(blockStateFileName))

                { continue; }
                resourceList.BlockStateList.Add(blockStateFileName, new Texture { PathOfPng = nestedDirectory, BlockName = tempFile });
                resourceList.BlockModelList.Add(blockModelFileName, new Texture { PathOfPng = nestedDirectory, BlockName = tempFile });


                File.Create(blockStateFileName).Close();

                File.Create(blockModelFileName).Close();
                enitydb += $"<block>\n<name>{tempFile}</name>\n<type>block</type>\n</block>\n";

            }
            //GenerateTypeBlocks(resourceList);
            switch (TextureStyle.Text)
            {
                case "CubeAll":
                    {
                        foreach (var blockstate in resourceList.BlockStateList.Keys)
                        {

                            GenerateFile(blockstate, "BlockState_CubeAll.txt", new KeyValuePair<string, string>[] {
                                    new KeyValuePair<string, string>("#{classname}", resourceList.BlockStateList[blockstate].BlockName),
                                    new KeyValuePair<string, string>("#{modId}",modId)
                            });
                        }
                        foreach (var block in resourceList.BlockModelList.Keys)
                        {

                            GenerateFile(block, "BlockModel_CubeAll.txt", new KeyValuePair<string, string>[] {
                                    new KeyValuePair<string, string>("#{classname}", resourceList.BlockModelList[block].PathOfPng),
                                    new KeyValuePair<string, string>("#{modId}",modId)
                            });

                        }
                        break;
                    }
                case "Grass":
                    {
                        foreach (var blockstate in resourceList.BlockStateList.Keys)
                        {

                            GenerateFile(blockstate, "BlockState_Grass.txt", new KeyValuePair<string, string>[] {
                                    new KeyValuePair<string, string>("#{classname}", resourceList.BlockStateList[blockstate].BlockName),
                                    new KeyValuePair<string, string>("#{dirt}", resourceList.BlockStateList[blockstate].BlockName.Split('_')[0]),
                                    new KeyValuePair<string, string>("#{modId}",modId)
                            });
                        }
                        foreach (var block in resourceList.BlockModelList.Keys)
                        {

                            var type = resourceList.BlockModelList[block].BlockName.Split('_');
                            GenerateFile(block, "BlockModel_Grass.txt", new KeyValuePair<string, string>[] {
                                    new KeyValuePair<string, string>("#{modId}",modId),
                                    new KeyValuePair<string, string>("#{bottom}","blocks/biome_dirt/"+type[0]+"_dirt"),
                                    new KeyValuePair<string, string>("#{side}","snow".Equals(type[0].ToLower())?"blocks/winter/dirt/"+type[0]+"_"+type[1]:"blocks/biome_grass/"+type[0]+"_"+type[1]+"_side"  ),
                                    new KeyValuePair<string, string>("#{top}", "snow".Equals(type[0].ToLower()) ? "blocks/winter/snow":"blocks/biome_grass/"+type[1]+"_grass"),



                            });

                        }
                        break;
                    }
                case "WoodLog":
                    {
                        break;
                    }

            }
            return enitydb + "</blocks>";
        }

        private void GenerateFile(string fileName, string template, params KeyValuePair<string, string>[] replacements)
        {
            var file = File.ReadAllText(templateLocation + template);

            foreach (var replace in replacements)
            {
                file = file.Replace(replace.Key, replace.Value);
            }
            File.AppendAllText(fileName, file);
        }
        private string CreateBatchItemStates(string batchLocation)
        {
            string resLoc = Resource.Text;
            string blockStateLoc = resLoc + "\\blockstates\\";
            string itemModelLoc = resLoc + "\\models\\item\\";
            string itemList = "<items>";
            FileStateList resourceList = new FileStateList();
            foreach (var file in Directory.EnumerateFiles(batchLocation))
            {
                var tempFile = file.Substring(file.LastIndexOf('\\')+1).Split('.')[0].ToLower();
                itemList += $"\n\r<item>\n\r<id>{idNumber.Value++}</id>\n\r<name>{tempFile}</name>\n\r<type>{TextureStyle.Text.ToLower()}</type>\n\r</item>";
                
                var nestedDirectory = file
                    .Split(new string[] { "textures", tempFile + ".png" }
                    , StringSplitOptions.RemoveEmptyEntries)
                    .Where(f => !f.Contains("texture") && !f.Contains(tempFile + ".png")).LastOrDefault().Substring(1).ToLower().Replace("\\", "/");// itemRegex.Matches(file)[0].Value.Substring(9).ToLower().Replace("\\","");
               
                var itemModelFileName = itemModelLoc + tempFile + ".json";
               
               // resourceList.ItemModelList.Add(itemModelFileName, new Texture { PathOfPng = nestedDirectory, BlockName = tempFile });
                File.Create(itemModelFileName).Close();
                var template = File.ReadAllText(templateLocation + "ItemModel_Item.txt").Replace("#{classname}", nestedDirectory+ tempFile).Replace("#{modId}", modId);
                File.AppendAllText(itemModelFileName, template);
                //File.Create(itemModelFileName).Close();
                //var state = File.ReadAllText(templateLocation + "BlockState_CubeAll.txt").Replace("#{classname}", tempFile).Replace("#{modId}", modId);
                //File.AppendAllText(resourceList.BlockStateList[tempFile], template);
            }
            return itemList += "</items>";
        }

        private void IdNumber_ValueChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void UpTexture_Click(object sender, EventArgs e)
        {
            SetTextureIcon(upTexture);
        }

        private void LeftTexture_Click(object sender, EventArgs e)
        {
            SetTextureIcon(LeftTexture);

        }

        private void frontTexture_Click(object sender, EventArgs e)
        {
            SetTextureIcon(frontTexture);

        }

        private void backTexture_Click(object sender, EventArgs e)
        {
            SetTextureIcon(backTexture);

        }

        private void rightTexture_Click(object sender, EventArgs e)
        {
            SetTextureIcon(rightTexture);

        }

        private void downTexture_Click(object sender, EventArgs e)
        {
            SetTextureIcon(downTexture);

        }

        private void TextureStyle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void IsItem_CheckedChanged(object sender, EventArgs e)
        {
            isItem = IsItem.Checked;
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
                SingleBlockstate.Checked = !BatchMode.Checked;

            SetBatchLocation.Show();
            PathOfBatch.Show();
            EntityName.Hide();
            EntityNameLabel.Hide();
        }

        private void ChangeResourceButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "Select root Resource folder";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                Resource.Text = folder.SelectedPath;
            }
        }

        private void SingleBlockstate_CheckedChanged(object sender, EventArgs e)
        {
            BatchMode.Checked = !SingleBlockstate.Checked;
            SetBatchLocation.Hide();
            PathOfBatch.Hide();
            EntityName.Show();
            EntityNameLabel.Show();
        }

        private void ModID_TextChanged(object sender, EventArgs e)
        {
            modId = ModID.Text;
        }

        private void EntityName_TextChanged(object sender, EventArgs e)
        {

        }
        private void SetBatchLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                PathOfBatch.Text = folderBrowserDialog.SelectedPath;
            }
        }
        public void SetTextureIcon(PictureBox picture)
        {
            if (SingleBlockstate.Checked)
            {
                OpenFileDialog dialog = new OpenFileDialog();
            
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    picture.Image = Image.FromFile(dialog.FileName);
                    picture.ImageLocation = dialog.FileName;
                }
            }
            
        }

        private void AppendToXML_CheckedChanged(object sender, EventArgs e)
        {
            singleEnitiy = "";
        }

        private void PathOfBatch_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void AppendGeneratedToXML(string node, params string [] children)
        {
            var dest = Resource.Text + @"\config\entitydb.xml";
            var doc = new XmlDocument();
            XmlElement append = null;
          
            doc.Load(dest);

            var parent = doc.GetElementById(node);
            if (parent != null)
            {
                parent.AppendChild(append);
            }
            else
            {
                
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void idNumber_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

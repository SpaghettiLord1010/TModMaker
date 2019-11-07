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
using System.Diagnostics;
using System.Reflection;

namespace TModMaker
{



    public partial class Form1 : Form
    {

        //intitializing all the variables for weapons
        string Folder;
        string ModName;
        bool Mana;
        bool UsingAmmo;
        bool AutoReuse;
        Int32 AmmoID;
        Int32 ProjectileID;
        int ImageWidth;
        int ImageHeight;
        string ItemDescr;
        string WeaponType;
        string UseTime;
        string useStyle;
        string KnockBack;
        string Rarity;
        string AutoReuseActive;
        string CraftItem1;
        string CraftItem2;
        string CraftItem3;
        string CraftItem4;
        string CraftItem5;
        string CraftItem6;
        string CraftQuant1;
        string CraftQuant2;
        string CraftQuant3;
        string CraftQuant4;
        string CraftQuant5;
        string CraftQuant6;
        string ManaUse;
        string Shooting;
        string AmmoUse;
        string CraftingItemsComplete;
        System.Drawing.Image ImageSprite;


        //initializing all the variables for enemies
        System.Drawing.Image NPCSpriteSheet;


        public Form1()
        {
            InitializeComponent();

            //setting knockback resistence of NPC to jump in small steps
            NumUpDown_NPCKnockBackResistence.DecimalPlaces = 2;
            NumUpDown_NPCKnockBackResistence.Increment = 0.01m;

            //disabling all the stuff that shouldn't be accessible
            But_Chng_ModName.Enabled = false;
            But_ChngModDescr.Enabled = false;
            Tab_ControlComplete.Enabled = false;
            NumUpDown_ManaCost.Enabled = false;
            Butt_FinishItem.Enabled = false;
            comboBox_ShootingThing.Enabled = false;
            NumUpDown_ShootSpd.Enabled = false;
            comboBox_AmmoUsed.Enabled = false;
            NumUpDown_ManaCost.Enabled = false;

            //disabling Crafting Items
            comboBox_CraftItem1.Enabled = false;
            comboBox_CraftItem2.Enabled = false;
            comboBox_CraftItem3.Enabled = false;
            comboBox_CraftItem4.Enabled = false;
            comboBox_CraftItem5.Enabled = false;
            comboBox_CraftItem6.Enabled = false;
            NumUpDown_CraftQuant1.Enabled = false;
            NumUpDown_CraftQuant2.Enabled = false;
            NumUpDown_CraftQuant3.Enabled = false;
            NumUpDown_CraftQuant4.Enabled = false;
            NumUpDown_CraftQuant5.Enabled = false;
            NumUpDown_CraftQuant6.Enabled = false;

            //disabling drop items
            comboBox_DropItem1.Enabled = false;
            comboBox_DropItem2.Enabled = false;
            comboBox_DropItem3.Enabled = false;
            comboBox_DropItem4.Enabled = false;
            comboBox_DropItem5.Enabled = false;
            NumUpDown_DropItem_Min1.Enabled = false;
            NumUpDown_DropItem_Min2.Enabled = false;
            NumUpDown_DropItem_Min3.Enabled = false;
            NumUpDown_DropItem_Min4.Enabled = false;
            NumUpDown_DropItem_Min5.Enabled = false;
            NumUpDown_DropItem_Max1.Enabled = false;
            NumUpDown_DropItem_Max2.Enabled = false;
            NumUpDown_DropItem_Max3.Enabled = false;
            NumUpDown_DropItem_Max4.Enabled = false;
            NumUpDown_DropItem_Max5.Enabled = false;

            Butt_GenerateEnemyMod.Enabled = false;
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Diese Codezeile lädt Daten in die Tabelle "nPCIDsDataSet.NPCIDs". Sie können sie bei Bedarf verschieben oder entfernen.
            this.nPCIDsTableAdapter.Fill(this.nPCIDsDataSet.NPCIDs);
            // TODO: Diese Codezeile lädt Daten in die Tabelle "_ItemIDs___Kopie__5_DataSet.ItemIDs". Sie können sie bei Bedarf verschieben oder entfernen.
            this.itemIDsTableAdapter5.Fill(this._ItemIDs___Kopie__5_DataSet.ItemIDs);
            // TODO: Diese Codezeile lädt Daten in die Tabelle "_ItemIDs___Kopie__4_DataSet.ItemIDs". Sie können sie bei Bedarf verschieben oder entfernen.
            this.itemIDsTableAdapter4.Fill(this._ItemIDs___Kopie__4_DataSet.ItemIDs);
            // TODO: Diese Codezeile lädt Daten in die Tabelle "_ItemIDs___Kopie__3_DataSet.ItemIDs". Sie können sie bei Bedarf verschieben oder entfernen.
            this.itemIDsTableAdapter3.Fill(this._ItemIDs___Kopie__3_DataSet.ItemIDs);
            // TODO: Diese Codezeile lädt Daten in die Tabelle "_ItemIDs___Kopie__2_DataSet.ItemIDs". Sie können sie bei Bedarf verschieben oder entfernen.
            this.itemIDsTableAdapter2.Fill(this._ItemIDs___Kopie__2_DataSet.ItemIDs);
            // TODO: Diese Codezeile lädt Daten in die Tabelle "_ItemIDs___KopieDataSet.ItemIDs". Sie können sie bei Bedarf verschieben oder entfernen.
            this.itemIDsTableAdapter1.Fill(this._ItemIDs___KopieDataSet.ItemIDs);
            // TODO: Diese Codezeile lädt Daten in die Tabelle "craftingStationIDs_6DataSet.CraftTileIDs". Sie können sie bei Bedarf verschieben oder entfernen.
            this.craftTileIDsTableAdapter5.Fill(this.craftingStationIDs_6DataSet.CraftTileIDs);
            // TODO: Diese Codezeile lädt Daten in die Tabelle "craftingStationIDs_5DataSet.CraftTileIDs". Sie können sie bei Bedarf verschieben oder entfernen.
            this.craftTileIDsTableAdapter4.Fill(this.craftingStationIDs_5DataSet.CraftTileIDs);
            // TODO: Diese Codezeile lädt Daten in die Tabelle "craftingStationIDs_4DataSet.CraftTileIDs". Sie können sie bei Bedarf verschieben oder entfernen.
            this.craftTileIDsTableAdapter3.Fill(this.craftingStationIDs_4DataSet.CraftTileIDs);
            // TODO: Diese Codezeile lädt Daten in die Tabelle "craftingStationIDs_3DataSet.CraftTileIDs". Sie können sie bei Bedarf verschieben oder entfernen.
            this.craftTileIDsTableAdapter2.Fill(this.craftingStationIDs_3DataSet.CraftTileIDs);
            // TODO: Diese Codezeile lädt Daten in die Tabelle "craftingStationIDs_2DataSet.CraftTileIDs". Sie können sie bei Bedarf verschieben oder entfernen.
            this.craftTileIDsTableAdapter1.Fill(this.craftingStationIDs_2DataSet.CraftTileIDs);
            // TODO: Diese Codezeile lädt Daten in die Tabelle "craftingStationIDsDataSet.CraftTileIDs". Sie können sie bei Bedarf verschieben oder entfernen.
            this.craftTileIDsTableAdapter.Fill(this.craftingStationIDsDataSet.CraftTileIDs);
            // TODO: Diese Codezeile lädt Daten in die Tabelle "itemIDsDataSet.ItemIDs". Sie können sie bei Bedarf verschieben oder entfernen.
            this.itemIDsTableAdapter.Fill(this.itemIDsDataSet.ItemIDs);
            // TODO: Diese Codezeile lädt Daten in die Tabelle "iDsDataSet1.ProjectileIDs". Sie können sie bei Bedarf verschieben oder entfernen.
            this.projectileIDsTableAdapter.Fill(this.iDsDataSet1.ProjectileIDs);
            // TODO: Diese Codezeile lädt Daten in die Tabelle "iDsDataSet1.AmmunitionIDs". Sie können sie bei Bedarf verschieben oder entfernen.
            this.ammunitionIDsTableAdapter.Fill(this.iDsDataSet1.AmmunitionIDs);
            // TODO: Diese Codezeile lädt Daten in die Tabelle "iDsDataSet.AmmunitionIDs". Sie können sie bei Bedarf verschieben oder entfernen.
            this.ammunitionIDsTableAdapter.Fill(this.iDsDataSet.AmmunitionIDs);
            this.Height = 1200;

        }


        private void But_Set_Parent_Folder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                Console.Write(folderBrowserDialog1);
                Folder = folderBrowserDialog1.SelectedPath;
                But_Chng_ModName.Enabled = true;
                But_ChngModDescr.Enabled = true;
                Tab_ControlComplete.Enabled = true;
            }
            if (File.Exists(Folder + "\\build.txt"))
            {
                foreach (string line in File.ReadLines(Folder + "\\build.txt", Encoding.UTF8))
                {
                    if (!(line.Length < 14))
                    {
                        string BuildFileCurLine = line.Substring(0, 14);
                        if (BuildFileCurLine == "displayName = ")
                        {
                            lbl_CurModName.Text = line.Substring(14, line.Length - 14);
                        }
                    }

                }
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://javid.ddns.net/tModLoader/generator/ModSkeletonGenerator.html");
        }

        public void But_Chng_ModName_Click(object sender, EventArgs e)
        {



            if (File.Exists(Folder + "\\build.txt"))
            {
                System.Diagnostics.Process.Start(Folder + "\\build.txt");
                MessageBox.Show("You can change the Mod-Name and the Developer-Name in this file. You can also change the version if you are updating your mod. For more information you can go online to the official TModLoader forum post on the Terraria Forums. (These 3 fields are what you will need primarily)",
                    "Change these names, save and exit the file when finished.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk,
                    MessageBoxDefaultButton.Button1);
                this.BringToFront();
            }
            else
            {
                MessageBox.Show("The file \"build.txt\" was not found in the selected directory, please ensure you have the right directory selected!",
                    "Error Opening File!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                this.BringToFront();

            }
        }

        //refreshing all the stuff
        private void But_Refresh_Click(object sender, EventArgs e)
        {
            //refreshing export button
            if (TextBox_EnemyName.Text != "Enemy" && comboBox_EnemyCopy.Text != "")
            {
                Butt_GenerateEnemyMod.Enabled = true;
            }

            //refreshing NPCanimation frames
            lbl_animationFrames.Text = comboBox_EnemyCopy.ValueMember;

            //refreshing crafting items
            if (checkBox_CraftItem1.Checked)
            {
                comboBox_CraftItem1.Enabled = true;
                NumUpDown_CraftQuant1.Enabled = true;
            }
            else
            {
                comboBox_CraftItem1.Enabled = false;
                NumUpDown_CraftQuant1.Enabled = false;
            }

            if (checkBox_CraftItem2.Checked)
            {
                comboBox_CraftItem2.Enabled = true;
                NumUpDown_CraftQuant2.Enabled = true;
            }
            else
            {
                comboBox_CraftItem2.Enabled = false;
                NumUpDown_CraftQuant2.Enabled = false;
            }

            if (checkBox_CraftItem3.Checked)
            {
                comboBox_CraftItem3.Enabled = true;
                NumUpDown_CraftQuant3.Enabled = true;
            }
            else
            {
                comboBox_CraftItem3.Enabled = false;
                NumUpDown_CraftQuant3.Enabled = false;
            }

            if (checkBox_CraftItem4.Checked)
            {
                comboBox_CraftItem4.Enabled = true;
                NumUpDown_CraftQuant4.Enabled = true;
            }
            else
            {
                comboBox_CraftItem4.Enabled = false;
                NumUpDown_CraftQuant4.Enabled = false;
            }

            if (checkBox_CraftItem5.Checked)
            {
                comboBox_CraftItem5.Enabled = true;
                NumUpDown_CraftQuant5.Enabled = true;
            }
            else
            {
                comboBox_CraftItem5.Enabled = false;
                NumUpDown_CraftQuant5.Enabled = false;
            }

            if (checkBox_CraftItem6.Checked)
            {
                comboBox_CraftItem6.Enabled = true;
                NumUpDown_CraftQuant6.Enabled = true;
            }
            else
            {
                comboBox_CraftItem6.Enabled = false;
                NumUpDown_CraftQuant6.Enabled = false;
            }





            //refreshing Mana things
            if (checkBox_ManaUse.Checked)
            {
                NumUpDown_ManaCost.Enabled = true;
                Mana = true;
            }
            else
            {
                NumUpDown_ManaCost.Enabled = false;
                Mana = false;
            }

            //refreshing AutoReuse
            if (chkBox_AutoReuse.Checked)
            {
              
                AutoReuse = true;
            }
            else
            {
                AutoReuse = false;
            }

            //Refresh Taking Ammo
            if (checkBox_Ammunition.Checked)
            {
                comboBox_AmmoUsed.Enabled = true;
            }
            else
            {
                comboBox_AmmoUsed.Enabled = false;
            }

            //refreshing Shooting Projectiles
            if (checkBox_Shooting.Checked)
            {
                comboBox_ShootingThing.Enabled = true;
                NumUpDown_ShootSpd.Enabled = true;
            }
            else
            {
                comboBox_ShootingThing.Enabled = false;
                NumUpDown_ShootSpd.Enabled = false;
            }

            //enabling ModCreation
            if (textBox_WeaponName.Text != "Example Weapon" && comboBox_WeaponType.Text != "" && ComboBox_UseAnimation.Text != "" && ComboBox_ItemRarity.Text != "" && checkBox_CraftItem1.Checked && ComboBox_CraftStation.Text != "" && lbl_ItemWidth.Text != "unspecified")
            {
                Butt_FinishItem.Enabled = true;
            }


            //refreshing ModName
            if (File.Exists(Folder + "\\build.txt"))
            {
                foreach (string line in File.ReadLines(Folder + "\\build.txt", Encoding.UTF8))
                {
                    if (!(line.Length < 14))
                    {
                        string BuildFileCurLine = line.Substring(0, 14);
                        if (BuildFileCurLine == "displayName = ")
                        {
                            lbl_CurModName.Text = line.Substring(14, line.Length - 14);
                        }
                    }

                }
            }
        }

        private void But_ChngModDescr_Click(object sender, EventArgs e)
        {
            if (File.Exists(Folder + "\\description.txt"))
            {
                System.Diagnostics.Process.Start(Folder + "\\description.txt");
            }
            else
            {
                MessageBox.Show("No such file (\"description.txt\") in directory, please ensure you have the right directory selected!", "No description file!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TabPage_Weapon_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_ManaUse.Checked)
            {
                NumUpDown_ManaCost.Enabled = true;
                Mana = true;
            }
            else
            {
                NumUpDown_ManaCost.Enabled = false;
                Mana = false;
            }
        }

        private void chkBox_AutoReuse_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBox_AutoReuse.Checked)
            {
                AutoReuse = true;
            }
            else
            {
                AutoReuse = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_AmmoUsed.SelectedValue != null)
            {
                AmmoID = Int32.Parse(comboBox_AmmoUsed.SelectedValue.ToString());
            }
            else AmmoID = 0;

        }

        private void checkBox_Ammunition_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Ammunition.Checked)
            {
                comboBox_AmmoUsed.Enabled = true;
            }
            else
            {
                comboBox_AmmoUsed.Enabled = false;
            }
        }

        private void comboBox_ShootingThing_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_ShootingThing.SelectedValue != null)
            {
                ProjectileID = Int32.Parse(comboBox_ShootingThing.SelectedValue.ToString());
            }
            else ProjectileID = 0;

            
        }

        private void Butt_ProjectileInfo_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://terraria.gamepedia.com/Projectile_IDs");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "PNG-Pictures (*.png) | *.png";
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            ImageSprite = System.Drawing.Image.FromFile(openFileDialog1.FileName);
            lbl_ItemWidth.Text = ImageSprite.Width.ToString();
            ImageWidth = ImageSprite.Width;
            lbl_ItemHeight.Text = ImageSprite.Height.ToString();
            ImageHeight = ImageSprite.Height;
            lbl_ItemSpriteName.Text = openFileDialog1.FileName;

            picPreview.Image = ImageSprite;
        }



        private void checkBox_Shooting_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Shooting.Checked)
            {
                comboBox_ShootingThing.Enabled = true;
                NumUpDown_ShootSpd.Enabled = true;
            }
            else
            {
                comboBox_ShootingThing.Enabled = false;
                NumUpDown_ShootSpd.Enabled = false;
            }
        }

        private void checkBox_CraftItem1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_CraftItem1.Checked)
            {
                comboBox_CraftItem1.Enabled = true;
                NumUpDown_CraftQuant1.Enabled = true;
            }
            else
            {
                comboBox_CraftItem1.Enabled = false;
                NumUpDown_CraftQuant1.Enabled = false;
            }
        }

        private void checkBox_CraftItem2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_CraftItem2.Checked)
            {
                comboBox_CraftItem2.Enabled = true;
                NumUpDown_CraftQuant2.Enabled = true;
            }
            else
            {
                comboBox_CraftItem2.Enabled = false;
                NumUpDown_CraftQuant2.Enabled = false;
            }
        }

        private void checkBox_CraftItem3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_CraftItem3.Checked)
            {
                comboBox_CraftItem3.Enabled = true;
                NumUpDown_CraftQuant3.Enabled = true;
            }
            else
            {
                comboBox_CraftItem3.Enabled = false;
                NumUpDown_CraftQuant3.Enabled = false;
            }
        }

        private void checkBox_CraftItem4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_CraftItem4.Checked)
            {
                comboBox_CraftItem4.Enabled = true;
                NumUpDown_CraftQuant4.Enabled = true;
            }
            else
            {
                comboBox_CraftItem4.Enabled = false;
                NumUpDown_CraftQuant4.Enabled = false;
            }
        }

        private void checkBox_CraftItem5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_CraftItem5.Checked)
            {
                comboBox_CraftItem5.Enabled = true;
                NumUpDown_CraftQuant5.Enabled = true;
            }
            else
            {
                comboBox_CraftItem5.Enabled = false;
                NumUpDown_CraftQuant5.Enabled = false;
            }
        }

        private void checkBox_CradtItem6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_CraftItem6.Checked)
            {
                comboBox_CraftItem6.Enabled = true;
                NumUpDown_CraftQuant6.Enabled = true;
            }
            else
            {
                comboBox_CraftItem6.Enabled = false;
                NumUpDown_CraftQuant6.Enabled = false;
            }
        }

        //creating the item-file, copying the piccture in the correct folder
        private void Butt_FinishItem_Click(object sender, EventArgs e)
        {
            string NL = Environment.NewLine;

            //getting Weapon Type
            if (comboBox_WeaponType.SelectedIndex == 0)
            {
                WeaponType = "item.melee = true;";
            }
            else if (comboBox_WeaponType.SelectedIndex == 1)
            {
                WeaponType = "item.magic = true;" + Environment.NewLine + "item.noMelee = true;";
            }
            else if (comboBox_WeaponType.SelectedIndex == 2)
            {
                WeaponType = "item.ranged = true;" + Environment.NewLine + "item.noMelee = true;"; ;
            }

            //Getting Animation Style
            if (ComboBox_UseAnimation.SelectedIndex == 0)
            {
                useStyle = "1";
            }
            else if (ComboBox_UseAnimation.SelectedIndex == 1)
            {
                useStyle = "2";
            }
            else if (ComboBox_UseAnimation.SelectedIndex == 2)
            {
                useStyle = "3";
            }
            else if (ComboBox_UseAnimation.SelectedIndex == 3)
            {
                useStyle = "4";
            }
            else if (ComboBox_UseAnimation.SelectedIndex == 4)
            {
                useStyle = "5";
            }

            //getting Rarity
            if (ComboBox_ItemRarity.SelectedIndex == 0)
            {
                Rarity = "-1";
            }
            else if (ComboBox_ItemRarity.SelectedIndex == 1)
            {
                Rarity = "0";
            }
            else if (ComboBox_ItemRarity.SelectedIndex == 2)
            {
                Rarity = "1";
            }
            else if (ComboBox_ItemRarity.SelectedIndex == 3)
            {
                Rarity = "2";
            }
            else if (ComboBox_ItemRarity.SelectedIndex == 4)
            {
                Rarity = "3";
            }
            else if (ComboBox_ItemRarity.SelectedIndex == 5)
            {
                Rarity = "4";
            }
            else if (ComboBox_ItemRarity.SelectedIndex == 6)
            {
                Rarity = "5";
            }
            else if (ComboBox_ItemRarity.SelectedIndex == 7)
            {
                Rarity = "6";
            }
            else if (ComboBox_ItemRarity.SelectedIndex == 8)
            {
                Rarity = "7";
            }
            else if (ComboBox_ItemRarity.SelectedIndex == 9)
            {
                Rarity = "8";
            }
            else if (ComboBox_ItemRarity.SelectedIndex == 10)
            {
                Rarity = "9";
            }
            else if (ComboBox_ItemRarity.SelectedIndex == 11)
            {
                Rarity = "10";
            }
            else if (ComboBox_ItemRarity.SelectedIndex == 12)
            {
                Rarity = "11";
            }
            else if (ComboBox_ItemRarity.SelectedIndex == 13)
            {
                Rarity = "-12";
            }

            //autoswing?
            if (AutoReuse)
            {
                AutoReuseActive = "item.autoReuse = true;";
            }
            else
            {
                AutoReuseActive = "item.autoReuse = false;";
            }

            //adding mana requirement
            if (checkBox_ManaUse.Checked)
            {
                ManaUse = "item.mana = " + NumUpDown_ManaCost.Value + ";";
            }
            else
            {
                ManaUse = "";
            }

            //adding shooting requirement
            if (checkBox_Shooting.Checked)
            {
                Shooting = "item.shoot = " + ProjectileID + ";" + Environment.NewLine + "item.shootSpeed = " + NumUpDown_ShootSpd.Value + "f;";
            }
            else
            {
                Shooting = "";
            }

            //adding the ammo requirement
            if (checkBox_Ammunition.Checked)
            {
                AmmoUse = "item.ammo = " + AmmoID + ";";
            }
            else
            {
                AmmoUse = "";
            }

            //Combining all craft things into 1 string for easier use
            //First craft-item
            if (checkBox_CraftItem1.Checked)
            {
                CraftQuant1 = NumUpDown_CraftQuant1.Value.ToString();
                CraftItem1 = ModName.Replace(" ", "") + "recipe.AddIngredient(" + Int32.Parse(comboBox_CraftItem1.SelectedValue.ToString()) + ", " + CraftQuant1 + ");";
            }
            else
            {
                CraftQuant1 = "";
                CraftItem1 = "";
            }
            //second craft-item
            if (checkBox_CraftItem2.Checked)
            {
                CraftQuant2 = NumUpDown_CraftQuant2.Value.ToString();
                CraftItem2 = ModName.Replace(" ", "") + "recipe.AddIngredient(" + Int32.Parse(comboBox_CraftItem2.SelectedValue.ToString()) + ", " + CraftQuant2 + ");";
            }
            else
            {
                CraftQuant2 = "";
                CraftItem2 = "";
            }
            //thrid craft-item
            if (checkBox_CraftItem3.Checked)
            {
                CraftQuant3 = NumUpDown_CraftQuant3.Value.ToString();
                CraftItem3 = ModName.Replace(" ", "") + "recipe.AddIngredient(" + Int32.Parse(comboBox_CraftItem3.SelectedValue.ToString()) + ", " + CraftQuant3 + ");";
            }
            else
            {
                CraftQuant3 = "";
                CraftItem3 = "";
            }
            //fourth craft-item
            if (checkBox_CraftItem4.Checked)
            {
                CraftQuant4 = NumUpDown_CraftQuant4.Value.ToString();
                CraftItem4 = ModName.Replace(" ", "") + "recipe.AddIngredient(" + Int32.Parse(comboBox_CraftItem4.SelectedValue.ToString()) + ", " + CraftQuant4 + ");";
            }
            else
            {
                CraftQuant4 = "";
                CraftItem4 = "";
            }
            //fith craft-item
            if (checkBox_CraftItem5.Checked)
            {
                CraftQuant5 = NumUpDown_CraftQuant5.Value.ToString();
                CraftItem5 = ModName.Replace(" ", "") + "recipe.AddIngredient(" + Int32.Parse(comboBox_CraftItem5.SelectedValue.ToString()) + ", " + CraftQuant5 + ");";
            }
            else
            {
                CraftQuant5 = "";
                CraftItem5 = "";
            }
            //sixth craft-item
            if (checkBox_CraftItem6.Checked)
            {
                CraftQuant6 = NumUpDown_CraftQuant6.Value.ToString();
                CraftItem6 = ModName.Replace(" ", "") + "recipe.AddIngredient(" + Int32.Parse(comboBox_CraftItem6.SelectedValue.ToString()) + ", " + CraftQuant6 + ");";
            }
            else
            {
                CraftQuant6 = "";
                CraftItem6 = "";
            }

            CraftingItemsComplete = CraftItem1 + Environment.NewLine + CraftItem2 + Environment.NewLine + CraftItem3 + Environment.NewLine + CraftItem4 + Environment.NewLine + CraftItem5 + Environment.NewLine + CraftItem6;

            string FolderNameMOD;

            FolderNameMOD = Path.GetFileName(Path.GetDirectoryName(Folder + "\\build.txt"));


            string CompleteFileText = (
                "using Terraria.ID;" + NL +
                "using Terraria.ModLoader;" + NL +
                "namespace " + FolderNameMOD +".Items" + NL +
                "{" + NL +
                "public class " + ModName.Replace(" ", "") + " : ModItem" + NL +
                "{" + NL +
                "public override void SetStaticDefaults()" + NL +
                "{" + NL +
                "DisplayName.SetDefault(\"" + ModName + "\");" + NL +
                "Tooltip.SetDefault(\"" + ItemDescr + "\");" + NL +
                "}" + NL + NL +
                "public override void SetDefaults()" + NL +
                "{" + NL +
                WeaponType + NL +
                "item.damage = " + NumUpDown_Damage.Value + ";" + NL +
                "item.useStyle = " + useStyle + ";" + NL +
                "item.useTime = " + NumUpDown_UseTime.Value + ";" + NL +
                "item.useAnimation = " + NumUpDown_UseTime.Value + ";" + NL +
                "item.knockBack = " + KnockBack + ";" + NL +
                "item.value = " + NumUpDown_ItemVal.Value + ";" + NL +
                "item.rare = " + Rarity + ";" + NL +
                "item.UseSound = SoundID.Item1;" + NL +
                AutoReuseActive + NL +
                "item.width = " + lbl_ItemWidth.Text + ";" + NL +
                "item.height = " + lbl_ItemHeight.Text + ";" + NL +
                ManaUse + NL +
                AmmoUse + NL +
                Shooting + NL +
                "}" + NL + NL +
                "public override void AddRecipes()" + NL +
                "{" + NL +
                "ModRecipe " + ModName.Replace(" ", "") + "recipe = new ModRecipe(mod);" + NL +
                CraftingItemsComplete + NL +
                ModName.Replace(" ", "") +"recipe.AddTile(" + ComboBox_CraftStation.SelectedValue + ");" + NL +
                ModName.Replace(" ", "") + "recipe.SetResult(this);" + NL +
                ModName.Replace(" ", "") + "recipe.AddRecipe();" + NL +
                "}" + NL +
                "}" + NL +
                "}");
            Clipboard.SetText(CompleteFileText);
            using (StreamWriter writer = new StreamWriter(Folder + "\\Items\\" + ModName + ".cs"))
            {
                writer.Write(CompleteFileText);
            }
            ImageSprite.Save(Folder + "\\Items\\" + ModName.Replace(" ", "") + ".png");
            MessageBox.Show("Finished creating the item-file and copying the picture! Enjoy your weapon!", "Success!");
        }

        private void textBox_WeaponName_TextChanged(object sender, EventArgs e)
        {
            ModName = textBox_WeaponName.Text;
        }

        private void textBox_ItemDescr_TextChanged(object sender, EventArgs e)
        {
            ItemDescr = textBox_ItemDescr.Text;
        }

        private void comboBox_WeaponType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NumUpDown_KnockBack_ValueChanged(object sender, EventArgs e)
        {
            KnockBack = NumUpDown_KnockBack.Value.ToString();
        }

        private void ComboBox_ItemRarity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox_WeaponName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                
                e.Handled = true;
                base.OnKeyPress(e);
               
            }

            if (e.KeyChar.ToString() == "ö" || e.KeyChar.ToString() == "Ö" || e.KeyChar.ToString() == "ä" || e.KeyChar.ToString() == "Ä" || e.KeyChar.ToString() == "ü" || e.KeyChar.ToString() == "Ü" || e.KeyChar.ToString() == "ß" )
                e.Handled = true;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void NumUpDown_NPCDmg_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            openFileDialogNPC.Filter = "SpriteSheet *.png | *.png";
            openFileDialogNPC.ShowDialog();
            NPCSpriteSheet = System.Drawing.Image.FromFile(openFileDialogNPC.FileName);
            lbl_npcWidth.Text = NPCSpriteSheet.Width.ToString();
            int singleSpriteHeight = NPCSpriteSheet.Height/3;
            lbl_npcHeight.Text = singleSpriteHeight.ToString();
            lbl_FileNameNPC.Text = openFileDialogNPC.FileName;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void NumUpDown_DropItem_Min1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void NumUpDown_DropItem_Min2_ValueChanged(object sender, EventArgs e)
        {
        }

        private void NumUpDown_DropItem_Min3_ValueChanged(object sender, EventArgs e)
        {
        }

        private void NumUpDown_DropItem_Min4_ValueChanged(object sender, EventArgs e)
        {
        }

        private void NumUpDown_DropItem_Min5_ValueChanged(object sender, EventArgs e)
        {
        }

        private void checkBox_DropItem1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_DropItem1.Checked)
            {
                comboBox_DropItem1.Enabled = true;
                NumUpDown_DropItem_Max1.Enabled = true;
                NumUpDown_DropItem_Min1.Enabled = true;
            }
            else
            {
                comboBox_DropItem1.Enabled = false;
                NumUpDown_DropItem_Max1.Enabled = false;
                NumUpDown_DropItem_Min1.Enabled = false;
            }
        }

        private void checkBox_DropItem2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_DropItem2.Checked)
            {
                comboBox_DropItem2.Enabled = true;
                NumUpDown_DropItem_Max2.Enabled = true;
                NumUpDown_DropItem_Min2.Enabled = true;
            }
            else
            {
                comboBox_DropItem2.Enabled = false;
                NumUpDown_DropItem_Max2.Enabled = false;
                NumUpDown_DropItem_Min2.Enabled = false;
            }
        }

        private void checkBox_DropItem3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_DropItem3.Checked)
            {
                comboBox_DropItem3.Enabled = true;
                NumUpDown_DropItem_Max3.Enabled = true;
                NumUpDown_DropItem_Min3.Enabled = true;
            }
            else
            {
                comboBox_DropItem3.Enabled = false;
                NumUpDown_DropItem_Max3.Enabled = false;
                NumUpDown_DropItem_Min3.Enabled = false;
            }
        }

        private void checkBox_DropItem4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_DropItem4.Checked)
            {
                comboBox_DropItem4.Enabled = true;
                NumUpDown_DropItem_Max4.Enabled = true;
                NumUpDown_DropItem_Min4.Enabled = true;
            }
            else
            {
                comboBox_DropItem4.Enabled = false;
                NumUpDown_DropItem_Max4.Enabled = false;
                NumUpDown_DropItem_Min4.Enabled = false;
            }
        }

        private void checkBox_DropItem5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_DropItem5.Checked)
            {
                comboBox_DropItem5.Enabled = true;
                NumUpDown_DropItem_Max5.Enabled = true;
                NumUpDown_DropItem_Min5.Enabled = true;
            }
            else
            {
                comboBox_DropItem5.Enabled = false;
                NumUpDown_DropItem_Max5.Enabled = false;
                NumUpDown_DropItem_Min5.Enabled = false;
            }
        }

        private void Butt_GenerateEnemyMod_Click(object sender, EventArgs e)
        {
            string FolderNameMOD;
            string NL = Environment.NewLine;

            string ItemDrop1;
            string ItemDrop2;
            string ItemDrop3;
            string ItemDrop4;
            string ItemDrop5;


            FolderNameMOD = Path.GetFileName(Path.GetDirectoryName(Folder + "\\build.txt"));

            //adding all item strings together
            if (checkBox_DropItem1.Checked)
            {
                ItemDrop1 = "Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, " + comboBox_DropItem1.SelectedValue + ", Main.rand.Next(" + NumUpDown_DropItem_Min1.Value + ", " + NumUpDown_DropItem_Max1.Value + "));";
            }
            else
            {
                ItemDrop1 = "";
            }

            if (checkBox_DropItem2.Checked)
            {
                ItemDrop2 = "Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, " + comboBox_DropItem2.SelectedValue + ", Main.rand.Next(" + NumUpDown_DropItem_Min2.Value + ", " + NumUpDown_DropItem_Max2.Value + "));";
            }
            else
            {
                ItemDrop2 = "";
            }

            if (checkBox_DropItem3.Checked)
            {
                ItemDrop3 = "Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, " + comboBox_DropItem3.SelectedValue + ", Main.rand.Next(" + NumUpDown_DropItem_Min3.Value + ", " + NumUpDown_DropItem_Max3.Value + "));";
            }
            else
            {
                ItemDrop3 = "";
            }

            if (checkBox_DropItem4.Checked)
            {
                ItemDrop4 = "Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, " + comboBox_DropItem4.SelectedValue + ", Main.rand.Next(" + NumUpDown_DropItem_Min4.Value + ", " + NumUpDown_DropItem_Max4.Value + "));";
            }
            else
            {
                ItemDrop4 = "";
            }

            if (checkBox_DropItem5.Checked)
            {
                ItemDrop5 = "Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, " + comboBox_DropItem5.SelectedValue + ", Main.rand.Next(" + NumUpDown_DropItem_Min5.Value + ", " + NumUpDown_DropItem_Max5.Value + "));";
            }
            else
            {
                ItemDrop5 = "";
            }
            string CompleteItemDrops = ItemDrop1 + NL + ItemDrop2 + NL + ItemDrop3 + NL + ItemDrop4 + NL + ItemDrop5;

            string ModName = TextBox_EnemyName.Text;

            string CompleteFileText = (
                "using Terraria;" + NL +
                "using Terraria.ID;" + NL +
                "using Terraria.ModLoader;" + NL +
                "namespace " + FolderNameMOD + ".NPCs" + NL +
                "{" + NL +
                "public class " + ModName.Replace(" ", "") + " : ModNPC" + NL +
                "{" + NL +
                "public override void SetStaticDefaults()" + NL +
                "{" + NL +
                "DisplayName.SetDefault(\"" + TextBox_EnemyName.Text + "\");" + NL +
                "}" + NL + NL +
                "public override void SetDefaults()" + NL +
                "{" + NL +
                "npc.width = " + NPCSpriteSheet.Width + ";" + NL +
                "npc.height = " + NPCSpriteSheet.Height / 3 + ";" + NL +
                "npc.damage = " + NumUpDown_NPCDmg.Value + ";" + NL +
                "npc.defense = " + NumUpDown_NPCDefense.Value + ";" + NL +
                "npc.lifeMax = " + NumUpDown_EnemyHealth.Value + ";" + NL +
                "npc.HitSound = SoundID.NPCHit2;" + NL +
                "npc.DeathSound = SoundID.NPCDeath2;" + NL +
                "npc.aiStyle = " + comboBox_EnemyCopy.SelectedValue + ";" + NL +
                "Main.npcFrameCount[npc.type] = 3;" + NL +
                "aiType = " + comboBox_EnemyCopy.SelectedValue + ";" + NL +
                "animationType = " + comboBox_EnemyCopy.SelectedValue + ";" + NL +
                "}" + NL + NL +
                "public override float SpawnChance(NPCSpawnInfo spawnInfo)" + NL +
                "{" + NL +
                "return SpawnCondition.OverworldNightMonster.Chance * " + NumUpDown_NPCSpwanRate.Value + "f;" + NL +
                "}" + NL +
                "public override void NPCLoot()" + NL +
                "{" + NL +
                CompleteItemDrops + NL +
                "}" + NL +
                "}" + NL +
                "}"

                );


            if (!Directory.Exists(Folder + "\\NPCs\\"))
            {
                Directory.CreateDirectory(Folder + "\\NPCs\\");
            }


            using (StreamWriter writer = new StreamWriter(Folder + "\\NPCs\\" + ModName + ".cs"))
            {
                writer.Write(CompleteFileText);
            }
            NPCSpriteSheet.Save(Folder + "\\NPCs\\" + ModName.Replace(" ", "") + ".png");
            MessageBox.Show("Finished creating the enemy-file and copying the picture! Enjoy your enemy!", "Success!");
        }

        private void TextBox_EnemyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {

                e.Handled = true;
                base.OnKeyPress(e);

            }

            if (e.KeyChar.ToString() == "ö" || e.KeyChar.ToString() == "Ö" || e.KeyChar.ToString() == "ä" || e.KeyChar.ToString() == "Ä" || e.KeyChar.ToString() == "ü" || e.KeyChar.ToString() == "Ü" || e.KeyChar.ToString() == "ß")
                e.Handled = true;
        }
    }
}

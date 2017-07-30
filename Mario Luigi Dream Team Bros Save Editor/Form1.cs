using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mario_Luigi_Dream_Team_Bros_Save_Editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string savegame;
        public int moneyall;

        public static byte[] BLKDTH_StringToByteArray(string hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        private void BLKDTH_get_openfile()
        {
            OpenFileDialog openFD = new OpenFileDialog();
            if (openFD.ShowDialog() == DialogResult.OK)
            {
                savegame = openFD.FileName;
            }
        }
        private void BLKDTH_get_data()
        {
            {
                FileStream savegame_fs = new FileStream(savegame, FileMode.Open);
                BinaryReader savegame_br = new BinaryReader(savegame_fs);
                long length = savegame_fs.Length;
                // Money
                savegame_br.BaseStream.Position = 0x91C;
                byte[] money = savegame_br.ReadBytes(4);
                int moneyall = BitConverter.ToInt32(money, 0);
                box_money.Text = (moneyall.ToString());
                // Mario Current HP
                savegame_br.BaseStream.Position = 0x74E;
                byte[] mariohp = savegame_br.ReadBytes(2);
                int mhp = BitConverter.ToInt16(mariohp, 0);
                m_chp.Text = (mhp.ToString());
                // Mario Max HP 
                savegame_br.BaseStream.Position = 0x750;
                byte[] mariomhp = savegame_br.ReadBytes(2);
                int mmhp = BitConverter.ToInt16(mariomhp, 0);
                m_mhp.Text = (mmhp.ToString());
                // Mario Current BP
                savegame_br.BaseStream.Position = 0x752;
                byte[] mariobp = savegame_br.ReadBytes(2);
                int mcbp = BitConverter.ToInt16(mariobp, 0);
                m_cbp.Text = (mcbp.ToString());
                // Mario Max BP
                savegame_br.BaseStream.Position = 0x754;
                byte[] mariombp = savegame_br.ReadBytes(2);
                int mmbp = BitConverter.ToInt16(mariombp, 0);
                m_mbp.Text = (mmbp.ToString());
                // Mario POW
                savegame_br.BaseStream.Position = 0x756;
                byte[] maroppow = savegame_br.ReadBytes(2);
                int mpow = BitConverter.ToInt16(maroppow, 0);
                m_pow.Text = (mpow.ToString());
                // Mario DEF
                savegame_br.BaseStream.Position = 0x758;
                byte[] mariodef = savegame_br.ReadBytes(2);
                int mdef = BitConverter.ToInt16(mariodef, 0);
                m_def.Text = (mdef.ToString());
                // Mario Speed
                savegame_br.BaseStream.Position = 0x75A;
                byte[] mariospeed = savegame_br.ReadBytes(2);
                int mspeed = BitConverter.ToInt16(mariospeed, 0);
                m_speed.Text = (mspeed.ToString());
                // Mario Mustache
                savegame_br.BaseStream.Position = 0x75C;
                byte[] mariomustache = savegame_br.ReadBytes(2);
                int mm = BitConverter.ToInt16(mariomustache, 0);
                m_m.Text = (mm.ToString());

                // Luigi Current HP
                savegame_br.BaseStream.Position = 0x836;
                byte[] luigihp = savegame_br.ReadBytes(2);
                int lhp = BitConverter.ToInt16(luigihp, 0);
                l_chp.Text = (lhp.ToString());
                // Luigi Max HP 
                savegame_br.BaseStream.Position = 0x838;
                byte[] luigimhp = savegame_br.ReadBytes(2);
                int lmhp = BitConverter.ToInt16(luigimhp, 0);
                l_mhp.Text = (lmhp.ToString());
                // Luigi Current BP
                savegame_br.BaseStream.Position = 0x83A;
                byte[] luigibp = savegame_br.ReadBytes(2);
                int lcbp = BitConverter.ToInt16(luigibp, 0);
                l_cbp.Text = (lcbp.ToString());
                // Luigi Max BP
                savegame_br.BaseStream.Position = 0x83C;
                byte[] luigimbp = savegame_br.ReadBytes(2);
                int lmbp = BitConverter.ToInt16(luigimbp, 0);
                l_mbp.Text = (lmbp.ToString());
                // Luigi POW
                savegame_br.BaseStream.Position = 0x83E;
                byte[] luigipow = savegame_br.ReadBytes(2);
                int lpow = BitConverter.ToInt16(luigipow, 0);
                l_pow.Text = (lpow.ToString());
                // Luigi DEF
                savegame_br.BaseStream.Position = 0x840;
                byte[] luigidef = savegame_br.ReadBytes(2);
                int ldef = BitConverter.ToInt16(luigidef, 0);
                l_def.Text = (ldef.ToString());
                // Luigi Speed
                savegame_br.BaseStream.Position = 0x842;
                byte[] luigispeed = savegame_br.ReadBytes(2);
                int lspeed = BitConverter.ToInt16(luigispeed, 0);
                l_speed.Text = (lspeed.ToString());
                // Luigi Mustache
                savegame_br.BaseStream.Position = 0x844;
                byte[] luigimustache = savegame_br.ReadBytes(2);
                int lm = BitConverter.ToInt16(luigimustache, 0);
                l_m.Text = (lm.ToString());
                savegame_br.Close();
            }

        }
        private void BLKDTH_set_data()
        {
            FileStream update_save_open = null;
            BinaryWriter update_save_write = null;
            update_save_open = new System.IO.FileStream(savegame, System.IO.FileMode.OpenOrCreate);
            update_save_write = new System.IO.BinaryWriter(update_save_open);

            #region data
            byte[] money = BLKDTH_StringToByteArray(int.Parse(box_money.Text).ToString("X8"));
            Array.Reverse(money);
            update_save_open.Position = Convert.ToInt64("91C", 16);
            update_save_write.Write(money);

            byte[] mariohp = BLKDTH_StringToByteArray(int.Parse(m_chp.Text).ToString("X4"));
            Array.Reverse(mariohp);
            update_save_open.Position = Convert.ToInt16("74E", 16);
            update_save_write.Write(mariohp);

            byte[] mariomhp = BLKDTH_StringToByteArray(int.Parse(m_mhp.Text).ToString("X4"));
            Array.Reverse(mariomhp);
            update_save_open.Position = Convert.ToInt16("750", 16);
            update_save_write.Write(mariomhp);

            byte[] mariobp = BLKDTH_StringToByteArray(int.Parse(m_cbp.Text).ToString("X4"));
            Array.Reverse(mariobp);
            update_save_open.Position = Convert.ToInt16("752", 16);
            update_save_write.Write(mariobp);

            byte[] mariombp = BLKDTH_StringToByteArray(int.Parse(m_mbp.Text).ToString("X4"));
            Array.Reverse(mariombp);
            update_save_open.Position = Convert.ToInt16("754", 16);
            update_save_write.Write(mariombp);

            byte[] maroppow = BLKDTH_StringToByteArray(int.Parse(m_pow.Text).ToString("X4"));
            Array.Reverse(maroppow);
            update_save_open.Position = Convert.ToInt16("756", 16);
            update_save_write.Write(maroppow);

            byte[] mariodef = BLKDTH_StringToByteArray(int.Parse(m_def.Text).ToString("X4"));
            Array.Reverse(mariodef);
            update_save_open.Position = Convert.ToInt16("758", 16);
            update_save_write.Write(mariodef);

            byte[] mariospeed = BLKDTH_StringToByteArray(int.Parse(m_speed.Text).ToString("X4"));
            Array.Reverse(mariospeed);
            update_save_open.Position = Convert.ToInt16("75A", 16);
            update_save_write.Write(mariospeed);

            byte[] mariomustache = BLKDTH_StringToByteArray(int.Parse(m_m.Text).ToString("X4"));
            Array.Reverse(mariomustache);
            update_save_open.Position = Convert.ToInt16("75C", 16);
            update_save_write.Write(mariomustache);



            byte[] luigihp = BLKDTH_StringToByteArray(int.Parse(l_chp.Text).ToString("X4"));
            Array.Reverse(luigihp);
            update_save_open.Position = Convert.ToInt16("836", 16);
            update_save_write.Write(luigihp);

            byte[] luigimhp = BLKDTH_StringToByteArray(int.Parse(l_mhp.Text).ToString("X4"));
            Array.Reverse(luigimhp);
            update_save_open.Position = Convert.ToInt16("838", 16);
            update_save_write.Write(luigimhp);

            byte[] luigibp = BLKDTH_StringToByteArray(int.Parse(l_cbp.Text).ToString("X4"));
            Array.Reverse(luigibp);
            update_save_open.Position = Convert.ToInt16("83A", 16);
            update_save_write.Write(luigibp);

            byte[] luigimbp = BLKDTH_StringToByteArray(int.Parse(l_mbp.Text).ToString("X4"));
            Array.Reverse(luigimbp);
            update_save_open.Position = Convert.ToInt16("83C", 16);
            update_save_write.Write(luigimbp);

            byte[] luigipow = BLKDTH_StringToByteArray(int.Parse(l_pow.Text).ToString("X4"));
            Array.Reverse(luigipow);
            update_save_open.Position = Convert.ToInt16("83E", 16);
            update_save_write.Write(luigipow);

            byte[] luigidef = BLKDTH_StringToByteArray(int.Parse(l_def.Text).ToString("X4"));
            Array.Reverse(luigidef);
            update_save_open.Position = Convert.ToInt16("840", 16);
            update_save_write.Write(luigidef);

            byte[] luigispeed = BLKDTH_StringToByteArray(int.Parse(l_speed.Text).ToString("X4"));
            Array.Reverse(luigispeed);
            update_save_open.Position = Convert.ToInt16("842", 16);
            update_save_write.Write(luigispeed);

            byte[] luigimustache = BLKDTH_StringToByteArray(int.Parse(l_m.Text).ToString("X4"));
            Array.Reverse(luigimustache);
            update_save_open.Position = Convert.ToInt16("844", 16);
            update_save_write.Write(luigimustache);
            #endregion

            update_save_open.Close();
        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Based on DaBlackDeath's (New Super Mario Bros 2 Save Editor Source) " +
                "htps://gbatemp.net/members/dablackdeath.110449/");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLKDTH_get_openfile();
            if (string.IsNullOrEmpty(savegame))
            {
                MessageBox.Show("no savegame selected");
            }
            else
            {
                BLKDTH_get_data();
                save.Enabled = true;
                items_max.Enabled = true;
                // Rank Check
                FileStream savegame_fs = new FileStream(savegame, FileMode.Open);
                BinaryReader savegame_br = new BinaryReader(savegame_fs);
                long length = savegame_fs.Length;
                savegame_br.BaseStream.Position = 0x77F;
                byte[] rank = savegame_br.ReadBytes(4);
                int rank1 = BitConverter.ToInt32(rank, 0);
                currentrank.Text = (rank1.ToString());
                savegame_br.Close();

                if (currentrank.Text == "590356272")
                {
                    lvl8.Enabled = true;
                    lvl16.Enabled = false;
                    lvl26.Enabled = false;
                    lvl40.Enabled = false;
                    lvl100.Enabled = false;
                }
                if (currentrank.Text == "590356273")
                {
                    lvl8.Enabled = false;
                    lvl16.Enabled = true;
                    lvl26.Enabled = false;
                    lvl40.Enabled = false;
                    lvl100.Enabled = false;
                }
                if (currentrank.Text == "590356274")
                {
                    lvl8.Enabled = false;
                    lvl16.Enabled = false;
                    lvl26.Enabled = true;
                    lvl40.Enabled = false;
                    lvl100.Enabled = false;
                }
                if (currentrank.Text == "590356275")
                {
                    lvl8.Enabled = false;
                    lvl16.Enabled = false;
                    lvl26.Enabled = false;
                    lvl40.Enabled = true;
                    lvl100.Enabled = false;
                }
                if (currentrank.Text == "590356276")
                {
                    lvl8.Enabled = false;
                    lvl16.Enabled = false;
                    lvl26.Enabled = false;
                    lvl40.Enabled = false;
                    lvl100.Enabled = true;
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLKDTH_set_data();
            MessageBox.Show("Data saved");
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void items_max_Click(object sender, EventArgs e)
        {
            FileStream update_save_open1 = null;
            BinaryWriter update_save_write1 = null;
            update_save_open1 = new System.IO.FileStream(savegame, System.IO.FileMode.OpenOrCreate);
            update_save_write1 = new System.IO.BinaryWriter(update_save_open1);

            #region data
            byte[] items_max = BLKDTH_StringToByteArray(int.Parse(textBox1.Text).ToString("x8"));
            Array.Reverse(items_max);
            update_save_open1.Position = Convert.ToInt64("920", 16);
            update_save_write1.Write(items_max);
            byte[] items_max2 = BLKDTH_StringToByteArray(int.Parse(textBox2.Text).ToString("X8"));
            Array.Reverse(items_max2);
            update_save_open1.Position = Convert.ToInt64("924", 16);
            update_save_write1.Write(items_max2);
            byte[] items_max3 = BLKDTH_StringToByteArray(int.Parse(textBox3.Text).ToString("X8"));
            Array.Reverse(items_max3);
            update_save_open1.Position = Convert.ToInt64("928", 16);
            update_save_write1.Write(items_max3);
            byte[] items_max4 = BLKDTH_StringToByteArray(int.Parse(textBox4.Text).ToString("X8"));
            Array.Reverse(items_max4);
            update_save_open1.Position = Convert.ToInt64("92C", 16);
            update_save_write1.Write(items_max4);
            byte[] items_max5 = BLKDTH_StringToByteArray(int.Parse(textBox5.Text).ToString("X8"));
            Array.Reverse(items_max5);
            update_save_open1.Position = Convert.ToInt64("930", 16);
            update_save_write1.Write(items_max5);
            byte[] items_max6 = BLKDTH_StringToByteArray(int.Parse(textBox6.Text).ToString("X8"));
            Array.Reverse(items_max6);
            update_save_open1.Position = Convert.ToInt64("934", 16);
            update_save_write1.Write(items_max6);
            byte[] items_max7 = BLKDTH_StringToByteArray(int.Parse(textBox7.Text).ToString("X8"));
            Array.Reverse(items_max7);
            update_save_open1.Position = Convert.ToInt64("938", 16);
            update_save_write1.Write(items_max7);
            byte[] items_max8 = BLKDTH_StringToByteArray(int.Parse(textBox8.Text).ToString("X8"));
            Array.Reverse(items_max8);
            update_save_open1.Position = Convert.ToInt64("93C", 16);
            update_save_write1.Write(items_max8);
            byte[] items_max9 = BLKDTH_StringToByteArray(int.Parse(textBox9.Text).ToString("X3"));
            Array.Reverse(items_max9);
            update_save_open1.Position = Convert.ToInt64("940", 16);
            update_save_write1.Write(items_max9);
            #endregion

            update_save_open1.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label17.Text = "Hint: You can only click 1 option at a Time. " +
                "Then save and Kill 1 Enemy to Rankup. " +
                "Then load your save back here and " +
                "select the next option...";
            this.Width = 955;
            this.Height = 260;
        }

        private void lvl8_Click(object sender, EventArgs e)
        {
            FileStream update_save_open2 = null;
            BinaryWriter update_save_write2 = null;
            update_save_open2 = new System.IO.FileStream(savegame, System.IO.FileMode.OpenOrCreate);
            update_save_write2 = new System.IO.BinaryWriter(update_save_open2);

            #region data
            byte[] exp = BLKDTH_StringToByteArray(int.Parse(exp8box.Text).ToString("x6"));
            Array.Reverse(exp);
            update_save_open2.Position = Convert.ToInt64("778", 16);
            update_save_write2.Write(exp);
            byte[] expl = BLKDTH_StringToByteArray(int.Parse(expl8box.Text).ToString("X6"));
            Array.Reverse(expl);
            update_save_open2.Position = Convert.ToInt64("77C", 16);
            update_save_write2.Write(expl);
            byte[] lvl8 = BLKDTH_StringToByteArray(int.Parse(lvl8box.Text).ToString("X2"));
            Array.Reverse(lvl8);
            update_save_open2.Position = Convert.ToInt64("77B", 16);
            update_save_write2.Write(lvl8);
            byte[] rank = BLKDTH_StringToByteArray(int.Parse(rank8box.Text).ToString("X2"));
            Array.Reverse(rank);
            update_save_open2.Position = Convert.ToInt64("77F", 16);
            update_save_write2.Write(rank);

            byte[] exp1 = BLKDTH_StringToByteArray(int.Parse(exp8box1.Text).ToString("x6"));
            Array.Reverse(exp1);
            update_save_open2.Position = Convert.ToInt64("860", 16);
            update_save_write2.Write(exp1);
            byte[] exp1l = BLKDTH_StringToByteArray(int.Parse(expl8box.Text).ToString("X6"));
            Array.Reverse(exp1l);
            update_save_open2.Position = Convert.ToInt64("864", 16);
            update_save_write2.Write(exp1l);
            byte[] lvl81 = BLKDTH_StringToByteArray(int.Parse(lvl8box.Text).ToString("X2"));
            Array.Reverse(lvl81);
            update_save_open2.Position = Convert.ToInt64("863", 16);
            update_save_write2.Write(lvl81);
            byte[] rank1 = BLKDTH_StringToByteArray(int.Parse(rank8box.Text).ToString("X2"));
            Array.Reverse(rank1);
            update_save_open2.Position = Convert.ToInt64("867", 16);
            update_save_write2.Write(rank1);
            #endregion

            update_save_open2.Close();
        }

        private void lvl16_Click(object sender, EventArgs e)
        {
            FileStream update_save_open2 = null;
            BinaryWriter update_save_write2 = null;
            update_save_open2 = new System.IO.FileStream(savegame, System.IO.FileMode.OpenOrCreate);
            update_save_write2 = new System.IO.BinaryWriter(update_save_open2);

            #region data
            byte[] exp = BLKDTH_StringToByteArray(int.Parse(exp16box.Text).ToString("x6"));
            Array.Reverse(exp);
            update_save_open2.Position = Convert.ToInt64("778", 16);
            update_save_write2.Write(exp);
            byte[] expl = BLKDTH_StringToByteArray(int.Parse(expl8box.Text).ToString("X6"));
            Array.Reverse(expl);
            update_save_open2.Position = Convert.ToInt64("77C", 16);
            update_save_write2.Write(expl);
            byte[] lvl8 = BLKDTH_StringToByteArray(int.Parse(lvl16box.Text).ToString("X2"));
            Array.Reverse(lvl8);
            update_save_open2.Position = Convert.ToInt64("77B", 16);
            update_save_write2.Write(lvl8);
            byte[] rank = BLKDTH_StringToByteArray(int.Parse(rank16box.Text).ToString("X2"));
            Array.Reverse(rank);
            update_save_open2.Position = Convert.ToInt64("77F", 16);
            update_save_write2.Write(rank);

            byte[] exp1 = BLKDTH_StringToByteArray(int.Parse(exp16box1.Text).ToString("x6"));
            Array.Reverse(exp1);
            update_save_open2.Position = Convert.ToInt64("860", 16);
            update_save_write2.Write(exp1);
            byte[] exp1l = BLKDTH_StringToByteArray(int.Parse(expl8box.Text).ToString("X6"));
            Array.Reverse(exp1l);
            update_save_open2.Position = Convert.ToInt64("864", 16);
            update_save_write2.Write(exp1l);
            byte[] lvl81 = BLKDTH_StringToByteArray(int.Parse(lvl16box.Text).ToString("X2"));
            Array.Reverse(lvl81);
            update_save_open2.Position = Convert.ToInt64("863", 16);
            update_save_write2.Write(lvl81);
            byte[] rank1 = BLKDTH_StringToByteArray(int.Parse(rank16box.Text).ToString("X2"));
            Array.Reverse(rank1);
            update_save_open2.Position = Convert.ToInt64("867", 16);
            update_save_write2.Write(rank1);
            #endregion

            update_save_open2.Close();
        }

        private void lvl26_Click(object sender, EventArgs e)
        {
            
                FileStream update_save_open2 = null;
                BinaryWriter update_save_write2 = null;
                update_save_open2 = new System.IO.FileStream(savegame, System.IO.FileMode.OpenOrCreate);
                update_save_write2 = new System.IO.BinaryWriter(update_save_open2);

                #region data
                byte[] exp = BLKDTH_StringToByteArray(int.Parse(exp26box.Text).ToString("x6"));
                Array.Reverse(exp);
                update_save_open2.Position = Convert.ToInt64("778", 16);
                update_save_write2.Write(exp);
                byte[] expl = BLKDTH_StringToByteArray(int.Parse(expl8box.Text).ToString("X6"));
                Array.Reverse(expl);
                update_save_open2.Position = Convert.ToInt64("77C", 16);
                update_save_write2.Write(expl);
                byte[] lvl8 = BLKDTH_StringToByteArray(int.Parse(lvl26box.Text).ToString("X2"));
                Array.Reverse(lvl8);
                update_save_open2.Position = Convert.ToInt64("77B", 16);
                update_save_write2.Write(lvl8);
                byte[] rank = BLKDTH_StringToByteArray(int.Parse(rank26box.Text).ToString("X2"));
                Array.Reverse(rank);
                update_save_open2.Position = Convert.ToInt64("77F", 16);
                update_save_write2.Write(rank);

                byte[] exp1 = BLKDTH_StringToByteArray(int.Parse(exp26box1.Text).ToString("x6"));
                Array.Reverse(exp1);
                update_save_open2.Position = Convert.ToInt64("860", 16);
                update_save_write2.Write(exp1);
                byte[] exp1l = BLKDTH_StringToByteArray(int.Parse(expl8box.Text).ToString("X6"));
                Array.Reverse(exp1l);
                update_save_open2.Position = Convert.ToInt64("864", 16);
                update_save_write2.Write(exp1l);
                byte[] lvl81 = BLKDTH_StringToByteArray(int.Parse(lvl26box.Text).ToString("X2"));
                Array.Reverse(lvl81);
                update_save_open2.Position = Convert.ToInt64("863", 16);
                update_save_write2.Write(lvl81);
                byte[] rank1 = BLKDTH_StringToByteArray(int.Parse(rank26box.Text).ToString("X2"));
                Array.Reverse(rank1);
                update_save_open2.Position = Convert.ToInt64("867", 16);
                update_save_write2.Write(rank1);
                #endregion

                update_save_open2.Close();
            
        }

        private void lvl40_Click(object sender, EventArgs e)
        {
            FileStream update_save_open2 = null;
            BinaryWriter update_save_write2 = null;
            update_save_open2 = new System.IO.FileStream(savegame, System.IO.FileMode.OpenOrCreate);
            update_save_write2 = new System.IO.BinaryWriter(update_save_open2);

            #region data
            byte[] exp = BLKDTH_StringToByteArray(int.Parse(exp40box.Text).ToString("x6"));
            Array.Reverse(exp);
            update_save_open2.Position = Convert.ToInt64("778", 16);
            update_save_write2.Write(exp);
            byte[] expl = BLKDTH_StringToByteArray(int.Parse(expl8box.Text).ToString("X6"));
            Array.Reverse(expl);
            update_save_open2.Position = Convert.ToInt64("77C", 16);
            update_save_write2.Write(expl);
            byte[] lvl8 = BLKDTH_StringToByteArray(int.Parse(lvl40box.Text).ToString("X2"));
            Array.Reverse(lvl8);
            update_save_open2.Position = Convert.ToInt64("77B", 16);
            update_save_write2.Write(lvl8);
            byte[] rank = BLKDTH_StringToByteArray(int.Parse(rank40box.Text).ToString("X2"));
            Array.Reverse(rank);
            update_save_open2.Position = Convert.ToInt64("77F", 16);
            update_save_write2.Write(rank);

            byte[] exp1 = BLKDTH_StringToByteArray(int.Parse(exp40box1.Text).ToString("x6"));
            Array.Reverse(exp1);
            update_save_open2.Position = Convert.ToInt64("860", 16);
            update_save_write2.Write(exp1);
            byte[] exp1l = BLKDTH_StringToByteArray(int.Parse(expl8box.Text).ToString("X6"));
            Array.Reverse(exp1l);
            update_save_open2.Position = Convert.ToInt64("864", 16);
            update_save_write2.Write(exp1l);
            byte[] lvl81 = BLKDTH_StringToByteArray(int.Parse(lvl40box.Text).ToString("X2"));
            Array.Reverse(lvl81);
            update_save_open2.Position = Convert.ToInt64("863", 16);
            update_save_write2.Write(lvl81);
            byte[] rank1 = BLKDTH_StringToByteArray(int.Parse(rank40box.Text).ToString("X2"));
            Array.Reverse(rank1);
            update_save_open2.Position = Convert.ToInt64("867", 16);
            update_save_write2.Write(rank1);
            #endregion

            update_save_open2.Close();
        }

        private void lvl100_Click(object sender, EventArgs e)
        {
            FileStream update_save_open2 = null;
            BinaryWriter update_save_write2 = null;
            update_save_open2 = new System.IO.FileStream(savegame, System.IO.FileMode.OpenOrCreate);
            update_save_write2 = new System.IO.BinaryWriter(update_save_open2);

            #region data
            byte[] exp = BLKDTH_StringToByteArray(int.Parse(exp100box.Text).ToString("x6"));
            Array.Reverse(exp);
            update_save_open2.Position = Convert.ToInt64("778", 16);
            update_save_write2.Write(exp);
            byte[] expl = BLKDTH_StringToByteArray(int.Parse(expl8box.Text).ToString("X6"));
            Array.Reverse(expl);
            update_save_open2.Position = Convert.ToInt64("77C", 16);
            update_save_write2.Write(expl);
            byte[] lvl8 = BLKDTH_StringToByteArray(int.Parse(lvl100box.Text).ToString("X2"));
            Array.Reverse(lvl8);
            update_save_open2.Position = Convert.ToInt64("77B", 16);
            update_save_write2.Write(lvl8);
            byte[] rank = BLKDTH_StringToByteArray(int.Parse(rank100box.Text).ToString("X2"));
            Array.Reverse(rank);
            update_save_open2.Position = Convert.ToInt64("77F", 16);
            update_save_write2.Write(rank);

            byte[] exp1 = BLKDTH_StringToByteArray(int.Parse(exp100box1.Text).ToString("x6"));
            Array.Reverse(exp1);
            update_save_open2.Position = Convert.ToInt64("860", 16);
            update_save_write2.Write(exp1);
            byte[] exp1l = BLKDTH_StringToByteArray(int.Parse(expl8box.Text).ToString("X6"));
            Array.Reverse(exp1l);
            update_save_open2.Position = Convert.ToInt64("864", 16);
            update_save_write2.Write(exp1l);
            byte[] lvl81 = BLKDTH_StringToByteArray(int.Parse(lvl100box.Text).ToString("X2"));
            Array.Reverse(lvl81);
            update_save_open2.Position = Convert.ToInt64("863", 16);
            update_save_write2.Write(lvl81);
            byte[] rank1 = BLKDTH_StringToByteArray(int.Parse(rank100box.Text).ToString("X2"));
            Array.Reverse(rank1);
            update_save_open2.Position = Convert.ToInt64("867", 16);
            update_save_write2.Write(rank1);
            #endregion

            update_save_open2.Close();
        }
    }
}

using Axie.Class;
using Axie.Enumerador;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Axie
{
    public partial class Form1 : Form
    {
        #region MyRegion
        List<Bitmap> lst_Aquatic = new List<Bitmap>();
        List<Bitmap> lst_Besta = new List<Bitmap>();
        List<Bitmap> lst_Bird = new List<Bitmap>();
        List<Bitmap> lst_Bug = new List<Bitmap>();
        List<Bitmap> lst_Planta = new List<Bitmap>();
        List<Bitmap> lst_Reptil = new List<Bitmap>();
        #endregion
        List<Cartas> Cartas = new List<Cartas>();
        public Form1()
        {
            InitializeComponent();
            PopularComboBox();
            PopularCartas();
            comboBox2.SelectedItem = pictureBox1.SizeMode.ToString();
        }
        public void PopularComboBox()
        {
            foreach (Tipo val in Enum.GetValues(typeof(Tipo)))
            {
                comboBox1.Items.Add(val);
            }
        }

        public void PopularCartas()
        {
            List<string> peixe, besta, planta, bug, reptil, bird;
            CartasXClasse(out peixe, out besta, out planta, out bug, out reptil, out bird);

            ResourceSet resourceSet = Properties.Resources.ResourceManager.GetResourceSet(System.Globalization.CultureInfo.CurrentUICulture, true, true);
            int ac = 0, a = 0, b = 0, c = 0, d = 0, e = 0, f = 0;
            foreach (DictionaryEntry entry in resourceSet)
            {
                ClassificaCartas(peixe, besta, planta, bug, reptil, bird, ref ac, ref a, ref b, ref c, ref d, ref e, ref f, entry);
            }


            #region MyRegion
            Debug.Print("Total Peixe: " + a.ToString());
            Debug.Print("Total Besta: " + b.ToString());
            Debug.Print("Total Bird: " + f.ToString());
            Debug.Print("Total Bug: " + d.ToString());
            Debug.Print("Total Planta: " + c.ToString());
            Debug.Print("Total Reptil: " + e.ToString());
            Debug.Print("Total Total: " + ac.ToString());
            var q_peixe = Cartas.Where(tip => tip.TipoClass.Equals(Tipo.Aquatic)).ToList<Cartas>().OrderBy(x => x.NomeCarta).Select(x => x.NomeCarta);
            var q_bug = Cartas.Where(tip => tip.TipoClass.Equals(Tipo.Bug)).ToList<Cartas>().OrderBy(x => x.NomeCarta).Select(x => x.NomeCarta);
            var q_Besta = Cartas.Where(tip => tip.TipoClass.Equals(Tipo.Besta)).ToList<Cartas>().OrderBy(x => x.NomeCarta).Select(x => x.NomeCarta);
            var q_Bird = Cartas.Where(tip => tip.TipoClass.Equals(Tipo.Bird)).ToList<Cartas>().OrderBy(x => x.NomeCarta).Select(x => x.NomeCarta);
            var q_Planta = Cartas.Where(tip => tip.TipoClass.Equals(Tipo.Planta)).ToList<Cartas>().OrderBy(x => x.NomeCarta).Select(x => x.NomeCarta);
            var q_Reptil = Cartas.Where(tip => tip.TipoClass.Equals(Tipo.Reptil)).ToList<Cartas>().OrderBy(x => x.NomeCarta).Select(x => x.NomeCarta);
            #endregion


        }
        /// <summary>
        /// Contem todas os nomes das cartas por classe
        /// </summary>
        /// <param name="peixe"></param>
        /// <param name="besta"></param>
        /// <param name="planta"></param>
        /// <param name="bug"></param>
        /// <param name="reptil"></param>
        /// <param name="bird"></param>
        private static void CartasXClasse(out List<string> peixe, out List<string> besta, out List<string> planta, out List<string> bug, out List<string> reptil, out List<string> bird)
        {
            peixe = new List<string>() { "ANEMONE_", "ANEMONE", "BABYLONIA", "BLUE_MOON", "CATFISH", "CLAMSHELL", "GOLDFISH", "HERMIT", "KOI", "LAM", "NAVAGA", "NIMO", "ORANDA", "PERCH", "PIRANHA", "RANCHU", "RISKY_FISH", "SHOAL_STAR", "SHRIMP", "SPONGE", "TADPOLE", "TEAL_SHELL" };
            besta = new List<string>() { "ARCO", "AXIE_KISS", "CONFIDENT", "COTTONTAIL", "DUAL_BLADE", "FURBALL", "GERBIL", "GODA", "HARE", "HERO", "IMP", "JAGUAR", "LITTLE_BRANCH", "MERRY", "NUT_CRACKER_", "NUT_CRACKER", "POCKY", "RICE", "RISKY_BEAST", "RONIN", "SHIBA", "TIMBER" };
            planta = new List<string>() { "BAMBOO_SHOOT", "BEECH", "BIDENS", "CACTUS", "CARROT", "CATTAIL", "HATSUNE", "HERBIVORE", "HOT_BUTT", "MINT", "POTATO_LEAF", "PUMPKIN", "ROSE_BUD", "SERIOUS", "SHIITAKE", "SILENCE_WHISPER", "STRAWBERRY_SHORTCAKE", "TURNIP", "WATERING_CAN", "WATERMELON", "YAM", "ZIGZAG" };
            bug = new List<string>() { "ANT", "ANTENNA", "BUZZ_BUZZ", "CATERPILLARS", "CUTE_BUNNY", "FISH_SNACK", "GARISH_WORM", "GRAVEL_ANT", "LAGGIN", "LEAF_BUG", "MOSQUITO", "PARASITE", "PINCER", "PLIERS", "PUPAE", "SANDAL", "SCARAB", "SNAIL_SHELL", "SPIKY_WING", "SQUARE_TEETH", "THORNY_CATTEPILAR", "TWIN_TAIL" };
            reptil = new List<string>() { "BONE_SAIL", "BUMPY", "CERASTES", "CROC", "GILA", "GRASS_SNAKE", "GREEN_THORNS", "IGUANA", "INCISOR", "INDIAN_STAR", "KOTARO", "RAZOR_BITE", "RED_EAR", "SCALY_SPEAR", "SCALY_SPOON", "SNAKE_JAR", "TINY_DINO", "TINY_TURTLE", "TOOTHLESS_BITE", "TRI_SPIKES", "UNKO", "WALL_GECKO" };
            bird = new List<string>() { "BALLOON", "CLOUD", "CUCKOO", "CUPID", "DOUBLETALK", "EGGSHELL", "FEATHER_FAN", "FEATHER_SPEAR", "GRANMA_S_FAN", "HUNGRY_BIRD", "KESTREL", "KINGFISHER", "LITTLE_OWL", "PEACE_MAKER", "PIGEON_POST", "POST_FIGHT", "RAVEN", "SWALLOW", "THE_LAST_ONE", "TRI_FEATHER", "TRUMP", "WING_HORN" };
        }
        /// <summary>
        /// Preenche as cartas com base na lista CartasXClasse
        /// </summary>
        /// <param name="peixe"></param>
        /// <param name="besta"></param>
        /// <param name="planta"></param>
        /// <param name="bug"></param>
        /// <param name="reptil"></param>
        /// <param name="bird"></param>
        /// <param name="ac"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <param name="f"></param>
        /// <param name="entry"></param>
        private void ClassificaCartas(List<string> peixe, List<string> besta, List<string> planta, List<string> bug, List<string> reptil, List<string> bird, ref int ac, ref int a, ref int b, ref int c, ref int d, ref int e, ref int f, DictionaryEntry entry)
        {
            if (peixe.Contains(entry.Key.ToString()))
            {
                Cartas.Add(new Cartas
                {
                    Imagem = (Bitmap)entry.Value,
                    NomeCarta = entry.Key.ToString(),
                    TipoClass = Tipo.Aquatic
                });
                a++;
                Debug.Print($"{a}|Nome: {entry.Key.ToString()} | Tipo: Peixe");
            }
            else if (besta.Contains(entry.Key.ToString()))
            {
                Cartas.Add(new Cartas
                {
                    Imagem = (Bitmap)entry.Value,
                    NomeCarta = entry.Key.ToString(),
                    TipoClass = Tipo.Besta
                });
                b++;
                Debug.Print($"{b}|Nome: {entry.Key.ToString()} | Tipo: Besta");
            }
            else if (planta.Contains(entry.Key.ToString()))
            {
                Cartas.Add(new Cartas
                {
                    Imagem = (Bitmap)entry.Value,
                    NomeCarta = entry.Key.ToString(),
                    TipoClass = Tipo.Planta
                });
                c++;
                Debug.Print($"{c}|Nome: {entry.Key.ToString()} | Tipo: Planta");
            }
            else if (bug.Contains(entry.Key.ToString()))
            {
                Cartas.Add(new Cartas
                {
                    Imagem = (Bitmap)entry.Value,
                    NomeCarta = entry.Key.ToString(),
                    TipoClass = Tipo.Bug
                });
                d++;
                Debug.Print($"{d}|Nome: {entry.Key.ToString()} | Tipo: Bug");
            }
            else if (reptil.Contains(entry.Key.ToString()))
            {
                Cartas.Add(new Cartas
                {
                    Imagem = (Bitmap)entry.Value,
                    NomeCarta = entry.Key.ToString(),
                    TipoClass = Tipo.Reptil
                });
                e++;
                Debug.Print($"{e}|Nome: {entry.Key.ToString()} | Tipo: Reptil");
            }
            else if (bird.Contains(entry.Key.ToString()))
            {
                Cartas.Add(new Cartas
                {
                    Imagem = (Bitmap)entry.Value,
                    NomeCarta = entry.Key.ToString(),
                    TipoClass = Tipo.Bird
                });
                f++;
                Debug.Print($"{f}|Nome: {entry.Key.ToString()} | Tipo: Bird");
            }
            else
            {
                Debug.Print($"Nome: {entry.Key.ToString()} | Tipo: Nenhum");
            }
            ac++;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<PictureBox> lstPictureBox = new List<PictureBox>();
            foreach (var item in tableLayoutPanel1.Controls)
            {
                if (item is PictureBox)
                {
                    lstPictureBox.Add(item as PictureBox);
                }
            }
            lstPictureBox.OrderBy(x => x.Name).ToList<PictureBox>();
            int index = 0;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    index = 0;
                    var lstCartas = Cartas.Where(x => x.TipoClass.Equals(Tipo.Aquatic)).OrderBy(x => x.NomeCarta).ToList<Cartas>();
                    index = PopularImagens(lstPictureBox, index, lstCartas);
                    break;
                case 1:
                    index = 0;
                    var lstBesta = Cartas.Where(x => x.TipoClass.Equals(Tipo.Besta)).OrderBy(x => x.NomeCarta).ToList<Cartas>();
                    index = PopularImagens(lstPictureBox, index, lstBesta);
                    break;
                case 2:
                    index = 0;
                    var lstBird = Cartas.Where(x => x.TipoClass.Equals(Tipo.Bird)).OrderBy(x => x.NomeCarta).ToList<Cartas>();
                    index = PopularImagens(lstPictureBox, index, lstBird);
                    break;
                case 3:
                    index = 0;
                    var lstBug = Cartas.Where(x => x.TipoClass.Equals(Tipo.Bug)).OrderBy(x => x.NomeCarta).ToList<Cartas>();

                    index = PopularImagens(lstPictureBox, index, lstBug);
                    break;
                case 4:
                    index = 0;
                    var lstPlanta = Cartas.Where(x => x.TipoClass.Equals(Tipo.Planta)).OrderBy(x => x.NomeCarta).ToList<Cartas>();
                    index = PopularImagens(lstPictureBox, index, lstPlanta);
                    break;
                case 5:
                    index = 0;
                    var lstReptil = Cartas.Where(x => x.TipoClass.Equals(Tipo.Reptil)).OrderBy(x => x.NomeCarta).ToList<Cartas>();
                    index = PopularImagens(lstPictureBox, index, lstReptil);
                    break;

            }

        }

        private int PopularImagens(List<PictureBox> lstPictureBox, int index, List<Cartas> lstCartas)
        {

            foreach (var item in lstPictureBox)
            {
                item.Image = lstCartas[index].Imagem;
                toolTip1.SetToolTip(item, $"Nome: {lstCartas[index].NomeCarta}\nTipo: {lstCartas[index].TipoClass}");
                index++;
            }

            return index;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in tableLayoutPanel1.Controls)
            {
                if (item is PictureBox)
                {
                    ((PictureBox)item).SizeMode = (PictureBoxSizeMode)comboBox2.SelectedIndex;

                }
            }
        }
    }
}

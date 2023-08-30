using IG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iG
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog img = new OpenFileDialog();
            img.ShowDialog();
            if (img.FileName != null)
            {
                pBselected.ImageLocation = img.FileName;
            }
        }
        int adet = 0;
        private void btnCheck_Click(object sender, EventArgs e)
        {
            adet++;
            //örnek görselleri işledik.
            // var
            var imageBytes = File.ReadAllBytes(pBselected.ImageLocation);
            MLModel1.ModelInput sampleData = new MLModel1.ModelInput()
            {
                ImageSource = imageBytes,
            };

            //Modeli yükleyip, eşleştirdik.
            var result = MLModel1.Predict(sampleData);

            if (result.PredictedLabel == "dog")
            {
                MessageBox.Show("KÖPEK", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (result.PredictedLabel == "cat")
            {
                MessageBox.Show("KEDİ", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (result.PredictedLabel == "snake")
            {
                MessageBox.Show("YILAN", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Belirsiz");
            }


            lBpast.Items.Add(adet + ". sınıflandırılan içerik : " + result.PredictedLabel);
        }
    }
}

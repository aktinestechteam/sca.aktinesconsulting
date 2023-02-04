using sca.aktinesconsulting.service.Implementation;
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

namespace sca.aktinesconsulting.windows
{
    public partial class Main : Form
    {
        private string ntxtfile = "";
        private string noutfile = "";

        public Main()
        {
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {

            ntxtfile = "";
            noutfile = "";
            txtFile.Text = ntxtfile;
            opfSchFile.Title = "Browse Excel Files";
            opfSchFile.DefaultExt = "xlsx";
            opfSchFile.FileName = "";
            opfSchFile.Filter = "Excel files *.xlsx|*.xlsx";
            opfSchFile.CheckFileExists = true;
            opfSchFile.CheckPathExists = true;
            txtFile.Text = ntxtfile;
            txtProgress.Text = "";
            txtoutputfile.Text = "";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            noutfile = "";
            txtProgress.Text = "";
            txtoutputfile.Text = "";
            txtProgress.Visible = false;
            txtoutputfile.Visible = false;
            if (opfSchFile.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = opfSchFile.FileName;
                ntxtfile = txtFile.Text;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            string noutfile = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtFile.Text))
                {
                    MessageBox.Show("Please select file!");
                    return;
                }
              
                btnBrowse.Enabled = false;
                btnRun.Enabled = false;
                txtProgress.Visible = false;
                txtoutputfile.Visible = false;
                FileService fs = new FileService();
                var dt = fs.ExcelDataReader(ntxtfile, string.Empty, "X").FirstOrDefault();
                if (dt != null)
                {
                    for (var r = 0; r < dt.Rows.Count; r++)
                    {
                        for (var c = 0; c < dt.Columns.Count; c++)
                        {
                            if (dt.Rows[r][c] == DBNull.Value)
                            {
                                dt.Rows[r][c] = string.Empty;
                            }
                        }
                    }
                    ExceptionService exceptionService = new ExceptionService();
                    var dtResult = exceptionService.Identify(dt);
                    noutfile = Path.GetDirectoryName(ntxtfile) + "\\" + Path.GetFileNameWithoutExtension(ntxtfile) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
                    fs.ExportToCSV(dtResult, noutfile);
                    btnBrowse.Enabled = true;
                    btnRun.Enabled = true;
                    txtProgress.Visible = true;
                    txtoutputfile.Visible = true;
                    txtProgress.Text = "Saved at:";
                    txtoutputfile.Text = noutfile;
                    MessageBox.Show("File converted successfully!");

                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occoured:\n" + ex.Message);
            }
            finally
            {


                btnBrowse.Enabled = true;
                btnRun.Enabled = true;
                txtProgress.Visible = true;
                txtoutputfile.Visible = true;
                txtProgress.Text = "Saved at:";
                txtoutputfile.Text = noutfile;
                //txtProgress.Visible = false;
            }
        }


    }





}

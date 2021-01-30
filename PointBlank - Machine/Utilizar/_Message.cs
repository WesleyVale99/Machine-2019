using System.Windows.Forms;

namespace PointBlank___Machine
{
    public class _Message
    {
        public void Info(string Texto)
        {
            MessageBox.Show(Texto, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void Error(string error)
        {
            MessageBox.Show(error, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace CBA_Test
    {
    public partial class Form1 : Form
        {
        /* Form1 Class Properties definitions */
        public static SerialPort obSerial = new SerialPort();
        byte[] readByteArray = new byte[obSerial.ReadBufferSize];
        HSPL hsplcontext = new HSPL();

        public Form1()
            {
            InitializeComponent();

            UpdateComboBox();
            }

        }
    }

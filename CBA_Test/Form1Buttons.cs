using System;
using System.Windows.Forms;

namespace CBA_Test
    {
    public partial class Form1 : Form
        {
        private void OpenCom_button_Click( object sender , EventArgs e )
            {
            setSerialConfig( (string)COM_ComboBox.SelectedItem );
            Terminal_textbox_updateText( "[DBG]: " + COM_ComboBox.SelectedItem + " Initialized\r\n" );
            }
        private void command_button_Click( object sender , EventArgs e )
            {
            byte[] message;
            hsplcontext.Protocol_prepareToSend( command_textbox.Text );
            message = hsplcontext.Serialize();
            obSerial.Write( message , 0 , message.Length );
            Terminal_textbox_updateText( "[TX]: " + hsplcontext.getPayload() + "\r\n" );
            hsplcontext.Init();
            }
        }
    }
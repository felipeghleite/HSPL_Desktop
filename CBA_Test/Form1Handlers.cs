using System;
using System.Windows.Forms;

namespace CBA_Test
    {
    public partial class Form1 : Form
        {
        public void serialReadHandler( object sender , EventArgs e )
            {
            if( obSerial.IsOpen == true )
                {
                obSerial.Read( readByteArray , 0 , obSerial.BytesToRead );
                if( hsplcontext.Protocol_Decode( hsplcontext , readByteArray , readByteArray.Length ) == (byte)HSPLConstants.HSPL_errors_code.HSPL_NO_ERROR )
                    {
                    Terminal_textbox_updateText( "[RX]: " + hsplcontext.getPayload() + "\r\n" );
                    Terminal_textbox_updateText( "[DBG]: Protocol decoded successfully.\r\n" );
                    }
                else
                    {
                    Terminal_textbox_updateText( "Protocol decode failed.\r\n" );
                    }
                readByteArray.Initialize();
                hsplcontext.Init();
                }
            else
                {
                readByteArray = null;
                }
            }
        }
    }
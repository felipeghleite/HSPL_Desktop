using System;
using System.Text;
using System.Collections.Generic;

namespace CBA_Test
    {
    static class HSPLConstants
        {
        public const int startPreAmbleSize = 3;
        public enum HSPL_errors_code
            {
            HSPL_NO_ERROR = 0,
            HSPL_DECODE_ERROR,
            HSPL_PAYLOAD_SIZE_ERROR
            };
        }
    internal class HSPL
        {
        byte[] b_StartPreAmble = new byte[HSPLConstants.startPreAmbleSize];
        byte b_sizeByte;
        String s_payloadString;
        UInt32 i_crc;
        public HSPL()
            {
            byte[] preamble = new byte[3] {0x00, 0x00, 0x00};
            b_StartPreAmble = preamble;
            b_sizeByte = 0;
            s_payloadString = null;
            i_crc = 0;
            }

        public void Init()
            {
            byte[] preamble = new byte[3] {0x00, 0x00, 0x00};
            b_StartPreAmble = preamble;
            b_sizeByte = 0;
            s_payloadString = null;
            i_crc = 0;
            }
        public byte Protocol_prepareToSend( string payload )
            {
            byte[] preamble = new byte[3] {0x55, 0x55, 0x55};
            b_StartPreAmble = preamble;
            b_sizeByte = (byte)payload.Length;
            s_payloadString = payload;
            i_crc = calculateCRC();

            return (byte)HSPLConstants.HSPL_errors_code.HSPL_NO_ERROR;
            }

        private uint calculateCRC()
            {
            uint index = 0;
            uint CRC = 0xFFFFFFFF;
            int size = b_sizeByte + 4;
            byte[] bytearray = new byte[b_StartPreAmble.Length + 1 + b_sizeByte];
            b_StartPreAmble.CopyTo( bytearray , 0 );
            bytearray.SetValue( b_sizeByte , b_StartPreAmble.Length );
            byte[] payloadBytes = Encoding.ASCII.GetBytes(s_payloadString);
            payloadBytes.CopyTo( bytearray , b_StartPreAmble.Length + 1 );

            if( b_sizeByte == 0 )
                {
                return (byte)HSPLConstants.HSPL_errors_code.HSPL_PAYLOAD_SIZE_ERROR; //error
                }

            while( size > 0 )
                {
                if( size > 3 )
                    {
                    CRC ^= (uint)(((bytearray[0+index] & 0xFF) << (8 * 3)) | ((bytearray[1 + index] & 0xFF) << (8 * 2)) | ((bytearray[2 + index] & 0xFF) << (8 * 1)) | ((bytearray[3 + index] & 0xFF) << (8 * 0)));
                    index += 4;
                    size -= 4;
                    }
                else
                    {
                    CRC ^= (uint)((bytearray[index]) & 0xFF);
                    index++;
                    size--;
                    }
                }

            return CRC;
            }

        public byte Protocol_Decode(HSPL context, byte[] message, Int32 size )
            {
            UInt32 checkCRC;
            int index2;
            int[] index;
            byte[] preamble = new byte[] {0x55, 0x55, 0x55};

            byte[] messageToBytes = message;

            index = messageToBytes.Locate( preamble );
            context.b_StartPreAmble = messageToBytes.SubArray( index[0] , 3 );
            index[0] += 3;
            context.b_sizeByte = messageToBytes.SubArray( index[0] , 1 )[0];
            index[0] += 1;
            context.s_payloadString = Encoding.ASCII.GetString(messageToBytes.SubArray( index[0] , context.b_sizeByte ));
            index[0] += context.b_sizeByte;

            for( index2 = 0 ; index2 < 4 ; index2++ )
                {
                context.i_crc |= (uint)(messageToBytes[index[0]+index2] & 0xFF) << (3 - index2) * 8; // copy the CRC.
                }

            checkCRC = context.calculateCRC();

            if( checkCRC != context.i_crc )
                return (byte)HSPLConstants.HSPL_errors_code.HSPL_DECODE_ERROR;
            else return (byte)HSPLConstants.HSPL_errors_code.HSPL_NO_ERROR;

            }

        public byte[] Serialize()
            {
            byte[] bytearray = new byte[b_StartPreAmble.Length + 1 + b_sizeByte + 4];
            b_StartPreAmble.CopyTo( bytearray , 0 );
            bytearray.SetValue( b_sizeByte , b_StartPreAmble.Length );
            byte[] payloadBytes = Encoding.ASCII.GetBytes(s_payloadString);
            payloadBytes.CopyTo( bytearray , b_StartPreAmble.Length + 1 );
            byte[] crcBytes = new byte[4];
            int index;
            for(index = 0 ; index < 4 ; index++ )
                {
                crcBytes[index] = (byte)((i_crc >> ((3 - index) * 8)) & 0xFF);
                }
            crcBytes.CopyTo( bytearray , b_StartPreAmble.Length + 1 + b_sizeByte );
            return bytearray;
            }

        public string getPayload()
            {
            return s_payloadString;
            }

        }

    static class ByteArrayRocks
        {

        static readonly int [] Empty = new int [0];

        public static int[] Locate( this byte[] self , byte[] candidate )
            {
            if( IsEmptyLocate( self , candidate ) )
                return Empty;

            var list = new List<int> ();

            for( int i = 0 ; i < self.Length ; i++ )
                {
                if( !IsMatch( self , i , candidate ) )
                    continue;

                list.Add( i );
                }

            return list.Count == 0 ? Empty : list.ToArray();
            }

        static bool IsMatch( byte[] array , int position , byte[] candidate )
            {
            if( candidate.Length > (array.Length - position) )
                return false;

            for( int i = 0 ; i < candidate.Length ; i++ )
                if( array[position + i] != candidate[i] )
                    return false;

            return true;
            }

        static bool IsEmptyLocate( byte[] array , byte[] candidate )
            {
            return array == null
                || candidate == null
                || array.Length == 0
                || candidate.Length == 0
                || candidate.Length > array.Length;
            }
        public static T[] SubArray<T>( this T[] data , int index , int length )
            {
            T[] result = new T[length];
            Array.Copy( data , index , result , 0 , length );
            return result;
            }

        }
        }
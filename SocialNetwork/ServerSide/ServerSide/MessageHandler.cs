using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSide
{

    public class MessageHandler
    {
        private (byte leftBoard, byte rightBoard) eventRange { get; }

        private (byte leftBoard, byte rightBoard) attributeRange { get; }

        private (byte leftBoard, byte rightBoard) signatureRange { get; }

        private (byte leftBoard, byte rightBoard) recipientRange { get; }

        private Crypter crypter;

        public MessageHandler(byte eventBoard, byte attributeBoard, byte signatureBoard, byte recipientBoard, Crypter crypterLink)
        {
            eventRange = (0, eventBoard);
            attributeRange = ((byte)(eventBoard + 1), attributeBoard);
            signatureRange = ((byte)(attributeBoard + 1), signatureBoard);
            recipientRange = ((byte)(signatureBoard + 1), recipientBoard);
            crypter = crypterLink;
        }

        public string Handle(byte[] message, string sender)
        {
            byte[] signature = new byte[signatureRange.rightBoard - signatureRange.leftBoard + 1];
            message.CopyTo(signature, signatureRange.leftBoard);
            if (crypter.VerifySignature(sender, signature))
            {
                switch (Encoding.Unicode.GetString(message, eventRange.leftBoard, eventRange.rightBoard))
                {
                    case "send":
                        {
                            switch (Encoding.Unicode.GetString(message, attributeRange.leftBoard, attributeRange.rightBoard))
                            {
                                case "message":
                                    {
                                        break;
                                    }
                            }

                            break;
                        }

                    case "update":
                        {
                            break;
                        }

                    case "give":
                        {
                            break;
                        }

                    case "create":
                        {
                            break;
                        }
                }

                return "Подтверждение пользователя";
            }
            else
            {
                return "Ошибка аутентификации пользователя";
            }
        }
    }
}

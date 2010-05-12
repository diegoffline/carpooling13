using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarpoolingDAL;
using CarpoolingModel.Types;
using CarpoolingModel.Repository;

namespace CarpoolingModel.Repository {
    public class MessageRepository {
        private static MessageRepository instanca = null;
        private static CarpoolingDBADataContext db = new CarpoolingDBADataContext();
        private MessageRepository() {
        }

        public static MessageRepository getInstanca() {
            if (instanca == null) {
                instanca = new MessageRepository();
            }
            return instanca;
        }

        public CarpoolingDAL.Message getMessageById(int id) {
            CarpoolingDAL.Message g = new CarpoolingDAL.Message();
            try {
                var query = db.Messages.Where(o => o.idMessage == id).First();
                g = query as CarpoolingDAL.Message;
            } catch (Exception) {
                g = null;
            }

            return g;
        }
    }
}

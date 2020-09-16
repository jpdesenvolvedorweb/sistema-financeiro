using Model.DAO;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Neg
{
    public class ModePayNeg
    {

        private ModePayDao objModePayDao;

        public ModePayNeg()
        {
            objModePayDao = new ModePayDao();
        }

        public void Create(ModePay objModePay)
        {
            bool verification = true;

            string name = objModePay.Name;
            if (name == null)
            {
                objModePay.State = 20;
                return;
            }
            else
            {
                name = objModePay.Name.Trim();
                verification = name.Length > 0 && name.Length <= 30;
                if (!verification)
                {
                    objModePay.State = 2;
                    return;
                }
            }

            string otherDetails = objModePay.OtherDetails;
            if (otherDetails == null)
            {
                objModePay.State = 30;
                return;
            }
            else
            {
                otherDetails = objModePay.OtherDetails.Trim();
                verification = otherDetails.Length > 0 && otherDetails.Length <= 30;
                if (!verification)
                {
                    objModePay.State = 3;
                    return;
                }
            }

            objModePayDao.Create(objModePay);
            objModePay.State = 99;
            return;
        }

        public void Update(ModePay objModePay)
        {
            bool verification = true;

            string name = objModePay.Name;
            if (name == null)
            {
                objModePay.State = 20;
                return;
            }
            else
            {
                name = objModePay.Name.Trim();
                verification = name.Length > 0 && name.Length <= 30;
                if (!verification)
                {
                    objModePay.State = 2;
                    return;
                }
            }

            string otherDetails = objModePay.OtherDetails;
            if (otherDetails == null)
            {
                objModePay.State = 30;
                return;
            }
            else
            {
                otherDetails = objModePay.OtherDetails;
                verification = otherDetails.Length > 0 && otherDetails.Length <= 30;
                if (!verification)
                {
                    objModePay.State = 3;
                    return;
                }
            }

            objModePayDao.Update(objModePay);
            objModePay.State = 99;
            return;
        }

        public void Delete(ModePay objModePay)
        {
            bool verification = true;

            ModePay objModePayAux = new ModePay();
            objModePayAux.IdModePay = objModePay.IdModePay;
            verification = objModePayDao.Find(objModePayAux);
            if (!verification)
            {
                objModePay.State = 33;
                return;
            }
     
            objModePayDao.Delete(objModePayAux);
            objModePay.State = 99;
            return;
        }

        public bool Find(ModePay objModePay)
        {
            return objModePayDao.Find(objModePay);
        }

        public List<ModePay> FindAll()
        {
           return objModePayDao.FindAll();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace BussLayer
{
    public class DealsModel
    {
        DBEngine objDBEngine;
        DataTable dtResult;
        public int GetFlyerPreview(int t,int count, out List<PreviewDeals> lstPreview)
        {
            int ReturnCode = 0;
            lstPreview = null;

            try
            {

                SqlParameter[] Param = {
                                            new SqlParameter("@Id",SqlDbType.Int),
                                            new SqlParameter("@Count",SqlDbType.Int),

                                      };

                Param[0].Value = t;
                Param[1].Value = count;

                using (objDBEngine = new DBEngine())
                {
                    dtResult = new DataTable();
                    dtResult = objDBEngine.GetDataTable("pGetFlyerPreviewTEST", Param);

                    if (dtResult.Rows.Count > 0)
                    {
                        lstPreview = new List<PreviewDeals>();
                        DTtoListConverter.ConvertTo(dtResult, out lstPreview);
                    }

                }

                ReturnCode = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ReturnCode;
        }
    }
}
